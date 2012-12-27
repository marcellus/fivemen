using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;
using HiPiaoInterface;
using System.Threading;

namespace HiPiaoTerminal.BuyTicket
{
    public partial class ShowWelcomePanel : UserControl
    {
        public ShowWelcomePanel()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            this.Width = 527;
            this.Height = 80;
            this.lbCoupons.Text = "兑换券：... 抵扣券：...";
            
        }
        public void SetValue()
        {
            try
            {
            UserObject user = GlobalTools.GetLoginUser();
            this.lbUserName.Text = user.Name;
            FT.Commons.Tools.WinFormHelper.LocationAfter(this.label2, this.lbUserName);
            this.lbPoints.Text = string.Format(this.lbPoints.Text, user.RewardPoints.ToString());
            this.lbBalance.Text = string.Format(this.lbBalance.Text, user.Balance.ToString());
            this.lbCoupons.Text = string.Format("兑换券：{0} 抵扣券：{1}", user.CouponNum.ToString(), user.DeductionNum.ToString());
            }
            catch
            {
            }
        }

        private void ShowWelcomePanel_Load(object sender, EventArgs e)
        {
            try
            {

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
