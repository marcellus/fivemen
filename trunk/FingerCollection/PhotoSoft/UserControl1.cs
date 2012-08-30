using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FT.Commons.TwainSupport;

namespace PhotoSoft
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }
        VedioGrap vedioGrap;
        private bool isVedio = false;

        public void BeginPhoto()
        {
            // twain.BeginPhoto();
            isVedio = true;
            vedioGrap.OpenCapture(this.panelPhotoRec);
        }

        public void EndPhoto()
        {
            // twain.EndPhoto();
            isVedio = false;
            Image image = vedioGrap.GrapPhoto();

            vedioGrap.StopVideo();
            Clipboard.Clear();
            this.processImage = image;
        }

        private Image processImage;

        private void btnPhoto_Click(object sender, EventArgs e)
        {
            if (!isVedio)
            {
                this.BeginPhoto();
            }
            else
            {
                this.EndPhoto();
            }
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            vedioGrap = new VedioGrap();
            this.BeginPhoto();
        }
    }
}
