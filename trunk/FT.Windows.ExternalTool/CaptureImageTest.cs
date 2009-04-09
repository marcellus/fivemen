using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Commons.Tools;
using FT.Windows.Forms;

namespace FT.Windows.ExternalTool
{
    public partial class CaptureImageTest : Form
    {
        public CaptureImageTest()
        {
            InitializeComponent();
        }

        private void btnSelector_Click(object sender, EventArgs e)
        {
            string path = FileDialogHelper.OpenImage();

            if (path != string.Empty)
            {

                try
                {
                    this.pictureBox1.Image = Image.FromFile(path);
                   
                }
                catch (Exception ex)
                {
                    MessageBoxHelper.Show("图片格式不对或正被其他程序使用！");
                }
            }
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            CaptureImage form = new CaptureImage(this.pictureBox1);
            form.ShowDialog();
        }
    }
}