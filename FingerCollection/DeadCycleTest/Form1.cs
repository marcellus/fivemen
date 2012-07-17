using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DeadCycleTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBegin_Click(object sender, EventArgs e)
        {
            timer1.Interval = Convert.ToInt32(this.txtTimerInterval.Text.Trim());
            timer1.Start();
            this.btnStop.Enabled = true;
            this.btnBegin.Enabled = false;
            sleepTime = Convert.ToInt32(this.txtSleepTime.Text.Trim());
        }
        int sleepTime = 0;

        private void btnStop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            this.btnBegin.Enabled = true;
            this.btnStop.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
           // SendKeys.Send("350128198403194910");
            System.Threading.Thread.Sleep(sleepTime);
            SendKeys.Send("{ENTER}");
            System.Threading.Thread.Sleep(sleepTime);
            SendKeys.Send("%{F4}");
            System.Threading.Thread.Sleep(sleepTime);
            SendKeys.Flush();
            timer1.Start();
        }
    }
}
