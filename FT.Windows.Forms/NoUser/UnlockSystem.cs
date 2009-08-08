using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Commons.Security;
using FT.Commons.Tools;
using FT.Commons.Cache;

namespace FT.Windows.Forms.NoUser
{
    public partial class UnlockSystem : DevExpress.XtraEditors.XtraForm
    {
        public UnlockSystem()
        {
            InitializeComponent();
        }

        private void btnUnlock_Click(object sender, EventArgs e)
        {
            string tmp = SecurityFactory.GetSecurity().Encrypt(this.txtPassword.Text.Trim());
            MockUser user = StaticCacheManager.GetConfig<MockUser>();
            if (tmp != user.Pwd)
            {
                MessageBoxHelper.Show("输入的密码有误，请重新输入！");
                this.txtPassword.Text = string.Empty;
                this.txtPassword.Focus();
                return;
            }
            else
            {
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}