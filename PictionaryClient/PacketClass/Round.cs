using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
