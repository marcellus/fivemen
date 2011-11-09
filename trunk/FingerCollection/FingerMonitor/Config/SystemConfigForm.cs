using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Commons.Tools;

namespace FingerMonitor.Config
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

        private void button2_Click(object sender, EventArgs e)
        {
            loader.SaveConfig();
            MessageBoxHelper.Show("保存配置成功！");
            if (this.checkAutoStart.Checked)
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

        private void btnMonitorPath_Click(object sender, EventArgs e)
        {
            string result = FileDialogHelper.OpenDir(this.txtMonitorPath.Text.Trim());
            if (result.Length > 0)
            {
                this.txtMonitorPath.Text = result;

            }
        }
    }
}
