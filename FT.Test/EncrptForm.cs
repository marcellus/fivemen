using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Commons.Security;

namespace FT.Test
{
    public partial class EncrptForm : Form
    {
        public EncrptForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text.Trim().Length > 0)
            {
                this.textBox2.Text=SecurityFactory.GetSecurity().Encrypt(this.textBox1.Text.Trim());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text.Trim().Length > 0)
            {
                this.textBox2.Text = SecurityFactory.GetSecurity().Decrypt(this.textBox1.Text.Trim());
            }
        }
    }
}