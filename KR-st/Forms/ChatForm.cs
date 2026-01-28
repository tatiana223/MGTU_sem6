using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using KR.Forms;
using Timer = System.Windows.Forms.Timer;

namespace KR.Forms
{
    public partial class ChatForm : Form
    {
        // переменные для портов
        private const byte START = 0xFF;
        private int uplinkTries;
        private int downlinkTries;
        private int ackTries;
        private List<SerialPort> ports = new List<SerialPort>();
        private Dictionary<string, SerialPort> portsDict = new Dictionary<string, SerialPort>();

        // таймеры
        public readonly Timer ActiveLinkTimer = new Timer();
        public readonly Timer DownLeft = new Timer();
        public readonly Timer DownRight = new Timer();
        public readonly Timer UpLeft = new Timer();
        public readonly Timer UpRight = new Timer();

        // пользователи
        public string CurrentUser;
        private readonly List<string> allUsers = new List<string>();
        private readonly Frames manager = new Frames();
        private SettingsForm settingsForm;
        private readonly LoginForm loginForm = new LoginForm();

        public ChatForm()
        {
            InitializeComponent();
        }


        private void UpLeftTick(object sender, EventArgs e)
        {
            if (ports.Count == 0) 
            {
                MessageBox.Show("Нет доступных портов");
                UpLeft.Stop();
                return;
            }

            var port = ports[0];
            if (uplinkTries > 0)
            {
                bool isOpen;
                manager.activePorts.TryGetValue(port.PortName, out isOpen);
                if (isOpen)
                {
                    uplinkTries = 3;
                    UpLeft.Stop();
                    manager.SendFrame(null, Frames.FrameType.UPLINK, false, ports[1]);
                    UpRight.Start();
                }
                else
                {
                    uplinkTries--;
                    manager.SendFrame(null, Frames.FrameType.UPLINK, false, port);
                }
            }
            else
            {
                UpLeft.Stop();
                DisconnectionState();
            }
        }

        private void ActiveTick(object sender, EventArgs e)
        {
            foreach (var port in ports)
            {
                if (ackTries > 0)
                {
                    if (!manager.activePorts.ContainsValue(false))
                    {
                        manager.SendFrame(null, Frames.FrameType.LINKACTIVE, true, port);
                        ackTries = 3 * ports.Count;
                    }
                    else
                    {
                        ackTries--;
                        manager.SendFrame(null, Frames.FrameType.LINKACTIVE, false, port);
                    }
                }
                else
                {
                    DisconnectionState();
                    textBox1.Clear();
                }
            }
        }

        private void UpRightTick(object sender, EventArgs e)
        {
            // Проверяем, что ports[1] существует
            if (ports.Count < 2)
            {
                MessageBox.Show("Ошибка: не хватает портов для связи.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                UpRight.Stop();
                return;
            }

            var port = ports[1];
            if (uplinkTries > 0)
            {
                bool isOpen;
                manager.activePorts.TryGetValue(port.PortName, out isOpen);
                if (isOpen && manager.activePorts.Count == 2)
                {
                    // Всё в порядке, активируем интерфейс
                    DownLinkButton.Enabled = true;
                    SendButton.Enabled = true;
                    textBox1.Enabled = true;
                    UpLinkButton.Enabled = true;
                    BroadcastCheckBox.Enabled = true;
                    UserBox.Enabled = true;

                    UpRight.Stop();
                }
                else
                {
                    uplinkTries--;
                    manager.SendFrame(null, Frames.FrameType.UPLINK, false, port);
                }
            }
            else
            {
                UpRight.Stop();
                DisconnectionState();
            }
        }

        private void DownLeftTick(object sender, EventArgs e)
        {
            if (ports.Count == 0)
            {
                DownLeft.Stop();
                DisconnectionState();
                return;
            }

            var port = ports[0];
            if (downlinkTries > 0)
            {
                bool isOpen;
                manager.activePorts.TryGetValue(port.PortName, out isOpen);
                if (isOpen)
                {
                    downlinkTries = 3;
                    DownLeft.Stop();
                    manager.SendFrame(null, Frames.FrameType.DOWNLINK, false, ports[1]);
                    DownRight.Start();
                }
                else
                {
                    downlinkTries--;
                    manager.SendFrame(null, Frames.FrameType.DOWNLINK, false, port);
                }
            }
            else
            {
                DownLeft.Stop();
                DisconnectionState();
            }
        }

        private void DownRightTick(object sender, EventArgs e)
        {
            var port = ports[1];

            if (downlinkTries > 0)
            {
                bool isOpen;
                manager.activePorts.TryGetValue(port.PortName, out isOpen);
                if (!isOpen)
                {

                    DownLinkButton.Enabled = false;
                    SendButton.Enabled = false;
                    textBox1.Enabled = false;
                    UpLinkButton.Enabled = true;
                    BroadcastCheckBox.Enabled = false;
                    UserBox.Enabled = false;

                    DownRight.Stop();
                    ActiveLinkTimer.Start();
                }
                else
                {
                    downlinkTries--;
                    manager.SendFrame(null, Frames.FrameType.DOWNLINK, false, port);
                }
            }
            else
            {
                DownRight.Stop();
                DisconnectionState();
            }

        }

        private void DisconnectionState()
        {
            manager.LinkActive = false;
        }

        private void portError(object sender, SerialErrorReceivedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void portData(object sender, SerialDataReceivedEventArgs e)
        {
            var port = (SerialPort)sender;
            
            if (port.BytesToRead == 0) return;
            
            // Убраны все Thread.Sleep
            if (port.ReadByte() == START)
            {
                var frameByte = (byte)port.ReadByte();
                manager.FrameAction(frameByte, port);
            }
            else
            {
                manager.SendFrame(null, Frames.FrameType.RET, true, port);
            }
        }

        private void customFormClosed(object sender, EventArgs e)
        {
            CurrentUser = loginForm.CurrentUser;
            manager.CurrentUser = CurrentUser;
            manager.TextBox1 = richTextBox1;
            manager.TextBox2 = richTextBox2;
            manager.Users = allUsers;
            CurrentUserLabel.Text += CurrentUser;
        }

        private void историяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "txt files (" + CurrentUser + "*.txt)|" + CurrentUser + "*.txt";
            openFileDialog1.InitialDirectory = Application.StartupPath;
            openFileDialog1.ShowDialog();
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new CreatorsForm();
            form.Show();
        }
        private bool AnotherPortOpen(string another_user, int i)
        {
            var portNumber = (i + 1) * 2 - 1; // Для Татьяны (i=0) -> 1, Виктории -> 3, Дианы -> 5
            var otherport = new SerialPort();
            try
            {
                otherport.PortName = "COM" + portNumber;
                otherport.RtsEnable = true;
                otherport.Open();
                Thread.Sleep(300);
                otherport.Close();
                Thread.Sleep(300);
                return true;
            }
            catch
            {
                return false;
            }
        }
        private void ChatForm_Load(object sender, EventArgs e)
        {
            allUsers.Add("Татьяна");
            allUsers.Add("Виктория");
            allUsers.Add("Диана");
            
            loginForm.FormClosed += customFormClosed;
            
            // Создаем экземпляр SettingsForm после получения текущего пользователя
            settingsForm = new SettingsForm();
            settingsForm.currentUser = CurrentUser;
            
            do {
                settingsForm.ShowDialog();
                
                if (!settingsForm.portIsFree)
                {
                    MessageBox.Show("Порт не настроен. Повторите настройку.", "Ошибка", 
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } while (!settingsForm.portIsFree);

            // Проверяем порты
            if (settingsForm.userPorts == null || settingsForm.userPorts.Count == 0)
            {
                MessageBox.Show("Порты не настроены.", "Ошибка", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Копируем порты
            portsDict = new Dictionary<string, SerialPort>(settingsForm.userPorts);
            ports.Clear();
            ports.AddRange(portsDict.Values);

            // Проверяем, что порты открыты
            foreach (var port in ports)
            {
                if (!port.IsOpen)
                {
                    MessageBox.Show($"Порт {port.PortName} не открыт.", "Ошибка", 
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                port.DataReceived += portData;
                port.ErrorReceived += portError;
            }

            // Настройка таймеров
            UpRight.Tick += UpRightTick;
            UpRight.Interval = 1000;

            UpLeft.Tick += UpLeftTick;
            UpLeft.Interval = 5000;

            DownLeft.Tick += DownLeftTick;
            DownLeft.Interval = 5000;

            DownRight.Tick += DownRightTick;
            DownRight.Interval = 5000;

            ActiveLinkTimer.Tick += ActiveTick;
            ActiveLinkTimer.Interval = 3000;

            // Включаем кнопки только если всё успешно
            DownLinkButton.Enabled = true;
            SendButton.Enabled = true;
            textBox1.Enabled = true;
            BroadcastCheckBox.Enabled = true;
            UserBox.Enabled = true;
            UserBox.DataSource = allUsers;
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text)) return;

            // 1. Получаем список выбранных пользователей
            IEnumerable users = BroadcastCheckBox.Checked ? UserBox.Items : UserBox.SelectedItems;
            var selectedUsers = new List<string>(); // Теперь переменная объявлена ДО использования
            
            foreach (string user in users)
            {
                if (user != CurrentUser)
                    selectedUsers.Add(user);
            }

            // 2. Формируем текст сообщения (без лишних пробелов)
            string message = $"{CurrentUser.Length}{CurrentUser}:{textBox1.Text}";

            // 3. Сохраняем историю и отправляем сообщение
            foreach (var selectedUser in selectedUsers)
            {
                // Сохранение у отправителя и получателя
                string senderHistoryPath = Path.Combine(Application.StartupPath, $"{CurrentUser}_{selectedUser}.txt");
                string receiverHistoryPath = Path.Combine(Application.StartupPath, $"{selectedUser}_{CurrentUser}.txt");
                
                File.AppendAllText(senderHistoryPath, $"[{DateTime.Now}] {CurrentUser}: {textBox1.Text}\n");
                File.AppendAllText(receiverHistoryPath, $"[{DateTime.Now}] {CurrentUser}: {textBox1.Text}\n");

                // Отправка через COM-порт
                if (portsDict.TryGetValue(selectedUser, out SerialPort port))
                {
                    manager.SendFrame(
                        message: message,
                        frameToSend: Frames.FrameType.DAT,
                        noDisplay: false,
                        port: port
                    );
                }
            }

            textBox1.Clear();
        }
        
        private void UpLinkButton_Click(object sender, EventArgs e)
        {
            uplinkTries = 3;
            manager.SendFrame(textBox1.Text, Frames.FrameType.UPLINK, false, ports[0]);
            UpRight.Start();
        }

        private void DownLinkButton_Click(object sender, EventArgs e)
        {
            // Покажем назначение портов в MessageBox
            string portInfo = "Текущие назначения портов:\n";
            foreach (var pair in portsDict)
            {
                string status = pair.Value.IsOpen ? "открыт" : "закрыт";
                portInfo += $"{pair.Key} -> {pair.Value.PortName} ({status})\n";
            }
            MessageBox.Show(portInfo, "Информация о портах");

            DownLinkButton.Enabled = false;
            SendButton.Enabled = false;
            textBox1.Enabled = false;
            BroadcastCheckBox.Enabled = false;
            UserBox.Enabled = false;
            downlinkTries = 3;
            manager.SendFrame(textBox1.Text, Frames.FrameType.DOWNLINK, false, ports[0]);
            DownRight.Start();
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var hForm = new HistoryForm { Filepath = openFileDialog1.FileName };
            if (openFileDialog1.SafeFileName != null)
                hForm.Text = "История ( " + openFileDialog1.SafeFileName.Replace(".txt", "") + " )";
            hForm.Show();
        }

        private void BroadcastCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
