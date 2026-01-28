using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace KR.Forms
{
    public partial class SettingsForm : Form
    {
        private readonly PortSetup settings = new PortSetup();
        public string currentUser;
        public bool portIsFree;
        public Dictionary<string, SerialPort> userPorts = new Dictionary<string, SerialPort>();

        public SettingsForm()
        {
            InitializeComponent();
        }

        private void LoadValues()
        {
            settings.SetParityToComboBox(SettingsParity);
            settings.SetStopBitsToComboBox(SettingsStop);
        }

        private void SetDefaults()
        {
            SettingsSpeed.SelectedIndex = 5;
            SettingsParity.SelectedIndex = 0;
            SettingsStop.SelectedIndex = 1;
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            LoadValues();
            SetDefaults();
        }

    

        private void SettingsOK_Click(object sender, EventArgs e)
        {
            settings.Parity = SettingsParity.Text;
            settings.Stop = SettingsStop.Text;
            settings.Bps = SettingsSpeed.Text;

            // Очищаем предыдущие порты
            settings.UserPorts.Clear();
            
            // Открываем порт для текущего пользователя
            portIsFree = settings.OpenPort(currentUser);
            
            // Проверяем результат
            if (!portIsFree || settings.UserPorts.Count == 0)
            {
                MessageBox.Show("Не удалось открыть порт. Проверьте настройки COM-порта.", 
                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Копируем порты
            userPorts = new Dictionary<string, SerialPort>(settings.UserPorts);
            Close();
        }

        public void SetSettings()
        {
            settings.Parity = "Odd";
            settings.Stop = "One";
            settings.Bps = "9600";
            
            // Очищаем предыдущие порты
            settings.UserPorts.Clear();
            
            portIsFree = settings.OpenPort(currentUser);
            userPorts = new Dictionary<string, SerialPort>(settings.UserPorts);
            
            if (!portIsFree || userPorts.Count == 0)
            {
                MessageBox.Show("Ошибка настройки порта.", "Ошибка", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void SettingsSpeed_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
