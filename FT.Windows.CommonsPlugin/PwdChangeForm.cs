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
                MessageBoxHelper.Show("����������룡");
                return;
            }

            else if (SecurityFactory.GetSecurity().Encrypt(this.txtOldPwd.Text.Trim()) != UserManager.LoginUser.Password)
            {
                MessageBoxHelper.Show("������������");
                return;
            }
            else if (this.txtNewPwd.Text.Trim() == string.Empty)
            {
                MessageBoxHelper.Show("�����������룡");
                return;
            }
            else if (this.txtNewPwd.Text.Trim().Length < 6)
            {
                MessageBoxHelper.Show("�����������ڵ���6λ��");
                this.txtRepeatPwd.Text = string.Empty;
                this.txtNewPwd.Text = string.Empty;
                this.txtNewPwd.Focus();
                return;
            }
            else if (this.txtNewPwd.Text.Trim() != this.txtRepeatPwd.Text.Trim())
            {
                MessageBoxHelper.Show("��������������벻һ�£�");
                this.txtRepeatPwd.Text = string.Empty;
                this.txtNewPwd.Text = string.Empty;
                this.txtNewPwd.Focus();
                return;
            }
            if (UserManager.ResetPwd(this.txtNewPwd.Text.Trim()))
            {
                MessageBoxHelper.Show("�޸ĳɹ���");
                this.txtNewPwd.Text = string.Empty;
                this.txtOldPwd.Text = string.Empty;
                this.txtRepeatPwd.Text = string.Empty;
                this.txtOldPwd.Focus();
            }
            else
            {
                MessageBoxHelper.Show("�޸�ʧ�ܣ�");
            }
        }
    }
}