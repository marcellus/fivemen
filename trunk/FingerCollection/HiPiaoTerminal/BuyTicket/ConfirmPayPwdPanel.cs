using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HiPiaoTerminal.BuyTicket
{
    public partial class ConfirmPayPwdPanel : HiPiaoTerminal.UserControlEx.SecondNotifyUserPanel
    {
        public ConfirmPayPwdPanel()
        {
            InitializeComponent();
         
        }
        

        private bool allowPay = false;
        private void userInputPanel1_KeyUp(object sender, KeyEventArgs e)
        {
          
            
        }

        private void txtUserPwd_onSubTextChanged()
        {
            string pwd = this.txtUserPwd.Text.Trim();
            if (pwd.Length >= 6)
            {
                allowPay = true;
                this.btnConfirmPay.Image = Properties.Resources.BuyTicket_Btn_Active;
            }
            else
            {
                allowPay = false;
                this.btnConfirmPay.Image = Properties.Resources.BuyTicket_Btn_Not_Active;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }

        private void btnConfirmPay_Click(object sender, EventArgs e)
        {
            if (this.txtUserPwd.Text != GlobalTools.GetLoginUser().Pwd)
            {
                this.lbMsg.Text = "密码不正确！";
                this.txtUserPwd.Text = string.Empty;
                this.txtUserPwd.Focus();
            }
            else
            {
                this.FindForm().Close();
            }
        }
    }
}
