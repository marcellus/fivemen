using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Windows.Forms.Domain;
using FT.Commons.Tools;

namespace FT.Windows.Forms
{
    public partial class SimpleCompany : Form
    {
        ConfigLoader<CompanyInfo> loader = null;
        public SimpleCompany()
        {
            InitializeComponent();
            FormHelper.InitHabitToForm(this);
            loader = new ConfigLoader<CompanyInfo>(this);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            loader.SaveConfig();
            MessageBoxHelper.Show("±£´æ³É¹¦£¡");
        }
    }
}