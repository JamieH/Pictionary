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
                    g.FillRectangle(new SolidBrush(penColor), e.X, e.Y, pixelSize.Value, pixelSize.Value);
                    Network.SendDraw(penColor, e.X, e.Y, pixelSize.Value);
                    Game_GamePicturebox.Image = GamePictureImage;
                }
            }
        }
        public void Game_GamePictureUpdate(int r, int g, int b, int x, int y, int size)
        {
            Color color = Color.FromArgb(255, r, g, b);
            using (var gl = Graphics.FromImage(GamePictureImage))
            {
                Console.WriteLine("Updating {0} : {1} : {2} : {3}", color.ToArgb().ToString(), x, y, size);
                gl.FillRectangle(new SolidBrush(color),x, y ,size, size );
            }
            Game_GamePicturebox.Image = GamePictureImage;
        }
        private void ColorClick(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            penColor = b.BackColor;
        }
    }
}