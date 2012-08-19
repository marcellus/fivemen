using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HiPiaoTerminal.ConfigModel;

namespace HiPiaoTerminal.CommonForm
{
    public partial class UnLockPanel : HiPiaoTerminal.UserControlEx.FirstNotifyUserPanel
    {
        public UnLockPanel()
        {
            InitializeComponent();
        }

        private void btnUnLock_Click(object sender, EventArgs e)
        {
            string inputPwd = this.txtManagePwd.Text.Trim();
            if (inputPwd.Length == 0)
            {
                this.lbReturnMsg.Text = "请输入解锁密码再点击确定解锁！";
                this.txtManagePwd.Text = string.Empty;

                this.txtManagePwd.Focus();
                return;
            }
            SystemConfig config = FT.Commons.Cache.StaticCacheManager.GetConfig<SystemConfig>();
            if (config.ManagePwd == inputPwd)
            {
                //GlobalTools.ReturnMaintain();
                Form form = this.FindForm();
                string ttt=form.GetType().ToString();
                this.FindForm().DialogResult = DialogResult.OK;
                this.FindForm().Close();
            }
            else
            {
                this.lbReturnMsg.Text = "密码不正确！";
                this.txtManagePwd.Text = string.Empty;

                this.txtManagePwd.Focus();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.FindForm().DialogResult = DialogResult.Cancel;
            this.FindForm().Close();
        }

        private void txtManagePwd_TextChanged(object sender, EventArgs e)
        {
           // GlobalTools.ShowInput(this.txtManagePwd);
        }
    }
}
