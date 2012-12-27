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
            this.userInfo = user;
            

        }

        public void SetValue()
        {
            this.lbCoupon.Text = this.userInfo.CouponNum.ToString();
            this.lbBuyRecord.Text = userInfo.BuyRecordNum.ToString();
        }

        private void UserInfoPanel_Load(object sender, EventArgs e)
        {
           
            try
            {

                if (userInfo != null)
                {
                    this.Visible = true;
                  //  this.userInfo = userInfo;
                    this.lbUserName.Text = userInfo.Name;
                    this.lbPoint.Text = userInfo.RewardPoints.ToString();
                    this.lbEmail.Text = userInfo.Email;
                    this.lbCoupon.Text = this.lbBuyRecord.Text = "正在加载...";

                    this.lbBalance.Text = userInfo.Balance.ToString();
                    // this.lbBuyRecord.Text = user.BuyRecords.Count.ToString();

                }
                else
                {
                    this.Visible = false;
                }
                Thread thread = new Thread(new ThreadStart(SetValue));
                thread.IsBackground = true;
                thread.Start();
            }
            catch
            {
            }
        }

        
    }
}
