using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ThoughtWorks.QRCode.Codec;
using ThoughtWorks.QRCode.Codec.Data;
using ThoughtWorks.QRCode.Codec.Util;
using System.Drawing.Drawing2D;
using FT.Commons.Bar;

namespace FT.Windows.ExternalTool
{
    public partial class QRCodeTest : Form
    {
        public QRCodeTest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Image image=this.GetQRImage(this.textBox1.Text.Trim());
            
            this.pictureBox1.Image = image;
        }

        private Image GetQRImage(string data)
        {
            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();

            qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;


            try
            {
                //14 2920bit/8=365byte 16 3624/8=453byte 18 4504=536byte 20 5352=669byte
                qrCodeEncoder.QRCodeScale = Int16.Parse(System.Configuration.ConfigurationManager.AppSettings["QRCodeScale"]);
            }
            catch (Exception ex)
            {

                qrCodeEncoder.QRCodeScale = 2;
            }


            try
            {
                //14 2920bit/8=365byte 16 3624/8=453byte 18 4504=536byte 20 5352=669byte
                qrCodeEncoder.QRCodeVersion = Int16.Parse(System.Configuration.ConfigurationManager.AppSettings["QRCodeVersion"]);
            }
            catch (Exception ex)
            {
                qrCodeEncoder.QRCodeVersion = 16;
            }


            string errorCorrect = "M";
            if (errorCorrect == "L")
                qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L;
            else if (errorCorrect == "M")
                qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
            else if (errorCorrect == "Q")
                qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.Q;
            else if (errorCorrect == "H")
                qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.H;

            Image image;
            //,System.Text.Encoding.UTF8
            int length = data.Length;
            image = qrCodeEncoder.Encode(data, System.Text.Encoding.GetEncoding("gb2312"));
            return image;
        }
    }
}