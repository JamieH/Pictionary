using System;

namespace PictionaryClient.PacketClass
{
    class Round
    {
        public Player Drawer;
        public String Word;
        public Round(Player drawer, string word)
        {
            Drawer = drawer;
            Word = word;
        }
    }
}
