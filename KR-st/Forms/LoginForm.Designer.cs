namespace KR.Forms
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.NameField = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LoginButton = new System.Windows.Forms.Button();
            this.ErrorLabel = new System.Windows.Forms.Label();
            this.PortSetupFailedErrorLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NameField
            // 
            this.NameField.Location = new System.Drawing.Point(9, 71);
            this.NameField.Margin = new System.Windows.Forms.Padding(2);
            this.NameField.Name = "NameField";
            this.NameField.Size = new System.Drawing.Size(311, 20);
            this.NameField.TabIndex = 0;
            this.NameField.TextChanged += new System.EventHandler(this.NameField_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(11, 47);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Пользователь";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // LoginButton
            // 
            this.LoginButton.BackColor = Color.LavenderBlush; // Красивый материал-зелёный
            this.LoginButton.FlatStyle = FlatStyle.Flat;
            this.LoginButton.FlatAppearance.BorderSize = 0;
            this.LoginButton.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LoginButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LoginButton.Location = new System.Drawing.Point(191, 144);
            this.LoginButton.Margin = new System.Windows.Forms.Padding(2);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(129, 42);
            this.LoginButton.TabIndex = 2;
            this.LoginButton.Text = "Войти";
            this.LoginButton.UseVisualStyleBackColor = false;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // ErrorLabel
            // 
            this.ErrorLabel.AutoSize = true;
            this.ErrorLabel.BackColor = System.Drawing.Color.Transparent;
            this.ErrorLabel.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ErrorLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.ErrorLabel.Location = new System.Drawing.Point(11, 93);
            this.ErrorLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ErrorLabel.Name = "ErrorLabel";
            this.ErrorLabel.Size = new System.Drawing.Size(224, 42);
            this.ErrorLabel.TabIndex = 3;
            this.ErrorLabel.Text = "Пользователь не зарегистрирован, \r\nобратитесь к администратору";
            this.ErrorLabel.Visible = false;
            this.ErrorLabel.Click += new System.EventHandler(this.ErrorLabel_Click);
            // 
            // PortSetupFailedErrorLabel
            // 
            this.PortSetupFailedErrorLabel.AutoSize = true;
            this.PortSetupFailedErrorLabel.BackColor = System.Drawing.Color.Transparent;
            this.PortSetupFailedErrorLabel.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PortSetupFailedErrorLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.PortSetupFailedErrorLabel.Location = new System.Drawing.Point(11, 93);
            this.PortSetupFailedErrorLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PortSetupFailedErrorLabel.Name = "PortSetupFailedErrorLabel";
            this.PortSetupFailedErrorLabel.Size = new System.Drawing.Size(225, 21);
            this.PortSetupFailedErrorLabel.TabIndex = 4;
            this.PortSetupFailedErrorLabel.Text = "Порт недоступен, попробуйте позже";
            this.PortSetupFailedErrorLabel.Visible = false;
            // 
            // button1
            // 
            this.button1.BackColor = Color.IndianRed; 
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(191, 10);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 32);
            this.button1.TabIndex = 5;
            this.button1.Text = "Закрыть";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.HotPink;
            this.BackgroundImage = System.Drawing.Image.FromFile("C:\\Users\\Tanya\\Учеба\\KR-st\\фон_лог.jpg");
            this.ClientSize = new System.Drawing.Size(331, 197);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.PortSetupFailedErrorLabel);
            this.Controls.Add(this.ErrorLabel);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NameField);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "LoginForm";
            this.Text = "Вход";
            this.ResumeLayout(false);
            this.PerformLayout();

            this.FormBorderStyle = FormBorderStyle.None;


        }

        

        #endregion

        private System.Windows.Forms.TextBox NameField;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.Label ErrorLabel;
        public System.Windows.Forms.Label PortSetupFailedErrorLabel;
        private System.Windows.Forms.Button button1;
    }
}