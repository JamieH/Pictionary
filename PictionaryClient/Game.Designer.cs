namespace PictionaryClient
{
    partial class Game
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Game_GamePicturebox = new System.Windows.Forms.PictureBox();
            this.Game_WhoIsDrawing = new System.Windows.Forms.Label();
            this.Game_HintsPicture = new System.Windows.Forms.PictureBox();
            this.Game_DrawTimeLeft = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.Color_Black = new System.Windows.Forms.Button();
            this.Color_White = new System.Windows.Forms.Button();
            this.Color_Darkgray = new System.Windows.Forms.Button();
            this.Color_Gray = new System.Windows.Forms.Button();
            this.Color_Pink = new System.Windows.Forms.Button();
            this.Color_Orange = new System.Windows.Forms.Button();
            this.Color_Brown = new System.Windows.Forms.Button();
            this.Color_Red = new System.Windows.Forms.Button();
            this.Color_LightGreen = new System.Windows.Forms.Button();
            this.Color_Green = new System.Windows.Forms.Button();
            this.Color_Peach = new System.Windows.Forms.Button();
            this.Color_Yellow = new System.Windows.Forms.Button();
            this.Color_LightBlue = new System.Windows.Forms.Button();
            this.Color_Blue = new System.Windows.Forms.Button();
            this.Color_lightAqua = new System.Windows.Forms.Button();
            this.Color_Aqua = new System.Windows.Forms.Button();
            this.Color_Purple = new System.Windows.Forms.Button();
            this.Color_Uhm = new System.Windows.Forms.Button();
            this.pixelSize = new System.Windows.Forms.TrackBar();
            this.Game_DrawSize = new System.Windows.Forms.PictureBox();
            this.Game_RemindMe = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Game_GamePicturebox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Game_HintsPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pixelSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Game_DrawSize)).BeginInit();
            this.SuspendLayout();
            // 
            // Game_GamePicturebox
            // 
            this.Game_GamePicturebox.BackColor = System.Drawing.Color.White;
            this.Game_GamePicturebox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Game_GamePicturebox.Location = new System.Drawing.Point(12, 37);
            this.Game_GamePicturebox.Name = "Game_GamePicturebox";
            this.Game_GamePicturebox.Size = new System.Drawing.Size(883, 413);
            this.Game_GamePicturebox.TabIndex = 0;
            this.Game_GamePicturebox.TabStop = false;
            this.Game_GamePicturebox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Game_GamePicturebox_MouseDown);
            this.Game_GamePicturebox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Game_GamePicturebox_MouseMove);
            this.Game_GamePicturebox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Game_GamePicturebox_MouseUp);
            // 
            // Game_WhoIsDrawing
            // 
            this.Game_WhoIsDrawing.AutoSize = true;
            this.Game_WhoIsDrawing.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Game_WhoIsDrawing.Location = new System.Drawing.Point(12, 9);
            this.Game_WhoIsDrawing.Name = "Game_WhoIsDrawing";
            this.Game_WhoIsDrawing.Size = new System.Drawing.Size(258, 25);
            this.Game_WhoIsDrawing.TabIndex = 1;
            this.Game_WhoIsDrawing.Text = "Username is currently drawing!";
            // 
            // Game_HintsPicture
            // 
            this.Game_HintsPicture.Location = new System.Drawing.Point(397, 456);
            this.Game_HintsPicture.Name = "Game_HintsPicture";
            this.Game_HintsPicture.Size = new System.Drawing.Size(498, 42);
            this.Game_HintsPicture.TabIndex = 2;
            this.Game_HintsPicture.TabStop = false;
            // 
            // Game_DrawTimeLeft
            // 
            this.Game_DrawTimeLeft.AutoSize = true;
            this.Game_DrawTimeLeft.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Game_DrawTimeLeft.Location = new System.Drawing.Point(458, 9);
            this.Game_DrawTimeLeft.Name = "Game_DrawTimeLeft";
            this.Game_DrawTimeLeft.Size = new System.Drawing.Size(253, 25);
            this.Game_DrawTimeLeft.TabIndex = 3;
            this.Game_DrawTimeLeft.Text = "Username has 90 seconds left";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 595);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(797, 20);
            this.textBox1.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(815, 594);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 20);
            this.button1.TabIndex = 5;
            this.button1.Text = "Send";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 508);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(878, 81);
            this.richTextBox1.TabIndex = 6;
            this.richTextBox1.Text = "";
            // 
            // Color_Black
            // 
            this.Color_Black.BackColor = System.Drawing.Color.Black;
            this.Color_Black.FlatAppearance.BorderSize = 0;
            this.Color_Black.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Color_Black.Location = new System.Drawing.Point(17, 456);
            this.Color_Black.Name = "Color_Black";
            this.Color_Black.Size = new System.Drawing.Size(18, 18);
            this.Color_Black.TabIndex = 7;
            this.Color_Black.UseVisualStyleBackColor = false;
            this.Color_Black.Click += new System.EventHandler(this.ColorClick);
            // 
            // Color_White
            // 
            this.Color_White.BackColor = System.Drawing.Color.White;
            this.Color_White.FlatAppearance.BorderSize = 0;
            this.Color_White.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Color_White.Location = new System.Drawing.Point(17, 480);
            this.Color_White.Name = "Color_White";
            this.Color_White.Size = new System.Drawing.Size(18, 18);
            this.Color_White.TabIndex = 8;
            this.Color_White.UseVisualStyleBackColor = false;
            this.Color_White.Click += new System.EventHandler(this.ColorClick);
            // 
            // Color_Darkgray
            // 
            this.Color_Darkgray.BackColor = System.Drawing.Color.Gray;
            this.Color_Darkgray.FlatAppearance.BorderSize = 0;
            this.Color_Darkgray.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Color_Darkgray.Location = new System.Drawing.Point(41, 456);
            this.Color_Darkgray.Name = "Color_Darkgray";
            this.Color_Darkgray.Size = new System.Drawing.Size(18, 18);
            this.Color_Darkgray.TabIndex = 9;
            this.Color_Darkgray.UseVisualStyleBackColor = false;
            this.Color_Darkgray.Click += new System.EventHandler(this.ColorClick);
            // 
            // Color_Gray
            // 
            this.Color_Gray.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Color_Gray.FlatAppearance.BorderSize = 0;
            this.Color_Gray.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Color_Gray.Location = new System.Drawing.Point(41, 480);
            this.Color_Gray.Name = "Color_Gray";
            this.Color_Gray.Size = new System.Drawing.Size(18, 18);
            this.Color_Gray.TabIndex = 10;
            this.Color_Gray.UseVisualStyleBackColor = false;
            this.Color_Gray.Click += new System.EventHandler(this.ColorClick);
            // 
            // Color_Pink
            // 
            this.Color_Pink.BackColor = System.Drawing.Color.MistyRose;
            this.Color_Pink.FlatAppearance.BorderSize = 0;
            this.Color_Pink.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Color_Pink.Location = new System.Drawing.Point(89, 480);
            this.Color_Pink.Name = "Color_Pink";
            this.Color_Pink.Size = new System.Drawing.Size(18, 18);
            this.Color_Pink.TabIndex = 14;
            this.Color_Pink.UseVisualStyleBackColor = false;
            this.Color_Pink.Click += new System.EventHandler(this.ColorClick);
            // 
            // Color_Orange
            // 
            this.Color_Orange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.Color_Orange.FlatAppearance.BorderSize = 0;
            this.Color_Orange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Color_Orange.Location = new System.Drawing.Point(89, 456);
            this.Color_Orange.Name = "Color_Orange";
            this.Color_Orange.Size = new System.Drawing.Size(18, 18);
            this.Color_Orange.TabIndex = 13;
            this.Color_Orange.UseVisualStyleBackColor = false;
            this.Color_Orange.Click += new System.EventHandler(this.ColorClick);
            // 
            // Color_Brown
            // 
            this.Color_Brown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Color_Brown.FlatAppearance.BorderSize = 0;
            this.Color_Brown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Color_Brown.Location = new System.Drawing.Point(65, 480);
            this.Color_Brown.Name = "Color_Brown";
            this.Color_Brown.Size = new System.Drawing.Size(18, 18);
            this.Color_Brown.TabIndex = 12;
            this.Color_Brown.UseVisualStyleBackColor = false;
            this.Color_Brown.Click += new System.EventHandler(this.ColorClick);
            // 
            // Color_Red
            // 
            this.Color_Red.BackColor = System.Drawing.Color.Red;
            this.Color_Red.FlatAppearance.BorderSize = 0;
            this.Color_Red.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Color_Red.Location = new System.Drawing.Point(65, 456);
            this.Color_Red.Name = "Color_Red";
            this.Color_Red.Size = new System.Drawing.Size(18, 18);
            this.Color_Red.TabIndex = 11;
            this.Color_Red.UseVisualStyleBackColor = false;
            this.Color_Red.Click += new System.EventHandler(this.ColorClick);
            // 
            // Color_LightGreen
            // 
            this.Color_LightGreen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.Color_LightGreen.FlatAppearance.BorderSize = 0;
            this.Color_LightGreen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Color_LightGreen.Location = new System.Drawing.Point(137, 480);
            this.Color_LightGreen.Name = "Color_LightGreen";
            this.Color_LightGreen.Size = new System.Drawing.Size(18, 18);
            this.Color_LightGreen.TabIndex = 18;
            this.Color_LightGreen.UseVisualStyleBackColor = false;
            this.Color_LightGreen.Click += new System.EventHandler(this.ColorClick);
            // 
            // Color_Green
            // 
            this.Color_Green.BackColor = System.Drawing.Color.Lime;
            this.Color_Green.FlatAppearance.BorderSize = 0;
            this.Color_Green.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Color_Green.Location = new System.Drawing.Point(137, 456);
            this.Color_Green.Name = "Color_Green";
            this.Color_Green.Size = new System.Drawing.Size(18, 18);
            this.Color_Green.TabIndex = 17;
            this.Color_Green.UseVisualStyleBackColor = false;
            this.Color_Green.Click += new System.EventHandler(this.ColorClick);
            // 
            // Color_Peach
            // 
            this.Color_Peach.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.Color_Peach.FlatAppearance.BorderSize = 0;
            this.Color_Peach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Color_Peach.Location = new System.Drawing.Point(113, 480);
            this.Color_Peach.Name = "Color_Peach";
            this.Color_Peach.Size = new System.Drawing.Size(18, 18);
            this.Color_Peach.TabIndex = 16;
            this.Color_Peach.UseVisualStyleBackColor = false;
            this.Color_Peach.Click += new System.EventHandler(this.ColorClick);
            // 
            // Color_Yellow
            // 
            this.Color_Yellow.BackColor = System.Drawing.Color.Yellow;
            this.Color_Yellow.FlatAppearance.BorderSize = 0;
            this.Color_Yellow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Color_Yellow.Location = new System.Drawing.Point(113, 456);
            this.Color_Yellow.Name = "Color_Yellow";
            this.Color_Yellow.Size = new System.Drawing.Size(18, 18);
            this.Color_Yellow.TabIndex = 15;
            this.Color_Yellow.UseVisualStyleBackColor = false;
            this.Color_Yellow.Click += new System.EventHandler(this.ColorClick);
            // 
            // Color_LightBlue
            // 
            this.Color_LightBlue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.Color_LightBlue.FlatAppearance.BorderSize = 0;
            this.Color_LightBlue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Color_LightBlue.Location = new System.Drawing.Point(185, 480);
            this.Color_LightBlue.Name = "Color_LightBlue";
            this.Color_LightBlue.Size = new System.Drawing.Size(18, 18);
            this.Color_LightBlue.TabIndex = 22;
            this.Color_LightBlue.UseVisualStyleBackColor = false;
            this.Color_LightBlue.Click += new System.EventHandler(this.ColorClick);
            // 
            // Color_Blue
            // 
            this.Color_Blue.BackColor = System.Drawing.Color.Blue;
            this.Color_Blue.FlatAppearance.BorderSize = 0;
            this.Color_Blue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Color_Blue.Location = new System.Drawing.Point(185, 456);
            this.Color_Blue.Name = "Color_Blue";
            this.Color_Blue.Size = new System.Drawing.Size(18, 18);
            this.Color_Blue.TabIndex = 21;
            this.Color_Blue.UseVisualStyleBackColor = false;
            this.Color_Blue.Click += new System.EventHandler(this.ColorClick);
            // 
            // Color_lightAqua
            // 
            this.Color_lightAqua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Color_lightAqua.FlatAppearance.BorderSize = 0;
            this.Color_lightAqua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Color_lightAqua.Location = new System.Drawing.Point(161, 480);
            this.Color_lightAqua.Name = "Color_lightAqua";
            this.Color_lightAqua.Size = new System.Drawing.Size(18, 18);
            this.Color_lightAqua.TabIndex = 20;
            this.Color_lightAqua.UseVisualStyleBackColor = false;
            this.Color_lightAqua.Click += new System.EventHandler(this.ColorClick);
            // 
            // Color_Aqua
            // 
            this.Color_Aqua.BackColor = System.Drawing.Color.Aqua;
            this.Color_Aqua.FlatAppearance.BorderSize = 0;
            this.Color_Aqua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Color_Aqua.Location = new System.Drawing.Point(161, 456);
            this.Color_Aqua.Name = "Color_Aqua";
            this.Color_Aqua.Size = new System.Drawing.Size(18, 18);
            this.Color_Aqua.TabIndex = 19;
            this.Color_Aqua.UseVisualStyleBackColor = false;
            this.Color_Aqua.Click += new System.EventHandler(this.ColorClick);
            // 
            // Color_Purple
            // 
            this.Color_Purple.BackColor = System.Drawing.Color.Fuchsia;
            this.Color_Purple.FlatAppearance.BorderSize = 0;
            this.Color_Purple.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Color_Purple.Location = new System.Drawing.Point(209, 456);
            this.Color_Purple.Name = "Color_Purple";
            this.Color_Purple.Size = new System.Drawing.Size(18, 18);
            this.Color_Purple.TabIndex = 23;
            this.Color_Purple.UseVisualStyleBackColor = false;
            this.Color_Purple.Click += new System.EventHandler(this.ColorClick);
            // 
            // Color_Uhm
            // 
            this.Color_Uhm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Color_Uhm.FlatAppearance.BorderSize = 0;
            this.Color_Uhm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Color_Uhm.Location = new System.Drawing.Point(209, 480);
            this.Color_Uhm.Name = "Color_Uhm";
            this.Color_Uhm.Size = new System.Drawing.Size(18, 18);
            this.Color_Uhm.TabIndex = 24;
            this.Color_Uhm.UseVisualStyleBackColor = false;
            this.Color_Uhm.Click += new System.EventHandler(this.ColorClick);
            // 
            // pixelSize
            // 
            this.pixelSize.Location = new System.Drawing.Point(233, 453);
            this.pixelSize.Maximum = 50;
            this.pixelSize.Minimum = 1;
            this.pixelSize.Name = "pixelSize";
            this.pixelSize.Size = new System.Drawing.Size(104, 45);
            this.pixelSize.TabIndex = 25;
            this.pixelSize.Value = 5;
            this.pixelSize.Scroll += new System.EventHandler(this.pixelSize_Scroll);
            // 
            // Game_DrawSize
            // 
            this.Game_DrawSize.Location = new System.Drawing.Point(343, 453);
            this.Game_DrawSize.Name = "Game_DrawSize";
            this.Game_DrawSize.Size = new System.Drawing.Size(50, 50);
            this.Game_DrawSize.TabIndex = 26;
            this.Game_DrawSize.TabStop = false;
            // 
            // Game_RemindMe
            // 
            this.Game_RemindMe.Location = new System.Drawing.Point(820, 9);
            this.Game_RemindMe.Name = "Game_RemindMe";
            this.Game_RemindMe.Size = new System.Drawing.Size(75, 23);
            this.Game_RemindMe.TabIndex = 27;
            this.Game_RemindMe.Text = "Remind me";
            this.Game_RemindMe.UseVisualStyleBackColor = true;
            this.Game_RemindMe.Visible = false;
            this.Game_RemindMe.Click += new System.EventHandler(this.Game_RemindMe_Click);
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 624);
            this.Controls.Add(this.Game_RemindMe);
            this.Controls.Add(this.Game_DrawSize);
            this.Controls.Add(this.pixelSize);
            this.Controls.Add(this.Color_Uhm);
            this.Controls.Add(this.Color_Purple);
            this.Controls.Add(this.Color_LightBlue);
            this.Controls.Add(this.Color_Blue);
            this.Controls.Add(this.Color_lightAqua);
            this.Controls.Add(this.Color_Aqua);
            this.Controls.Add(this.Color_LightGreen);
            this.Controls.Add(this.Color_Green);
            this.Controls.Add(this.Color_Peach);
            this.Controls.Add(this.Color_Yellow);
            this.Controls.Add(this.Color_Pink);
            this.Controls.Add(this.Color_Orange);
            this.Controls.Add(this.Color_Brown);
            this.Controls.Add(this.Color_Red);
            this.Controls.Add(this.Color_Gray);
            this.Controls.Add(this.Color_Darkgray);
            this.Controls.Add(this.Color_White);
            this.Controls.Add(this.Color_Black);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Game_DrawTimeLeft);
            this.Controls.Add(this.Game_HintsPicture);
            this.Controls.Add(this.Game_WhoIsDrawing);
            this.Controls.Add(this.Game_GamePicturebox);
            this.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.Name = "Game";
            this.Text = "Game";
            ((System.ComponentModel.ISupportInitialize)(this.Game_GamePicturebox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Game_HintsPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pixelSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Game_DrawSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Game_GamePicturebox;
        private System.Windows.Forms.PictureBox Game_HintsPicture;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button Color_Black;
        private System.Windows.Forms.Button Color_White;
        private System.Windows.Forms.Button Color_Darkgray;
        private System.Windows.Forms.Button Color_Gray;
        private System.Windows.Forms.Button Color_Pink;
        private System.Windows.Forms.Button Color_Orange;
        private System.Windows.Forms.Button Color_Brown;
        private System.Windows.Forms.Button Color_Red;
        private System.Windows.Forms.Button Color_LightGreen;
        private System.Windows.Forms.Button Color_Green;
        private System.Windows.Forms.Button Color_Peach;
        private System.Windows.Forms.Button Color_Yellow;
        private System.Windows.Forms.Button Color_LightBlue;
        private System.Windows.Forms.Button Color_Blue;
        private System.Windows.Forms.Button Color_lightAqua;
        private System.Windows.Forms.Button Color_Aqua;
        private System.Windows.Forms.Button Color_Purple;
        private System.Windows.Forms.Button Color_Uhm;
        private System.Windows.Forms.TrackBar pixelSize;
        public System.Windows.Forms.Label Game_WhoIsDrawing;
        public System.Windows.Forms.Label Game_DrawTimeLeft;
        private System.Windows.Forms.PictureBox Game_DrawSize;
        public System.Windows.Forms.Button Game_RemindMe;
    }
}