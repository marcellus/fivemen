using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Windows.Forms.Domain;
using FT.Commons.Tools;

namespace Vehicle.Plugins
{
    public partial class VehicleConfig : Form
    {
        ConfigLoader<SystemConfig> loader = null;
        public VehicleConfig()
        {
            InitializeComponent();
            loader=new ConfigLoader<SystemConfig>(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            loader.SaveConfig();
            MessageBoxHelper.Show("±£´æÅäÖÃ³É¹¦£¡");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string result=FileDialogHelper.OpenDir(this.txtPhotoDir.Text.Trim());
            if (result.Length > 0)
            {
                this.txtPhotoDir.Text = result;
            }
        }
    }
}