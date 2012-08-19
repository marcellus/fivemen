using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HiPiaoTerminal.UserControlEx;
using HiPiaoTerminal.ConfigModel;

namespace HiPiaoTerminal.Maintain
{
    public partial class ManagerLoginWithPwdPanel : MaintainFirstPanel
    {
        public ManagerLoginWithPwdPanel()
        {
            InitializeComponent();
        }

        private void btnManagerLogin_Click(object sender, EventArgs e)
        {
            string inputPwd = this.txtManagePwd.Text.Trim();
            if (inputPwd.Length == 0)
            {
                this.lbReturnMsg.Text = "请输入登陆密码再点击登陆！";
                this.txtManagePwd.Text = string.Empty;
                this.txtManagePwd.Focus();
                return;
            }
            SystemConfig config = FT.Commons.Cache.StaticCacheManager.GetConfig<SystemConfig>();
            if (config.ManagePwd == inputPwd)
            {
                GlobalTools.ReturnMaintain();
    
            }
            else
            {
                this.lbReturnMsg.Text = "密码不正确！";
                this.txtManagePwd.Text = string.Empty;
                this.txtManagePwd.Focus();
            }
        }

        
    }
}
