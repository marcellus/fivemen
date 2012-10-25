using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HiPiaoTerminal.Account
{
    public partial class BindMobileSuccessPanel : HiPiaoTerminal.UserControlEx.SecondNotifyUserPanel
    {
        public BindMobileSuccessPanel()
        {
            InitializeComponent();
            this.lbUserName.Text = string.Format(this.lbUserName.Text, GlobalTools.GetLoginUser().Name);
            this.lbMobile.Text = string.Format(this.lbMobile.Text, GlobalTools.GetLoginUser().Mobile);
            
        }

        private void btnBuyTicket_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
            GlobalTools.QuickBuyTicket();
        }
    }
}
