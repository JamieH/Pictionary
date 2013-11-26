using Lidgren.Network;

namespace PictionaryClient.PacketClass
{
    public class Player
    {
        public string Name;
        public long UID;
        private bool _readyStatus;
        public bool isHost;
        public NetConnection Connection;
        public Player(string name)
        {
            Name = name;
        }
        public Player(string name, long uid)
        {
            Name = name;
            UID = uid;
        }

        public void ToggleReady()
        {
            if (_readyStatus)
            {
                _readyStatus = false;
            }
            else
            {
                _readyStatus = true;
            }
        }

        public bool GetReadyStatus()
        {
            return _readyStatus;
        }
    }
}
