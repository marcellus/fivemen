using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;
using HiPiaoInterface;

namespace HiPiaoTerminal.BuyTicket
{
    public partial class ShowWelcomePanel : UserControl
    {
        public ShowWelcomePanel()
        {
            InitializeComponent();
        }

        private void ShowWelcomePanel_Load(object sender, EventArgs e)
        {
            try
            {
                UserObject user = GlobalTools.GetLoginUser();
                this.lbUserName.Text = user.Name;
                this.lbCoupons.Text = string.Format(this.lbCoupons.Text, user.CouponNum.ToString(), user.DeductionNum.ToString());
                this.lbPoints.Text = string.Format(this.lbPoints.Text, user.RewardPoints.ToString());
                this.lbBalance.Text = string.Format(this.lbBalance.Text, user.Balance.ToString());
            }
            catch
            {
            }
        }
    }
}
