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
            MessageBoxHelper.Show("保存配置成功！");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string result=FileDialogHelper.OpenDir(this.txtPhotoDir.Text.Trim());
            if (result.Length > 0)
            {
                this.txtPhotoDir.Text = result;
            }
        }

        private void txtImageWidth_TextChanged(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked)
            {
                try
                {
                    int width = Convert.ToInt32(this.txtImageWidth.Text.Trim());
                    int height = 230 * width / 368;
                    this.txtImageHeight.Text = height.ToString();
                }
                catch (Exception ex)
                {
                    MessageBoxHelper.Show("图片宽度必须是数字！");
                    this.txtImageWidth.Focus();
                }
            }
        }

        private void txtImageHeight_TextChanged(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked)
            {
                try
                {
                    int height = Convert.ToInt32(this.txtImageHeight.Text.Trim());
                    int width = 368 * height / 230;
                    this.txtImageWidth.Text = width.ToString();
                }
                catch (Exception ex)
                {
                    MessageBoxHelper.Show("图片宽度必须是数字！");
                    this.txtImageHeight.Focus();
                }
            }
        }
    }
}