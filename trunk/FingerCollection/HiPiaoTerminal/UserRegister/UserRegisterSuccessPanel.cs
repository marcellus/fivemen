using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HiPiaoTerminal.UserRegister
{
    public partial class UserRegisterSuccessPanel : HiPiaoTerminal.UserControlEx.SecondNotifyUserPanel
    {
        public UserRegisterSuccessPanel()
        {
            InitializeComponent();
        }

        private void btnQuitAccount_Click(object sender, EventArgs e)
        {
            if (GlobalTools.QuitAccount())
            {
                this.FindForm().Close();
                //GlobalTools.ReturnMain();
            }
        }

        private void btnQueryAccount_Click(object sender, EventArgs e)
        {
            if (GlobalTools.QueryAccount())
            {
                this.FindForm().Close();
                GlobalTools.ReturnMain();
            }
        }

        private void btnReturnHome_Click(object sender, EventArgs e)
        {
           
            this.FindForm().Close();
            GlobalTools.ReturnMain();
        }

       
    }
}
