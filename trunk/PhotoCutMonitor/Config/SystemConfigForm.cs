using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Commons.Tools;
using FT.Commons.Cache;

namespace PhotoCutMonitor
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

        private void btnMonitorPath_Click(object sender, EventArgs e)
        {
            string result = FileDialogHelper.OpenDir(this.txtBakPath.Text.Trim());
            if (result.Length > 0)
            {
                this.txtMonitorPath.Text = result;

            }
        }

        private void btnCutPath_Click(object sender, EventArgs e)
        {
            string result = FileDialogHelper.OpenDir(this.txtBakPath.Text.Trim());
            if (result.Length > 0)
            {
                this.txtCutPath.Text = result;

            }
        }

        private void btnBakPath_Click(object sender, EventArgs e)
        {
            string result = FileDialogHelper.OpenDir(this.txtBakPath.Text.Trim());
            if (result.Length > 0)
            {
                this.txtBakPath.Text = result;

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            loader.SaveConfig();
            MessageBoxHelper.Show("±£¥Ê≈‰÷√≥…π¶£°");
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
    }
}