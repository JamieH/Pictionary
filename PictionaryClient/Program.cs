using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PictionaryClient.PacketClass;

namespace PictionaryClient
{
    static class Program
    {
        public static string AutoDiscoveryIP;
        public static string PlayerUsername;
        // ReSharper disable once FieldCanBeMadeReadOnly.Global
        public static Dictionary<long, Player> PlayerStore = new Dictionary<long, Player>(); //This is where we store the player
        public static Boolean didError = false;
        public static Boolean AreWeHost;
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
