using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PictionaryClient.PacketClass;

namespace PictionaryClient
{
    static class Program
    {
        public static string AutoDiscoveryIP = null;
        public static string PlayerUsername = null;
        public static Dictionary<long, Player> PlayerStore = new Dictionary<long, Player>(); //This is where we store the player
        public static Boolean didError = false;
        public static Boolean areWeHost = false;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Menu());

        }
    }
}
