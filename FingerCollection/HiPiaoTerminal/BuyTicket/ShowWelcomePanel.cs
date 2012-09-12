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
            try
            {
                UserObject user = GlobalTools.GetLoginUser();
                this.lbUserName.Text = user.Name;
                
                this.lbPoints.Text = string.Format(this.lbPoints.Text, user.RewardPoints.ToString());
                this.lbBalance.Text = string.Format(this.lbBalance.Text, user.Balance.ToString());
                Thread thread = new Thread(new ThreadStart(SetValue));
                thread.IsBackground = true;
                thread.Start();
            }
            catch
            {
            }
        }
        public void SetValue()
        {
            UserObject user = GlobalTools.GetLoginUser();
            this.lbCoupons.Text = string.Format(this.lbCoupons.Text, user.CouponNum.ToString(), user.DeductionNum.ToString());
        }

        private void ShowWelcomePanel_Load(object sender, EventArgs e)
        {
            
        }
    }
}
