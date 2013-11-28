using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using PictionaryClient.PacketClass;
using PictionaryShared;

namespace PictionaryClient
{
    public partial class Lobby : Form
    {
        private static Image lobbyPictureImage = new Bitmap(900, 600);
        public static Timer timer = new Timer {Interval = 1000, Enabled = false};
        private static int _countDown = 10;
        public static Game game = new Game();
        public Lobby()
        {
            InitializeComponent();
            timer.Tick += timer_Tick;
        }

        void timer_Tick(object sender, EventArgs e)
        {
            Network.SendText(PacketTypes.Headers.ChatSend, "Game staring in: " + _countDown);
            _countDown--;
            if (_countDown == 0)
            {
                Network.SendText(PacketTypes.Headers.ChatSend, "Game is now starting!");
                _countDown = 10;
                timer.Stop();
                Network.SendText(PacketTypes.Headers.StartGame, "true");
            }
        }

        public void UpdateDisplay()
        {

            using (var g = Graphics.FromImage(lobbyPictureImage)) //g is an alias, picture is gened
            {
                g.Clear(SystemColors.Control); // clear picture
                int counter = 1; // counter for how many players to do with pos
                int y = 10; //y coord

                foreach (KeyValuePair<long, Player> entry in Program.PlayerStore)
                {
                    if (counter % 12 == 0) // if mutiple of 5 increment y and reset counter
                    {
                        counter = 1;
                        y += 120;
                    }
                    if (entry.Value.GetReadyStatus())
                    {
                        g.DrawEllipse(new Pen(Color.Lime, 8), new Rectangle(14 + y, 40 * counter, 8, 8));
                    }
                    else
                    {
                        g.DrawEllipse(new Pen(Color.Red, 8), new Rectangle(14 + y, 40 * counter, 8, 8));
                    }
                    g.DrawString(entry.Value.Name, new Font(FontFamily.GenericSansSerif, 12), Brushes.Black, new Point(25 + y, 36 * counter)); //draw name
                    counter++;
                }
                Lobby_PlayersPicture.Image = lobbyPictureImage;
            }
        }

        private void Lobby_Load(object sender, EventArgs e)
        {
            UpdateDisplay();
        }

        private void Lobby_ReadyupButton_Click(object sender, EventArgs e)
        {
            Program.PlayerStore[0].ToggleReady();
            Network.SendText(PacketTypes.Headers.ReadyUpdate, Program.PlayerStore[0].GetReadyStatus().ToString());
            UpdateDisplay();
        }

        private void Lobby_SendMessageButton_Click(object sender, EventArgs e)
        {

                if (Lobby_OutgoingMessageBox.Text.Length <= 2)
                {
                    Network.SendText(PacketTypes.Headers.ChatSend, Lobby_OutgoingMessageBox.Text);
                    Lobby_OutgoingMessageBox.Text = "";
                }
            
        }

        private void Lobby_OutgoingMessageBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (Lobby_OutgoingMessageBox.Text.Length >= 2)
                {
                    Network.SendText(PacketTypes.Headers.ChatSend, Lobby_OutgoingMessageBox.Text);
                    Lobby_OutgoingMessageBox.Text = "";
                }
            }
        }

        private void Lobby_HostStart_Click(object sender, EventArgs e)
        {
            bool notReady = false;
            foreach (var p in Program.PlayerStore)
            {
                if (!p.Value.GetReadyStatus() & p.Value.Name != Program.PlayerUsername)
                {
                    notReady = true;
                }
            }
            if (timer.Enabled)
            {
                Lobby_HostStart.Text = @"Start";
                timer.Stop();
                _countDown = 10;
                Network.SendText(PacketTypes.Headers.ChatSend, "The countdown was cancelled!");
            }
            else
            {
                Lobby_HostStart.Text = @"Cancel";
                if (notReady)
                {
                    timer.Enabled = true;
                    timer.Start();
                }
                else
                {
                    _countDown = 5;
                    timer.Enabled = true;
                    timer.Start();
                }
            }
            
        }
    }
}
