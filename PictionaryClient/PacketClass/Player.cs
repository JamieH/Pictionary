using Lidgren.Network;

namespace PictionaryClient.PacketClass
{
    public class Player
    {
        public string Name;
        public long UID;
        private bool _readyStatus;
        public bool IsHost;
        public int drawTimes = 0;
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
        public Player(string name, long uid, bool readyStatus)
        {
            Name = name;
            UID = uid;
            _readyStatus = readyStatus;
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
