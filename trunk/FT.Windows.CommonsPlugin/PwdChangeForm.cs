using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Commons.Tools;
using FT.Commons.Security;
using FT.Windows.CommonsPlugin.Entity;

namespace FT.Windows.CommonsPlugin
{
    public partial class PwdChangeForm : Form
    {
        public PwdChangeForm()
        {
            InitializeComponent();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (this.txtOldPwd.Text.Trim() == string.Empty)
            {
                MessageBoxHelper.Show("请输入旧密码！");
                return;
            }

            else if (SecurityFactory.GetSecurity().Encrypt(this.txtOldPwd.Text.Trim()) != UserManager.LoginUser.Password)
            {
                MessageBoxHelper.Show("输入旧密码错误！");
                return;
            }
            else if (this.txtNewPwd.Text.Trim() == string.Empty)
            {
                MessageBoxHelper.Show("请输入新密码！");
                return;
            }
            else if (this.txtNewPwd.Text.Trim().Length < 6)
            {
                MessageBoxHelper.Show("新密码必须大于等于6位！");
                this.txtRepeatPwd.Text = string.Empty;
                this.txtNewPwd.Text = string.Empty;
                this.txtNewPwd.Focus();
                return;
            }
            else if (this.txtNewPwd.Text.Trim() != this.txtRepeatPwd.Text.Trim())
            {
                MessageBoxHelper.Show("两次输入的新密码不一致！");
                this.txtRepeatPwd.Text = string.Empty;
                this.txtNewPwd.Text = string.Empty;
                this.txtNewPwd.Focus();
                return;
            }
            if (UserManager.ResetPwd(this.txtNewPwd.Text.Trim()))
            {
                MessageBoxHelper.Show("修改成功！");
                this.txtNewPwd.Text = string.Empty;
                this.txtOldPwd.Text = string.Empty;
                this.txtRepeatPwd.Text = string.Empty;
                this.txtOldPwd.Focus();
            }
            else
            {
                MessageBoxHelper.Show("修改失败！");
            }
        }
    }
}