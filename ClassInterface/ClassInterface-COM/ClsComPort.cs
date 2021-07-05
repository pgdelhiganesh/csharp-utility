using System;
using System.IO.Ports;
using System.Threading;

namespace WinFrmApp
{
    /// <summary>
    /// Event driven RS232 COM Port wrapper
    /// <c> | Class Version 1.0.1</c>
    /// </summary>
    public class ClsCOMPort
    {
        #region Properties and members

        /// <summary>
        /// Enum for COM Port Connection Status
        /// </summary>
        public enum ConnectionStatus
        {
            NotConnected,
            Connecting,
            Connected,
            Disconnected,
            Error
        }

        /// <summary>
        /// Serial Port instance
        /// </summary>
        SerialPort _userSerialPort = null;
        /// <summary>
        /// Serial Port connected or not status update variable
        /// </summary>
        public bool _IsConnected = false;

        /// <summary>
        /// Serial Port current connection status update variable
        /// </summary>
        private ConnectionStatus _ConStat;

        /// <summary>
        /// OnDataReceived Event handler
        /// </summary>
        /// <param name="data"></param>
        public delegate void OnDataReceived(string data);
        public event OnDataReceived onDataReceived;

        /// <summary>
        /// OnConnectionStatusChanged Event handler
        /// </summary>
        /// <param name="connection_status"></param>
        public delegate void OnConnectionStatusChanged(string connection_status);
        public event OnConnectionStatusChanged onConnectionStatusChanged;

        /// <summary>
        /// Thread variable for running connection in seperate thread
        /// </summary>
        Thread t;

        #endregion Properties and members

        /// <summary>
        /// Opens Connection
        /// </summary>
        /// <param name="comportno"></param>
        /// <param name="baudrate"></param>
        /// <param name="databit"></param>
        /// <param name="paritybit"></param>
        /// <param name="stopbit"></param>
        /// <param name="handshake"></param>
        public void Connect(string comportno, string baudrate, string databit = "8", string paritybit = "None", string stopbit = "1", string handshake = "None")
        {
            if (_IsConnected == false)
            {
                try
                {
                    if (t != null)
                    { t.Abort(); }

                    _userSerialPort = new SerialPort();

                    _userSerialPort.PortName = comportno;

                    _userSerialPort.BaudRate = Convert.ToInt32(baudrate);

                    _userSerialPort.DataBits = Convert.ToInt32(databit);

                    if (string.Equals(paritybit, "None",StringComparison.OrdinalIgnoreCase))
                    { _userSerialPort.Parity = Parity.None; }
                    else if(string.Equals(paritybit, "Even", StringComparison.OrdinalIgnoreCase))
                    { _userSerialPort.Parity = Parity.Even; }
                    else if(string.Equals(paritybit, "Odd", StringComparison.OrdinalIgnoreCase))
                    { _userSerialPort.Parity = Parity.Odd; }
                    else if(string.Equals(paritybit, "Mark", StringComparison.OrdinalIgnoreCase))
                    { _userSerialPort.Parity = Parity.Mark; }
                    else if(string.Equals(paritybit, "Space", StringComparison.OrdinalIgnoreCase))
                    { _userSerialPort.Parity = Parity.Space; }
                    else
                    { _userSerialPort.Parity = Parity.None; }

                    if (string.Equals(stopbit, "1", StringComparison.OrdinalIgnoreCase))
                    { _userSerialPort.StopBits = StopBits.One; }
                    else if (string.Equals(stopbit, "1.5", StringComparison.OrdinalIgnoreCase))
                    { _userSerialPort.StopBits = StopBits.OnePointFive; }
                    else if (string.Equals(stopbit, "2", StringComparison.OrdinalIgnoreCase))
                    { _userSerialPort.StopBits = StopBits.Two; }
                    else
                    { _userSerialPort.StopBits = StopBits.None; }

                    if (string.Equals(handshake, "None", StringComparison.OrdinalIgnoreCase))
                    { _userSerialPort.Handshake = Handshake.None; }
                    else if (string.Equals(handshake, "RTS", StringComparison.OrdinalIgnoreCase))
                    { _userSerialPort.Handshake = Handshake.RequestToSend; }
                    else if (string.Equals(handshake, "Hardware", StringComparison.OrdinalIgnoreCase))
                    { _userSerialPort.Handshake = Handshake.XOnXOff; }
                    else if (string.Equals(handshake, "Xon / Xoff", StringComparison.OrdinalIgnoreCase))
                    { _userSerialPort.Handshake = Handshake.RequestToSendXOnXOff; }
                    else
                    { _userSerialPort.Handshake = Handshake.None; }
                
                    _IsConnected = false;
                    _ConStat = ConnectionStatus.NotConnected;
                    onConnectionStatusChanged?.Invoke(_ConStat.ToString());
                    try
                    {
                        _ConStat = ConnectionStatus.Connecting;
                        onConnectionStatusChanged?.Invoke(_ConStat.ToString());
                        if (!(_userSerialPort.IsOpen))
                        {
                            _userSerialPort.Open();
                            _IsConnected = true;
                            _ConStat = ConnectionStatus.Connected;
                            onConnectionStatusChanged?.Invoke(_ConStat.ToString());
                            ////SerialDataReceivedEventHandler SerialPortDataReceived = null;
                            ////_userSerialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
                            //_userSerialPort.DataReceived += SerialPortDataReceived;

                            if (t != null)
                            { t.Abort(); }
                        
                            t = new Thread(new ThreadStart(ListenForData));
                            t.Start();
                        }
                        else
                        {
                            _userSerialPort.Close();
                            _IsConnected = false;
                            _ConStat = ConnectionStatus.NotConnected;
                            onConnectionStatusChanged?.Invoke(_ConStat.ToString());
                            if (t != null)
                            { t.Abort(); }
                        }
                    }
                    catch
                    {
                        _userSerialPort.Close();
                        _IsConnected = false;
                        _ConStat = ConnectionStatus.Error;
                        onConnectionStatusChanged?.Invoke(_ConStat.ToString());
                        //MessageBox.Show("Error opening serial port..." + ex.Message, "Error!");
                        if (t != null)
                        { t.Abort(); }
                    }
                }
                catch
                {
                    try
                    {
                        _IsConnected = false;
                        //_userSerialPort.DataReceived -= SerialPortDataReceived;
                        _userSerialPort.DtrEnable = false;
                        _userSerialPort.RtsEnable = false;
                        while (!(_userSerialPort.BytesToRead == 0 && _userSerialPort.BytesToWrite == 0))
                        {
                            _userSerialPort.DiscardInBuffer();
                            _userSerialPort.DiscardOutBuffer();
                        }
                        _userSerialPort.Close();
                        _ConStat = ConnectionStatus.NotConnected;
                        onConnectionStatusChanged?.Invoke(_ConStat.ToString());
                        if (t != null)
                        { t.Abort(); }
                    }
                    catch { }
                }
            }
            else
            {
                try
                {
                    _IsConnected = false;
                    //_userSerialPort.DataReceived -= SerialPortDataReceived;
                    _userSerialPort.DtrEnable = false;
                    _userSerialPort.RtsEnable = false;
                    while (!(_userSerialPort.BytesToRead == 0 && _userSerialPort.BytesToWrite == 0))
                    {
                        _userSerialPort.DiscardInBuffer();
                        _userSerialPort.DiscardOutBuffer();
                    }
                    _userSerialPort.Close();
                    _ConStat = ConnectionStatus.NotConnected;
                    onConnectionStatusChanged?.Invoke(_ConStat.ToString());
                    if (t != null)
                    { t.Abort(); }
                }
                catch { }
            }
        }

        /// <summary>
        /// Close the Connection
        /// </summary>
        public void Disconnect()
        {
            try
            {
                _IsConnected = false;
                //_userSerialPort.DataReceived -= SerialPortDataReceived;
                _userSerialPort.DtrEnable = false;
                _userSerialPort.RtsEnable = false;
                while (!(_userSerialPort.BytesToRead == 0 && _userSerialPort.BytesToWrite == 0))
                {
                    _userSerialPort.DiscardInBuffer();
                    _userSerialPort.DiscardOutBuffer();
                }
                _userSerialPort.Close();
                _ConStat = ConnectionStatus.NotConnected;
                onConnectionStatusChanged?.Invoke(_ConStat.ToString());
                if (t != null)
                { t.Abort(); }
            }
            catch { }
        }

        /// <summary>
        /// Contineous monitoring of data reception in seperate thread.
        /// </summary>
        public void ListenForData()
        {
            while (_IsConnected)
            {
                try
                {
                    //var data = _userSerialPort.ReadExisting();
                    var data = _userSerialPort.ReadLine();
                    onDataReceived?.BeginInvoke(data.ToString(), null, null);
                }
                catch 
                {
                    if (_IsConnected == true)
                    {
                        Disconnect();

                        _ConStat = ConnectionStatus.Disconnected;
                        onConnectionStatusChanged?.Invoke(_ConStat.ToString());
                    }
                    _IsConnected = false;
                }
            }
        }

        /// <summary>
        /// SerialPortDataReceived event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void SerialPortDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (_IsConnected == true)
            {
                var serialPort = (SerialPort)sender;
                try
                {
                    //var data = serialPort.ReadExisting();
                    var data = serialPort.ReadLine();
                    onDataReceived?.BeginInvoke(data.ToString(),null,null);
                }
                catch { }
            }
        }

        /// <summary>
        /// Data send to COM port.
        /// </summary>
        /// <param name="data"></param>
        public void SendDataToCOMPort(string DataToSend)
        {
            if (_IsConnected == true)
            {
                try
                {
                    _userSerialPort.Write(DataToSend);
                }
                catch { }
            }
        }
    }
}

/* 
* Example Code

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Media;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DNSFrmCVHID
{
    public partial class FrmCVHID : Form
    {

        ClsCOMPort comPort;
        public bool isConnected = false;
        public string receivedData = "";
        public bool isAutoConnecting = false;

        public FrmCVHID()
        {
            InitializeComponent();
            //Form.CheckForIllegalCrossThreadCalls = false;
            //TextBox.CheckForIllegalCrossThreadCalls = false;
        }

        private const int WS_EX_NOACTIVATE = 0x08000000;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;
                createParams.ExStyle |= WS_EX_NOACTIVATE;
                return createParams;
            }
        }

        //public class NoActivateForm : Form
        //{
        //    protected override bool ShowWithoutActivation
        //    {
        //        get
        //        {
        //            return true;
        //        }
        //    }
        //}

        //private const int WM_MOUSEACTIVATE = 0x0021, MA_NOACTIVATE = 0x0003;
        //protected override void WndProc(ref Message m)
        //{
        //    if (m.Msg == WM_MOUSEACTIVATE)
        //    {
        //        m.Result = (IntPtr)MA_NOACTIVATE;
        //        return;
        //    }
        //    base.WndProc(ref m);
        //}

        private void FrmCVHID_Load(object sender, EventArgs e)
        {
            this.Icon = WinFrmApp.Properties.Resources.keyboard_blue_icon;

            this.Text = this.Text + " V " + ClsSoftwareInfo.Product_Version;

            TrayNotifyIcon.Icon = WinFrmApp.Properties.Resources.keyboard_blue_icon;

            LoadPage();

            if (CbCOMPort.Text.Trim().Length > 0)
            {
                //Initialize the event driven client
                comPort = new ClsCOMPort();
                //Initialize the events
                comPort.onDataReceived += new ClsCOMPort.OnDataReceived(clientDataReceived);
                comPort.onConnectionStatusChanged += new ClsCOMPort.OnConnectionStatusChanged(clientConnectionStatusChanged);
                comPort.Connect(CbCOMPort.Text, CbBaudrate1.Text, CbDatabit1.Text, CbParitybit1.Text, CbStopbit1.Text, CbFlowcontrol1.Text);
            }
        }

        private void FrmCVHID_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            { comPort.Disconnect(); }
            catch { }

            try
            { comPort2.Disconnect(); }
            catch { }
        }

        private void FrmCVHID_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                TrayNotifyIcon.Visible = true;
                TrayNotifyIcon.ShowBalloonTip(1000);
            }
        }

        private void TrayNotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            TrayNotifyIcon.Visible = false;
        }

        private void LblCOMPort_1_Click(object sender, EventArgs e)
        {
            try
            {
                //Populate the Combobox with SerialPorts on the System
                CbCOMPort.Items.Clear();
                CbCOMPort.Items.AddRange(SerialPort.GetPortNames());
            }
            catch { }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (ChBxReadContinue.Checked)
            {
                ClsReadWriteAppSetting.WriteAppSetting("ContineousRead", "TRUE");
            }
            else
            {
                ClsReadWriteAppSetting.WriteAppSetting("ContineousRead", "FALSE");
            }

            if (ChbxACK.Checked)
            {
                ClsReadWriteAppSetting.WriteAppSetting("AckBack", "TRUE");
            }
            else
            {
                ClsReadWriteAppSetting.WriteAppSetting("AckBack", "FALSE");
            }

            ClsReadWriteAppSetting.WriteAppSetting("AckText", TbACkReturn.Text);

            if (ChbxSuffixEnter.Checked)
            {
                ClsReadWriteAppSetting.WriteAppSetting("SuffixEnter", "TRUE");
            }
            else
            {
                ClsReadWriteAppSetting.WriteAppSetting("SuffixEnter", "FALSE");
            }

            if (ChbxSuffixTab.Checked)
            {
                ClsReadWriteAppSetting.WriteAppSetting("SuffixTab", "TRUE");
            }
            else
            {
                ClsReadWriteAppSetting.WriteAppSetting("SuffixTab", "FALSE");
            }

            if (ChbxSound.Checked)
            {
                ClsReadWriteAppSetting.WriteAppSetting("ReceiveSound", "TRUE");
            }
            else
            {
                ClsReadWriteAppSetting.WriteAppSetting("ReceiveSound", "FALSE");
            }

            ClsReadWriteAppSetting.WriteAppSetting("COMPort", CbCOMPort.Text.Trim());
            ClsReadWriteAppSetting.WriteAppSetting("Baudrate", CbBaudrate1.Text.Trim());
            ClsReadWriteAppSetting.WriteAppSetting("Databit", CbDatabit1.Text.Trim());
            ClsReadWriteAppSetting.WriteAppSetting("Paritybit", CbParitybit1.Text.Trim());
            ClsReadWriteAppSetting.WriteAppSetting("Stopbit", CbStopbit1.Text.Trim());
            ClsReadWriteAppSetting.WriteAppSetting("Flowcontrol", CbFlowcontrol1.Text.Trim());

            LblStatus.Text = "COM Port && Settings Done."; LblStatus.Update();

            ClsLoadSoftware.LoadAppSetting();

            LoadPage();
        }

        private void BtnReconnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (comPort != null)
                {
                    comPort.Disconnect();

                    comPort.Connect(CbCOMPort.Text, CbBaudrate1.Text, CbDatabit1.Text, CbParitybit1.Text, CbStopbit1.Text, CbFlowcontrol1.Text);
                }
                else
                {
                    if (CbCOMPort.Text.Trim().Length > 0)
                    {
                        //Initialize the event driven client
                        comPort = new ClsCOMPort();
                        //Initialize the events
                        comPort.onDataReceived += new ClsCOMPort.OnDataReceived(clientDataReceived);
                        comPort.onConnectionStatusChanged += new ClsCOMPort.OnConnectionStatusChanged(clientConnectionStatusChanged);
                        comPort.Connect(CbCOMPort.Text, CbBaudrate1.Text, CbDatabit1.Text, CbParitybit1.Text, CbStopbit1.Text, CbFlowcontrol1.Text);
                    }
                }
            }
            catch { }
        }

        private void BtnGetData_Click(object sender, EventArgs e)
        {
            if (receivedData.Length > 0)
            {
                //try { SendKeys.SendWait(receivedData); receivedData = ""; } catch { }

                //Clipboard.Clear();  // Always clear the clipboard first
                //Clipboard.SetText(receivedData);
                //SendKeys.Send("^v");  // Paste //SendKeysWait.Send("^v");  // Paste

                SendKeys.Send(receivedData);
                
                if (ChbxSuffixEnter.Checked == true)
                {
                    System.Threading.Thread.Sleep(10);
                    SendKeys.Send("{ENTER}");
                }

                if (ChbxSuffixTab.Checked == true)
                {
                    System.Threading.Thread.Sleep(10);
                    SendKeys.Send("{TAB}");
                }

                if (ChbxACK.Checked == true)
                {
                    System.Threading.Thread.Sleep(10);
                    //char character7 = (char)7;
                    //string ascii_str = character7.ToString();
                    string ascii_str = TbACkReturn.Text;
                    comPort.SendDataToCOMPort(ascii_str);
                }

                receivedData = "";
            }
        }

        private void AutoReconnectTimer_Tick(object sender, EventArgs e)
        {
            AutoReconnectTimer.Stop();
            LblStatus.Text = "Reconnecting"; LblStatus.Update();
            BtnReconnect_Click(null, null);
        }


        private void LoadPage()
        {
            if (string.Equals(ClsSoftwareInfo.ContineousRead, "TRUE", StringComparison.OrdinalIgnoreCase))
            {
                ChBxReadContinue.Checked = true;
            }
            else
            {
                ChBxReadContinue.Checked = false;
            }

            if (string.Equals(ClsSoftwareInfo.AckBack, "TRUE", StringComparison.OrdinalIgnoreCase))
            {
                ChbxACK.Checked = true;
            }
            else
            {
                ChbxACK.Checked = false;
            }

            TbACkReturn.Text = ClsSoftwareInfo.AckText;

            if (string.Equals(ClsSoftwareInfo.SuffixEnter, "TRUE", StringComparison.OrdinalIgnoreCase))
            {
                ChbxSuffixEnter.Checked = true;
            }
            else
            {
                ChbxSuffixEnter.Checked = false;
            }

            if (string.Equals(ClsSoftwareInfo.SuffixTab, "TRUE", StringComparison.OrdinalIgnoreCase))
            {
                ChbxSuffixTab.Checked = true;
            }
            else
            {
                ChbxSuffixTab.Checked = false;
            }

            if (string.Equals(ClsSoftwareInfo.ReceiveSound, "TRUE", StringComparison.OrdinalIgnoreCase))
            {
                ChbxSound.Checked = true;
            }
            else
            {
                ChbxSound.Checked = false;
            }

            try
            {   
                //Populate the Combobox with SerialPorts on the System
                CbCOMPort.Items.Clear();
                CbCOMPort.Items.AddRange(SerialPort.GetPortNames());
            }
            catch { }
            CbCOMPort.Text = ClsSoftwareInfo.COMPort;
            CbBaudrate1.Text = ClsSoftwareInfo.Baudrate;
            CbDatabit1.Text = ClsSoftwareInfo.Databit;
            CbStopbit1.Text = ClsSoftwareInfo.Stopbit;
            CbParitybit1.Text = ClsSoftwareInfo.Paritybit;
            CbFlowcontrol1.Text = ClsSoftwareInfo.Flowcontrol;
        }

        void clientConnectionStatusChanged(String status)
        {
            if (status == "Connected")
            {
                isConnected = true;

                if (ChbxSound.Checked)
                {
                    try
                    { SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\Windows Hardware Insert.wav"); simpleSound.Play(); }
                    catch { }
                }
                isAutoConnecting = false;
                LblStatus.ForeColor = Color.FromArgb(0, 0, 192);
            }
            else
            {
                isConnected = false;
                LblStatus.ForeColor = Color.OrangeRed;
            }

            //Check if this event was fired on a different thread, if it is then we must invoke it on the UI thread
            if (InvokeRequired)
            {
                try
                {
                    Invoke(new ClsCOMPort.OnConnectionStatusChanged(clientConnectionStatusChanged), status);
                }
                catch { }
                return;
            }
            BtnReconnect.Text = status;
            LblStatus.Text = status;
            if (status == "Error" || status == "Disconnected")
            {
                if (isAutoConnecting == false)
                {
                    if (ChbxSound.Checked)
                    {
                        try
                        { SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\tada.wav"); simpleSound.Play(); }
                        catch { }
                    }
                    isAutoConnecting = true;
                    AutoReconnectTimer.Start();
                    isAutoConnecting = false;
                }
            }
        }

        void clientDataReceived(String data)
        {
            //Again, check if this needs to be invoked in the UI thread
            if (InvokeRequired)
            {
                try
                {
                    Invoke(new ClsCOMPort.OnDataReceived(clientDataReceived), data);
                }
                catch
                { }
                return;
            }
            //data = Regex.Replace(data, @"[^\u0000-\u007F]+", string.Empty);
            //data = System.Text.RegularExpressions.Regex.Replace(data, @"[^\u0000-\u007F\u0900-\u097f]", "");
            TbDataReceived.Text = data; TbDataReceived.Update();
            receivedData = data.Trim();
            
            if (receivedData.Length > 0)
            {
                if (ChbxSound.Checked)
                {
                    try
                    { SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\chimes.wav"); simpleSound.Play(); }
                    catch { }
                }

                if (ChBxReadContinue.Checked == true)
                {
                    //Regex rgx = new Regex(@"[^0-9\.]"); this is for weighing scale only.
                    //receivedData = rgx.Replace(receivedData, ""); this is for weighing scale only.

                    //Clipboard.Clear();  // Always clear the clipboard first
                    //Clipboard.SetText(receivedData);
                    //SendKeys.SendWait("^v");  // Paste //SendKeysWait.Send("^v");  // Paste

                    SendKeys.Send(receivedData);
                    
                    if (ChbxSuffixEnter.Checked == true)
                    {
                        System.Threading.Thread.Sleep(10);
                        SendKeys.Send("{ENTER}");
                    }
                    
                    if (ChbxSuffixTab.Checked == true)
                    {
                        System.Threading.Thread.Sleep(1105);
                        SendKeys.Send("{TAB}");
                    }

                    if (ChbxACK.Checked == true)
                    {
                        System.Threading.Thread.Sleep(10);
                        //char character7 = (char)7;
                        //string ascii_str = character7.ToString();
                        string ascii_str = TbACkReturn.Text;
                        comPort.SendDataToCOMPort(ascii_str);
                    }
                    receivedData = "";
                }
            }
        }
    }
}
*/
