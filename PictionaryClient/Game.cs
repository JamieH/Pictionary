using System;
using System.Drawing;
using System.Windows.Forms;

namespace PictionaryClient
{
    public partial class Game : Form
    {
        private static Image GamePictureImage = new Bitmap(900, 600);
        private static Boolean clicked;
        public static Color penColor = Color.Black;
        public Game()
        {
            InitializeComponent();
            using (var g = Graphics.FromImage(GamePictureImage)) //g is an alias, picture is gened
            {
                g.Clear(Color.White);
            }
        }

        private void Game_GamePicturebox_MouseDown(object sender, MouseEventArgs e)
        {
            clicked = true;
        }

        private void Game_GamePicturebox_MouseUp(object sender, MouseEventArgs e)
        {
            clicked = false;
        }

        private void Game_GamePicturebox_MouseMove(object sender, MouseEventArgs e)
        {
            if (clicked)
            {
                using (var g = Graphics.FromImage(GamePictureImage)) //g is an alias, picture is gened
                {

                    int counter = 1; // counter for how many players to do with pos
                    int y = 10; //y coord


                    g.FillRectangle(new SolidBrush(penColor), e.X, e.Y, pixelSize.Value, pixelSize.Value);
                    counter++;

                    Game_GamePicturebox.Image = GamePictureImage;
                }
            }
        }
        private void ColorClick(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            penColor = b.BackColor;
        }
    }
}