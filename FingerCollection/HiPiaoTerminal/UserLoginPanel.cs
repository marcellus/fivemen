using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using HiPiaoTerminal.UserControlEx;
using HiPiaoTerminal.Account;

namespace HiPiaoTerminal
{
    public partial class UserLoginPanel : OperationTimeParentPanel
    {
        private int loginSuccessType = 0;
        public UserLoginPanel(int type)
        {
            InitializeComponent();
            this.SetSepartor(false);
            loginSuccessType=type;
        }

        private void UserLoginPanel_Load(object sender, EventArgs e)
        {
           // GlobalTools.RegistUpdateUnOperationTime(null);
            this.txtUserName.Focus();
        }

       

        private bool allowLogin=false;

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (allowLogin)
            {
                if (GlobalTools.LoginAccount(this.txtUserName.Text, this.txtPwd.Text))
                {
                    if (loginSuccessType == 0)
                    {
                        GlobalTools.ReturnUserAccout();
                    }
                    else if (loginSuccessType == 1)
                    {
                        GlobalTools.QuickBuyTicket();
                    }
                }
                else
                {
                    GlobalTools.Pop(new UIdOrPwdErrorPanel());

                }
            }
        }

        private void txtUserName_onSubTextChanged()
        {
            string uid = this.txtUserName.Text;
            string pwd = this.txtPwd.Text;
            if (uid.Length > 0 && pwd.Length > 0)
            {
                allowLogin = true;
                this.btnLogin.IsActived = true;
            }
            else
            {
                allowLogin = false;
                this.btnLogin.IsActived = false;
            }

        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
          //  GlobalTools.QuitAccount();
            GlobalTools.ReturnMain();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            GlobalTools.ReturnMain();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            GlobalTools.ReturnMain();
        }
    }
}
