using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DNSClsLoadSoftwareDependencies;
using DNSClsPrinter;
using DNSClsReadWriteAppConfig;
using DNSClsUtility;

namespace WinFrmApp.ClassLabelPrint
{
    public partial class FrmLabelPrintMandoLabel : Form
    {
        #region basic code
        #region move borderless form
        //This gives us the ability to drag the borderless form to a new location
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        #endregion borderless form
        public FrmLabelPrintMandoLabel()
        {
            InitializeComponent();
        }

        private void FrmLabelPrintAvinashTagLabel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void PanelTop_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void BtnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnMaximizeForm_Click(object sender, EventArgs e)
        {
            WindowState = WindowState == FormWindowState.Maximized
             ? FormWindowState.Normal
             : FormWindowState.Maximized;
        }

        private void BtnMinimizeForm_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion basic code

        private string LabelPrinterName = "";
        private string LabelDesignTemplateText = "";
        private string LabelDesignTemplateAcross = "1";
        int ButtonPressCallCount = 0;
        private void FrmLabelPrintAvinashTagLabel_Load(object sender, EventArgs e)
        {
            // Watch for keyboard activity
            KeyboardListener.s_KeyEventHandler += new EventHandler(KeyboardListener_s_KeyEventHandler);

            LoadDisplay();
        }

        private void KeyboardListener_s_KeyEventHandler(object sender, EventArgs e)
        {
            KeyboardListener.UniversalKeyEventArgs eventArgs = (KeyboardListener.UniversalKeyEventArgs)e;
            string tmp = string.Format("Key = {0}  Msg = {1}  Text = {2}", eventArgs.m_Key, eventArgs.m_Msg, eventArgs.KeyData);

            if (eventArgs.m_Key == 145 && eventArgs.KeyData.ToString() == "Scroll")
            {
                CallPrintLabel();
            }
            // 256 : key down    257 : key up
            //if (eventArgs.m_Msg == 256)
            //{
            //    this.BackColor = Color.Red;
            //}
            //else
            //{
            //    this.BackColor = Color.Green;
            //}
        }

        private void CallPrintLabel()
        {
            ButtonPressCallCount++; //every two count button pressed and released
            if (ButtonPressCallCount > 3)
            {
                ButtonPressCallCount = 0;
                this.BackColor = Color.White;
                PrintLabel();
            }
            else
            {
                this.BackColor = Color.Green;
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadDisplay();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            DataClear();
        }

        private void TbFromSerialNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TbNoOfPrint_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            PrintLabel();
        }

        private void LoadDisplay()
        {
            LabelPrinterName = ClsLoadSoftwareDependencies.LabelPrinterName1;
            LabelDesignTemplateText = ClsUtility.LoadPRNFile("MandoLabel.txt");
            //LabelDesignTemplateAcross = ClsLoadSoftwareDependencies.PRN1LabelAcross;

            LblPrintingStatus.Text = "Printing Status...";
            DataClear();

            TbLeftPartNumber.Text = ClsReadWriteAppSetting.ReadAppSetting("LHPart");
            TbLeftCode.Text = ClsReadWriteAppSetting.ReadAppSetting("LHCode");
            TbRightPartNumber.Text = ClsReadWriteAppSetting.ReadAppSetting("RHPart");
            TbRightCode.Text = ClsReadWriteAppSetting.ReadAppSetting("RHCode");
        }

        private void DataClear()
        {
            TbNoOfPrint.Text = "1";
            TbLeftPartNumber.Text = "";
            TbRightPartNumber.Text = "";
            TbLeftCode.Text = "";
            TbRightCode.Text = "";
            TbLeftPartNumber.Focus();
        }

        private bool FieldValidate()
        {
            bool ret_val = true;

            if (RbtnLeft.Checked)
            {
                if (TbLeftPartNumber.Text.Length < 1)
                {
                    TbLeftPartNumber.Focus();
                    ret_val = false;
                    return ret_val;
                }
            }
            else if (RbtnRight.Checked)
            {
                if (TbRightPartNumber.Text.Length < 1)
                {
                    TbRightPartNumber.Focus();
                    ret_val = false;
                    return ret_val;
                }
            }
            else
            {
                RbtnLeft.BackColor = Color.OrangeRed;
                RbtnRight.BackColor = Color.OrangeRed;
                RbtnLeft.Update(); RbtnRight.Update(); System.Threading.Thread.Sleep(75);
                RbtnLeft.BackColor = Color.White;
                RbtnRight.BackColor = Color.White;
                RbtnLeft.Update(); RbtnRight.Update(); System.Threading.Thread.Sleep(75);
                RbtnLeft.BackColor = Color.OrangeRed;
                RbtnRight.BackColor = Color.OrangeRed;
                RbtnLeft.Update(); RbtnRight.Update(); System.Threading.Thread.Sleep(75);
                RbtnLeft.BackColor = Color.White;
                RbtnRight.BackColor = Color.White;
                RbtnLeft.Update(); RbtnRight.Update(); System.Threading.Thread.Sleep(75);
                RbtnLeft.BackColor = Color.OrangeRed;
                RbtnRight.BackColor = Color.OrangeRed;
                RbtnLeft.Update(); RbtnRight.Update(); System.Threading.Thread.Sleep(75);
                RbtnLeft.BackColor = Color.White;
                RbtnRight.BackColor = Color.White;
                RbtnLeft.Update(); RbtnRight.Update(); System.Threading.Thread.Sleep(75);
                ret_val = false;
                return ret_val;
            }

            if (TbNoOfPrint.Text.Length <= 0)
            {
                TbNoOfPrint.Focus();
                ret_val = false;
                return ret_val;
            }
            return ret_val;
        }

        private void PrintLabel()
        {
            if (FieldValidate())
            {
                if (TbNoOfPrint.Text.Length > 0)
                {
                    int noofprint = 0;
                    try
                    { noofprint = Convert.ToInt32(TbNoOfPrint.Text); }
                    catch { noofprint = 0; }
                    if (noofprint > 0)
                    {
                        int label_across = 0;
                        try
                        { label_across = Convert.ToInt32(LabelDesignTemplateAcross); }
                        catch { label_across = 0; }
                        if (label_across > 0)
                        {
                            int copies = 0;
                            try
                            {
                                if ((noofprint % label_across) > 0)
                                {
                                    copies = noofprint / label_across;
                                    copies = copies + 1;
                                }
                                else
                                {
                                    copies = noofprint / label_across;
                                }
                            }
                            catch { copies = 0; }
                            if (copies > 0)
                            {

                                for (int i = 1; i <= copies; i++)
                                {
                                    string LabelDesignTemplateTextChanged = "";
                                    if (RbtnLeft.Checked)
                                    {
                                        LabelDesignTemplateTextChanged = LabelDesignTemplateText.Replace("@partnumber@", TbLeftPartNumber.Text);
                                        LabelDesignTemplateTextChanged = LabelDesignTemplateTextChanged.Replace("@code@", TbLeftCode.Text);
                                    }
                                    else
                                    {
                                        LabelDesignTemplateTextChanged = LabelDesignTemplateText.Replace("@partnumber@", TbRightPartNumber.Text);
                                        LabelDesignTemplateTextChanged = LabelDesignTemplateTextChanged.Replace("@code@", TbRightCode.Text);
                                    }
                                    
                                    if (ClsPrinter.SendDataToPrinter(LabelPrinterName, LabelDesignTemplateTextChanged) == 1)
                                    {
                                        LblPrintingStatus.Text = "Printing " + i.ToString() + " Done";
                                        LblPrintingStatus.Update();
                                        System.Threading.Thread.Sleep(100);
                                    }
                                    else
                                    {
                                        LblPrintingStatus.Text = "Printing " + i.ToString() + " Fail";
                                        LblPrintingStatus.Update();
                                        System.Threading.Thread.Sleep(100);
                                    }
                                }
                                //DataClear();
                            }
                            else
                            {
                                MessageBox.Show("Cannot calculate number of label copies to print.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please Check Label Accross Value in PRN Setting.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                    {
                        TbNoOfPrint.Text = "";
                        TbNoOfPrint.BackColor = Color.Red; TbNoOfPrint.Update(); System.Threading.Thread.Sleep(75);
                        TbNoOfPrint.BackColor = Color.White; TbNoOfPrint.Update(); System.Threading.Thread.Sleep(75);
                        TbNoOfPrint.BackColor = Color.Red; TbNoOfPrint.Update(); System.Threading.Thread.Sleep(75);
                        TbNoOfPrint.BackColor = Color.White; TbNoOfPrint.Update(); System.Threading.Thread.Sleep(75);
                        TbNoOfPrint.BackColor = Color.Red; TbNoOfPrint.Update(); System.Threading.Thread.Sleep(75);
                        TbNoOfPrint.BackColor = Color.White;
                        TbNoOfPrint.Focus();
                    }
                }
                else
                {
                    TbNoOfPrint.Text = "";
                    TbNoOfPrint.BackColor = Color.Red; TbNoOfPrint.Update(); System.Threading.Thread.Sleep(75);
                    TbNoOfPrint.BackColor = Color.White; TbNoOfPrint.Update(); System.Threading.Thread.Sleep(75);
                    TbNoOfPrint.BackColor = Color.Red; TbNoOfPrint.Update(); System.Threading.Thread.Sleep(75);
                    TbNoOfPrint.BackColor = Color.White; TbNoOfPrint.Update(); System.Threading.Thread.Sleep(75);
                    TbNoOfPrint.BackColor = Color.Red; TbNoOfPrint.Update(); System.Threading.Thread.Sleep(75);
                    TbNoOfPrint.BackColor = Color.White;
                    TbNoOfPrint.Focus();
                }
            }
        }

        private void RbtnLeft_CheckedChanged(object sender, EventArgs e)
        {
            if (RbtnLeft.Checked)
            {
                RbtnRight.Checked = false;

                GbLeft.BackColor = Color.LightGray;
                GbRight.BackColor = Color.White;

                RbtnLeft.BackColor = Color.DarkViolet;
                RbtnLeft.ForeColor = Color.White;
                RbtnRight.BackColor = Color.White;
                RbtnRight.ForeColor = Color.Black;
            }
            //else
            //{
            //    GbLeft.BackColor = Color.White;
            //    GbRight.BackColor = Color.LightGray;

            //    RbtnLeft.BackColor = Color.White;
            //    RbtnLeft.ForeColor = Color.Black;
            //    RbtnRight.BackColor = Color.DarkViolet;
            //    RbtnRight.ForeColor = Color.White;
            //}
        }

        private void RbtnRight_CheckedChanged(object sender, EventArgs e)
        {
            if (RbtnRight.Checked)
            {
                RbtnLeft.Checked = false;

                GbLeft.BackColor = Color.White;
                GbRight.BackColor = Color.LightGray;

                RbtnLeft.BackColor = Color.White;
                RbtnLeft.ForeColor = Color.Black;
                RbtnRight.BackColor = Color.DarkViolet;
                RbtnRight.ForeColor = Color.White;
            }
            //else
            //{
            //    GbLeft.BackColor = Color.White;
            //    GbRight.BackColor = Color.LightGray;

            //    RbtnLeft.BackColor = Color.DarkViolet;
            //    RbtnLeft.ForeColor = Color.White;
            //    RbtnRight.BackColor = Color.White;
            //    RbtnRight.ForeColor = Color.Black;
            //}
        }

        private void PicBoxLogo_Click(object sender, EventArgs e)
        {
            ClsReadWriteAppSetting.WriteAppSetting("LHPart", TbLeftPartNumber.Text);
            ClsReadWriteAppSetting.WriteAppSetting("LHCode", TbLeftCode.Text);
            ClsReadWriteAppSetting.WriteAppSetting("RHPart", TbRightPartNumber.Text);
            ClsReadWriteAppSetting.WriteAppSetting("RHCode", TbRightCode.Text);

            MessageBox.Show("Save Success.");
        }
    }
}
