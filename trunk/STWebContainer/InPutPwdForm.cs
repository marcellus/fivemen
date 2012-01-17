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
    public partial class InPutPwdForm : Form
    {
        public InPutPwdForm()
        {
            InitializeComponent();
        }

        private void InPutPwdForm_Load(object sender, EventArgs e)
        {
            this.txtPwd.Focus();
            //this.txtPwd.CanSelect = false;
            //this.txtPwd.
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            STWebContainerSetting set = StaticCacheManager.GetConfig<STWebContainerSetting>();
            if (set.Pwd == this.txtPwd.Text.Trim())
            {
                this.txtPwd.Visible = false;
                this.Close();
                Form frm = new SettingForm();
                frm.ShowDialog();
            }
            else
            {
                this.label2.Visible = true;
                this.txtPwd.Text = string.Empty;
            }
        }

        private void pwdInputControl1_Enter(object sender, EventArgs e)
        {
            this.txtPwd.Focus();
            this.txtPwd.DeselectAll();
           // this.txtPwd.SelectionStart = this.txtPwd.Text.Length;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
