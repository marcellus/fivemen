using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Commons.Cache;

namespace STWebContainer
{
    public partial class ChangePwdForm : Form
    {
        public ChangePwdForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string pwd = this.txtNewPwd.Text.Trim();
            if (pwd.Length < 6)
            {
                this.lbHint.Text = "密码长度不能小于6位！";
                this.lbHint.Visible = true;
                this.txtRepeatPwd.Text = this.txtNewPwd.Text = string.Empty;
                this.txtNewPwd.Focus();
                return;
            }
            if (pwd != this.txtRepeatPwd.Text.Trim())
            {
                this.lbHint.Text = "两次输入的密码不一致！";
                this.lbHint.Visible = true;
                this.txtRepeatPwd.Text = this.txtNewPwd.Text = string.Empty;
                this.txtNewPwd.Focus();
            }
            else
            {
                STWebContainerSetting set = StaticCacheManager.GetConfig<STWebContainerSetting>();
                set.Pwd = pwd;
                StaticCacheManager.SaveConfig(set);
                this.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private TextBox focusTxt;

        private void txtNewPwd_Enter(object sender, EventArgs e)
        {
            this.focusTxt = this.txtNewPwd;
        }

        private void txtRepeatPwd_Enter(object sender, EventArgs e)
        {
            this.focusTxt = this.txtRepeatPwd;
        }

        private void pwdInputControl1_Enter(object sender, EventArgs e)
        {
            this.focusTxt.Focus();
            this.focusTxt.SelectionStart = this.focusTxt.Text.Length;
        }

        private void ChangePwdForm_Load(object sender, EventArgs e)
        {
            this.focusTxt = this.txtNewPwd;
            this.txtNewPwd.Focus();
        }
    }
}
