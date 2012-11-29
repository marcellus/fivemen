using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HiPiaoTerminal.CommonForm
{
    public partial class SelectSeatMessageFirst : HiPiaoTerminal.UserControlEx.FirstNotifyUserPanel
    {
        public SelectSeatMessageFirst()
        {
            InitializeComponent();
        }
        public SelectSeatMessageFirst(string text)
        {
            InitializeComponent();
            this.lbMsg1.Text = text;
        }

        private void picSure_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }
    }
}
