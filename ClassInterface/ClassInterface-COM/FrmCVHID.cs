using System;
using System.Drawing;
using System.IO.Ports;
using System.Media;
using System.Windows.Forms;

namespace WinFrmApp
{
    public partial class FrmCVHID : Form
    {

        ClsCOMPort comPort;
        public bool isConnected = false;
        public string receivedData = "";
        public bool isAutoConnecting = false;

        ClsCOMPort comPort2;
        public bool isConnected2 = false;
        public string receivedData2 = "";
        public bool isAutoConnecting2 = false;

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

            this.Text = "COM_Virtual_HID " + " V " + ClsSoftwareInfo.Product_Version;

            TrayNotifyIcon.Icon = WinFrmApp.Properties.Resources.keyboard_blue_icon;

            LoadPage();

            if (CbCOMPort1.Text.Trim().Length > 0)
            {
                //Initialize the event driven client
                comPort = new ClsCOMPort();
                //Initialize the events
                comPort.onDataReceived += new ClsCOMPort.OnDataReceived(clientDataReceived);
                comPort.onConnectionStatusChanged += new ClsCOMPort.OnConnectionStatusChanged(clientConnectionStatusChanged);
                comPort.Connect(CbCOMPort1.Text, CbBaudrate1.Text, CbDatabit1.Text, CbParitybit1.Text, CbStopbit1.Text, CbFlowcontrol1.Text);
            }

            if (CbCOMPort2.Text.Trim().Length > 0)
            {
                //Initialize the event driven client
                comPort2 = new ClsCOMPort();
                //Initialize the events
                //comPort2.onDataReceived += new ClsCOMPort.OnDataReceived(clientDataReceived2); // we only use COM2 for data sending.
                comPort2.onConnectionStatusChanged += new ClsCOMPort.OnConnectionStatusChanged(clientConnectionStatusChanged2);
                comPort2.Connect(CbCOMPort2.Text, CbBaudrate2.Text, CbDatabit2.Text, CbParitybit2.Text, CbStopbit2.Text, CbFlowcontrol2.Text);
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
                CbCOMPort2.Items.Clear();
                CbCOMPort2.Items.AddRange(SerialPort.GetPortNames());
            }
            catch { }
        }

        private void LblCOMPort_2_Click(object sender, EventArgs e)
        {
            try
            {
                //Populate the Combobox with SerialPorts on the System
                CbCOMPort1.Items.Clear();
                CbCOMPort1.Items.AddRange(SerialPort.GetPortNames());
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

            ClsReadWriteAppSetting.WriteAppSetting("COMPort", CbCOMPort1.Text.Trim());
            ClsReadWriteAppSetting.WriteAppSetting("Baudrate", CbBaudrate1.Text.Trim());
            ClsReadWriteAppSetting.WriteAppSetting("Databit", CbDatabit1.Text.Trim());
            ClsReadWriteAppSetting.WriteAppSetting("Paritybit", CbParitybit1.Text.Trim());
            ClsReadWriteAppSetting.WriteAppSetting("Stopbit", CbStopbit1.Text.Trim());
            ClsReadWriteAppSetting.WriteAppSetting("Flowcontrol", CbFlowcontrol1.Text.Trim());

            ClsReadWriteAppSetting.WriteAppSetting("COMPort2", CbCOMPort2.Text.Trim());
            ClsReadWriteAppSetting.WriteAppSetting("Baudrate2", CbBaudrate2.Text.Trim());
            ClsReadWriteAppSetting.WriteAppSetting("Databit2", CbDatabit2.Text.Trim());
            ClsReadWriteAppSetting.WriteAppSetting("Paritybit2", CbParitybit2.Text.Trim());
            ClsReadWriteAppSetting.WriteAppSetting("Stopbit2", CbStopbit2.Text.Trim());
            ClsReadWriteAppSetting.WriteAppSetting("Flowcontrol2", CbFlowcontrol2.Text.Trim());

            LblStatus.Text = "COM Port && Settings Done."; LblStatus.Update();
            LblStatus2.Text = "COM Port && Settings Done."; LblStatus2.Update();

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

                    comPort.Connect(CbCOMPort1.Text, CbBaudrate1.Text, CbDatabit1.Text, CbParitybit1.Text, CbStopbit1.Text, CbFlowcontrol1.Text);
                }
                else
                {
                    if (CbCOMPort1.Text.Trim().Length > 0)
                    {
                        //Initialize the event driven client
                        comPort = new ClsCOMPort();
                        //Initialize the events
                        comPort.onDataReceived += new ClsCOMPort.OnDataReceived(clientDataReceived);
                        comPort.onConnectionStatusChanged += new ClsCOMPort.OnConnectionStatusChanged(clientConnectionStatusChanged);
                        comPort.Connect(CbCOMPort1.Text, CbBaudrate1.Text, CbDatabit1.Text, CbParitybit1.Text, CbStopbit1.Text, CbFlowcontrol1.Text);
                    }
                }
            }
            catch { }
        }

        private void BtnReconnect2_Click(object sender, EventArgs e)
        {
            try
            {
                if (comPort2 != null)
                {
                    comPort2.Disconnect();

                    comPort2.Connect(CbCOMPort2.Text, CbBaudrate2.Text, CbDatabit2.Text, CbParitybit2.Text, CbStopbit2.Text, CbFlowcontrol2.Text);
                }
                else
                {
                    if (CbCOMPort2.Text.Trim().Length > 0)
                    {
                        //Initialize the event driven client
                        comPort2 = new ClsCOMPort();
                        //Initialize the events
                        //comPort2.onDataReceived += new ClsCOMPort.OnDataReceived(clientDataReceived2); // we only use COM2 for data sending.
                        comPort2.onConnectionStatusChanged += new ClsCOMPort.OnConnectionStatusChanged(clientConnectionStatusChanged2);
                        comPort2.Connect(CbCOMPort2.Text, CbBaudrate2.Text, CbDatabit2.Text, CbParitybit2.Text, CbStopbit2.Text, CbFlowcontrol2.Text);
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

                if (isConnected2)
                {
                    try
                    {
                        if (ChbxSuffixEnter.Checked == true)
                        {
                            receivedData += receivedData + "\r\n";
                        }

                        if (ChbxSuffixTab.Checked == true)
                        {
                            receivedData += receivedData + "\t";
                        }
                        comPort2.SendDataToCOMPort(receivedData);
                    }
                    catch { }
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

        private void AutoReconnectTimer2_Tick(object sender, EventArgs e)
        {
            AutoReconnectTimer2.Stop();
            LblStatus2.Text = "Reconnecting"; LblStatus2.Update();
            BtnReconnect2_Click(null, null);
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
                CbCOMPort1.Items.Clear();
                CbCOMPort1.Items.AddRange(SerialPort.GetPortNames());
            }
            catch { }
            CbCOMPort1.Text = ClsSoftwareInfo.COMPort;
            CbBaudrate1.Text = ClsSoftwareInfo.Baudrate;
            CbDatabit1.Text = ClsSoftwareInfo.Databit;
            CbStopbit1.Text = ClsSoftwareInfo.Stopbit;
            CbParitybit1.Text = ClsSoftwareInfo.Paritybit;
            CbFlowcontrol1.Text = ClsSoftwareInfo.Flowcontrol;

            try
            {
                //Populate the Combobox with SerialPorts on the System
                CbCOMPort2.Items.Clear();
                CbCOMPort2.Items.AddRange(SerialPort.GetPortNames());
            }
            catch { }
            CbCOMPort2.Text = ClsSoftwareInfo.COMPort2;
            CbBaudrate2.Text = ClsSoftwareInfo.Baudrate2;
            CbDatabit2.Text = ClsSoftwareInfo.Databit2;
            CbStopbit2.Text = ClsSoftwareInfo.Stopbit2;
            CbParitybit2.Text = ClsSoftwareInfo.Paritybit2;
            CbFlowcontrol2.Text = ClsSoftwareInfo.Flowcontrol2;
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

                    if (isConnected2)
                    {
                        try
                        {
                            if (ChbxSuffixEnter.Checked == true)
                            {
                                receivedData += receivedData + "\r\n";
                            }

                            if (ChbxSuffixTab.Checked == true)
                            {
                                receivedData += receivedData + "\t";
                            }
                            comPort2.SendDataToCOMPort(receivedData);
                        }
                        catch { }
                    }

                    receivedData = "";
                }
            }
        }


        void clientConnectionStatusChanged2(String status)
        {
            if (status == "Connected")
            {
                isConnected2 = true;

	    	    // sound not necessary for COM2
                //if (ChbxSound.Checked)
                //{
                //    try
                //    { SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\Windows Hardware Insert.wav"); simpleSound.Play(); }
                //    catch { }
                //}
                isAutoConnecting2 = false;
                LblStatus2.ForeColor = Color.FromArgb(0, 0, 192);
            }
            else
            {
                isConnected2 = false;
                LblStatus2.ForeColor = Color.OrangeRed;
            }

            //Check if this event was fired on a different thread, if it is then we must invoke it on the UI thread
            if (InvokeRequired)
            {
                try
                {
                    Invoke(new ClsCOMPort.OnConnectionStatusChanged(clientConnectionStatusChanged2), status);
                }
                catch { }
                return;
            }
            BtnReconnect2.Text = status;
            LblStatus2.Text = status;
            if (status == "Error" || status == "Disconnected")
            {
                if (isAutoConnecting2 == false)
                {
		            // sound not necessary for COM2
                    //if (ChbxSound.Checked)
                    //{
                        //try
                        //{ SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\tada.wav"); simpleSound.Play(); }
                        //catch { }
                    //}
                    isAutoConnecting2 = true;
                    AutoReconnectTimer2.Start();
                    isAutoConnecting2 = false;
                }
            }
        }

        // we dont want COM2 data, we only use it for sending data.
        /*
        void clientDataReceived2(String data)
        {
            //Again, check if this needs to be invoked in the UI thread
            if (InvokeRequired)
            {
                try
                {
                    Invoke(new ClsCOMPort.OnDataReceived(clientDataReceived2), data);
                }
                catch
                { }
                return;
            }
            //data = Regex.Replace(data, @"[^\u0000-\u007F]+", string.Empty);
            //data = System.Text.RegularExpressions.Regex.Replace(data, @"[^\u0000-\u007F\u0900-\u097f]", "");
            TbDataReceived.Text = data; TbDataReceived.Update();
            receivedData2 = data.Trim();
            
            if (receivedData2.Length > 0)
            {
				// sound not necessary for COM2
                //if (ChbxSound.Checked)
                //{
                //    try
                //    { SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\chimes.wav"); simpleSound.Play(); }
                //    catch { }
                //}
				
                if (ChBxReadContinue.Checked == true)
                {
                    //Regex rgx = new Regex(@"[^0-9\.]"); this is for weighing scale only.
                    //receivedData2 = rgx.Replace(receivedData2, ""); this is for weighing scale only.

                    //Clipboard.Clear();  // Always clear the clipboard first
                    //Clipboard.SetText(receivedData2);
                    //SendKeys.SendWait("^v");  // Paste //SendKeysWait.Send("^v");  // Paste

                    SendKeys.Send(receivedData2);
                    
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
                        comPort2.SendDataToCOMPort(ascii_str);
                    }

                    if (isConnected2)
                    {
                        try
                        {
                            if (ChbxSuffixEnter.Checked == true)
                            {
                                receivedData2 += receivedData2 + "\r\n";
                            }

                            if (ChbxSuffixTab.Checked == true)
                            {
                                receivedData2 += receivedData2 + "\t";
                            }
                            comPort2.SendDataToCOMPort(receivedData2);
                        }
                        catch { }
                    }

                    receivedData2 = "";
                }
            }
        }
        */

    }
}
