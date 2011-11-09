using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Commons.Tools;
using FT.Commons.Cache;

namespace FingerCollection.Config
{
    public partial class SystemConfigForm : Form
    {
        ConfigLoader<SystemConfig> loader = null;
        public SystemConfigForm()
        {
            InitializeComponent();
            FormHelper.InitHabitToForm(this);
            loader = new ConfigLoader<SystemConfig>(this);
           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            loader.SaveConfig();
            MessageBoxHelper.Show("保存配置成功！");
        }
    }
}
