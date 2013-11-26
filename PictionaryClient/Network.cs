using Lidgren.Network;
using PictionaryClient.PacketClass;
using PictionaryShared;
using System;
using System.Net;
using System.Threading;

namespace PictionaryClient
{
    static class Network
    {
        private static NetClient NetClient = null;
        public static void SendText(PacketTypes.Headers packet, string message)
        {
            NetOutgoingMessage msg = NetClient.CreateMessage();
            msg.Write((byte)packet);
            msg.Write(message);
            NetClient.SendMessage(msg, NetDeliveryMethod.ReliableOrdered);
        }
        public static void ConnectToServer(string ip)
        {
            if (NetClient == null) {NetClient = ConnectServer();}
            NetClient.Start();
            NetOutgoingMessage hailMsg = NetClient.CreateMessage();
            hailMsg.Write((byte)PacketTypes.Headers.Login);
            hailMsg.Write(Program.PlayerUsername);
            Program.PlayerStore.Add(0, new Player(Program.PlayerUsername));
            NetClient.Connect(ip, 666, hailMsg);
        }
        public static void SendDiscovery()
        {
            if (NetClient == null) { NetClient = ConnectServer(); }
            NetClient.Start();
            NetClient.DiscoverLocalPeers(666);
        }

        private static NetClient ConnectServer()
        {
            var config = new NetPeerConfiguration("pic") {EnableUPnP = true};
            var thisClient = new NetClient(config);
            thisClient.RegisterReceivedCallback(HandleMessage);
            return thisClient;
        }

        private static void HandleMessage(object peer)
        {
            Console.WriteLine("HANDLE MESSAAGE CALLED PLS WORK");
            NetIncomingMessage inc;
            while ((inc = NetClient.ReadMessage()) != null)
            {
                Console.WriteLine(inc.MessageType);
                switch (inc.MessageType)
                {
                    // Data type is all messages manually sent from client
                    case NetIncomingMessageType.Data:
                        byte pheader = inc.ReadByte();

                        switch ((PacketTypes.Headers) pheader)
                        {

                            case PacketTypes.Headers.PlayerRec:
                               var uid = inc.ReadInt64();
                                var username = inc.ReadString();
                                Player player = new Player(username, uid);
                                Program.PlayerStore.Add(uid, player);
                                Console.WriteLine("Got new player called: {0}", username, uid);
                                Menu.lobby.UpdateDisplay();
                                break;
                            case PacketTypes.Headers.ReadyUpdate:
                                var puid = inc.ReadInt64();
                                var status = inc.ReadBoolean();
                                if (Program.PlayerStore.ContainsKey(puid))
                                {
                                    Program.PlayerStore[puid].ToggleReady();
                                    Console.WriteLine("{0} changed status to {1}", Program.PlayerStore[puid].Name, Program.PlayerStore[puid].GetReadyStatus());
                                    Menu.lobby.UpdateDisplay();
                                }
                                break;
                            case PacketTypes.Headers.LoggedIn:
                                Console.WriteLine("Server has acked us");
                                var loginstatus = inc.ReadBoolean();
                                    SendText(PacketTypes.Headers.LoggedIn, Program.PlayerUsername);
                                break;
                            case PacketTypes.Headers.YouAreHost:
                                Console.WriteLine("We are apparently the host");
                                Program.areWeHost = true;
                                Menu.lobby.Lobby_HostStart.Visible = true;
                                break;
                            default:
                                Console.WriteLine("Invalid Packet Header: {0}", pheader);
                                break;
                        }
                        break;

                    case NetIncomingMessageType.StatusChanged:
                        Console.WriteLine(@"---Status Changed---");
                        Console.WriteLine(NetClient.ConnectionStatus);
                        Console.WriteLine(inc.ReadString());
                        Console.WriteLine(@"---End---");
                        break;

                    case NetIncomingMessageType.DiscoveryResponse:
                        Console.WriteLine(@"---Auto Discovery Response---");
                        Console.WriteLine(inc.ReadString());
                        Program.AutoDiscoveryIP = inc.SenderEndPoint.Address.ToString();
                        Console.WriteLine(@"---End---");
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
        }
    }
}
