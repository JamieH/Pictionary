using Lidgren.Network;
using PictionaryClient.PacketClass;
using PictionaryShared;
using System;

namespace PictionaryClient
{
    static class Network
    {
        private static NetClient _netClient;
        public static void SendText(PacketTypes.Headers packet, string message)
        {
            NetOutgoingMessage msg = _netClient.CreateMessage();
            msg.Write((byte)packet);
            msg.Write(message);
            _netClient.SendMessage(msg, NetDeliveryMethod.ReliableOrdered);
        }
        public static void ConnectToServer(string ip)
        {
            if (_netClient == null) {_netClient = ConnectServer();}
            _netClient.Start();
            NetOutgoingMessage hailMsg = _netClient.CreateMessage();
            hailMsg.Write((byte)PacketTypes.Headers.Login);
            hailMsg.Write(Program.PlayerUsername);
            Program.PlayerStore.Add(0, new Player(Program.PlayerUsername));
            _netClient.Connect(ip, 666, hailMsg);
        }
        public static void SendDiscovery()
        {
            if (_netClient == null) { _netClient = ConnectServer(); }
            _netClient.Start();
            _netClient.DiscoverLocalPeers(666);
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
            NetIncomingMessage inc;
            while ((inc = _netClient.ReadMessage()) != null)
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
                                var readyStatus = inc.ReadBoolean();
                                Player player = new Player(username, uid, readyStatus);
                                Program.PlayerStore.Add(uid, player);
                                Console.WriteLine(@"Got new player called: {0} with ID {1} and status of {2}", username, uid, readyStatus);
                                Menu.lobby.UpdateDisplay();
                                break;
                            case PacketTypes.Headers.ReadyUpdate:
                                var puid = inc.ReadInt64();
                                inc.ReadBoolean(); //status
                                if (Program.PlayerStore.ContainsKey(puid))
                                {
                                    Program.PlayerStore[puid].ToggleReady();
                                    Console.WriteLine(@"{0} changed status to {1}", Program.PlayerStore[puid].Name, Program.PlayerStore[puid].GetReadyStatus());
                                    Menu.lobby.UpdateDisplay();
                                }
                                break;
                            case PacketTypes.Headers.LoggedIn:
                                Console.WriteLine(@"Server has acked us");
                                inc.ReadBoolean(); //loginstatus
                                    SendText(PacketTypes.Headers.LoggedIn, Program.PlayerUsername);
                                break;
                            case PacketTypes.Headers.YouAreHost:
                                Console.WriteLine(@"We are apparently the host");
                                Program.AreWeHost = true;
                                Menu.lobby.Lobby_HostStart.Visible = true;
                                break;
                            case PacketTypes.Headers.ChatReceive:
                                var chatUser = inc.ReadString();
                                var chatMsg = inc.ReadString();
                                ChatboxHelpers.AppendText(Menu.lobby.Lobby_Chatbox, String.Format("{0} : {1}", chatUser, chatMsg));
                                break;
                            default:
                                Console.WriteLine(@"Invalid Packet Header: {0}", pheader);
                                break;
                        }
                        break;

                    case NetIncomingMessageType.StatusChanged:
                        Console.WriteLine(@"---Status Changed---");
                        Console.WriteLine(_netClient.ConnectionStatus);
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
