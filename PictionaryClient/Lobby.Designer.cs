namespace PictionaryClient
{
    partial class Lobby
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
            this.Lobby_PlayersPicture = new System.Windows.Forms.PictureBox();
            this.Lobby_HostStart = new System.Windows.Forms.Button();
            this.Lobby_ReadyupButton = new System.Windows.Forms.Button();
            this.Lobby_OutgoingMessageBox = new System.Windows.Forms.TextBox();
            this.Lobby_SendMessageButton = new System.Windows.Forms.Button();
            this.Lobby_Chatbox = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Lobby_PlayersPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // Lobby_PlayersPicture
            // 
            this.Lobby_PlayersPicture.Location = new System.Drawing.Point(12, 12);
            this.Lobby_PlayersPicture.Name = "Lobby_PlayersPicture";
            this.Lobby_PlayersPicture.Size = new System.Drawing.Size(687, 375);
            this.Lobby_PlayersPicture.TabIndex = 0;
            this.Lobby_PlayersPicture.TabStop = false;
            // 
            // Lobby_HostStart
            // 
            this.Lobby_HostStart.Location = new System.Drawing.Point(581, 470);
            this.Lobby_HostStart.Name = "Lobby_HostStart";
            this.Lobby_HostStart.Size = new System.Drawing.Size(118, 23);
            this.Lobby_HostStart.TabIndex = 1;
            this.Lobby_HostStart.Text = "Start";
            this.Lobby_HostStart.UseVisualStyleBackColor = true;
            this.Lobby_HostStart.Visible = false;
            this.Lobby_HostStart.Click += new System.EventHandler(this.Lobby_HostStart_Click);
            // 
            // Lobby_ReadyupButton
            // 
            this.Lobby_ReadyupButton.Location = new System.Drawing.Point(581, 499);
            this.Lobby_ReadyupButton.Name = "Lobby_ReadyupButton";
            this.Lobby_ReadyupButton.Size = new System.Drawing.Size(118, 23);
            this.Lobby_ReadyupButton.TabIndex = 2;
            this.Lobby_ReadyupButton.Text = "Ready Up";
            this.Lobby_ReadyupButton.UseVisualStyleBackColor = true;
            this.Lobby_ReadyupButton.Click += new System.EventHandler(this.Lobby_ReadyupButton_Click);
            // 
            // Lobby_OutgoingMessageBox
            // 
            this.Lobby_OutgoingMessageBox.Location = new System.Drawing.Point(12, 544);
            this.Lobby_OutgoingMessageBox.Name = "Lobby_OutgoingMessageBox";
            this.Lobby_OutgoingMessageBox.Size = new System.Drawing.Size(563, 20);
            this.Lobby_OutgoingMessageBox.TabIndex = 3;
            this.Lobby_OutgoingMessageBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Lobby_OutgoingMessageBox_KeyDown);
            // 
            // Lobby_SendMessageButton
            // 
            this.Lobby_SendMessageButton.Location = new System.Drawing.Point(581, 542);
            this.Lobby_SendMessageButton.Name = "Lobby_SendMessageButton";
            this.Lobby_SendMessageButton.Size = new System.Drawing.Size(118, 23);
            this.Lobby_SendMessageButton.TabIndex = 4;
            this.Lobby_SendMessageButton.Text = "Send";
            this.Lobby_SendMessageButton.UseVisualStyleBackColor = true;
            this.Lobby_SendMessageButton.Click += new System.EventHandler(this.Lobby_SendMessageButton_Click);
            // 
            // Lobby_Chatbox
            // 
            this.Lobby_Chatbox.Location = new System.Drawing.Point(12, 394);
            this.Lobby_Chatbox.Name = "Lobby_Chatbox";
            this.Lobby_Chatbox.Size = new System.Drawing.Size(563, 144);
            this.Lobby_Chatbox.TabIndex = 5;
            this.Lobby_Chatbox.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(581, 390);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "label1";
            // 
            // Lobby
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 577);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Lobby_Chatbox);
            this.Controls.Add(this.Lobby_SendMessageButton);
            this.Controls.Add(this.Lobby_OutgoingMessageBox);
            this.Controls.Add(this.Lobby_ReadyupButton);
            this.Controls.Add(this.Lobby_HostStart);
            this.Controls.Add(this.Lobby_PlayersPicture);
            this.Name = "Lobby";
            this.Text = "Lobby";
            this.Load += new System.EventHandler(this.Lobby_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Lobby_PlayersPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Lobby_ReadyupButton;
        private System.Windows.Forms.TextBox Lobby_OutgoingMessageBox;
        private System.Windows.Forms.Button Lobby_SendMessageButton;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.PictureBox Lobby_PlayersPicture;
        public System.Windows.Forms.Button Lobby_HostStart;
        public System.Windows.Forms.RichTextBox Lobby_Chatbox;
    }
}