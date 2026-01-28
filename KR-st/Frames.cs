using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Text;
using System.Windows.Forms;

namespace KR
{
    internal class Frames
    {
        public enum FrameType : byte
        {
            //установка соединения
            UPLINK,
            ACK_UPLINK,
            RET_UPLINK,
            //разрыв соединения
            DOWNLINK,
            ACK_DOWNLINK,
            RET_DOWNLINK,

            //подключения
            LINKACTIVE,
            ACK_LINKACTIVE,
            RET_LINKACITVE,

            // данные
            DAT,
            RET_DAT,
            ACK,
            RET
        }


        public enum MessageType
        {
            Recieve,
            Send,
            Error
        };

        private const byte Start = 0xFF;

        public string HistoryFileName = "History.txt";

        public RichTextBox TextBox1; // текстбокс чата
        public RichTextBox TextBox2; // текстбокс кадров

        private readonly Coding coder = new Coding();
        private readonly Color[] messageColor = { Color.Black, Color.Blue, Color.Red };

        // подключения
        public bool LinkActive;
        public Dictionary<string, bool> activePorts = new Dictionary<string, bool>();
        private byte previousOperation;
        private string lastMsg = string.Empty;
        private int reSendCount = 3;

        public List<string> Users;
        public string CurrentUser;

        public void FrameAction(byte recieved, SerialPort port)
        {
            previousOperation = recieved;
            switch (recieved)
            {
                case (byte)FrameType.UPLINK:
                    DisplayMessage(MessageType.Recieve, DateTime.Now + " UPLINK \n", false);
                    SendFrame(null, FrameType.ACK_UPLINK, false, port);
                    break;

                case (byte)FrameType.ACK_UPLINK:
                    if (activePorts.ContainsKey(port.PortName))
                        activePorts.Remove(port.PortName);
                    activePorts.Add(port.PortName, true);
                    DisplayMessage(MessageType.Recieve, DateTime.Now + " ACK_UPLINK \n", false);
                    break;

                case (byte)FrameType.RET_UPLINK:
                    if (activePorts.ContainsKey(port.PortName))
                        activePorts.Remove(port.PortName);
                    activePorts.Add(port.PortName, false);
                    DisplayMessage(MessageType.Recieve, DateTime.Now + " RET_UPLINK \n", false);
                    SendFrame(null, FrameType.UPLINK, false, port);
                    break;


                case (byte)FrameType.DOWNLINK:
                    if (activePorts.ContainsKey(port.PortName))
                        activePorts.Remove(port.PortName);
                    DisplayMessage(MessageType.Recieve, DateTime.Now + " DOWNLINK \n", false);
                    SendFrame(null, FrameType.ACK_DOWNLINK, false, port);
                    break;

                case (byte)FrameType.ACK_DOWNLINK:
                    if (activePorts.ContainsKey(port.PortName))
                        activePorts.Remove(port.PortName);
                    activePorts.Add(port.PortName, false);
                    DisplayMessage(MessageType.Recieve, DateTime.Now + " ACK_DOWNLINK \n", false);
                    break;

                case (byte)FrameType.RET_DOWNLINK:
                    if (activePorts.ContainsKey(port.PortName))
                        activePorts.Remove(port.PortName);
                    activePorts.Add(port.PortName, false);
                    DisplayMessage(MessageType.Recieve, DateTime.Now + " RET_DOWNLINK \n", false);
                    SendFrame(null, FrameType.DOWNLINK, false, port);
                    break;


                case (byte)FrameType.LINKACTIVE:
                    DisplayMessage(MessageType.Recieve, DateTime.Now + " LINKACTIVE \n", false);
                    SendFrame(null, FrameType.ACK_LINKACTIVE, false, port);
                    break;

                case (byte)FrameType.ACK_LINKACTIVE:
                    DisplayMessage(MessageType.Recieve, DateTime.Now + " ACK_LINKACTIVE \n", false);
                    break;


                case (byte)FrameType.RET_LINKACITVE:
                    if (activePorts.ContainsKey(port.PortName))
                        activePorts.Remove(port.PortName);
                    activePorts.Add(port.PortName, false);
                    DisplayMessage(MessageType.Recieve, DateTime.Now + " RET_LINKACITVE \n", false);
                    SendFrame(null, FrameType.LINKACTIVE, false, port);
                    break;


                case (byte)FrameType.DAT:
                    DisplayMessage(MessageType.Recieve, DateTime.Now + " DAT \n", false);

                    var bytesCount = port.BytesToRead;
                    var text = new byte[bytesCount];
                    port.Read(text, 0, bytesCount);

                    var decoded = coder.Decode(text);
                    if (decoded == string.Empty) SendFrame(null, FrameType.RET_DAT, false, port);
                    else
                    {
                        var senUserLength = CharToInt(decoded.Substring(0, 1)[0]);
                        var sendUser = decoded.Substring(1, senUserLength);
                        var dataText = "[ " + DateTime.Now + " ]";
                        var message = decoded.Substring(1);
                        var path = Application.StartupPath + @"\" + CurrentUser + "_" + sendUser + ".txt";
                        var wstream =
                            new StreamWriter(path, true, Encoding.Default);
                        wstream.WriteLine(dataText);
                        wstream.WriteLine(message);
                        wstream.Close();
                        SendFrame(null, FrameType.ACK, false, port);
                        DisplayMessage(MessageType.Recieve, "\n[ " + DateTime.Now + " ]\n" + message + "\n", true);
                    }
                    break;

                case (byte)FrameType.RET_DAT:
                    DisplayMessage(MessageType.Recieve, DateTime.Now + " RET \n", false);
                    if (reSendCount > 0)
                    {
                        reSendCount--;
                        SendFrame(lastMsg, FrameType.DAT, false, port);
                    }
                    else
                    {
                        reSendCount = 3;
                    }
                    break;

                case (byte)FrameType.ACK:
                    reSendCount = 3;
                    DisplayMessage(MessageType.Recieve, DateTime.Now + " ACK \n", false);
                    break;

                default:
                    DisplayMessage(MessageType.Error, DateTime.Now + " . \n", false);
                    break;
            }
        }

        private static int CharToInt(char c)
        {
            return c - '0';
        }

        [STAThread]
        private void DisplayMessage(MessageType type, string toDisplay, bool textboxChoice)
        {
            // печатает в textbox 1 или 2.
            if (textboxChoice)
                TextBox1.Invoke(new EventHandler(delegate
                {
                    TextBox1.SelectedText = string.Empty;
                    TextBox1.SelectionFont = new Font(TextBox1.SelectionFont, FontStyle.Bold);
                    TextBox1.SelectionColor = messageColor[(int)type];
                    TextBox1.AppendText(toDisplay);
                    TextBox1.ScrollToCaret();
                }));
            else
                TextBox2.Invoke(new EventHandler(delegate
                {
                    TextBox2.SelectedText = string.Empty;
                    TextBox2.SelectionFont = new Font(TextBox2.SelectionFont, FontStyle.Bold);
                    TextBox2.SelectionColor = messageColor[(int)type];
                    TextBox2.AppendText(toDisplay);
                    TextBox2.ScrollToCaret();
                }));
        }


        public void SendFrame(string message, FrameType frameToSend, bool noDisplay, SerialPort port)
        {
            lastMsg = message;
            var frameFields = new List<byte> { Start, (byte)frameToSend };

            switch (frameToSend)
            {
                // отправка сообщения
                case FrameType.DAT:
                    try
                    {
                        if (string.IsNullOrEmpty(message))
                            return;
                        frameFields.AddRange(coder.Encode(message));
                        port.Write(frameFields.ToArray(), 0, frameFields.Count);
                        if (!noDisplay)
                        {
                            DisplayMessage(MessageType.Send, DateTime.Now + " " + frameToSend + "\n", false);
                            DisplayMessage(MessageType.Send, "\n[ " + DateTime.Now + " ] \n" + message.Substring(1), true);
                        }
                    }
                    catch (FormatException ex)
                    {
                        DisplayMessage(MessageType.Error, ex.Message, false);
                    }

                    break;
                default:
                    if (port.IsOpen != true) port.Open();
                    port.Write(frameFields.ToArray(), 0, 2);
                    if (!noDisplay)
                        DisplayMessage(MessageType.Send, DateTime.Now + " " + frameToSend + "\n", false);
                    break;
            }
        }
    }
}
