using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HiPiaoTerminal.Account
{
    public partial class MyAccountPanel : HiPiaoTerminal.UserControlEx.OperationTimeParentPanel
    {
        public MyAccountPanel()
        {
            InitializeComponent();
        }

      

        private void btnAccountInfo_Click(object sender, EventArgs e)
        {
            Console.WriteLine("用户点击了账户信息按钮！");
            if (!this.btnAccountInfo.IsActive)
            {
                this.btnFeeDetailInfo.IsActive = this.btnModifyPwd.IsActive = false;
                this.btnAccountInfo.IsActive = true;
                UserInfoPanel panel = new UserInfoPanel(GlobalTools.GetLoginUser());
                
                ChangePanel(panel);
            }
        }

        private void ChangePanel(Control panel)
        {
            this.panelContent.Controls.Clear();
           
            panel.Dock = DockStyle.Fill;
            
            this.panelContent.Controls.Add(panel);
        }

        private void btnFeeDetailInfo_Click(object sender, EventArgs e)
        {
            Console.WriteLine("用户点击了消费信息按钮！");
            if (!this.btnFeeDetailInfo.IsActive)
            {
                this.btnAccountInfo.IsActive = this.btnModifyPwd.IsActive = false;
                this.btnFeeDetailInfo.IsActive = true;
                FeeDetailPanel panel = new FeeDetailPanel();
                panel.SetBuyLists(GlobalTools.GetLoginUser().BuyRecords);
                ChangePanel(panel);
               
            }
        }

        private void btnModifyPwd_Click(object sender, EventArgs e)
        {
            Console.WriteLine("用户点击了修改密码按钮！");
            if (!this.btnModifyPwd.IsActive)
            {
                this.btnFeeDetailInfo.IsActive = this.btnAccountInfo.IsActive = false;
                this.btnModifyPwd.IsActive = true;
                ModifyPwdPanel panel = new ModifyPwdPanel();

                ChangePanel(panel);
            }
        }

        private void btnReturnHome_Click(object sender, EventArgs e)
        {
            GlobalTools.ReturnMain();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            GlobalTools.ReturnMain();
        }

        private void btnQuitAccount_Click(object sender, EventArgs e)
        {
            if (GlobalTools.QuitAccount())
            {
                GlobalTools.ReturnMain();
            }
        }

        private void btnGoBuyTicket_Click(object sender, EventArgs e)
        {
            GlobalTools.QuickBuyTicket();
        }

        private void panelHeader_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MyAccountPanel_Load(object sender, EventArgs e)
        {
            btnAccountInfo_Click(null, null);
        }

        private void btnModifyPwd_Load(object sender, EventArgs e)
        {

        }

        private void btnFeeDetailInfo_Load(object sender, EventArgs e)
        {

        }

        

       
    }
}
