using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HiPiaoTerminal.ConfigModel;

namespace HiPiaoTerminal.Maintain
{
    public partial class ManagerModifyPwdPanel : HiPiaoTerminal.UserControlEx.MaintainParentPanel
    {
        public ManagerModifyPwdPanel()
        {
            InitializeComponent();
        }

        private void btnKeepSave_Click(object sender, EventArgs e)
        {
            string oldPwd = this.txtOldPwd.Text;
            if (oldPwd.Length == 0)
            {
                this.lbReturnMsg.Text = "请先输入旧密码！";
                return;
            }
            SystemConfig config = FT.Commons.Cache.StaticCacheManager.GetConfig<SystemConfig>();
            if (config.ManagePwd != oldPwd)
            {
                this.lbReturnMsg.Text = "旧密码错误！";
                this.txtOldPwd.Text = string.Empty;
                this.txtOldPwd.Focus();
                return;
            }
            if (this.txtNewPwd.Text != this.txtRepeatPwd.Text.Trim())
            {
                this.lbReturnMsg.Text = "两次输入新密码不一致！";
                this.txtNewPwd.Text = string.Empty;
                this.txtRepeatPwd.Text = string.Empty;
                this.txtNewPwd.Focus();
                return;
            }
            config.ManagePwd = this.txtRepeatPwd.Text;
            FT.Commons.Cache.StaticCacheManager.SaveConfig<SystemConfig>(config);
            this.lbReturnMsg.Text = "修改成功！";
        }

        private void btnCancelSave_Click(object sender, EventArgs e)
        {
            GlobalTools.ReturnMaintain();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
