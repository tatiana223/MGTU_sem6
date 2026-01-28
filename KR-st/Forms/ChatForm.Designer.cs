namespace KR.Forms
{
    partial class ChatForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.историяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CurrentUserLabel = new System.Windows.Forms.Label();
            this.SendButton = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BroadcastCheckBox = new System.Windows.Forms.CheckBox();
            this.DownLinkButton = new System.Windows.Forms.Button();
            this.UpLinkButton = new System.Windows.Forms.Button();
            this.UserBox = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.историяToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(530, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // историяToolStripMenuItem
            // 
            this.историяToolStripMenuItem.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.историяToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.историяToolStripMenuItem.Name = "историяToolStripMenuItem";
            this.историяToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.историяToolStripMenuItem.Text = "История";
            this.историяToolStripMenuItem.Click += new System.EventHandler(this.историяToolStripMenuItem_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.справкаToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.справкаToolStripMenuItem.Text = "Справка";
            this.справкаToolStripMenuItem.Click += new System.EventHandler(this.справкаToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.BroadcastCheckBox);
            this.groupBox1.Controls.Add(this.CurrentUserLabel);
            this.groupBox1.Controls.Add(this.SendButton);
            this.groupBox1.Controls.Add(this.richTextBox1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Location = new System.Drawing.Point(9, 291);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(513, 214);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Чат";
            // 
            // CurrentUserLabel
            // 
            this.CurrentUserLabel.AutoSize = true;
            this.CurrentUserLabel.Font = new System.Drawing.Font("Franklin Gothic Heavy", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CurrentUserLabel.Location = new System.Drawing.Point(4, 21);
            this.CurrentUserLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.CurrentUserLabel.Name = "CurrentUserLabel";
            this.CurrentUserLabel.Size = new System.Drawing.Size(121, 21);
            this.CurrentUserLabel.TabIndex = 3;
            this.CurrentUserLabel.Text = "Пользователь:";
            // 
            // SendButton
            // 
            this.SendButton.BackColor = System.Drawing.Color.DarkViolet;
            this.SendButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SendButton.Font = new System.Drawing.Font("Franklin Gothic Heavy", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SendButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.SendButton.Location = new System.Drawing.Point(361, 177);
            this.SendButton.Margin = new System.Windows.Forms.Padding(2);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(148, 32);
            this.SendButton.TabIndex = 2;
            this.SendButton.Text = "Отправить";
            this.SendButton.UseVisualStyleBackColor = false;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.Lavender;
            this.richTextBox1.Location = new System.Drawing.Point(4, 46);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(505, 100);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(8, 177);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(350, 26);
            this.textBox1.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.DownLinkButton);
            this.groupBox2.Controls.Add(this.UpLinkButton);
            this.groupBox2.Controls.Add(this.UserBox);
            this.groupBox2.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Location = new System.Drawing.Point(274, 29);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(248, 258);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Пользователи";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // BroadcastCheckBox
            // 
            this.BroadcastCheckBox.AutoSize = true;
            this.BroadcastCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.BroadcastCheckBox.Font = new System.Drawing.Font("Franklin Gothic Heavy", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BroadcastCheckBox.ForeColor = System.Drawing.SystemColors.Control;
            this.BroadcastCheckBox.Location = new System.Drawing.Point(361, 150);
            this.BroadcastCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.BroadcastCheckBox.Name = "BroadcastCheckBox";
            this.BroadcastCheckBox.Size = new System.Drawing.Size(152, 25);
            this.BroadcastCheckBox.TabIndex = 4;
            this.BroadcastCheckBox.Text = "Отправить всем";
            this.BroadcastCheckBox.UseVisualStyleBackColor = false;
            this.BroadcastCheckBox.CheckedChanged += new System.EventHandler(this.BroadcastCheckBox_CheckedChanged);
            // 
            // DownLinkButton
            // 
            this.DownLinkButton.BackColor = System.Drawing.Color.LavenderBlush;
            this.DownLinkButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DownLinkButton.Font = new System.Drawing.Font("Franklin Gothic Heavy", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DownLinkButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.DownLinkButton.Location = new System.Drawing.Point(126, 182);
            this.DownLinkButton.Margin = new System.Windows.Forms.Padding(2);
            this.DownLinkButton.Name = "DownLinkButton";
            this.DownLinkButton.Size = new System.Drawing.Size(117, 72);
            this.DownLinkButton.TabIndex = 2;
            this.DownLinkButton.Text = "Отключиться";
            this.DownLinkButton.UseVisualStyleBackColor = false;
            this.DownLinkButton.Click += new System.EventHandler(this.DownLinkButton_Click);
            // 
            // UpLinkButton
            // 
            this.UpLinkButton.BackColor = System.Drawing.Color.LightSkyBlue;
            this.UpLinkButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UpLinkButton.Font = new System.Drawing.Font("Franklin Gothic Heavy", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UpLinkButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.UpLinkButton.Location = new System.Drawing.Point(5, 182);
            this.UpLinkButton.Margin = new System.Windows.Forms.Padding(2);
            this.UpLinkButton.Name = "UpLinkButton";
            this.UpLinkButton.Size = new System.Drawing.Size(117, 72);
            this.UpLinkButton.TabIndex = 1;
            this.UpLinkButton.Text = "Подключиться";
            this.UpLinkButton.UseVisualStyleBackColor = false;
            this.UpLinkButton.Click += new System.EventHandler(this.UpLinkButton_Click);
            // 
            // UserBox
            // 
            this.UserBox.BackColor = System.Drawing.Color.Lavender;
            this.UserBox.Font = new System.Drawing.Font("Franklin Gothic Heavy", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UserBox.FormattingEnabled = true;
            this.UserBox.ItemHeight = 21;
            this.UserBox.Location = new System.Drawing.Point(4, 21);
            this.UserBox.Margin = new System.Windows.Forms.Padding(2);
            this.UserBox.Name = "UserBox";
            this.UserBox.Size = new System.Drawing.Size(240, 151);
            this.UserBox.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.richTextBox2);
            this.groupBox3.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox3.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox3.Location = new System.Drawing.Point(5, 29);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(261, 262);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Служебные сообщения";
            // 
            // richTextBox2
            // 
            this.richTextBox2.BackColor = System.Drawing.Color.Lavender;
            this.richTextBox2.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox2.Location = new System.Drawing.Point(4, 21);
            this.richTextBox2.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.Size = new System.Drawing.Size(253, 233);
            this.richTextBox2.TabIndex = 0;
            this.richTextBox2.Text = "";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // ChatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(530, 516);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ChatForm";
            this.Text = "Чат";
            this.Load += new System.EventHandler(this.ChatForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem историяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox BroadcastCheckBox;
        private System.Windows.Forms.Button DownLinkButton;
        private System.Windows.Forms.Button UpLinkButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Label CurrentUserLabel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ListBox UserBox;
    }
}