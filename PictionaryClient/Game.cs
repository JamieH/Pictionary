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
        private static Boolean _clicked;
        public static Color PenColor = Color.Black;
        private Boolean _first = true;
        private int _newX;
        private int _newY;
        private int _oldX;
        private int _oldY;

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
                UpdateDisplay();
                Program.TimeLeft = 90;
                roundTimer.Stop();
            }
            else
            {
                Program.TimeLeft --;
                UpdateDisplay();
            }
        }

        private void Game_GamePicturebox_MouseDown(object sender, MouseEventArgs e)
        {
            if (Program.PlayerUsername == Program.Drawer)
            {
                _clicked = true;
                using (Graphics g = Graphics.FromImage(GamePictureImage)) //g is an alias, picture is gened
                {
                    g.FillEllipse(new SolidBrush(PenColor), e.X - (pixelSize.Value/2), e.Y - (pixelSize.Value/2),
                        pixelSize.Value, pixelSize.Value);
                    Network.SendDraw(PenColor, e.X, e.Y, pixelSize.Value);
                    Game_GamePicturebox.Image = GamePictureImage;
                }
            }
        }

        private void Game_GamePicturebox_MouseUp(object sender, MouseEventArgs e)
        {
            _first = true;
            _clicked = false;
        }

        private void Game_GamePicturebox_MouseMove(object sender, MouseEventArgs e)
        {
            if (Program.PlayerUsername == Program.Drawer)
            {
                if (_clicked)
                {
                    if (_first)
                    {
                        _newX = e.X;
                        _newY = e.Y;
                        _first = false;
                    }

                    _oldX = _newX;
                    _oldY = _newY;
                    _newX = e.X;
                    _newY = e.Y;

                    Game_GamePictureUpdate(PenColor.R, PenColor.G, PenColor.B, e.X, e.Y, pixelSize.Value);
                    Network.SendDraw(PenColor, e.X, e.Y, pixelSize.Value);
                    Network.SendDrawline(PenColor, e.X, e.Y, pixelSize.Value, _oldX, _oldY);
                    Game_GamePicturebox.Image = GamePictureImage;
                }
            }
        }

        public void Game_GamePictureUpdate(int r, int g, int b, int x, int y, int size)
        {
            Color color = Color.FromArgb(255, r, g, b);
            using (Graphics gl = Graphics.FromImage(GamePictureImage))
            {
                gl.DrawLine(new Pen(color, pixelSize.Value), _oldX, _oldY, _newX, _newY);
                gl.FillEllipse(new SolidBrush(color), x - (size/2), y - (size/2), size, size);
            }
            Game_GamePicturebox.Image = GamePictureImage;
        }
        public void Game_GamePictureDrawline(int r, int g, int b, int x, int y, int size, int x1, int y1)
        {
            Color color = Color.FromArgb(255, r, g, b);
            using (Graphics gl = Graphics.FromImage(GamePictureImage))
            {
                gl.DrawLine(new Pen(color, size), x, y, x1, y1);
            }
            Game_GamePicturebox.Image = GamePictureImage;
        }

        public void UpdateDisplay()
        {
            Game_WhoIsDrawing.Text = String.Format("{0} is currently drawing", Program.Drawer);
            Game_DrawTimeLeft.Text = String.Format("{0} has {1} left to draw", Program.Drawer, Program.TimeLeft);
        }

        private void ColorClick(object sender, EventArgs e)
        {
            var b = (Button) sender;
            PenColor = b.BackColor;
            pixelSize_Scroll(null, null);
        }

        private void pixelSize_Scroll(object sender, EventArgs e)
        {
            using (Graphics g = Graphics.FromImage(GameDrawSize)) //g is an alias, picture is gened
            {
                g.Clear(SystemColors.Control);
                g.FillEllipse(new SolidBrush(PenColor), 25 - (pixelSize.Value/2), 25 - (pixelSize.Value/2),
                    pixelSize.Value, pixelSize.Value);
                Game_DrawSize.Image = GameDrawSize;
            }
        }

        public void ShowWord(string word)
        {
            MessageBox.Show(@"You are drawing: " + word);
        }

        private void Game_RemindMe_Click(object sender, EventArgs e)
        {
            ShowWord(Program.Word);
        }

        private void Game_SendMessageButton_Click(object sender, EventArgs e)
        {

            if (Game_OutgoingMessageBox.Text.Length <= 2)
            {
                Network.SendText(PacketTypes.Headers.ChatSend, Game_OutgoingMessageBox.Text);
                Game_OutgoingMessageBox.Text = "";
            }

        }

        private void Game_OutgoingMessageBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (Game_OutgoingMessageBox.Text.Length >= 2)
                {
                    Network.SendText(PacketTypes.Headers.ChatSend, Game_OutgoingMessageBox.Text);
                    Game_OutgoingMessageBox.Text = "";
                }
            }
        }

        public void ResetPic()
        {
            using (Graphics g = Graphics.FromImage(GamePictureImage)) //g is an alias, picture is gened
            {
                g.Clear(Color.White);
            }
            Game_GamePicturebox.Image = GamePictureImage;
            if (Program.Drawer == Program.PlayerUsername)
            {
                Game_OutgoingMessageBox.Text = @"You may not use chat as you are drawing,";
                Game_OutgoingMessageBox.Enabled = false;
                Game_SendChatMessage.Enabled = false;
            }
            else
            {
                Game_OutgoingMessageBox.Text = @"";
                Game_OutgoingMessageBox.Enabled = true;
                Game_SendChatMessage.Enabled = true;
            }
        }
    }
}