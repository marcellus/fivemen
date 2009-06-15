using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace FT.Commons.Tools
{
    public class ImageHelper:BaseHelper
    {
        /**/
        /// <summary>
        /// ����JPGʱ��
        /// </summary>
        /// <param name="mimeType"> </param>
        /// <returns>�õ�ָ��mimeType��ImageCodecInfo </returns>
        public static ImageCodecInfo GetCodecInfo(string mimeType)
        {
            ImageCodecInfo[] CodecInfo = ImageCodecInfo.GetImageEncoders();
            foreach (ImageCodecInfo ici in CodecInfo)
            {
                if (ici.MimeType == mimeType) return ici;
            }
            return null;
        }

        public static void SaveOneInchPic(Image image, string path)
        {
            try
            {
                image = image.Clone() as Image;
                ((Bitmap)image).SetResolution(350f, 350f);//����ͼƬ��ӡ��dpi
                ImageCodecInfo myImageCodecInfo;
                EncoderParameters myEncoderParameters;
                myImageCodecInfo = ImageHelper.GetCodecInfo("image/jpeg");
                myEncoderParameters = new EncoderParameters(2);
                myEncoderParameters.Param[0] = new EncoderParameter(Encoder.Quality, (long)100);
                myEncoderParameters.Param[1] = new EncoderParameter(Encoder.ColorDepth, (long)ColorDepth.Depth32Bit);
                //image.Save(path,ImageFormat.Jpeg,)
                image.Save(path, myImageCodecInfo, myEncoderParameters);
                image.Dispose();
            }
            catch (System.Exception e)
            {
                log.Fatal(e);
            }
            
        }

        /**/
        /// <summary>
        /// ����ΪJPEG��ʽ��֧��ѹ������ѡ��
        /// </summary>
        /// <param name="bmp"></param>
        /// <param name="FileName"></param>
        /// <param name="Qty"></param>
        /// <returns></returns>
        public static bool KiSaveAsJPEG(Bitmap image, string FileName, int Qty)
        {
            try
            {
                EncoderParameter p;
                EncoderParameters ps;

                ps = new EncoderParameters(1);

                p = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, Qty);
                ps.Param[0] = p;
                image.Save(FileName, GetCodecInfo("image/jpeg"), ps);
                

                return true;
            }
            catch(Exception ex)
            {
                log.Error(ex.ToString());
                return false;
            }

        }
    }
}
