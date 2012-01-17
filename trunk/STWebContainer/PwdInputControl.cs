using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace STWebContainer
{
    public partial class PwdInputControl : UserControl
    {
        public PwdInputControl()
        {
            InitializeComponent();
        }

        

        private void btnNum_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            SendKeys.Send(btn.Text);
        }

        private void btnBackspace_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{BKSP}");
        }
    }
}
