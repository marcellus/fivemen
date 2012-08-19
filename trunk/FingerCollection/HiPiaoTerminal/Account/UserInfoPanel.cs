using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;
using HiPiaoInterface;

namespace HiPiaoTerminal.Account
{
    public partial class UserInfoPanel : UserControl
    {
        private UserObject userInfo;
        public UserInfoPanel(UserObject user)
        {
            InitializeComponent();
            if (user != null)
            {
                this.Visible = true;
                this.userInfo = user;
                this.lbUserName.Text = user.Name;
                this.lbPoint.Text = user.RewardPoints.ToString();
                this.lbEmail.Text = user.Email;
                this.lbCoupon.Text = user.Coupons.Count.ToString();
                this.lbBalance.Text = user.Balance.ToString();
                this.lbBuyRecord.Text = user.BuyRecords.Count.ToString();
            }
            else
            {
                this.Visible = false;
            }

        }

        
    }
}
