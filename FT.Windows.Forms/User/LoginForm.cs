using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using FT.Commons.Tools;
using System.Reflection;

namespace FT.Windows.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            FormHelper.InitHabitToForm(this);
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                ArrayList users=FT.DAL.Orm.SimpleOrmOperator.QueryListAll(typeof(FT.Windows.Forms.User));
                if (users.Count > 0)
                {
                    //this.cbGroup
                    this.cbName.DataSource = users;
                    this.cbName.DisplayMember = "��¼��";
                    this.cbName.ValueMember = "��¼��";
                }
                this.cbName.SelectedIndex = 0;
                this.Text = Application.ProductName + Application.ProductVersion + "-��¼";
            }
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string name = this.cbName.Text;
            if (name == "" || this.txtPwd.Text == "")
            {
                MessageBox.Show("�������û��������룡", "��¼��ʾ");
                return;
            }
            int result = UserManager.Login(name, this.txtPwd.Text);
            if (result == 0)
            {
                this.DialogResult = DialogResult.OK;

            }
            else if (result == 1)
            {
                MessageBoxHelper.Show("����������������룡");
                this.txtPwd.Text = string.Empty;
                this.txtPwd.Focus();
            }
            else if (result == 3)
            {
                MessageBoxHelper.Show("�Բ��𣬸��û���������,����ϵ��ϵͳ����Ա��");
                this.txtPwd.Text = string.Empty;
                this.txtPwd.Focus();
            }
            else 
            {
                MessageBoxHelper.Show("�û����������������룡");
                //this.txtName.Text.Trim();
                this.txtPwd.Text = "";
                //this.txtName.Focus();

            }
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult != DialogResult.Cancel && this.DialogResult != DialogResult.OK)
                e.Cancel = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}