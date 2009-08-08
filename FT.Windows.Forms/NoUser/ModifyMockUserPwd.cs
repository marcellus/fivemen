using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Commons.Tools;
using FT.Commons.Security;
using FT.Commons.Cache;

namespace FT.Windows.Forms.NoUser
{
    public partial class ModifyMockUserPwd : DevExpress.XtraEditors.XtraForm
    {
        public ModifyMockUserPwd()
        {
            InitializeComponent();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            string tmp = SecurityFactory.GetSecurity().Encrypt(this.txtOldPwd.Text.Trim());
            MockUser user=StaticCacheManager.GetConfig<MockUser>();
            if (tmp != user.Pwd || this.txtOldPwd.Text.Trim().Length < 6)
            {
                MessageBoxHelper.Show("�����������������������룡");
                this.txtOldPwd.Text = string.Empty;
                this.txtOldPwd.Focus();
                return;
            }
            if (this.txtNewPwd.Text.Trim().Length < 6)
            {
                MessageBoxHelper.Show("�����볤�ȱ��벻��С��6λ��");
                this.txtNewPwd.Text = string.Empty;
                this.txtRepeatPwd.Text = string.Empty;
                this.txtNewPwd.Focus();
                return;
            }
            else if (this.txtNewPwd.Text.Trim() != this.txtRepeatPwd.Text.Trim())
            {
                MessageBoxHelper.Show("��������������벻һ�£�");
                this.txtNewPwd.Text = string.Empty;
                this.txtRepeatPwd.Text = string.Empty;
                this.txtNewPwd.Focus();
                return;
            }
            else
            {
                string tmp2 = SecurityFactory.GetSecurity().Encrypt(this.txtNewPwd.Text.Trim());
                user.Pwd = tmp2;
                StaticCacheManager.SaveConfig<MockUser>(user);
                MessageBoxHelper.Show("�޸ĳɹ���");
                this.Close();
            }
        }
    }
}