using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Borderlessmovetest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        private const int cGrip = 16;
        private const int cCaption = 32;

        protected override void WndProc(ref Message m)
        {
            //switch (m.Msg)
            //{
            //    case 0x84:
            //        base.WndProc(ref m);
            //        if ((int)m.Result == 0x1)
            //            m.Result = (IntPtr)0x2;
            //        return;
            //}

            if (m.Msg == 0x84)
            {
                Point point = new Point(m.LParam.ToInt32());
                point = this.PointToClient(point);
                if (point.Y < cCaption)
                {
                    m.Result = (IntPtr)2;
                    return;
                }
                if (point.X >= this.ClientSize.Width - cGrip && point.Y >= this.ClientSize.Height - cGrip)
                {
                    m.Result = (IntPtr)17;
                    return;
                }

                base.WndProc(ref m);
                if ((int)m.Result == 0x1)
                    m.Result = (IntPtr)0x2;
                return;
            }

            base.WndProc(ref m);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
