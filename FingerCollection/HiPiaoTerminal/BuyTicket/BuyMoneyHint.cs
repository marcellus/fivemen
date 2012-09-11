using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HiPiaoTerminal.BuyTicket
{
    public partial class BuyMoneyHint : HiPiaoTerminal.UserControlEx.FirstNotifyUserPanel
    {
        public BuyMoneyHint()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }

        private void btnQuitAccout_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
            GlobalTools.QuitAccount();
        }
    }
}
