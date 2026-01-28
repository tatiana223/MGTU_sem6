using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Windows.Forms;

namespace KR
{
    class PortSetup
    {
        private string parity = string.Empty;
        private string bps = string.Empty;
        private string stop = string.Empty;
        private readonly SerialPort comPort = new SerialPort();

        // Изменим словарь: ключ - текущий пользователь, значение - его порт для отправки
        public Dictionary<string, SerialPort> UserPorts = new Dictionary<string, SerialPort>();
        public DateTime CurrentDate = new DateTime();

        public string Bps
        {
            get => bps;
            set => bps = value;
        }

        public string Parity
        {
            get => parity;
            set => parity = value;
        }

        public string Stop
        {
            get => stop;
            set => stop = value;
        }

        public bool LinkActive { get; set; }

        public void SetParityToComboBox(ComboBox comboBox)
        {
            comboBox.Items.Clear();
            comboBox.Items.AddRange(Enum.GetNames(typeof(Parity)));
        }

        public void SetStopBitsToComboBox(ComboBox comboBox)
        {
            comboBox.Items.Clear();
            comboBox.Items.AddRange(Enum.GetNames(typeof(StopBits)));
        }

        public bool OpenPort(string currentUser)
        {
            try
            {
                var (nextUser, portNumber) = currentUser switch
                {
                    "Татьяна" => ("Виктория", 1),
                    "Виктория" => ("Диана", 3),
                    "Диана" => ("Татьяна", 5),
                    _ => throw new ArgumentException("Неизвестный пользователь")
                };

                var port = new SerialPort
                {
                    PortName = $"COM{portNumber}",
                    BaudRate = int.Parse(bps),
                    DataBits = 8,
                    StopBits = (StopBits)Enum.Parse(typeof(StopBits), stop),
                    Parity = (Parity)Enum.Parse(typeof(Parity), parity),
                    RtsEnable = true
                };

                // Закрываем порт, если уже открыт
                if (port.IsOpen) port.Close();
                
                port.Open();
                
                // Сохраняем порт с ключом текущего пользователя
                UserPorts[currentUser] = port;
                
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка открытия COM-порта: {ex.Message}");
                UserPorts.Clear();
                return false;
            }
        }
        private (string nextUser, int portNumber) GetNextUserAndPort(string currentUser)
        {
            return currentUser switch
            {
                "Татьяна" => ("Виктория", 1),
                "Виктория" => ("Диана", 3),
                "Диана" => ("Татьяна", 5),
                _ => throw new ArgumentException("Неизвестный пользователь")
            };
        }

        // Метод для получения порта текущего пользователя
        public SerialPort GetUserPort(string userName)
        {
            if (UserPorts.TryGetValue(userName, out var port))
                return port;
            
            throw new KeyNotFoundException($"Порт для пользователя {userName} не найден");
        }
    }
}