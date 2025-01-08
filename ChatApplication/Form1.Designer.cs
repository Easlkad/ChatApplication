namespace ChatApplication
{
    partial class Form1
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
            this.button2 = new System.Windows.Forms.Button();
            this.usernameBox = new System.Windows.Forms.TextBox();
            this.ActiveUsers = new System.Windows.Forms.TextBox();
            this.MessageBox = new System.Windows.Forms.TextBox();
            this.SendButton = new System.Windows.Forms.Button();
            this.Chat = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(2, 84);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(151, 23);
            this.button2.TabIndex = 0;
            this.button2.Text = "Connect";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // usernameBox
            // 
            this.usernameBox.Location = new System.Drawing.Point(2, 32);
            this.usernameBox.Name = "usernameBox";
            this.usernameBox.Size = new System.Drawing.Size(151, 20);
            this.usernameBox.TabIndex = 1;
            this.usernameBox.TextChanged += new System.EventHandler(this.usernameBoxChanged);
            // 
            // ActiveUsers
            // 
            this.ActiveUsers.Location = new System.Drawing.Point(2, 113);
            this.ActiveUsers.Multiline = true;
            this.ActiveUsers.Name = "ActiveUsers";
            this.ActiveUsers.Size = new System.Drawing.Size(151, 389);
            this.ActiveUsers.TabIndex = 3;
            // 
            // MessageBox
            // 
            this.MessageBox.Location = new System.Drawing.Point(160, 451);
            this.MessageBox.Multiline = true;
            this.MessageBox.Name = "MessageBox";
            this.MessageBox.Size = new System.Drawing.Size(374, 51);
            this.MessageBox.TabIndex = 4;
            // 
            // SendButton
            // 
            this.SendButton.Location = new System.Drawing.Point(543, 451);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(75, 51);
            this.SendButton.TabIndex = 5;
            this.SendButton.Text = "Send";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // Chat
            // 
            this.Chat.Location = new System.Drawing.Point(160, 31);
            this.Chat.Multiline = true;
            this.Chat.Name = "Chat";
            this.Chat.Size = new System.Drawing.Size(458, 387);
            this.Chat.TabIndex = 6;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(630, 514);
            this.Controls.Add(this.Chat);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.MessageBox);
            this.Controls.Add(this.ActiveUsers);
            this.Controls.Add(this.usernameBox);
            this.Controls.Add(this.button2);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textChat;
        private System.Windows.Forms.TextBox textMessage;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox usernameBox;
        private System.Windows.Forms.TextBox ActiveUsers;
        private System.Windows.Forms.TextBox MessageBox;
        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.TextBox Chat;
    }
}

