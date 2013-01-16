using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FT.AuthLicense.Checker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cbAppName_SelectedIndexChanged(object sender, EventArgs e)
        {
            AuthLicenseObject license=FT.AuthLicense.AuthLicenseHelper.GetLicense(this.cbAppName.Text.Trim());
            if (license != null)
            {
                
                this.txtCompany.Text = license.Company;
                this.txtMAC.Text = license.MachineCode;
                this.txtRightCode.Text = license.RightCode;
                this.txtTerminalNum.Text = license.TerminalNum.ToString();
                this.txtUserNum.Text = license.UserNum.ToString();
            }
            else
            {
                this.txtCompany.Text = "未找到授权文件！";
                this.txtMAC.Text = string.Empty;
                this.txtTerminalNum.Text = string.Empty;
                this.txtRightCode.Text = string.Empty;
                this.txtUserNum.Text = string.Empty;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.cbAppName.SelectedIndex = 0;
        }
    }
}
