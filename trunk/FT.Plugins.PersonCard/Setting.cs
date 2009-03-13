using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Commons.Tools;

namespace FT.Plugins.PersonCard
{
    public partial class Setting : Form
    {
        ConfigLoader<CarStartSetting> loader = null;
        public Setting()
        {
            InitializeComponent();
            loader = new ConfigLoader<CarStartSetting>(this);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            loader.SaveConfig();
            MessageBoxHelper.Show("保存成功,新配置将在下次生效！");
        }
    }
}