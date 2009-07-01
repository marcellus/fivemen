using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

namespace FT.Commons.Tools
{
    public class ImageHelper:BaseHelper
    {

        public static Bitmap Base64StrToBmp(string ImgBase64Str)
        {
            byte[] ImgBuffer = Convert.FromBase64String(ImgBase64Str);
            MemoryStream MStream = new MemoryStream(ImgBuffer);
            Bitmap Bmp = new Bitmap(MStream);
            return Bmp;
        }

        public static string ImageToBase64Str(string ImgName)
        {
            Image Img = Image.FromFile(ImgName);
            System.IO.MemoryStream MStream = new System.IO.MemoryStream();
            Img.Save(MStream, ImageFormat.Jpeg);
            byte[] ImgBuffer = MStream.GetBuffer();
            string ImgBase64Str = Convert.ToBase64String(ImgBuffer);
            //释放资源，让别的使用
            Img.Dispose();
            return ImgBase64Str;
        }
        public static string ImageToBase64Str(Image Img)
        {
            System.IO.MemoryStream MStream = new System.IO.MemoryStream();
            Img.Save(MStream, ImageFormat.Jpeg);
            byte[] ImgBuffer = MStream.GetBuffer();
            string ImgBase64Str = Convert.ToBase64String(ImgBuffer);
            return ImgBase64Str;
        }
        /**/
        /// <summary>
        /// 保存JPG时用
        /// </summary>
        /// <param name="mimeType"> </param>
        /// <returns>得到指定mimeType的ImageCodecInfo </returns>
        public static ImageCodecInfo GetCodecInfo(string mimeType)
        {
            ImageCodecInfo[] CodecInfo = ImageCodecInfo.GetImageEncoders();
            foreach (ImageCodecInfo ici in CodecInfo)
            {
                if (ici.MimeType == mimeType) return ici;
            }
            return null;
        }

        #region 色彩处理  
         /// <summary>  
         /// 设置图形颜色  边缘的色彩更换成新的颜色  
         /// </summary>  
         /// <param name="p_Image">图片</param>  
         /// <param name="p_OldColor">老的边缘色彩</param>  
         /// <param name="p_NewColor">新的边缘色彩</param>  
         /// <param name="p_Float">溶差</param>  
         /// <returns>清理后的图形</returns>  
         public static Image SetImageColorBrim(Image p_Image, Color p_OldColor, Color p_NewColor, int p_Float)  
         {  
             int _Width = p_Image.Width;  
             int _Height = p_Image.Height;  
   
             Bitmap _NewBmp = new Bitmap(_Width, _Height, PixelFormat.Format32bppArgb);  
             Graphics _Graphics = Graphics.FromImage(_NewBmp);  
             _Graphics.DrawImage(p_Image, new Rectangle(0, 0, _Width, _Height));  
             _Graphics.Dispose();  
   
             BitmapData _Data = _NewBmp.LockBits(new Rectangle(0, 0, _Width, _Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);  
             _Data.PixelFormat = PixelFormat.Format32bppArgb;  
             int _ByteSize = _Data.Stride * _Height;  
             byte[] _DataBytes = new byte[_ByteSize];  
             Marshal.Copy(_Data.Scan0, _DataBytes, 0, _ByteSize);  
   
             int _Index = 0;  
             #region 列  
             for (int z = 0; z != _Height; z++)  
             {  
                 _Index = z * _Data.Stride;  
                 for (int i = 0; i != _Width; i++)  
                 {  
                     Color _Color = Color.FromArgb(_DataBytes[_Index + 3], _DataBytes[_Index + 2], _DataBytes[_Index + 1], _DataBytes[_Index]);  
   
                     if (ScanColor(_Color, p_OldColor, p_Float))  
                     {  
                         _DataBytes[_Index + 3] = (byte)p_NewColor.A;  
                         _DataBytes[_Index + 2] = (byte)p_NewColor.R;  
                         _DataBytes[_Index + 1] = (byte)p_NewColor.G;  
                         _DataBytes[_Index] = (byte)p_NewColor.B;  
                         _Index += 4;  
                     }  
                     else  
                     {  
                         break;  
                     }  
                 }  
                 _Index = (z + 1) * _Data.Stride;  
                 for (int i = 0; i != _Width; i++)  
                 {  
                     Color _Color = Color.FromArgb(_DataBytes[_Index - 1], _DataBytes[_Index - 2], _DataBytes[_Index - 3], _DataBytes[_Index - 4]);  
   
                     if (ScanColor(_Color, p_OldColor, p_Float))  
                     {  
                         _DataBytes[_Index - 1] = (byte)p_NewColor.A;  
                         _DataBytes[_Index - 2] = (byte)p_NewColor.R;  
                         _DataBytes[_Index - 3] = (byte)p_NewColor.G;  
                         _DataBytes[_Index - 4] = (byte)p_NewColor.B;  
                         _Index -= 4;  
                     }  
                     else  
                     {  
                         break;  
                     }  
                 }  
             }  
             #endregion  
  
             #region 行  
   
             for (int i = 0; i != _Width; i++)  
             {  
                 _Index = i * 4;  
                 for (int z = 0; z != _Height; z++)  
                 {  
                     Color _Color = Color.FromArgb(_DataBytes[_Index + 3], _DataBytes[_Index + 2], _DataBytes[_Index + 1], _DataBytes[_Index]);  
                     if (ScanColor(_Color, p_OldColor, p_Float))  
                     {  
                         _DataBytes[_Index + 3] = (byte)p_NewColor.A;  
                         _DataBytes[_Index + 2] = (byte)p_NewColor.R;  
                         _DataBytes[_Index + 1] = (byte)p_NewColor.G;  
                         _DataBytes[_Index] = (byte)p_NewColor.B;  
                         _Index += _Data.Stride;  
                     }  
                     else  
                     {  
                         break;  
                     }  
                 }  
                 _Index = (i * 4) + ((_Height - 1) * _Data.Stride);  
                 for (int z = 0; z != _Height; z++)  
                 {  
                     Color _Color = Color.FromArgb(_DataBytes[_Index + 3], _DataBytes[_Index + 2], _DataBytes[_Index + 1], _DataBytes[_Index]);  
                     if (ScanColor(_Color, p_OldColor, p_Float))  
                     {  
                         _DataBytes[_Index + 3] = (byte)p_NewColor.A;  
                         _DataBytes[_Index + 2] = (byte)p_NewColor.R;  
                         _DataBytes[_Index + 1] = (byte)p_NewColor.G;  
                         _DataBytes[_Index] = (byte)p_NewColor.B;  
                         _Index -= _Data.Stride;  
                     }  
                     else  
                     {  
                         break;  
                     }  
                 }  
             }  
  
  
             #endregion  
             Marshal.Copy(_DataBytes, 0, _Data.Scan0, _ByteSize);  
             _NewBmp.UnlockBits(_Data);  
             return _NewBmp;  
         }  
         /// <summary>  
         /// 设置图形颜色  所有的色彩更换成新的颜色  
         /// </summary>  
         /// <param name="p_Image">图片</param>  
         /// <param name="p_OdlColor">老的颜色</param>  
         /// <param name="p_NewColor">新的颜色</param>  
         /// <param name="p_Float">溶差</param>  
         /// <returns>清理后的图形</returns>  
         public static Image SetImageColorAll(Image p_Image, Color p_OdlColor, Color p_NewColor, int p_Float)  
         {  
             int _Width = p_Image.Width;  
             int _Height = p_Image.Height;  
   
             Bitmap _NewBmp = new Bitmap(_Width, _Height, PixelFormat.Format32bppArgb);  
             Graphics _Graphics = Graphics.FromImage(_NewBmp);  
             _Graphics.DrawImage(p_Image, new Rectangle(0, 0, _Width, _Height));  
             _Graphics.Dispose();  
   
             BitmapData _Data = _NewBmp.LockBits(new Rectangle(0, 0, _Width, _Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);  
             _Data.PixelFormat = PixelFormat.Format32bppArgb;  
             int _ByteSize = _Data.Stride * _Height;  
             byte[] _DataBytes = new byte[_ByteSize];  
             Marshal.Copy(_Data.Scan0, _DataBytes, 0, _ByteSize);  
   
             int _WhileCount = _Width * _Height;  
             int _Index = 0;  
             for (int i = 0; i != _WhileCount; i++)  
             {  
                 Color _Color = Color.FromArgb(_DataBytes[_Index + 3], _DataBytes[_Index + 2], _DataBytes[_Index + 1], _DataBytes[_Index]);  
                 if (ScanColor(_Color, p_OdlColor, p_Float))  
                 {  
                     _DataBytes[_Index + 3] = (byte)p_NewColor.A;  
                     _DataBytes[_Index + 2] = (byte)p_NewColor.R;  
                     _DataBytes[_Index + 1] = (byte)p_NewColor.G;  
                     _DataBytes[_Index] = (byte)p_NewColor.B;  
                 }  
                 _Index += 4;  
             }  
             Marshal.Copy(_DataBytes, 0, _Data.Scan0, _ByteSize);  
             _NewBmp.UnlockBits(_Data);  
             return _NewBmp;  
         }  
         /// <summary>  
         /// 设置图形颜色  坐标的颜色更换成新的色彩 （漏斗）  
         /// </summary>  
         /// <param name="p_Image">新图形</param>  
         /// <param name="p_Point">位置</param>  
         /// <param name="p_NewColor">新的色彩</param>  
         /// <param name="p_Float">溶差</param>  
         /// <returns>清理后的图形</returns>  
         public static Image SetImageColorPoint(Image p_Image, Point p_Point, Color p_NewColor, int p_Float)  
         {  
             int _Width = p_Image.Width;  
             int _Height = p_Image.Height;  
   
             if (p_Point.X > _Width - 1) return p_Image;  
             if (p_Point.Y > _Height - 1) return p_Image;  
   
             Bitmap _SS = (Bitmap)p_Image;  
             Color _Scolor = _SS.GetPixel(p_Point.X, p_Point.Y);  
             Bitmap _NewBmp = new Bitmap(_Width, _Height, PixelFormat.Format32bppArgb);  
             Graphics _Graphics = Graphics.FromImage(_NewBmp);  
             _Graphics.DrawImage(p_Image, new Rectangle(0, 0, _Width, _Height));  
             _Graphics.Dispose();  
   
             BitmapData _Data = _NewBmp.LockBits(new Rectangle(0, 0, _Width, _Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);  
             _Data.PixelFormat = PixelFormat.Format32bppArgb;  
             int _ByteSize = _Data.Stride * _Height;  
             byte[] _DataBytes = new byte[_ByteSize];  
             Marshal.Copy(_Data.Scan0, _DataBytes, 0, _ByteSize);  
   
   
             int _Index = (p_Point.Y * _Data.Stride) + (p_Point.X * 4);  
   
             Color _OldColor = Color.FromArgb(_DataBytes[_Index + 3], _DataBytes[_Index + 2], _DataBytes[_Index + 1], _DataBytes[_Index]);  
   
             if (_OldColor.Equals(p_NewColor)) return p_Image;  
             Stack<Point> _ColorStack = new Stack<Point>(1000);  
             _ColorStack.Push(p_Point);  
   
             _DataBytes[_Index + 3] = (byte)p_NewColor.A;  
             _DataBytes[_Index + 2] = (byte)p_NewColor.R;  
             _DataBytes[_Index + 1] = (byte)p_NewColor.G;  
             _DataBytes[_Index] = (byte)p_NewColor.B;  
   
             do  
             {  
                 Point _NewPoint = (Point)_ColorStack.Pop();  
   
                 if (_NewPoint.X > 0) SetImageColorPoint(_DataBytes, _Data.Stride, _ColorStack, _NewPoint.X - 1, _NewPoint.Y, _OldColor, p_NewColor, p_Float);  
                 if (_NewPoint.Y > 0) SetImageColorPoint(_DataBytes, _Data.Stride, _ColorStack, _NewPoint.X, _NewPoint.Y - 1, _OldColor, p_NewColor, p_Float);  
   
                 if (_NewPoint.X < _Width - 1) SetImageColorPoint(_DataBytes, _Data.Stride, _ColorStack, _NewPoint.X + 1, _NewPoint.Y, _OldColor, p_NewColor, p_Float);  
                 if (_NewPoint.Y < _Height - 1) SetImageColorPoint(_DataBytes, _Data.Stride, _ColorStack, _NewPoint.X, _NewPoint.Y + 1, _OldColor, p_NewColor, p_Float);  
   
             }  
             while (_ColorStack.Count > 0);  
   
             Marshal.Copy(_DataBytes, 0, _Data.Scan0, _ByteSize);  
             _NewBmp.UnlockBits(_Data);  
             return _NewBmp;  
         }  
         /// <summary>  
         /// SetImageColorPoint 循环调用 检查新的坐标是否符合条件 符合条件会写入栈p_ColorStack 并更改颜色  
         /// </summary>  
         /// <param name="p_DataBytes">数据区</param>  
         /// <param name="p_Stride">行扫描字节数</param>  
         /// <param name="p_ColorStack">需要检查的位置栈</param>  
         /// <param name="p_X">位置X</param>  
         /// <param name="p_Y">位置Y</param>  
         /// <param name="p_OldColor">老色彩</param>  
         /// <param name="p_NewColor">新色彩</param>  
         /// <param name="p_Float">溶差</param>  
         private static void SetImageColorPoint(byte[] p_DataBytes, int p_Stride, Stack<Point> p_ColorStack, int p_X, int p_Y, Color p_OldColor, Color p_NewColor, int p_Float)  
         {  
   
             int _Index = (p_Y * p_Stride) + (p_X * 4);  
             Color _OldColor = Color.FromArgb(p_DataBytes[_Index + 3], p_DataBytes[_Index + 2], p_DataBytes[_Index + 1], p_DataBytes[_Index]);  
   
             if (ScanColor(_OldColor, p_OldColor, p_Float))  
             {  
                 p_ColorStack.Push(new Point(p_X, p_Y));  
   
                 p_DataBytes[_Index + 3] = (byte)p_NewColor.A;  
                 p_DataBytes[_Index + 2] = (byte)p_NewColor.R;  
                 p_DataBytes[_Index + 1] = (byte)p_NewColor.G;  
                 p_DataBytes[_Index] = (byte)p_NewColor.B;  
             }  
         }  
   
         /// <summary>  
         /// 检查色彩(可以根据这个更改比较方式  
         /// </summary>  
         /// <param name="p_CurrentlyColor">当前色彩</param>  
         /// <param name="p_CompareColor">比较色彩</param>  
         /// <param name="p_Float">溶差</param>  
         /// <returns></returns>  
         private static bool ScanColor(Color p_CurrentlyColor, Color p_CompareColor, int p_Float)  
         {  
             int _R = p_CurrentlyColor.R;  
             int _G = p_CurrentlyColor.G;  
             int _B = p_CurrentlyColor.B;  
   
             return (_R <= p_CompareColor.R + p_Float && _R >= p_CompareColor.R - p_Float) && (_G <= p_CompareColor.G + p_Float && _G >= p_CompareColor.G - p_Float) && (_B <= p_CompareColor.B + p_Float && _B >= p_CompareColor.B - p_Float);  
   
         }  
         #endregion 

         #region 保存条码的图片质量要好
        public static void SaveCoderPic(Image image, string path)
        {
            try
            {
                ((Bitmap)image).SetResolution(350f, 350f);//设置图片打印的dpi
                ImageCodecInfo myImageCodecInfo;
                EncoderParameters myEncoderParameters;
                myImageCodecInfo = ImageHelper.GetCodecInfo("image/jpeg");
                myEncoderParameters = new EncoderParameters(2);
                myEncoderParameters.Param[0] = new EncoderParameter(Encoder.Quality, (long)100);
                myEncoderParameters.Param[1] = new EncoderParameter(Encoder.ColorDepth, (long)ColorDepth.Depth32Bit);
                image.Save(path, myImageCodecInfo, myEncoderParameters);
                image.Dispose();
            }
            catch (System.Exception e)
            {
                log.Fatal(e);
            }
        }
            #endregion

         public static void SaveOneInchPic(Image image,Color transColor,float dpi, string path)
        {
            try
            {
                image = image.Clone() as Image;
                
                ((Bitmap)image).SetResolution(dpi, dpi);//设置图片打印的dpi
               // if (transColor != SystemColors.Control)
                //{
                    //((Bitmap)image).MakeTransparent(transColor);
                    //ImageHelper.SetImageColorBrim(image,Color.Black,Color.White,0);
               // }
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
        /// 保存为JPEG格式，支持压缩质量选项
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
