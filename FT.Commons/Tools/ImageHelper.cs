using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

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
        private static ImageCodecInfo GetCodecInfo(string mimeType)
        {
            ImageCodecInfo[] CodecInfo = ImageCodecInfo.GetImageEncoders();
            foreach (ImageCodecInfo ici in CodecInfo)
            {
                if (ici.MimeType == mimeType) return ici;
            }
            return null;
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
