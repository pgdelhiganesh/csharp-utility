///////////////////////////////////////////PANEL SLIDING CODE//////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace g500_app0._1
{
    public partial class Form1 : Form
    {
        int panel_slider_size = 0;
        bool panel_slider_visible = false;
        public Form1()
        {
            InitializeComponent();
            panel_slider_size = panel_slider.Width;
            panel_slider_visible = false;
        }

        private void btn_slider_Click(object sender, EventArgs e)
        {
            timer_panel_slider.Start();
        }

        private void timer_panel_slider_Tick(object sender, EventArgs e)
        {
            if (panel_slider_visible == true)
            {
                panel_slider.Width = panel_slider.Width + 10;
                if (panel_slider.Width >= panel_slider_size)
                {
                    timer_panel_slider.Stop();
                    panel_slider_visible = false;
                    this.Refresh();
                    btn_slider.Text = "<";
                }
            }
            else
            {
                panel_slider.Width = panel_slider.Width - 10;
                if (panel_slider.Width <= 0)
                {
                    timer_panel_slider.Stop();
                    panel_slider_visible = true;
                    this.Refresh();
                    btn_slider.Text = ">";
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////