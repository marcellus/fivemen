using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace InputDevMonitor
{
    public partial class InputDeviceMonitor : Form
    {
        private Form1 form1 = new Form1();

        public InputDeviceMonitor()
        {
            InitializeComponent();
        }

        private void 输入设备系统配置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Form1 form1 = new Form1();
            form1.Show();
        }

        protected override void OnActivated(EventArgs e)
        {
            this.Hide();
        }

        private void 退出监控ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
