using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FT.Windows.Forms.CommonForm
{
    public partial class KeyCharMonitorForm : Form
    {
        public KeyCharMonitorForm()
        {
            InitializeComponent();
        }

        private void KeyCharMonitorForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            FT.Commons.Tools.MessageBoxHelper.Show("���µİ���"+e.KeyChar+"��KeyCharΪ��\r\n"+(int)e.KeyChar);
        }
    }
}