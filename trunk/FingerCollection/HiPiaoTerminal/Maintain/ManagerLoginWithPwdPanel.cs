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
             SystemConfig config = FT.Commons.Cache.StaticCacheManager.GetConfig<SystemConfig>();
            if (inputPwd.Length == 0)
            {
                this.lbReturnMsg.Text = "请输入登陆密码再点击登陆！";
                this.txtManagePwd.Text = string.Empty;
                this.txtManagePwd.Focus();
               // if(config.AllowNumberKeyboard)
                   // GlobalTools.SetAllKeyBoardWithForm(this.tx, 1);
                return;
            }
           
            if (config.ManagePwd == inputPwd)
            {
                GlobalTools.ErrorManagePwdTimes = 0;
                GlobalTools.ReturnMaintain();
    
            }
            else
            {
              
                this.lbReturnMsg.Text = "密码不正确！";
                GlobalTools.ErrorManagePwdTimes +=1;
                GlobalTools.ErrorManagePwdLastTime = System.DateTime.Now;
                
                this.txtManagePwd.Text = string.Empty;
                this.txtManagePwd.Focus();
                if (GlobalTools.ErrorManagePwdTimes == 3)
                {
                    GlobalTools.ShowMessage("密码输入次数太多！", true);
                    // GlobalTools.ReturnMain();
                }
            }
        }

        private void ManagerLoginWithPwdPanel_Load(object sender, EventArgs e)
        {
            this.txtManagePwd.Focus();
        }

        
    }
}
