using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HiPiaoTerminal.ConfigModel;

namespace HiPiaoTerminal
{
    public partial class FullAdShowForm : Form
    {
        public FullAdShowForm()
        {
            InitializeComponent();
            this.Width = 1280;
            this.Height = 960;
            GlobalTools.SetCursor();
        }

        private void adShowPanel1_MouseClick(object sender, MouseEventArgs e)
        {
#if DEBUG
            Console.WriteLine(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "全屏广告进行了鼠标单击!");
#endif
            this.Hide();
            GlobalTools.MainForm.Activate();
            if (GlobalTools.MainForm.Controls[0] is MainPanel)
            {
            }
            else
            {
                GlobalTools.ReturnMain();

            }
            GlobalTools.MainForm.BringToFront();
        }

        private void adShowPanel1_MouseMove(object sender, MouseEventArgs e)
        {
#if DEBUG
            Console.WriteLine(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "全屏广告有鼠标移过!");
#endif
            /*
            this.Hide();
            if (GlobalTools.MainForm.Controls[0] is MainPanel)
            {
            }
            else
            {
                GlobalTools.ReturnMain();
            }
            GlobalTools.MainForm.BringToFront();
             * */
        }
    }
}
