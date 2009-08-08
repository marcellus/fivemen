using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Commons.Tools;


namespace FT.Device.IDCard
{
    public partial class IDCardConfigForm : BaseSkinForm
    {
        ConfigLoader<IDCardConfig> loader = null;
        public IDCardConfigForm()
        {
            InitializeComponent();
            FormHelper.InitHabitToForm(this);
            loader = new ConfigLoader<IDCardConfig>(this);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            loader.SaveConfig();
            MessageBoxHelper.Show("±£´æ³É¹¦£¡");
        }
    }
}