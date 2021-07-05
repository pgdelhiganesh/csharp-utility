namespace WinFrmApp
{
    partial class FrmEVHID
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
            this.AutoReconnectTimer = new System.Windows.Forms.Timer(this.components);
            this.TrayNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.ChbxSuffixEnter = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ChbxACK = new System.Windows.Forms.CheckBox();
            this.TbDataReceived = new System.Windows.Forms.TextBox();
            this.ChBxReadContinue = new System.Windows.Forms.CheckBox();
            this.BtnGetData = new System.Windows.Forms.Button();
            this.BtnReconnect = new System.Windows.Forms.Button();
            this.LblStatus = new System.Windows.Forms.Label();
            this.BtnSave = new System.Windows.Forms.Button();
            this.TbPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TbIPAddress = new System.Windows.Forms.TextBox();
            this.TbACkReturn = new System.Windows.Forms.TextBox();
            this.ChbxSound = new System.Windows.Forms.CheckBox();
            this.ChbxSuffixTab = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // AutoReconnectTimer
            // 
            this.AutoReconnectTimer.Interval = 2000;
            this.AutoReconnectTimer.Tick += new System.EventHandler(this.AutoReconnectTimer_Tick);
            // 
            // TrayNotifyIcon
            // 
            this.TrayNotifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.TrayNotifyIcon.BalloonTipText = "Running";
            this.TrayNotifyIcon.BalloonTipTitle = "Ethernet - Virtual HID";
            this.TrayNotifyIcon.Text = "Ethernet - Virtual HID";
            this.TrayNotifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TrayNotifyIcon_MouseDoubleClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(318, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 16);
            this.label6.TabIndex = 32;
            this.label6.Text = "Suffix";
            // 
            // ChbxSuffixEnter
            // 
            this.ChbxSuffixEnter.AutoSize = true;
            this.ChbxSuffixEnter.Checked = true;
            this.ChbxSuffixEnter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChbxSuffixEnter.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChbxSuffixEnter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.ChbxSuffixEnter.Location = new System.Drawing.Point(318, 104);
            this.ChbxSuffixEnter.Name = "ChbxSuffixEnter";
            this.ChbxSuffixEnter.Size = new System.Drawing.Size(55, 20);
            this.ChbxSuffixEnter.TabIndex = 31;
            this.ChbxSuffixEnter.Text = "Enter";
            this.ChbxSuffixEnter.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label5.Location = new System.Drawing.Point(41, 192);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(301, 17);
            this.label5.TabIndex = 30;
            this.label5.Text = "Allmark Device Integrations Pvt Ltd, Chennai.";
            // 
            // ChbxACK
            // 
            this.ChbxACK.AutoSize = true;
            this.ChbxACK.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChbxACK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.ChbxACK.Location = new System.Drawing.Point(318, 7);
            this.ChbxACK.Name = "ChbxACK";
            this.ChbxACK.Size = new System.Drawing.Size(50, 20);
            this.ChbxACK.TabIndex = 29;
            this.ChbxACK.Text = "ACK";
            this.ChbxACK.UseVisualStyleBackColor = true;
            // 
            // TbDataReceived
            // 
            this.TbDataReceived.BackColor = System.Drawing.Color.Navy;
            this.TbDataReceived.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbDataReceived.ForeColor = System.Drawing.Color.White;
            this.TbDataReceived.Location = new System.Drawing.Point(74, 30);
            this.TbDataReceived.Multiline = true;
            this.TbDataReceived.Name = "TbDataReceived";
            this.TbDataReceived.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TbDataReceived.Size = new System.Drawing.Size(307, 50);
            this.TbDataReceived.TabIndex = 26;
            this.TbDataReceived.Text = "No data...";
            // 
            // ChBxReadContinue
            // 
            this.ChBxReadContinue.AutoSize = true;
            this.ChBxReadContinue.Checked = true;
            this.ChBxReadContinue.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChBxReadContinue.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChBxReadContinue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.ChBxReadContinue.Location = new System.Drawing.Point(74, 6);
            this.ChBxReadContinue.Name = "ChBxReadContinue";
            this.ChBxReadContinue.Size = new System.Drawing.Size(126, 20);
            this.ChBxReadContinue.TabIndex = 25;
            this.ChBxReadContinue.Text = "Countineous Read";
            this.ChBxReadContinue.UseVisualStyleBackColor = true;
            // 
            // BtnGetData
            // 
            this.BtnGetData.BackColor = System.Drawing.Color.Navy;
            this.BtnGetData.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.BtnGetData.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            this.BtnGetData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGetData.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGetData.ForeColor = System.Drawing.Color.White;
            this.BtnGetData.Location = new System.Drawing.Point(8, 4);
            this.BtnGetData.Name = "BtnGetData";
            this.BtnGetData.Size = new System.Drawing.Size(60, 76);
            this.BtnGetData.TabIndex = 24;
            this.BtnGetData.Text = "Get Data";
            this.BtnGetData.UseVisualStyleBackColor = false;
            this.BtnGetData.Click += new System.EventHandler(this.BtnGetData_Click);
            // 
            // BtnReconnect
            // 
            this.BtnReconnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnReconnect.Location = new System.Drawing.Point(8, 129);
            this.BtnReconnect.Name = "BtnReconnect";
            this.BtnReconnect.Size = new System.Drawing.Size(190, 33);
            this.BtnReconnect.TabIndex = 23;
            this.BtnReconnect.Text = "Reconnect";
            this.BtnReconnect.UseVisualStyleBackColor = true;
            this.BtnReconnect.Click += new System.EventHandler(this.BtnReconnect_Click);
            // 
            // LblStatus
            // 
            this.LblStatus.AutoSize = true;
            this.LblStatus.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblStatus.ForeColor = System.Drawing.Color.Black;
            this.LblStatus.Location = new System.Drawing.Point(8, 163);
            this.LblStatus.Name = "LblStatus";
            this.LblStatus.Size = new System.Drawing.Size(135, 23);
            this.LblStatus.TabIndex = 22;
            this.LblStatus.Text = "Not Connected...";
            // 
            // BtnSave
            // 
            this.BtnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSave.Location = new System.Drawing.Point(204, 129);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(106, 33);
            this.BtnSave.TabIndex = 21;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // TbPort
            // 
            this.TbPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbPort.Location = new System.Drawing.Point(204, 103);
            this.TbPort.Name = "TbPort";
            this.TbPort.Size = new System.Drawing.Size(106, 22);
            this.TbPort.TabIndex = 20;
            this.TbPort.Text = "9004";
            this.TbPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbPort_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(204, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 16);
            this.label2.TabIndex = 19;
            this.label2.Text = "Server Port";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 18;
            this.label1.Text = "Server IP";
            // 
            // TbIPAddress
            // 
            this.TbIPAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbIPAddress.Location = new System.Drawing.Point(8, 103);
            this.TbIPAddress.Name = "TbIPAddress";
            this.TbIPAddress.Size = new System.Drawing.Size(190, 22);
            this.TbIPAddress.TabIndex = 17;
            this.TbIPAddress.Text = "192.168.100.100";
            this.TbIPAddress.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbIPAddress_KeyPress);
            // 
            // TbACkReturn
            // 
            this.TbACkReturn.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold);
            this.TbACkReturn.Location = new System.Drawing.Point(204, 4);
            this.TbACkReturn.Name = "TbACkReturn";
            this.TbACkReturn.Size = new System.Drawing.Size(106, 22);
            this.TbACkReturn.TabIndex = 33;
            // 
            // ChbxSound
            // 
            this.ChbxSound.AutoSize = true;
            this.ChbxSound.Checked = true;
            this.ChbxSound.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChbxSound.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChbxSound.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.ChbxSound.Location = new System.Drawing.Point(318, 163);
            this.ChbxSound.Name = "ChbxSound";
            this.ChbxSound.Size = new System.Drawing.Size(63, 20);
            this.ChbxSound.TabIndex = 34;
            this.ChbxSound.Text = "Sound";
            this.ChbxSound.UseVisualStyleBackColor = true;
            // 
            // ChbxSuffixTab
            // 
            this.ChbxSuffixTab.AutoSize = true;
            this.ChbxSuffixTab.Checked = true;
            this.ChbxSuffixTab.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChbxSuffixTab.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChbxSuffixTab.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.ChbxSuffixTab.Location = new System.Drawing.Point(318, 135);
            this.ChbxSuffixTab.Name = "ChbxSuffixTab";
            this.ChbxSuffixTab.Size = new System.Drawing.Size(48, 20);
            this.ChbxSuffixTab.TabIndex = 35;
            this.ChbxSuffixTab.Text = "TAB";
            this.ChbxSuffixTab.UseVisualStyleBackColor = true;
            // 
            // FrmEVHID
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 211);
            this.Controls.Add(this.ChbxSuffixTab);
            this.Controls.Add(this.ChbxSound);
            this.Controls.Add(this.TbACkReturn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ChbxSuffixEnter);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ChbxACK);
            this.Controls.Add(this.TbDataReceived);
            this.Controls.Add(this.BtnGetData);
            this.Controls.Add(this.BtnReconnect);
            this.Controls.Add(this.LblStatus);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.TbPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TbIPAddress);
            this.Controls.Add(this.ChBxReadContinue);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmEVHID";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ethernet_Virtual_HID";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmEVHID_FormClosing);
            this.Load += new System.EventHandler(this.FrmEVHID_Load);
            this.Resize += new System.EventHandler(this.FrmEVHID_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer AutoReconnectTimer;
        private System.Windows.Forms.NotifyIcon TrayNotifyIcon;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox ChbxSuffixEnter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox ChbxACK;
        private System.Windows.Forms.TextBox TbDataReceived;
        private System.Windows.Forms.CheckBox ChBxReadContinue;
        private System.Windows.Forms.Button BtnGetData;
        private System.Windows.Forms.Button BtnReconnect;
        private System.Windows.Forms.Label LblStatus;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.TextBox TbPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TbIPAddress;
        private System.Windows.Forms.TextBox TbACkReturn;
        private System.Windows.Forms.CheckBox ChbxSound;
        private System.Windows.Forms.CheckBox ChbxSuffixTab;
    }
}