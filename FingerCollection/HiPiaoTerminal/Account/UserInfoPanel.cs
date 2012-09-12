using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;
using HiPiaoInterface;
using System.Threading;

namespace HiPiaoTerminal.Account
{
    public partial class UserInfoPanel : UserControl
    {
        private UserObject userInfo;
        public UserInfoPanel(UserObject user)
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            if (user != null)
            {
                this.Visible = true;
                this.userInfo = user;
                this.lbUserName.Text = user.Name;
                this.lbPoint.Text = user.RewardPoints.ToString();
                this.lbEmail.Text = user.Email;
                this.lbCoupon.Text = this.lbBuyRecord.Text = "正在加载...";
               
                this.lbBalance.Text = user.Balance.ToString();
               // this.lbBuyRecord.Text = user.BuyRecords.Count.ToString();
                Thread thread = new Thread(new ThreadStart(SetValue));
                thread.IsBackground = true;
                thread.Start();
            }
            else
            {
                this.Visible = false;
            }

        }

        public void SetValue()
        {
            this.lbCoupon.Text = this.userInfo.CouponNum.ToString();
            this.lbBuyRecord.Text = userInfo.BuyRecordNum.ToString();
        }

        
    }
}
