using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Commons.Tools;

namespace FT.Windows.Forms
{
    public partial class DbAutoBakConfigForm : DevExpress.XtraEditors.XtraForm
    {
        ConfigLoader<DbAutoBakConfig> loader = null;
        public DbAutoBakConfigForm()
        {
            InitializeComponent();
            FormHelper.InitHabitToForm(this);
            loader = new ConfigLoader<DbAutoBakConfig>(this);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            loader.SaveConfig();
            MessageBoxHelper.Show("±£´æ³É¹¦£¡");
        }
    }
}