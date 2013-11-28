using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Timers;
using Lidgren.Network;
using PictionaryClient.PacketClass;
using PictionaryShared;
using Timer = System.Timers.Timer;

namespace PictionaryServer
{
    internal static class Program
    {
        private static readonly Dictionary<long, Player> Players = new Dictionary<long, Player>();
        private static List<string> _wordList = new List<string>();
        private static List<string> _badwordList = new List<string>();

        private static readonly Timer RoundTimer = new Timer {Interval = 92*1000, Enabled = false};
        private static string _theWord;
        private static string _drawer;
        private static NetServer _server;

        private static void Main()
        {
            var config = new NetPeerConfiguration("pic")
            {
                Port = 666,
                EnableUPnP = true,
                MaximumConnections = 50,
                ConnectionTimeout = 5f
            };
            config.EnableMessageType(NetIncomingMessageType.ConnectionApproval);
            _server = new NetServer(config);
            RoundTimer.Elapsed += roundTimer_Elapsed;
            _server.Start();
            _server.UPnP.ForwardPort(666, "Pictionary");

            Console.WriteLine(@"Pictionary Server Started");
            long timeToRun;
            int loadedWords = LoadWords("list.txt", out _wordList, out timeToRun);
            Console.WriteLine("Loaded {0} words into the Word list taking {1} ms to run", loadedWords, timeToRun);

            loadedWords = LoadWords("badwords.txt", out _badwordList, out timeToRun);
            Console.WriteLine("Loaded {0} words into the Bad word list taking {1} ms to run", loadedWords, timeToRun);
            NetIncomingMessage inc; // Incoming Message

            while (true)
            {
                if ((inc = _server.ReadMessage()) == null) continue;
                HandleMessage(inc, _server);
            }
// ReSharper disable once FunctionNeverReturns
        }

        private static void roundTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            NetOutgoingMessage failedmsg = _server.CreateMessage();
            failedmsg.Write((byte) PacketTypes.Headers.ChatReceive);
            failedmsg.Write("Server");
            failedmsg.Write("You have all failed. The word was:" + _theWord);
            _server.SendToAll(failedmsg, NetDeliveryMethod.ReliableOrdered);
            StartNewRound(_server);
        }

        private static void HandleMessage(NetIncomingMessage inc, NetServer server)
        {
            switch (inc.MessageType)
            {
                case NetIncomingMessageType.ConnectionApproval: //If ConnectionApproval request
                    if (inc.ReadByte() == (byte) PacketTypes.Headers.Login)
                    {
                        string username = inc.ReadString();
                        Console.WriteLine("New Login Request from: {0}", username);
                        if (username.Length > 1 & Players.Values.All(c => c.Name != username) &
                            !_badwordList.Contains(username, StringComparer.OrdinalIgnoreCase))
                        {
                            inc.SenderConnection.Approve();
                            NetOutgoingMessage connectedMessage = server.CreateMessage();
                            Thread.Sleep(500);
                            Console.WriteLine("Sending a ack to {0}", username);
                            connectedMessage.Write((byte) PacketTypes.Headers.LoggedIn);
                            connectedMessage.Write(true);
                            server.SendMessage(connectedMessage, inc.SenderConnection, NetDeliveryMethod.ReliableOrdered);
                        }
                        else
                        {
                            inc.SenderConnection.Deny("Bad Username");
                        }
                    }

                    break;

                case NetIncomingMessageType.Data:
                    byte packetheader = inc.ReadByte();
                    HandleProtocol(inc, packetheader, server);
                    break;

                case NetIncomingMessageType.StatusChanged:
                    Console.WriteLine(inc.SenderConnection + " status changed. " + inc.SenderConnection.Status);
                    if (inc.SenderConnection.Status == NetConnectionStatus.Disconnected)
                    {
                        Console.WriteLine("Player: {0} has disconnected",
                            Players[inc.SenderConnection.RemoteUniqueIdentifier].Name);
                        Players.Remove(inc.SenderConnection.RemoteUniqueIdentifier);
                    }
                    break;

                case NetIncomingMessageType.DiscoveryRequest:
                    NetOutgoingMessage discovermsg = server.CreateMessage();
                    discovermsg.Write("Hey I just met you, I'm a server, so address me maybe");
                    Console.WriteLine(@"Auto Discovery Request");
                    server.SendDiscoveryResponse(discovermsg, inc.SenderEndPoint);
                    break;

                case NetIncomingMessageType.DebugMessage:
                case NetIncomingMessageType.ErrorMessage:
                case NetIncomingMessageType.WarningMessage:
                case NetIncomingMessageType.VerboseDebugMessage:
                    Console.WriteLine(@"---Debug---");
                    Console.WriteLine(inc.ReadString());
                    Console.WriteLine(@"---End---");
                    break;
            }
        }

        private static Player NewPlayer(NetIncomingMessage inc, NetServer server, string username)
        {
            var newPlayer = new Player(username);
            foreach (long key in Players.Keys)
            {
                NetOutgoingMessage msgToNewClient = server.CreateMessage();
                msgToNewClient.Write((byte) PacketTypes.Headers.PlayerRec);
                msgToNewClient.Write(key);
                msgToNewClient.Write(Players[key].Name);
                msgToNewClient.Write(Players[key].GetReadyStatus());

                Console.WriteLine("NClient: Sent message about {0} to: {1}", username, Players[key].Name);
                server.SendMessage(msgToNewClient, inc.SenderConnection,
                    NetDeliveryMethod.ReliableOrdered);

                NetOutgoingMessage msgToCurrentClient = server.CreateMessage();
                msgToCurrentClient.Write((byte) PacketTypes.Headers.PlayerRec);
                msgToCurrentClient.Write(inc.SenderConnection.RemoteUniqueIdentifier);
                msgToCurrentClient.Write(username);
                msgToCurrentClient.Write(false);

                Console.WriteLine("CClient: Sent message about {0} to: {1}", Players[key].Name, username);
                server.SendMessage(msgToCurrentClient, Players[key].Connection, NetDeliveryMethod.ReliableOrdered);
            }
            return newPlayer;
        }

        private static void HandleProtocol(NetIncomingMessage inc, byte packetheader, NetServer server)
        {
            switch ((PacketTypes.Headers) packetheader)
            {
                case PacketTypes.Headers.ReadyUpdate:
                    bool playerStatus = Convert.ToBoolean(inc.ReadString());
                    Player thePlayer = LookUpPlayer(inc.SenderConnection.RemoteUniqueIdentifier);

                    Console.WriteLine("Player {0} changed status to {1}", thePlayer.Name, playerStatus);
                    Players[inc.SenderConnection.RemoteUniqueIdentifier].ToggleReady();
                    NetOutgoingMessage msg = server.CreateMessage();
                    msg.Write((byte) PacketTypes.Headers.ReadyUpdate);
                    msg.Write(inc.SenderConnection.RemoteUniqueIdentifier);
                    msg.Write(playerStatus);
                    server.SendToAll(msg, NetDeliveryMethod.ReliableOrdered);
                    break;
                case PacketTypes.Headers.LoggedIn:
                    string username = inc.ReadString();
                    Player newPlayer = NewPlayer(inc, server, username);
                    Console.WriteLine(Players.Count);
                    if (Players.Count == 0)
                    {
                        Console.WriteLine("Sending {0} host packet", newPlayer.Name);
                        NetOutgoingMessage hMessage = server.CreateMessage();
                        hMessage.Write((byte) PacketTypes.Headers.YouAreHost);
                        server.SendMessage(hMessage, inc.SenderConnection, NetDeliveryMethod.ReliableOrdered);
                    }

                    Players.Add(inc.SenderConnection.RemoteUniqueIdentifier, newPlayer);
                    Players[inc.SenderConnection.RemoteUniqueIdentifier].Connection = inc.SenderConnection;
                    break;
                case PacketTypes.Headers.ChatSend:
                    if (Players[inc.SenderConnection.RemoteUniqueIdentifier].Name != _drawer)
                    {
                        NetOutgoingMessage chatMessageRelay = server.CreateMessage();
                        string chatM = inc.ReadString();
                        chatMessageRelay.Write((byte) PacketTypes.Headers.ChatReceive);
                        chatMessageRelay.Write(Players[inc.SenderConnection.RemoteUniqueIdentifier].Name);
                        chatMessageRelay.Write(chatM);
                        if (!_badwordList.Contains(chatM, StringComparer.OrdinalIgnoreCase))
                        {
                            server.SendToAll(chatMessageRelay, NetDeliveryMethod.ReliableOrdered);
                        }
                        if (String.Equals(chatM, _theWord, StringComparison.CurrentCultureIgnoreCase) & chatM != null)
                        {
                            NetOutgoingMessage someoneOne = server.CreateMessage();
                            someoneOne.Write((byte) PacketTypes.Headers.ChatReceive);
                            someoneOne.Write("Server");
                            someoneOne.Write(Players[inc.SenderConnection.RemoteUniqueIdentifier].Name
                                             + " has guessed the correct word being: " + _theWord);
                            server.SendToAll(someoneOne, NetDeliveryMethod.ReliableOrdered);
                            RoundTimer.Stop();
                            StartNewRound(server);
                        }
                    }
                    break;
                case PacketTypes.Headers.PictureUpdate:
                    int r = inc.ReadVariableInt32();
                    int g = inc.ReadVariableInt32();
                    int b = inc.ReadVariableInt32();
                    int x = inc.ReadVariableInt32();
                    int y = inc.ReadVariableInt32();
                    int size = inc.ReadVariableInt32();
                    NetOutgoingMessage msgPicture = server.CreateMessage();
                    msgPicture.Write((byte) PacketTypes.Headers.PictureUpdate);
                    msgPicture.WriteVariableInt32(r);
                    msgPicture.WriteVariableInt32(g);
                    msgPicture.WriteVariableInt32(b);
                    msgPicture.WriteVariableInt32(x);
                    msgPicture.WriteVariableInt32(y);
                    msgPicture.WriteVariableInt32(size);
                    server.SendToAll(msgPicture, NetDeliveryMethod.ReliableOrdered);
                    break;
                case PacketTypes.Headers.StartGame:
                    NetOutgoingMessage msgStart = server.CreateMessage();
                    msgStart.Write((byte) PacketTypes.Headers.StartGame);
                    server.SendToAll(msgStart, NetDeliveryMethod.ReliableOrdered);
                    RoundTimer.Enabled = true;
                    StartNewRound(server);
                    break;
                case PacketTypes.Headers.DrawLine:
                {
                    int r1 = inc.ReadVariableInt32();
                    int g1 = inc.ReadVariableInt32();
                    int b1 = inc.ReadVariableInt32();
                    int x1 = inc.ReadVariableInt32();
                    int y1 = inc.ReadVariableInt32();
                    int size1 = inc.ReadVariableInt32();
                    int x11 = inc.ReadVariableInt32();
                    int y11 = inc.ReadVariableInt32();
                    NetOutgoingMessage msgDrawLine = server.CreateMessage();
                    msgDrawLine.Write((byte) PacketTypes.Headers.DrawLine);
                    msgDrawLine.WriteVariableInt32(r1);
                    msgDrawLine.WriteVariableInt32(g1);
                    msgDrawLine.WriteVariableInt32(b1);
                    msgDrawLine.WriteVariableInt32(x1);
                    msgDrawLine.WriteVariableInt32(y1);
                    msgDrawLine.WriteVariableInt32(size1);
                    msgDrawLine.WriteVariableInt32(x11);
                    msgDrawLine.WriteVariableInt32(y11);
                    server.SendToAll(msgDrawLine, NetDeliveryMethod.ReliableOrdered);
                }
                    break;
            }
        }

        private static void StartNewRound(NetServer server)
        {
            Round theRound = NewRound();
            _drawer = theRound.Drawer.Name;
            _theWord = theRound.Word;
            NetOutgoingMessage newRoundMsg = server.CreateMessage();
            newRoundMsg.Write((byte) PacketTypes.Headers.NewRound);
            newRoundMsg.Write(theRound.Drawer.Name);
            server.SendToAll(newRoundMsg, NetDeliveryMethod.ReliableOrdered);

            NetOutgoingMessage drawerMsg = server.CreateMessage();
            drawerMsg.Write((byte) PacketTypes.Headers.WordMessage);
            drawerMsg.Write(theRound.Word);
            server.SendMessage(drawerMsg, theRound.Drawer.Connection, NetDeliveryMethod.ReliableOrdered);
            _theWord = theRound.Word;
            RoundTimer.Start();
        }

        private static Round NewRound()
        {
            int lowestPlayer = 100;
            var lowestPlayerPlayer = new Player("Debug");
            foreach (var p in Players)
            {
                if (p.Value.DrawTimes < lowestPlayer)
                {
                    lowestPlayer = p.Value.DrawTimes;
                    lowestPlayerPlayer = p.Value;
                }
            }
            var ra = new Random();
            lowestPlayerPlayer.DrawTimes++;
            string word = _wordList[ra.Next(0, _wordList.Count)];
            Console.WriteLine("Player: {0} is drawing the word {1}", lowestPlayerPlayer.Name, word);
            return new Round(lowestPlayerPlayer, word);
        }

        private static Player LookUpPlayer(long uid)
        {
            return Players[uid];
        }

        private static int LoadWords(string listname, out List<string> list, out long timeToRun)
        {
            var time = new Stopwatch();
            time.Start();

            list = new List<string>();
            int count = 0;
            foreach (string line in File.ReadAllLines(listname))
            {
                list.Add(line);
                count++;
            }
            time.Stop();
            timeToRun = time.ElapsedMilliseconds;
            return count;
        }
    }
}