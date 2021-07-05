using System;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace WinFrmApp
{
    /// <summary>
    /// Event driven TCP client wrapper
    /// <c> | Class Version 1.0.1</c>
    /// </summary>
    public class ClsTCPClient
    {
        #region Properties and members

        /// <summary>
        /// Enum for TCP Connection Status
        /// </summary>
        public enum ConnectionStatus
        {
            NotConnected,
            Connecting,
            Connected,
            AutoReconnecting,
            DisconnectedByUser,
            DisconnectedByHost,
            ConnectFail_Timeout,
            ReceiveFail_Timeout,
            SendFail_Timeout,
            SendFail_NotConnected,
            Error
        }

        /// <summary>
        /// TCP Client Socket
        /// </summary>
        private TcpClient ClientSocket;

        /// <summary>
        /// TCP IP address to connect
        /// </summary>
        private IPAddress _IP = IPAddress.None;
        /// <summary>
        /// TCP Port number to connect
        /// </summary>
        private int _Port = 0;

        /// <summary>
        /// TCP current connection status update variable
        /// </summary>
        private ConnectionStatus _ConStat;
        /// <summary>
        /// TCP connected or not status update variable
        /// </summary>
        public bool _IsConnected = false;

        /// <summary>
        /// TCP write buffer byte array
        /// </summary>
        private byte[] WriteBuffer;
        /// <summary>
        /// TCP Read buffer byte array
        /// </summary>
        private byte[] ReadBuffer;
        /// <summary>
        /// TCP write buffer byte array size
        /// </summary>
        private int writeBufferSize = 512;
        /// <summary>
        /// TCP Read buffer byte array size
        /// </summary>
        private int readBufferSize = 512;

        /// <summary>
        /// Thread variable for running connection in seperate thred
        /// </summary>
        Thread t;

        /// <summary>
        /// data received from server
        /// </summary>
        private string received_data = "";

        /// <summary>
        /// TCP client connect time out with server
        /// </summary>
        private System.Timers.Timer timerConnectTimeout = null;

        /// <summary>
        /// Default data encoding/decoding formats
        /// </summary>
        private Encoding _encode = Encoding.Default;

        /// <summary>
        /// OnDataReceived Event handler
        /// </summary>
        /// <param name="data"></param>
        public delegate void OnDataReceived(String data);
        public event OnDataReceived onDataReceived;

        /// <summary>
        /// OnConnectionStatusChanged Event handler
        /// </summary>
        /// <param name="connection_status"></param>
        public delegate void OnConnectionStatusChanged(String connection_status);
        public event OnConnectionStatusChanged onConnectionStatusChanged;

        #endregion


        /// <summary>
        /// Constructor method.
        /// </summary>
        /// <param name="ipaddress"></param>
        /// <param name="ipport"></param>
        public ClsTCPClient(string ipaddress, string ipport)
        {
            this._IP = IPAddress.Parse(ipaddress);
            this._Port = int.Parse(ipport);
            _ConStat = ConnectionStatus.NotConnected;
            _IsConnected = false;

            WriteBuffer = new byte[writeBufferSize];
            ReadBuffer = new byte[readBufferSize];

            //this.ClientSocket = null;
            this.ClientSocket = new TcpClient(AddressFamily.InterNetwork);
            //this.ClientSocket.NoDelay = true; //Disable the nagel algorithm for simplicity
            this.ClientSocket.SendTimeout = 512;
            this.ClientSocket.ReceiveTimeout = 512;
            this.ClientSocket.SendBufferSize = writeBufferSize;
            this.ClientSocket.ReceiveBufferSize = readBufferSize;

            timerConnectTimeout = new System.Timers.Timer();
            timerConnectTimeout.Interval = 1000;
            // Hook up the Elapsed event for the timer. 
            timerConnectTimeout.Elapsed += new System.Timers.ElapsedEventHandler(timerConnectTimeout_Elapsed);
            // Have the timer fire repeated events (true is the default)
            timerConnectTimeout.AutoReset = true;
            // Start the timer
            timerConnectTimeout.Start();
        }


        /// <summary>
        /// Sets IP address in this class global variable.
        /// </summary>
        /// <param name="ipaddress"></param>
        /// <param name="ipport"></param>
        public void SetIPPort(string ipaddress, string ipport)
        {
            try
            {
                this._IP = IPAddress.Parse(ipaddress);
                this._Port = int.Parse(ipport);
            }
            catch { }
        }


        /// <summary>
        /// Fresh/New connection establish method.
        /// </summary>
        public void Connect()
        {
            try
            {
                if (ClientSocket != null)
                {
                    if (t != null)
                    { t.Abort(); }
                    //if (clientSocket.Client.Connected)
                    //{
                    ClientSocket.Close();
                    //this.ClientSocket = null;
                    this.ClientSocket = new TcpClient(AddressFamily.InterNetwork);
                    //.ClientSocket.NoDelay = true; //Disable the nagel algorithm for simplicity
                    this.ClientSocket.SendTimeout = 512;
                    this.ClientSocket.ReceiveTimeout = 512;
                    this.ClientSocket.SendBufferSize = writeBufferSize;
                    this.ClientSocket.ReceiveBufferSize = readBufferSize;
                    //}

                    if (!ClientSocket.Client.Connected)
                    {
                        IPEndPoint iep = new IPEndPoint(_IP, _Port);
                        ClientSocket.Client.Connect(iep);
                        //clientStream = clientSocket.GetStream();
                        //ClientSocket.Connect(iep);
                        _IsConnected = true;
                        _ConStat = ConnectionStatus.Connected;
                        //Send off the data for other classes to handle
                        onConnectionStatusChanged?.Invoke(_ConStat.ToString());
                        t = new Thread(new ThreadStart(ListenForPackets));
                        t.Start();
                    }
                    else
                    {
                        _IsConnected = false;
                        _ConStat = ConnectionStatus.ConnectFail_Timeout;
                        //Send off the data for other classes to handle
                        onConnectionStatusChanged?.Invoke(_ConStat.ToString());
                        if (t != null)
                        { t.Abort(); }
                        //ClientSocket.Client.Connected = false;
                        //ClientSocket.Close();
                        //ClientSocket.Client.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                string exp = ex.ToString();
                _IsConnected = false;
                _ConStat = ConnectionStatus.ConnectFail_Timeout;
                //Send off the data for other classes to handle
                onConnectionStatusChanged?.Invoke(_ConStat.ToString());
                if (t != null)
                { t.Abort(); }
            }
        }


        /// <summary>
        /// Disconnect method.
        /// </summary>
        public void Disconnect()
        {
            timerConnectTimeout.Stop();
            if (_IsConnected == true)
            {
                ClientSocket.Close();
                _ConStat = ConnectionStatus.DisconnectedByUser;
                //Send off the data for other classes to handle
                onConnectionStatusChanged?.Invoke(_ConStat.ToString());
            }
            _IsConnected = false;
        }


        /// <summary>
        /// Reconnect method.
        /// </summary>
        public void Reconnect()
        {
            timerConnectTimeout.Stop();
            if (_IsConnected == true)
            {
                ClientSocket.Close();
                _IsConnected = false;
                _ConStat = ConnectionStatus.AutoReconnecting;
                //Send off the data for other classes to handle
                onConnectionStatusChanged?.Invoke(_ConStat.ToString());
            }
            timerConnectTimeout.Start();
        }


        /// <summary>
        /// Contineous monitoring of data reception in seperate thread.
        /// </summary>
        public void ListenForPackets()
        {
            int NumberOfBytesReceived = 0;
            String DataBytesReceived = "";

            while (_IsConnected)
            {
                NumberOfBytesReceived = 0;
                DataBytesReceived = "";
                if (ClientSocket != null)
                {
                    if (ClientSocket.Client.Connected)
                    {
                        NetworkStream clientStream = ClientSocket.GetStream();
                        try
                        {
                            if (clientStream.CanRead)
                            {
                                //Blocks until a message is received from the server
                                StringBuilder completeMessage = new StringBuilder();
                                //while (clientStream.DataAvailable)
                                while (true)
                                {
                                    NumberOfBytesReceived = clientStream.Read(ReadBuffer, 0, readBufferSize);
                                    String RetData;
                                    string[] temp = new string[1024];
                                    //string returndata = System.Text.Encoding.ASCII.GetString(data, 0, bytesRead).Trim();
                                    temp = Encoding.Default.GetString(ReadBuffer,0, NumberOfBytesReceived).Split('\n');
                                    if (temp.Length > 1)
                                    {
                                        if (temp[0].Trim('\0').Length > temp[1].Trim('\0').Length)
                                        { RetData = temp[0]; }
                                        else
                                        { RetData = temp[1]; }
                                    }
                                    else
                                    { RetData = temp[0]; }
                                    DataBytesReceived += RetData;

                                    /*completeMessage.AppendFormat("{0}", Encoding.ASCII.GetString(ReadBuffer, 0, NumberOfBytesReceived));
                                    if (completeMessage.ToString().Contains('\r'))
                                    {
                                        break;
                                    }*/
                                    Array.Clear(ReadBuffer, 0, ReadBuffer.Length);
                                    if (DataBytesReceived.Contains('\r'))
                                    {
                                        break;
                                    }
                                }
                                //DataBytesReceived = completeMessage.ToString();
                                NumberOfBytesReceived = DataBytesReceived.Length;
                            }
                        }
                        catch (Exception ex)
                        {
                            //nothing to read
                            string exp = ex.ToString();
                        }

                        if (NumberOfBytesReceived == 0)
                        {
                            //The server has disconnected
                            //break;
                            try
                            {
                                NetworkStream clientStreamout = ClientSocket.GetStream();
                                byte[] outStream = System.Text.Encoding.ASCII.GetBytes("\0");
                                clientStreamout.Write(outStream, 0, outStream.Length);
                                clientStreamout.Flush();
                            }
                            catch (Exception ex)
                            {
                                _IsConnected = false;
                                _ConStat = ConnectionStatus.SendFail_NotConnected;
                                //Send off the data for other classes to handle
                                onConnectionStatusChanged?.Invoke(_ConStat.ToString());
                                string exp = ex.ToString();
                            }
                        }

                        if (NumberOfBytesReceived > 0 && _IsConnected == true)
                        {
                            try
                            {
                                //String RetData, CheckString;
                                String RetData;
                                //string returndata = System.Text.Encoding.ASCII.GetString(data, 0, bytesRead).Trim();
                                string[] temp = Encoding.Default.GetString(ReadBuffer).Split('\0');
                                if (temp.Length > 1)
                                {
                                    if (temp[0].Trim('\0').Length > temp[1].Trim('\0').Length)
                                    { RetData = temp[0]; }
                                    else
                                    { RetData = temp[1]; }
                                }
                                else
                                { RetData = temp[0]; }

                                //RetData = RetData.Substring(0, bytesRead);

                                received_data = RetData + '\n';

                                //Send off the data for other classes to handle
                                //onDataReceived?.Invoke(received_data);
                                //received_data = "";

                                onDataReceived?.Invoke(DataBytesReceived);
                                DataBytesReceived = "";
                                
                                //System.Threading.Thread.Sleep(15);
                                Array.Clear(ReadBuffer, 0, ReadBuffer.Length);
                                //ReadBuffer = null;
                                //ReadBuffer = new byte[readBufferSize];
                            }
                            catch (Exception ex)
                            {
                                string i = ex.ToString();
                            }
                        }
                    }
                    else
                    {
                        _IsConnected = false;
                        _ConStat = ConnectionStatus.NotConnected;
                        //Send off the data for other classes to handle
                        onConnectionStatusChanged?.Invoke(_ConStat.ToString());
                    }
                }
            }
            ClientSocket.Close();
            _ConStat = ConnectionStatus.NotConnected;
            //Send off the data for other classes to handle
            onConnectionStatusChanged?.Invoke(_ConStat.ToString());
        }
        

        /// <summary>
        /// Connect timeout event handler.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void timerConnectTimeout_Elapsed(Object source, System.Timers.ElapsedEventArgs e)
        {
            _ConStat = ConnectionStatus.NotConnected;
            _IsConnected = false;
            //Send off the data for other classes to handle
            onConnectionStatusChanged?.Invoke(_ConStat.ToString());
            timerConnectTimeout.Stop();
            if (_IsConnected == false)
            {
                _ConStat = ConnectionStatus.Connecting;
                //Send off the data for other classes to handle
                onConnectionStatusChanged?.Invoke(_ConStat.ToString());
                try
                {
                    Connect();
                }
                catch
                {
                    _ConStat = ConnectionStatus.ConnectFail_Timeout;
                    //Send off the data for other classes to handle
                    onConnectionStatusChanged?.Invoke(_ConStat.ToString());
                }
                if (_IsConnected == true)
                {
                    _ConStat = ConnectionStatus.Connected;
                    //Send off the data for other classes to handle
                    onConnectionStatusChanged?.Invoke(_ConStat.ToString());
                }
                else
                {
                    _ConStat = ConnectionStatus.ConnectFail_Timeout;
                    //Send off the data for other classes to handle
                    onConnectionStatusChanged?.Invoke(_ConStat.ToString());
                }
            }
            else
            {
                timerConnectTimeout.Start();
            }
        }


        /// <summary>
        /// Data send to server.
        /// </summary>
        /// <param name="data"></param>
        public void SendDataToServer(string data)
        {
            if (_IsConnected == true)
            {
                try
                {
                    NetworkStream clientStreamout = ClientSocket.GetStream();
                    byte[] outStream = System.Text.Encoding.ASCII.GetBytes(data);
                    clientStreamout.Write(outStream, 0, outStream.Length);
                    clientStreamout.Flush();
                }
                catch (Exception ex)
                {
                    _IsConnected = false;
                    _ConStat = ConnectionStatus.SendFail_NotConnected;
                    //Send off the data for other classes to handle
                    onConnectionStatusChanged?.Invoke(_ConStat.ToString());
                    string exp = ex.ToString();
                }
            }
        }
    
    }
}

/*
 * Example Code
 * 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DNSFrmEVHID
{
    public partial class FrmEVHID : Form
    {
        ClsTCPClient tcpclient;
        public bool isConnected = false;
        public string receivedData = "";
        public bool isAutoConnecting = false;

        public FrmEVHID()
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


        private void FrmEVHID_Load(object sender, EventArgs e)
        {
            this.Icon = WinFrmApp.Properties.Resources.keyboard_blue_icon;

            this.Text = this.Text + " V " + ClsSoftwareInfo.Product_Version;

            TrayNotifyIcon.Icon = WinFrmApp.Properties.Resources.keyboard_blue_icon;

            LoadPage();

            //Initialize the event driven client
            tcpclient = new ClsTCPClient(TbIPAddress.Text, TbPort.Text);
            //Initialize the events
            tcpclient.onDataReceived += new ClsTCPClient.OnDataReceived(clientDataReceived);
            tcpclient.onConnectionStatusChanged += new ClsTCPClient.OnConnectionStatusChanged(clientConnectionStatusChanged);
        }

        private void FrmEVHID_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            { tcpclient.Disconnect(); }
            catch { }
        }

        private void FrmEVHID_Resize(object sender, EventArgs e)
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

        private void TbIPAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != '.';
        }

        private void TbPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (TbIPAddress.Text.Trim().Length >= 8 && TbIPAddress.Text.Trim().Length > 0)
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

                ClsReadWriteAppSetting.WriteAppSetting("IPAddress", TbIPAddress.Text.Trim());

                ClsReadWriteAppSetting.WriteAppSetting("PortNumber", TbPort.Text.Trim());


                LblStatus.Text = "TCP IP/Port && Settings Done."; LblStatus.Update();

                ClsLoadSoftware.LoadAppSetting();

                LoadPage();
            }
            else
            {
                LblStatus.Text = "Invalid TCP IP/Port !"; LblStatus.Update();
            }
        }

        private void BtnReconnect_Click(object sender, EventArgs e)
        {
            if (tcpclient != null)
            {
                tcpclient.Disconnect();
            }
            //set new ip port
            tcpclient.SetIPPort(TbIPAddress.Text, TbPort.Text);
            tcpclient.Reconnect();
        }

        private void BtnGetData_Click(object sender, EventArgs e)
        {
            if (receivedData.Length >= 0)
            {
                //try { SendKeys.SendWait(receivedData); receivedData = ""; } catch { }

                //Clipboard.Clear();  // Always clear the clipboard first
                //Clipboard.SetText(receivedData);
                //SendKeys.Send("^v");  // Paste //SendKeysWait.Send("^v");  // Paste
                SendKeys.Send(receivedData);
                System.Threading.Thread.Sleep(20);
                if (ChbxSuffixEnter.Checked == true)
                {
                    SendKeys.Send("{ENTER}");
                }
                System.Threading.Thread.Sleep(20);
                if (ChbxSuffixEnter.Checked == true)
                {
                    SendKeys.Send("{TAB}");
                }
                if (ChbxACK.Checked == true)
                {
                    System.Threading.Thread.Sleep(100);
                    //char character7 = (char)7;
                    //string ascii_str = character7.ToString();
                    string ascii_str = TbACkReturn.Text;
                    tcpclient.SendDataToServer(ascii_str);
                }
            }
            receivedData = "";
        }

        private void AutoReconnectTimer_Tick(object sender, EventArgs e)
        {
            AutoReconnectTimer.Stop();
            LblStatus.Text = "Reconnecting...";
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

            TbIPAddress.Text = ClsSoftwareInfo.IPAddress;

            TbPort.Text = ClsSoftwareInfo.PortNumber;
        }

        void clientConnectionStatusChanged(string status)
        {
            if (status == "Connected")
            {
                if (ChbxSound.Checked)
                {
                    try
                    { SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\Windows Hardware Insert.wav"); simpleSound.Play(); }
                    catch { }
                }
                isConnected = true;
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
                    Invoke(new ClsTCPClient.OnConnectionStatusChanged(clientConnectionStatusChanged), status);
                }
                catch
                { }
                return;
            }
            LblStatus.Text = status;
            if (status == "DisconnectedByHost" || status == "ConnectFail_Timeout" || status == "Error" || status == "SendFail_NotConnected")
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

        void clientDataReceived(string data)
        {
            //Again, check if this needs to be invoked in the UI thread
            if (InvokeRequired)
            {
                try
                {
                        Invoke(new ClsTCPClient.OnDataReceived(clientDataReceived), data);
                }
                catch { }
                return;
            }
            //data = Regex.Replace(data, @"[^\u0000-\u007F]+", string.Empty);
            //data = System.Text.RegularExpressions.Regex.Replace(data, @"[^\u0000-\u007F\u0900-\u097f]", "");
            TbDataReceived.Text = data;
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
                    //try { SendKeys.SendWait(receivedData); receivedData = ""; } catch { }
                    if (receivedData.Length > 0)
                    {
                        //Clipboard.Clear();  // Always clear the clipboard first
                        //Clipboard.SetText(receivedData);
                        //SendKeys.SendWait("^v");  // Paste //SendKeysWait.Send("^v");  // Paste
                        SendKeys.Send(receivedData);
                        System.Threading.Thread.Sleep(20);
                        if (ChbxSuffixEnter.Checked == true)
                        {
                            SendKeys.Send("{ENTER}");
                        }
                        System.Threading.Thread.Sleep(20);
                        if (ChbxSuffixTab.Checked == true)
                        {
                            SendKeys.Send("{TAB}");
                        }

                        if (ChbxACK.Checked == true)
                        {
                            System.Threading.Thread.Sleep(100);
                            //char character7 = (char)7;
                            //string ascii_str = character7.ToString();
                            string ascii_str = TbACkReturn.Text;
                            tcpclient.SendDataToServer(ascii_str);
                        }
                    }
                }
                receivedData = "";
            }
        }

    }
}

 */
