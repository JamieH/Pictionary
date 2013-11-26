namespace PictionaryShared
{
    static class PacketTypes
    {
        public enum Headers
        {
            Login,
            PlayerRec,
            ChatSend,
            ChatReceive,
            ReadyUpdate,
            LoggedIn,
            YouAreHost,
            HostCanStart,
            StartGame
        }
    }
}
