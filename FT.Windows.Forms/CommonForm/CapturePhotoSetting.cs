using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Commons.Tools;
using FT.Commons.Cache;

namespace FT.Windows.Forms.CommonForm
{
    public partial class CapturePhotoSetting : DevExpress.XtraEditors.XtraForm
    {
        ConfigLoader<CapturePhotoSet> loader = null;
        public CapturePhotoSetting()
        {
            InitializeComponent();
            FormHelper.InitHabitToForm(this);
            loader = new ConfigLoader<CapturePhotoSet>(this);
            CapturePhotoSet set= StaticCacheManager.GetConfig<CapturePhotoSet>();
            try
            {
                this.lbBgColor.BackColor =
                    Color.FromArgb(set.BgRgbR,set.BgRgbG,set.BgRgbB);
            }
            catch (System.Exception ex)
            {

            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loader.SaveConfig();
            MessageBoxHelper.Show("±£´æ³É¹¦£¡");
        }

        private void lbBgColor_Click(object sender, EventArgs e)
        {
            Color result=SystemColors.Control;
            try
            {
                result=
                    Color.FromArgb(Convert.ToInt32(this.lbBgRgbR.Text),
                    Convert.ToInt32(this.lbBgRgbG.Text),
                    Convert.ToInt32(this.lbBgRgbB.Text));
            }
            catch (System.Exception ex)
            {

            }

            result = MessageBoxHelper.PickColor(result);
            if(result!=null)
            {

                this.lbBgColor.BackColor = result;
                this.lbBgRgbR.Text = result.R.ToString();
                this.lbBgRgbG.Text = result.G.ToString();
                this.lbBgRgbB.Text = result.B.ToString();
            }
        }

        private void CapturePhotoSetting_Load(object sender, EventArgs e)
        {
            
        }
    }
}