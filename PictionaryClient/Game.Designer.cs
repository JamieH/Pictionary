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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Game_GamePicturebox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Game_HintsPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // Game_GamePicturebox
            // 
            this.Game_GamePicturebox.Location = new System.Drawing.Point(78, 37);
            this.Game_GamePicturebox.Name = "Game_GamePicturebox";
            this.Game_GamePicturebox.Size = new System.Drawing.Size(633, 443);
            this.Game_GamePicturebox.TabIndex = 0;
            this.Game_GamePicturebox.TabStop = false;
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
            this.Game_HintsPicture.Location = new System.Drawing.Point(17, 37);
            this.Game_HintsPicture.Name = "Game_HintsPicture";
            this.Game_HintsPicture.Size = new System.Drawing.Size(55, 443);
            this.Game_HintsPicture.TabIndex = 2;
            this.Game_HintsPicture.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(458, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(253, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Username has 30 seconds left";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(17, 606);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(613, 20);
            this.textBox1.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(636, 606);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 20);
            this.button1.TabIndex = 5;
            this.button1.Text = "Send";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(17, 486);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(694, 111);
            this.richTextBox1.TabIndex = 6;
            this.richTextBox1.Text = "";
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 638);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Game_HintsPicture);
            this.Controls.Add(this.Game_WhoIsDrawing);
            this.Controls.Add(this.Game_GamePicturebox);
            this.Name = "Game";
            this.Text = "Game";
            ((System.ComponentModel.ISupportInitialize)(this.Game_GamePicturebox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Game_HintsPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Game_GamePicturebox;
        private System.Windows.Forms.Label Game_WhoIsDrawing;
        private System.Windows.Forms.PictureBox Game_HintsPicture;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}