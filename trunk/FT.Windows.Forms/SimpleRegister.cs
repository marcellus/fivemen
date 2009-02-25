using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Windows.Forms.Domain;
using FT.Commons.Tools;
using FT.Commons.Security;

namespace FT.Windows.Forms
{
    public partial class SimpleRegister : Form
    {
        
        ConfigLoader<ProgramRegConfig> loader = null;
        public SimpleRegister()
        {
            InitializeComponent();
            loader = new ConfigLoader<ProgramRegConfig>(this);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            ISecurity md5 = new MD5Security();
            ISecurity sec= FT.Commons.Security.SecurityFactory.GetSecurity();
            if (this.txtCompany.Text.Trim().Length == 0)
            {
                MessageBoxHelper.Show("必须输入授权用户！");
                return;
            }
            if (this.txtKeyCode.Text.Trim().Length > 0)
            {
                if (this.txtKeyCode.Text.Trim() != md5.Encrypt(sec.Encrypt(this.txtMachineCode.Text+this.txtCompany.Text.Trim()+this.txtMachineCode.Text)))
                {
                    this.txtKeyCode.Focus();
                    MessageBoxHelper.Show("注册码错误，请重新输入！");
                    return;
                }
            }
            loader.SaveConfig();
            MessageBoxHelper.Show("保存成功！");
        }

        private void SimpleRegister_Load(object sender, EventArgs e)
        {
            this.txtMachineCode.Text = FT.Commons.Tools.HardwareManager.GetMachineCode();
        }

       
    }
}