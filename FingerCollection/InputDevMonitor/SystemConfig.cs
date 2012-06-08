using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Commons.Tools;

namespace InputDevMonitor
{
    public partial class SystemConfig : Form
    {
        ConfigLoader<MonitorConfig> loader = null;
         public SystemConfig()
        {
            InitializeComponent();
            FormHelper.InitHabitToForm(this);
            loader = new ConfigLoader<MonitorConfig>(this);
           
        }

        

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            loader.SaveConfig();
            MessageBoxHelper.Show("保存配置成功！");
            if (this.checkIsStart.Checked)
            {
                ShortcutHelper.CreateStartUpShortcut();
                //RegisterHelper.SetAutoStart("PhotoMonitor_Drv");
            }
            else
            {
                ShortcutHelper.DeleteStartUpShortcut();
                //RegisterHelper.ClearAutoStart("PhotoMonitor_Drv");
            }
        }
    }
}
