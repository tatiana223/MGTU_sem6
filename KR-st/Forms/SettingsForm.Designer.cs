namespace KR.Forms
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.SettingsOK = new System.Windows.Forms.Button();
            this.SettingsSpeed = new System.Windows.Forms.ComboBox();
            this.SettingsStop = new System.Windows.Forms.ComboBox();
            this.SettingsParity = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SettingsOK
            // 
            this.SettingsOK.BackColor = System.Drawing.Color.BlueViolet;
            this.SettingsOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SettingsOK.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SettingsOK.Location = new System.Drawing.Point(12, 223);
            this.SettingsOK.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SettingsOK.Name = "SettingsOK";
            this.SettingsOK.Size = new System.Drawing.Size(414, 37);
            this.SettingsOK.TabIndex = 0;
            this.SettingsOK.Text = "Завершить\r\nнастройку";
            this.SettingsOK.UseVisualStyleBackColor = false;
            this.SettingsOK.Click += new System.EventHandler(this.SettingsOK_Click);
            // 
            // SettingsSpeed
            // 
            this.SettingsSpeed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SettingsSpeed.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SettingsSpeed.FormattingEnabled = true;
            this.SettingsSpeed.Items.AddRange(new object[] {
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "28800",
            "36000",
            "115000"});
            this.SettingsSpeed.Location = new System.Drawing.Point(12, 53);
            this.SettingsSpeed.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SettingsSpeed.Name = "SettingsSpeed";
            this.SettingsSpeed.Size = new System.Drawing.Size(414, 32);
            this.SettingsSpeed.TabIndex = 1;
            this.SettingsSpeed.SelectedIndexChanged += new System.EventHandler(this.SettingsSpeed_SelectedIndexChanged);
            // 
            // SettingsStop
            // 
            this.SettingsStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SettingsStop.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SettingsStop.FormattingEnabled = true;
            this.SettingsStop.Location = new System.Drawing.Point(12, 173);
            this.SettingsStop.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SettingsStop.Name = "SettingsStop";
            this.SettingsStop.Size = new System.Drawing.Size(414, 32);
            this.SettingsStop.TabIndex = 2;
            // 
            // SettingsParity
            // 
            this.SettingsParity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SettingsParity.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SettingsParity.FormattingEnabled = true;
            this.SettingsParity.Location = new System.Drawing.Point(12, 114);
            this.SettingsParity.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SettingsParity.Name = "SettingsParity";
            this.SettingsParity.Size = new System.Drawing.Size(414, 32);
            this.SettingsParity.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(11, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "Скорость передачи";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(11, 87);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 24);
            this.label2.TabIndex = 6;
            this.label2.Text = "Бит четности";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(8, 148);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 24);
            this.label3.TabIndex = 7;
            this.label3.Text = "Стоп";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.IndianRed;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(219, 5);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(206, 34);
            this.button1.TabIndex = 8;
            this.button1.Text = "Закрыть";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = System.Drawing.Image.FromFile("C:\\Users\\Tanya\\Учеба\\KR-st\\фон_лог.jpg");
            this.ClientSize = new System.Drawing.Size(437, 271);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SettingsParity);
            this.Controls.Add(this.SettingsStop);
            this.Controls.Add(this.SettingsSpeed);
            this.Controls.Add(this.SettingsOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "SettingsForm";
            this.Text = "Настройки";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SettingsOK;
        private System.Windows.Forms.ComboBox SettingsSpeed;
        private System.Windows.Forms.ComboBox SettingsStop;
        private System.Windows.Forms.ComboBox SettingsParity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
    }
}