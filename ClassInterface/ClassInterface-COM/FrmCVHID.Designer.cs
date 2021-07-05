namespace WinFrmApp
{
    partial class FrmCVHID
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
            this.components = new System.ComponentModel.Container();
            this.TrayNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.AutoReconnectTimer = new System.Windows.Forms.Timer(this.components);
            this.ChbxSuffixTab = new System.Windows.Forms.CheckBox();
            this.ChbxSound = new System.Windows.Forms.CheckBox();
            this.TbACkReturn = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ChbxSuffixEnter = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ChbxACK = new System.Windows.Forms.CheckBox();
            this.TbDataReceived = new System.Windows.Forms.TextBox();
            this.BtnGetData = new System.Windows.Forms.Button();
            this.BtnReconnect = new System.Windows.Forms.Button();
            this.LblStatus = new System.Windows.Forms.Label();
            this.BtnSave = new System.Windows.Forms.Button();
            this.ChBxReadContinue = new System.Windows.Forms.CheckBox();
            this.TabPageCOM2 = new System.Windows.Forms.TabControl();
            this.TabPageCOM1 = new System.Windows.Forms.TabPage();
            this.CbFlowcontrol1 = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.CbStopbit1 = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.CbParitybit1 = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.CbDatabit1 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.CbBaudrate1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CbCOMPort1 = new System.Windows.Forms.ComboBox();
            this.LblCOMPort_1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.CbFlowcontrol2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CbStopbit2 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CbParitybit2 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CbDatabit2 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.CbBaudrate2 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.LblStatus2 = new System.Windows.Forms.Label();
            this.BtnReconnect2 = new System.Windows.Forms.Button();
            this.CbCOMPort2 = new System.Windows.Forms.ComboBox();
            this.LblCOMPort_2 = new System.Windows.Forms.Label();
            this.AutoReconnectTimer2 = new System.Windows.Forms.Timer(this.components);
            this.TabPageCOM2.SuspendLayout();
            this.TabPageCOM1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // TrayNotifyIcon
            // 
            this.TrayNotifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.TrayNotifyIcon.BalloonTipText = "Running";
            this.TrayNotifyIcon.BalloonTipTitle = "COM - Virtual HID";
            this.TrayNotifyIcon.Text = "COM - Virtual HID";
            this.TrayNotifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TrayNotifyIcon_MouseDoubleClick);
            // 
            // AutoReconnectTimer
            // 
            this.AutoReconnectTimer.Interval = 2000;
            this.AutoReconnectTimer.Tick += new System.EventHandler(this.AutoReconnectTimer_Tick);
            // 
            // ChbxSuffixTab
            // 
            this.ChbxSuffixTab.AutoSize = true;
            this.ChbxSuffixTab.Checked = true;
            this.ChbxSuffixTab.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChbxSuffixTab.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChbxSuffixTab.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.ChbxSuffixTab.Location = new System.Drawing.Point(314, 171);
            this.ChbxSuffixTab.Name = "ChbxSuffixTab";
            this.ChbxSuffixTab.Size = new System.Drawing.Size(48, 20);
            this.ChbxSuffixTab.TabIndex = 52;
            this.ChbxSuffixTab.Text = "TAB";
            this.ChbxSuffixTab.UseVisualStyleBackColor = true;
            // 
            // ChbxSound
            // 
            this.ChbxSound.AutoSize = true;
            this.ChbxSound.Checked = true;
            this.ChbxSound.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChbxSound.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChbxSound.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.ChbxSound.Location = new System.Drawing.Point(314, 198);
            this.ChbxSound.Name = "ChbxSound";
            this.ChbxSound.Size = new System.Drawing.Size(63, 20);
            this.ChbxSound.TabIndex = 51;
            this.ChbxSound.Text = "Sound";
            this.ChbxSound.UseVisualStyleBackColor = true;
            // 
            // TbACkReturn
            // 
            this.TbACkReturn.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold);
            this.TbACkReturn.Location = new System.Drawing.Point(202, 3);
            this.TbACkReturn.Name = "TbACkReturn";
            this.TbACkReturn.Size = new System.Drawing.Size(106, 22);
            this.TbACkReturn.TabIndex = 50;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(314, 121);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 16);
            this.label6.TabIndex = 49;
            this.label6.Text = "Suffix";
            // 
            // ChbxSuffixEnter
            // 
            this.ChbxSuffixEnter.AutoSize = true;
            this.ChbxSuffixEnter.Checked = true;
            this.ChbxSuffixEnter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChbxSuffixEnter.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChbxSuffixEnter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.ChbxSuffixEnter.Location = new System.Drawing.Point(314, 144);
            this.ChbxSuffixEnter.Name = "ChbxSuffixEnter";
            this.ChbxSuffixEnter.Size = new System.Drawing.Size(55, 20);
            this.ChbxSuffixEnter.TabIndex = 48;
            this.ChbxSuffixEnter.Text = "Enter";
            this.ChbxSuffixEnter.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label5.Location = new System.Drawing.Point(39, 273);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(301, 17);
            this.label5.TabIndex = 47;
            this.label5.Text = "Allmark Device Integrations Pvt Ltd, Chennai.";
            // 
            // ChbxACK
            // 
            this.ChbxACK.AutoSize = true;
            this.ChbxACK.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChbxACK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.ChbxACK.Location = new System.Drawing.Point(316, 6);
            this.ChbxACK.Name = "ChbxACK";
            this.ChbxACK.Size = new System.Drawing.Size(50, 20);
            this.ChbxACK.TabIndex = 46;
            this.ChbxACK.Text = "ACK";
            this.ChbxACK.UseVisualStyleBackColor = true;
            // 
            // TbDataReceived
            // 
            this.TbDataReceived.BackColor = System.Drawing.Color.Navy;
            this.TbDataReceived.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbDataReceived.ForeColor = System.Drawing.Color.White;
            this.TbDataReceived.Location = new System.Drawing.Point(72, 29);
            this.TbDataReceived.Multiline = true;
            this.TbDataReceived.Name = "TbDataReceived";
            this.TbDataReceived.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TbDataReceived.Size = new System.Drawing.Size(307, 50);
            this.TbDataReceived.TabIndex = 45;
            this.TbDataReceived.Text = "No data...";
            // 
            // BtnGetData
            // 
            this.BtnGetData.BackColor = System.Drawing.Color.Navy;
            this.BtnGetData.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.BtnGetData.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            this.BtnGetData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGetData.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGetData.ForeColor = System.Drawing.Color.White;
            this.BtnGetData.Location = new System.Drawing.Point(6, 3);
            this.BtnGetData.Name = "BtnGetData";
            this.BtnGetData.Size = new System.Drawing.Size(60, 76);
            this.BtnGetData.TabIndex = 43;
            this.BtnGetData.Text = "Get Data";
            this.BtnGetData.UseVisualStyleBackColor = false;
            this.BtnGetData.Click += new System.EventHandler(this.BtnGetData_Click);
            // 
            // BtnReconnect
            // 
            this.BtnReconnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnReconnect.Location = new System.Drawing.Point(35, 98);
            this.BtnReconnect.Name = "BtnReconnect";
            this.BtnReconnect.Size = new System.Drawing.Size(227, 33);
            this.BtnReconnect.TabIndex = 42;
            this.BtnReconnect.Text = "Reconnect";
            this.BtnReconnect.UseVisualStyleBackColor = true;
            this.BtnReconnect.Click += new System.EventHandler(this.BtnReconnect_Click);
            // 
            // LblStatus
            // 
            this.LblStatus.AutoSize = true;
            this.LblStatus.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblStatus.ForeColor = System.Drawing.Color.Black;
            this.LblStatus.Location = new System.Drawing.Point(34, 130);
            this.LblStatus.Name = "LblStatus";
            this.LblStatus.Size = new System.Drawing.Size(135, 23);
            this.LblStatus.TabIndex = 41;
            this.LblStatus.Text = "Not Connected...";
            // 
            // BtnSave
            // 
            this.BtnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSave.Location = new System.Drawing.Point(314, 225);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(64, 33);
            this.BtnSave.TabIndex = 40;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // ChBxReadContinue
            // 
            this.ChBxReadContinue.AutoSize = true;
            this.ChBxReadContinue.Checked = true;
            this.ChBxReadContinue.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChBxReadContinue.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChBxReadContinue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.ChBxReadContinue.Location = new System.Drawing.Point(72, 5);
            this.ChBxReadContinue.Name = "ChBxReadContinue";
            this.ChBxReadContinue.Size = new System.Drawing.Size(126, 20);
            this.ChBxReadContinue.TabIndex = 44;
            this.ChBxReadContinue.Text = "Countineous Read";
            this.ChBxReadContinue.UseVisualStyleBackColor = true;
            // 
            // TabPageCOM2
            // 
            this.TabPageCOM2.Controls.Add(this.TabPageCOM1);
            this.TabPageCOM2.Controls.Add(this.tabPage2);
            this.TabPageCOM2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabPageCOM2.Location = new System.Drawing.Point(6, 83);
            this.TabPageCOM2.Name = "TabPageCOM2";
            this.TabPageCOM2.SelectedIndex = 0;
            this.TabPageCOM2.Size = new System.Drawing.Size(302, 188);
            this.TabPageCOM2.TabIndex = 53;
            // 
            // TabPageCOM1
            // 
            this.TabPageCOM1.BackColor = System.Drawing.SystemColors.Control;
            this.TabPageCOM1.Controls.Add(this.CbFlowcontrol1);
            this.TabPageCOM1.Controls.Add(this.label18);
            this.TabPageCOM1.Controls.Add(this.CbStopbit1);
            this.TabPageCOM1.Controls.Add(this.label15);
            this.TabPageCOM1.Controls.Add(this.CbParitybit1);
            this.TabPageCOM1.Controls.Add(this.label12);
            this.TabPageCOM1.Controls.Add(this.CbDatabit1);
            this.TabPageCOM1.Controls.Add(this.label9);
            this.TabPageCOM1.Controls.Add(this.CbBaudrate1);
            this.TabPageCOM1.Controls.Add(this.label1);
            this.TabPageCOM1.Controls.Add(this.LblStatus);
            this.TabPageCOM1.Controls.Add(this.BtnReconnect);
            this.TabPageCOM1.Controls.Add(this.CbCOMPort1);
            this.TabPageCOM1.Controls.Add(this.LblCOMPort_1);
            this.TabPageCOM1.Location = new System.Drawing.Point(4, 29);
            this.TabPageCOM1.Name = "TabPageCOM1";
            this.TabPageCOM1.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageCOM1.Size = new System.Drawing.Size(294, 155);
            this.TabPageCOM1.TabIndex = 0;
            this.TabPageCOM1.Text = "Input COM";
            // 
            // CbFlowcontrol1
            // 
            this.CbFlowcontrol1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CbFlowcontrol1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CbFlowcontrol1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CbFlowcontrol1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbFlowcontrol1.FormattingEnabled = true;
            this.CbFlowcontrol1.Items.AddRange(new object[] {
            "None",
            "RTS",
            "Hardware",
            "Xon/Xoff"});
            this.CbFlowcontrol1.Location = new System.Drawing.Point(208, 23);
            this.CbFlowcontrol1.Name = "CbFlowcontrol1";
            this.CbFlowcontrol1.Size = new System.Drawing.Size(80, 24);
            this.CbFlowcontrol1.TabIndex = 185;
            // 
            // label18
            // 
            this.label18.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label18.Location = new System.Drawing.Point(208, 4);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(79, 16);
            this.label18.TabIndex = 184;
            this.label18.Text = "Flow control";
            // 
            // CbStopbit1
            // 
            this.CbStopbit1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CbStopbit1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CbStopbit1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CbStopbit1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbStopbit1.FormattingEnabled = true;
            this.CbStopbit1.Items.AddRange(new object[] {
            "1",
            "1.5",
            "2",
            "None"});
            this.CbStopbit1.Location = new System.Drawing.Point(208, 70);
            this.CbStopbit1.Name = "CbStopbit1";
            this.CbStopbit1.Size = new System.Drawing.Size(80, 24);
            this.CbStopbit1.TabIndex = 183;
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label15.Location = new System.Drawing.Point(208, 51);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 16);
            this.label15.TabIndex = 182;
            this.label15.Text = "Stop bit";
            // 
            // CbParitybit1
            // 
            this.CbParitybit1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CbParitybit1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CbParitybit1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CbParitybit1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbParitybit1.FormattingEnabled = true;
            this.CbParitybit1.Items.AddRange(new object[] {
            "None",
            "Even",
            "Odd",
            "Mark",
            "Space"});
            this.CbParitybit1.Location = new System.Drawing.Point(108, 69);
            this.CbParitybit1.Name = "CbParitybit1";
            this.CbParitybit1.Size = new System.Drawing.Size(80, 24);
            this.CbParitybit1.TabIndex = 181;
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label12.Location = new System.Drawing.Point(108, 51);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 16);
            this.label12.TabIndex = 180;
            this.label12.Text = "Parity bit";
            // 
            // CbDatabit1
            // 
            this.CbDatabit1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CbDatabit1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CbDatabit1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CbDatabit1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbDatabit1.FormattingEnabled = true;
            this.CbDatabit1.Items.AddRange(new object[] {
            "8",
            "7",
            "6",
            "5",
            "4"});
            this.CbDatabit1.Location = new System.Drawing.Point(6, 70);
            this.CbDatabit1.Name = "CbDatabit1";
            this.CbDatabit1.Size = new System.Drawing.Size(80, 24);
            this.CbDatabit1.TabIndex = 179;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label9.Location = new System.Drawing.Point(6, 51);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 16);
            this.label9.TabIndex = 178;
            this.label9.Text = "Data bit";
            // 
            // CbBaudrate1
            // 
            this.CbBaudrate1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CbBaudrate1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CbBaudrate1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CbBaudrate1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbBaudrate1.FormattingEnabled = true;
            this.CbBaudrate1.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200",
            "230400"});
            this.CbBaudrate1.Location = new System.Drawing.Point(108, 23);
            this.CbBaudrate1.Name = "CbBaudrate1";
            this.CbBaudrate1.Size = new System.Drawing.Size(80, 24);
            this.CbBaudrate1.TabIndex = 177;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(108, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 16);
            this.label1.TabIndex = 176;
            this.label1.Text = "Baud rate";
            // 
            // CbCOMPort1
            // 
            this.CbCOMPort1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CbCOMPort1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CbCOMPort1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CbCOMPort1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbCOMPort1.FormattingEnabled = true;
            this.CbCOMPort1.Location = new System.Drawing.Point(6, 23);
            this.CbCOMPort1.Name = "CbCOMPort1";
            this.CbCOMPort1.Size = new System.Drawing.Size(80, 24);
            this.CbCOMPort1.TabIndex = 175;
            // 
            // LblCOMPort_1
            // 
            this.LblCOMPort_1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LblCOMPort_1.AutoSize = true;
            this.LblCOMPort_1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblCOMPort_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCOMPort_1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.LblCOMPort_1.Location = new System.Drawing.Point(6, 4);
            this.LblCOMPort_1.Name = "LblCOMPort_1";
            this.LblCOMPort_1.Size = new System.Drawing.Size(79, 16);
            this.LblCOMPort_1.TabIndex = 174;
            this.LblCOMPort_1.Text = "COM Port_1";
            this.LblCOMPort_1.Click += new System.EventHandler(this.LblCOMPort_1_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.CbFlowcontrol2);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.CbStopbit2);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.CbParitybit2);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.CbDatabit2);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.CbBaudrate2);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.LblStatus2);
            this.tabPage2.Controls.Add(this.BtnReconnect2);
            this.tabPage2.Controls.Add(this.CbCOMPort2);
            this.tabPage2.Controls.Add(this.LblCOMPort_2);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(294, 155);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Output COM";
            // 
            // CbFlowcontrol2
            // 
            this.CbFlowcontrol2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CbFlowcontrol2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CbFlowcontrol2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CbFlowcontrol2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbFlowcontrol2.FormattingEnabled = true;
            this.CbFlowcontrol2.Items.AddRange(new object[] {
            "None",
            "RTS",
            "Hardware",
            "Xon/Xoff"});
            this.CbFlowcontrol2.Location = new System.Drawing.Point(208, 23);
            this.CbFlowcontrol2.Name = "CbFlowcontrol2";
            this.CbFlowcontrol2.Size = new System.Drawing.Size(80, 24);
            this.CbFlowcontrol2.TabIndex = 199;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label2.Location = new System.Drawing.Point(208, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 16);
            this.label2.TabIndex = 198;
            this.label2.Text = "Flow control";
            // 
            // CbStopbit2
            // 
            this.CbStopbit2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CbStopbit2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CbStopbit2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CbStopbit2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbStopbit2.FormattingEnabled = true;
            this.CbStopbit2.Items.AddRange(new object[] {
            "1",
            "1.5",
            "2",
            "None"});
            this.CbStopbit2.Location = new System.Drawing.Point(208, 70);
            this.CbStopbit2.Name = "CbStopbit2";
            this.CbStopbit2.Size = new System.Drawing.Size(80, 24);
            this.CbStopbit2.TabIndex = 197;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label3.Location = new System.Drawing.Point(208, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 16);
            this.label3.TabIndex = 196;
            this.label3.Text = "Stop bit";
            // 
            // CbParitybit2
            // 
            this.CbParitybit2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CbParitybit2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CbParitybit2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CbParitybit2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbParitybit2.FormattingEnabled = true;
            this.CbParitybit2.Items.AddRange(new object[] {
            "None",
            "Even",
            "Odd",
            "Mark",
            "Space"});
            this.CbParitybit2.Location = new System.Drawing.Point(108, 69);
            this.CbParitybit2.Name = "CbParitybit2";
            this.CbParitybit2.Size = new System.Drawing.Size(80, 24);
            this.CbParitybit2.TabIndex = 195;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label4.Location = new System.Drawing.Point(108, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 16);
            this.label4.TabIndex = 194;
            this.label4.Text = "Parity bit";
            // 
            // CbDatabit2
            // 
            this.CbDatabit2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CbDatabit2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CbDatabit2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CbDatabit2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbDatabit2.FormattingEnabled = true;
            this.CbDatabit2.Items.AddRange(new object[] {
            "8",
            "7",
            "6",
            "5",
            "4"});
            this.CbDatabit2.Location = new System.Drawing.Point(6, 70);
            this.CbDatabit2.Name = "CbDatabit2";
            this.CbDatabit2.Size = new System.Drawing.Size(80, 24);
            this.CbDatabit2.TabIndex = 193;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label7.Location = new System.Drawing.Point(6, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 16);
            this.label7.TabIndex = 192;
            this.label7.Text = "Data bit";
            // 
            // CbBaudrate2
            // 
            this.CbBaudrate2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CbBaudrate2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CbBaudrate2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CbBaudrate2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbBaudrate2.FormattingEnabled = true;
            this.CbBaudrate2.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200",
            "230400"});
            this.CbBaudrate2.Location = new System.Drawing.Point(108, 23);
            this.CbBaudrate2.Name = "CbBaudrate2";
            this.CbBaudrate2.Size = new System.Drawing.Size(80, 24);
            this.CbBaudrate2.TabIndex = 191;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label8.Location = new System.Drawing.Point(108, 4);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 16);
            this.label8.TabIndex = 190;
            this.label8.Text = "Baud rate";
            // 
            // LblStatus2
            // 
            this.LblStatus2.AutoSize = true;
            this.LblStatus2.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblStatus2.ForeColor = System.Drawing.Color.Black;
            this.LblStatus2.Location = new System.Drawing.Point(34, 130);
            this.LblStatus2.Name = "LblStatus2";
            this.LblStatus2.Size = new System.Drawing.Size(135, 23);
            this.LblStatus2.TabIndex = 186;
            this.LblStatus2.Text = "Not Connected...";
            // 
            // BtnReconnect2
            // 
            this.BtnReconnect2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnReconnect2.Location = new System.Drawing.Point(35, 98);
            this.BtnReconnect2.Name = "BtnReconnect2";
            this.BtnReconnect2.Size = new System.Drawing.Size(227, 33);
            this.BtnReconnect2.TabIndex = 187;
            this.BtnReconnect2.Text = "Reconnect";
            this.BtnReconnect2.UseVisualStyleBackColor = true;
            this.BtnReconnect2.Click += new System.EventHandler(this.BtnReconnect2_Click);
            // 
            // CbCOMPort2
            // 
            this.CbCOMPort2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CbCOMPort2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CbCOMPort2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CbCOMPort2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbCOMPort2.FormattingEnabled = true;
            this.CbCOMPort2.Location = new System.Drawing.Point(6, 23);
            this.CbCOMPort2.Name = "CbCOMPort2";
            this.CbCOMPort2.Size = new System.Drawing.Size(80, 24);
            this.CbCOMPort2.TabIndex = 189;
            // 
            // LblCOMPort_2
            // 
            this.LblCOMPort_2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LblCOMPort_2.AutoSize = true;
            this.LblCOMPort_2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblCOMPort_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCOMPort_2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.LblCOMPort_2.Location = new System.Drawing.Point(6, 4);
            this.LblCOMPort_2.Name = "LblCOMPort_2";
            this.LblCOMPort_2.Size = new System.Drawing.Size(79, 16);
            this.LblCOMPort_2.TabIndex = 188;
            this.LblCOMPort_2.Text = "COM Port_2";
            this.LblCOMPort_2.Click += new System.EventHandler(this.LblCOMPort_2_Click);
            // 
            // AutoReconnectTimer2
            // 
            this.AutoReconnectTimer2.Interval = 2000;
            this.AutoReconnectTimer2.Tick += new System.EventHandler(this.AutoReconnectTimer2_Tick);
            // 
            // FrmCVHID
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 293);
            this.Controls.Add(this.TabPageCOM2);
            this.Controls.Add(this.ChbxSuffixTab);
            this.Controls.Add(this.ChbxSound);
            this.Controls.Add(this.TbACkReturn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ChbxSuffixEnter);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ChbxACK);
            this.Controls.Add(this.TbDataReceived);
            this.Controls.Add(this.BtnGetData);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.ChBxReadContinue);
            this.Name = "FrmCVHID";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "COM_Virtual_HID";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCVHID_FormClosing);
            this.Load += new System.EventHandler(this.FrmCVHID_Load);
            this.Resize += new System.EventHandler(this.FrmCVHID_Resize);
            this.TabPageCOM2.ResumeLayout(false);
            this.TabPageCOM1.ResumeLayout(false);
            this.TabPageCOM1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon TrayNotifyIcon;
        private System.Windows.Forms.Timer AutoReconnectTimer;
        private System.Windows.Forms.CheckBox ChbxSuffixTab;
        private System.Windows.Forms.CheckBox ChbxSound;
        private System.Windows.Forms.TextBox TbACkReturn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox ChbxSuffixEnter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox ChbxACK;
        private System.Windows.Forms.TextBox TbDataReceived;
        private System.Windows.Forms.Button BtnGetData;
        private System.Windows.Forms.Button BtnReconnect;
        private System.Windows.Forms.Label LblStatus;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.CheckBox ChBxReadContinue;
        private System.Windows.Forms.TabControl TabPageCOM2;
        private System.Windows.Forms.TabPage TabPageCOM1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox CbFlowcontrol1;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox CbStopbit1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox CbParitybit1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox CbDatabit1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox CbBaudrate1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CbCOMPort1;
        private System.Windows.Forms.Label LblCOMPort_1;
        private System.Windows.Forms.ComboBox CbFlowcontrol2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CbStopbit2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CbParitybit2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CbDatabit2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox CbBaudrate2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label LblStatus2;
        private System.Windows.Forms.Button BtnReconnect2;
        private System.Windows.Forms.ComboBox CbCOMPort2;
        private System.Windows.Forms.Label LblCOMPort_2;
        private System.Windows.Forms.Timer AutoReconnectTimer2;
    }
}