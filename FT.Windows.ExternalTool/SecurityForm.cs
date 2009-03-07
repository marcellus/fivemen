using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Commons.Security;

namespace FT.Windows.ExternalTool
{
    public partial class SecurityForm : Form
    {
        public SecurityForm()
        {
            InitializeComponent();
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text.Trim().Length > 0)
            {
                this.textBox2.Text = SecurityFactory.GetSecurity().Encrypt(this.textBox1.Text.Trim());
            }
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text.Trim().Length > 0)
            {
                this.textBox2.Text = SecurityFactory.GetSecurity().Decrypt(this.textBox1.Text.Trim());
            }
        }
    }
}