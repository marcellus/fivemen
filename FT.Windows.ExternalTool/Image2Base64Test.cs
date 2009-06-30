using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Commons.Tools;

namespace FT.Windows.ExternalTool
{
    public partial class Image2Base64Test : Form
    {
        public Image2Base64Test()
        {
            InitializeComponent();
        }

        private void btnSelector_Click(object sender, EventArgs e)
        {
            string path = FileDialogHelper.OpenImage();
            if(path!=null&&path.Length>0)
            {
                this.pictureBox1.Image = Image.FromFile(path);
                this.txtPicPath.Text = path;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(this.pictureBox1.Image!=null)
            {
                this.txtBase64.Text = ImageHelper.ImageToBase64Str(this.pictureBox1.Image);
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.txtBase64.Text.Length>0)
            {
                this.pictureBox1.Image = ImageHelper.Base64StrToBmp(this.txtBase64.Text.Trim());

            }
        }
    }
}