using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace WinFrmApp
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

            this.Text = "Ethernet_Virtual_HID " + " V " + ClsSoftwareInfo.Product_Version;

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
            if (receivedData.Length > 0)
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
                        System.Threading.Thread.Sleep(10);
                        if (ChbxSuffixEnter.Checked == true)
                        {
                            SendKeys.Send("{ENTER}");
                        }
                        System.Threading.Thread.Sleep(10);
                        if (ChbxSuffixTab.Checked == true)
                        {
                            SendKeys.Send("{TAB}");
                        }

                        if (ChbxACK.Checked == true)
                        {
                            System.Threading.Thread.Sleep(10);
                            //char character7 = (char)7;
                            //string ascii_str = character7.ToString();
                            //string ascii_str = ""; // BEL Symbol
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
