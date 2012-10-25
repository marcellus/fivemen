using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using HiPiaoTerminal.UserControlEx;
using HiPiaoTerminal.Account;
using HiPiaoTerminal.ConfigModel;

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
            if (type == 0)
            {
                this.userLoginWithMoviePanel1.Visible = false;
                this.StopOpertionTime();
                this.SetOperationTime(100);
            }
            else
            {
                this.userLoginWithMoviePanel1.Visible = true;
                this.StopOpertionTime();
                this.SetOperationTime(100);
            }
           
            this.KeyDown += new KeyEventHandler(UserLoginPanel_KeyDown);
            HiPiaoTerminal.ConfigModel.SystemConfig config = FT.Commons.Cache.StaticCacheManager.GetConfig<SystemConfig>();
            if (config.UseRfid)
            {
                this.panelUseRfid.Location = new Point(this.panelUseKey.Location.X, this.panelUseKey.Location.Y);
                this.panelUseRfid.Visible = true;
            }
            else
            {
                this.panelUseRfid.Visible = false;
            }
            this.panelUseKey.Visible = false;
        }

        private void UserLoginPanel_Load(object sender, EventArgs e)
        {
           // GlobalTools.RegistUpdateUnOperationTime(null);
            
            //this.FindForm().AcceptButton = this.btnLogin;
            this.txtUserName.Focus();
        }

        void UserLoginPanel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnLogin_Click(null, null);
            }
        }
       // override pro

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                //Cursor.Current = Cursors.Default;
               // Cursor.Show();
                this.btnLogin_Click(null, null);
                //this.Close();
                

            }
            return false;
            //return false;
        }


       

        private bool allowLogin=false;

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (allowLogin)
            {
                try
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
                catch (Exception ex)
                {
                    GlobalTools.PopNetError();
                }
            }
        }

        private void txtUserName_onSubTextChanged()
        {
            string uid = this.txtUserName.Text;
            string pwd = this.txtPwd.Text;
            if (uid.Length > 0 && pwd.Length ==6)
            {
                allowLogin = true;
                this.btnLogin.IsActived = true;
            }
            else
            {
                allowLogin = false;
                this.btnLogin.IsActived = false;
            }
            if (this.txtPwd.Focused)
            {
                   // this.panelUseRfid.Visible = false;
                   


            }
            else if (this.txtUserName.Focused)
            {
              //  this.panelUseKey.Visible = false;
              

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

        protected override bool IsInputKey(System.Windows.Forms.Keys keyData)
        {
            switch (keyData)
            {
                // Add the list of special keys that you want to handle 
                case Keys.Tab:
                    return true;
                case Keys.Enter:
                    return true;
                default:
                    return base.IsInputKey(keyData);
            }
        }

        private void panelContent_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnLogin_Click(null,null);
            }
        }

        private void txtUserName_Enter(object sender, EventArgs e)
        {
            HiPiaoTerminal.ConfigModel.SystemConfig config = FT.Commons.Cache.StaticCacheManager.GetConfig<SystemConfig>();
            if (config.UseRfid)
            {
                this.panelUseRfid.Visible = true;

            }
            else
            {
                this.panelUseRfid.Visible = false;
            }
            this.panelUseKey.Visible = false;
        }

        private void txtPwd_Enter(object sender, EventArgs e)
        {
            HiPiaoTerminal.ConfigModel.SystemConfig config = FT.Commons.Cache.StaticCacheManager.GetConfig<SystemConfig>();
            if (config.UseHardwareKeyboard)
            {
                this.panelUseKey.Visible = true;

            }
            else
            {
                this.panelUseKey.Visible = false;
            }
            this.panelUseRfid.Visible = false;
        }
    }
}
