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
                    this.cbName.DisplayMember = "登录名";
                    this.cbName.ValueMember = "登录名";
                }
                this.cbName.SelectedIndex = 0;
                this.Text = Application.ProductName + Application.ProductVersion + "-登录";
            }
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string name = this.cbName.Text;
            if (name == "" || this.txtPwd.Text == "")
            {
                MessageBox.Show("请输入用户名和密码！", "登录提示");
                return;
            }
            int result = UserManager.Login(name, this.txtPwd.Text);
            if (result == 0)
            {
                this.DialogResult = DialogResult.OK;

            }
            else if (result == 1)
            {
                MessageBoxHelper.Show("密码错误，请重新输入！");
                this.txtPwd.Text = string.Empty;
                this.txtPwd.Focus();
            }
            else if (result == 3)
            {
                MessageBoxHelper.Show("对不起，该用户名被锁定,请联系本系统管理员！");
                this.txtPwd.Text = string.Empty;
                this.txtPwd.Focus();
            }
            else 
            {
                MessageBoxHelper.Show("用户名错误，请重新输入！");
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