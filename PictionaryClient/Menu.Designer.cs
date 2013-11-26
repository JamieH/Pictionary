using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PictionaryClient
{
    partial class Menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.Menu_TitleText = new System.Windows.Forms.Label();
            this.Menu_ConnectButton = new System.Windows.Forms.Button();
            this.Menu_Label1 = new System.Windows.Forms.Label();
            this.Menu_UsernameTextbox = new System.Windows.Forms.TextBox();
            this.Menu_IPTextbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Menu_AutoDiscoverButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Menu_TitleText
            // 
            this.Menu_TitleText.AutoSize = true;
            this.Menu_TitleText.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Menu_TitleText.Location = new System.Drawing.Point(50, 9);
            this.Menu_TitleText.Name = "Menu_TitleText";
            this.Menu_TitleText.Size = new System.Drawing.Size(144, 33);
            this.Menu_TitleText.TabIndex = 0;
            this.Menu_TitleText.Text = "Pictionary";
            // 
            // Menu_ConnectButton
            // 
            this.Menu_ConnectButton.Location = new System.Drawing.Point(12, 103);
            this.Menu_ConnectButton.Name = "Menu_ConnectButton";
            this.Menu_ConnectButton.Size = new System.Drawing.Size(228, 23);
            this.Menu_ConnectButton.TabIndex = 1;
            this.Menu_ConnectButton.Text = "Connect";
            this.Menu_ConnectButton.UseVisualStyleBackColor = true;
            this.Menu_ConnectButton.Click += new System.EventHandler(this.Menu_ConnectButton_Click);
            // 
            // Menu_Label1
            // 
            this.Menu_Label1.AutoSize = true;
            this.Menu_Label1.Location = new System.Drawing.Point(12, 54);
            this.Menu_Label1.Name = "Menu_Label1";
            this.Menu_Label1.Size = new System.Drawing.Size(38, 13);
            this.Menu_Label1.TabIndex = 2;
            this.Menu_Label1.Text = "Name:";
            // 
            // Menu_UsernameTextbox
            // 
            this.Menu_UsernameTextbox.Location = new System.Drawing.Point(56, 51);
            this.Menu_UsernameTextbox.Name = "Menu_UsernameTextbox";
            this.Menu_UsernameTextbox.Size = new System.Drawing.Size(184, 20);
            this.Menu_UsernameTextbox.TabIndex = 3;
            // 
            // Menu_IPTextbox
            // 
            this.Menu_IPTextbox.Location = new System.Drawing.Point(56, 77);
            this.Menu_IPTextbox.Name = "Menu_IPTextbox";
            this.Menu_IPTextbox.Size = new System.Drawing.Size(184, 20);
            this.Menu_IPTextbox.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "IP:";
            // 
            // Menu_AutoDiscoverButton
            // 
            this.Menu_AutoDiscoverButton.Location = new System.Drawing.Point(12, 132);
            this.Menu_AutoDiscoverButton.Name = "Menu_AutoDiscoverButton";
            this.Menu_AutoDiscoverButton.Size = new System.Drawing.Size(228, 23);
            this.Menu_AutoDiscoverButton.TabIndex = 6;
            this.Menu_AutoDiscoverButton.Text = "Auto Connect";
            this.Menu_AutoDiscoverButton.UseVisualStyleBackColor = true;
            this.Menu_AutoDiscoverButton.Click += new System.EventHandler(this.Menu_AutoDiscoverButton_Click);
            // 
            // Menu
            // 
            this.ClientSize = new System.Drawing.Size(252, 162);
            this.Controls.Add(this.Menu_AutoDiscoverButton);
            this.Controls.Add(this.Menu_IPTextbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Menu_UsernameTextbox);
            this.Controls.Add(this.Menu_Label1);
            this.Controls.Add(this.Menu_ConnectButton);
            this.Controls.Add(this.Menu_TitleText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Menu";
            this.Text = "Pictionary Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label Menu_TitleText;
        private Button Menu_ConnectButton;
        private Label Menu_Label1;
        private TextBox Menu_UsernameTextbox;
        private TextBox Menu_IPTextbox;
        private Label label1;
        private Button Menu_AutoDiscoverButton;
    }
}

