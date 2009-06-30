using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Commons.Tools;

namespace PhotoMonitor
{
    public partial class SystemMonitorConfig : Form
    {
        ConfigLoader<SystemConfig> loader = null;
        public SystemMonitorConfig()
        {
            InitializeComponent();
            FormHelper.InitHabitToForm(this);
            loader = new ConfigLoader<SystemConfig>(this);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            loader.SaveConfig();
            MessageBoxHelper.Show("±£´æÅäÖÃ³É¹¦£¡");
            if(this.checkAutoStart.Checked)
            {
                //RegisterHelper.SetAutoStart("PhotoMonitor_Drv");
            }
            else
            {
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

        private void btnBakPath_Click(object sender, EventArgs e)
        {
            string result = FileDialogHelper.OpenDir(this.txtBakPath.Text.Trim());
            if (result.Length > 0)
            {
                this.txtBakPath.Text = result;
                
            }
        }
    }
}