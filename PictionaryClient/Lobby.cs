using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PictionaryClient.PacketClass;
using PictionaryShared;

namespace PictionaryClient
{
    public partial class Lobby : Form
    {
        private static Image lobbyPictureImage = new Bitmap(900, 600);
        public Lobby()
        {
            InitializeComponent();
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
    }
}
