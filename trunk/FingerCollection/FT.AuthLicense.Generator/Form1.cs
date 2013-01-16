using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FT.AuthLicense.Generator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.cbAppName.SelectedIndex = 0;
        }

        private void btnGenerator_Click(object sender, EventArgs e)
        {
            try
            {
                AuthLicenseObject license = new AuthLicenseObject();
                license.AppName = this.cbAppName.Text.Trim();
                license.Company = this.txtCompany.Text.Trim();
                license.MachineCode = this.txtMAC.Text.Trim();
                license.TerminalNum = Convert.ToInt32(this.txtTerminalNum.Text.Trim());
                license.UserNum = Convert.ToInt32(this.txtUserNum.Text.Trim());
                AuthLicenseHelper.CreateLicenseFile(license);
                MessageBox.Show("授权成功！授权文件已经产生在C盘目录下");
            }
            catch (Exception ex)
            {
                MessageBox.Show("授权失败！"+ex.ToString());
            }
        }
    }
}
