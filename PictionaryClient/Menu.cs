﻿using System;
using System.Windows.Forms;

namespace PictionaryClient
{
    public partial class Menu : Form
    {
        public static Lobby lobby = new Lobby();

        public Menu()
        {
            InitializeComponent();
        }
        
        private Timer buttonTimer = new Timer { Enabled = true, Interval = 1000 };
        private bool _tickSet;
        private void Menu_AutoDiscoverButton_Click(object sender, EventArgs e)
        {
            if (!_tickSet)
            {
                buttonTimer.Tick += buttonTimer_Tick;
                _tickSet = true;
            }

            buttonTimer.Start();
            Console.WriteLine(@"Auto Discovery Button Click");
            Network.SendDiscovery();
            Menu_AutoDiscoverButton.Enabled = false;
        }

        private int _timerCount = 4;
        void buttonTimer_Tick(object sender, EventArgs e)
        {
            _timerCount--;
            Menu_AutoDiscoverButton.Text = String.Format("Attempting Discovery ({0})", _timerCount);

            if (Program.AutoDiscoveryIP != null)
            {
                Menu_IPTextbox.Text = Program.AutoDiscoveryIP;
                Program.AutoDiscoveryIP = null;
                _timerCount = 0;
            }

            if (_timerCount == 0)
            {
                _timerCount = 4;
                buttonTimer.Stop();
                Menu_AutoDiscoverButton.Enabled = true;
                Menu_AutoDiscoverButton.Text = @"Auto Connect";
            }
        }

        private void Menu_ConnectButton_Click(object sender, EventArgs e)
        {
            Program.PlayerUsername = Menu_UsernameTextbox.Text;
            Network.ConnectToServer(Menu_IPTextbox.Text);

            if (Program.didError)
            {
                MessageBox.Show(@"Server declined connection");
            }
            else
            {
                lobby.Show();
                Hide();
            }
        }
    }
}
