using System;
using System.Drawing;
using System.Windows.Forms;
using PictionaryShared;

namespace PictionaryClient
{
    public partial class Game : Form
    {
        private static readonly Image GamePictureImage = new Bitmap(900, 600);
        private static readonly Image GameDrawSize = new Bitmap(200, 200);
        private static Boolean clicked;
        public static Color penColor = Color.Black;
        private Boolean first = true;
        private int newX;
        private int newY;
        private int oldX;
        private int oldY;
        public Timer roundTimer = new Timer {Interval = 1000, Enabled = true};

        public Game()
        {
            InitializeComponent();
            using (Graphics g = Graphics.FromImage(GamePictureImage)) //g is an alias, picture is gened
            {
                g.Clear(Color.White);
            }
            pixelSize_Scroll(null, null);
            roundTimer.Tick += roundTimer_Tick;
        }

        private void roundTimer_Tick(object sender, EventArgs e)
        {
            if (Program.TimeLeft == 0)
            {
                if (Program.AreWeDrawing)
                {
                    Network.SendText(PacketTypes.Headers.ChatSend, "The word I was drawing was: " +  Program.Word);
                }
                updateDisplay();
                Program.TimeLeft = 90;
                roundTimer.Stop();
            }
            else
            {
                Program.TimeLeft --;
                updateDisplay();
            }
        }

        private void Game_GamePicturebox_MouseDown(object sender, MouseEventArgs e)
        {
            if (Program.AreWeDrawing)
            {
                clicked = true;
                using (Graphics g = Graphics.FromImage(GamePictureImage)) //g is an alias, picture is gened
                {
                    g.FillEllipse(new SolidBrush(penColor), e.X - (pixelSize.Value/2), e.Y - (pixelSize.Value/2),
                        pixelSize.Value, pixelSize.Value);
                    Network.SendDraw(penColor, e.X, e.Y, pixelSize.Value);
                    Game_GamePicturebox.Image = GamePictureImage;
                }
            }
        }

        private void Game_GamePicturebox_MouseUp(object sender, MouseEventArgs e)
        {
            first = true;
            clicked = false;
        }

        private void Game_GamePicturebox_MouseMove(object sender, MouseEventArgs e)
        {
            if (clicked)
            {
                if (first)
                {
                    newX = e.X;
                    newY = e.Y;
                    first = false;
                }

                oldX = newX;
                oldY = newY;
                newX = e.X;
                newY = e.Y;

                Game_GamePictureUpdate(penColor.R, penColor.G, penColor.B, e.X, e.Y, pixelSize.Value);
                Network.SendDraw(penColor, e.X, e.Y, pixelSize.Value);
                Game_GamePicturebox.Image = GamePictureImage;
            }
        }

        public void Game_GamePictureUpdate(int r, int g, int b, int x, int y, int size)
        {
            Color color = Color.FromArgb(255, r, g, b);
            using (Graphics gl = Graphics.FromImage(GamePictureImage))
            {
                gl.DrawLine(new Pen(color, pixelSize.Value), oldX, oldY, newX, newY);
                gl.FillEllipse(new SolidBrush(color), x - (size/2), y - (size/2), size, size);
            }
            Game_GamePicturebox.Image = GamePictureImage;
        }

        public void updateDisplay()
        {
            Game_WhoIsDrawing.Text = String.Format("{0} is currently drawing", Program.Drawer);
            Game_DrawTimeLeft.Text = String.Format("{0} has {1} left to draw", Program.Drawer, Program.TimeLeft);
        }

        private void ColorClick(object sender, EventArgs e)
        {
            var b = (Button) sender;
            penColor = b.BackColor;
            pixelSize_Scroll(null, null);
        }

        private void pixelSize_Scroll(object sender, EventArgs e)
        {
            using (Graphics g = Graphics.FromImage(GameDrawSize)) //g is an alias, picture is gened
            {
                g.Clear(SystemColors.Control);
                Math.Atan2(newX, oldX);
                g.FillEllipse(new SolidBrush(penColor), 25 - (pixelSize.Value/2), 25 - (pixelSize.Value/2),
                    pixelSize.Value, pixelSize.Value);
                Game_DrawSize.Image = GameDrawSize;
            }
        }

        public void clearImage()
        {
            Graphics g = Graphics.FromImage(GamePictureImage);
            g.Clear(Color.White);
            Game_GamePicturebox.Image = GamePictureImage;
        }

        public void showWord(string word)
        {
            MessageBox.Show("You are drawing: " + word);
        }

        private void Game_RemindMe_Click(object sender, EventArgs e)
        {
            showWord(Program.Word);
        }
    }
}