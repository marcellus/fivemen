using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Drawing.Drawing2D;

namespace FT.Commons.Tools
{
    public class ImageHelper:BaseHelper
    {
        public static Bitmap SetBlur(Bitmap bitmap)
        {

            if (bitmap == null)
            {
                return null;
            }

            int width = bitmap.Width;
            int height = bitmap.Height;

            try
            {
                Bitmap bmpReturn = new Bitmap(width, height, PixelFormat.Format24bppRgb);
                BitmapData srcBits = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                BitmapData targetBits = bmpReturn.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);

                unsafe
                {
                    byte* pSrcBits = (byte*)srcBits.Scan0.ToPointer();
                    byte* pTargetBits = (byte*)targetBits.Scan0.ToPointer();
                    int stride = srcBits.Stride;
                    byte* pTemp;

                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            if (x == 0 || x == width - 1 || y == 0 || y == height - 1)
                            {
                                //最边上的像素不处理
                                pTargetBits[0] = pSrcBits[0];
                                pTargetBits[1] = pSrcBits[1];
                                pTargetBits[2] = pSrcBits[2];
                            }
                            else
                            {
                                //取周围9点的值
                                int r1, r2, r3, r4, r5, r6, r7, r8, r9;
                                int g1, g2, g3, g4, g5, g6, g7, g8, g9;
                                int b1, b2, b3, b4, b5, b6, b7, b8, b9;

                                float fR, fG, fB;

                                //左上
                                pTemp = pSrcBits - stride - 3;
                                r1 = pTemp[2];
                                g1 = pTemp[1];
                                b1 = pTemp[0];

                                //正上
                                pTemp = pSrcBits - stride;
                                r2 = pTemp[2];
                                g2 = pTemp[1];
                                b2 = pTemp[0];

                                //右上
                                pTemp = pSrcBits - stride + 3;
                                r3 = pTemp[2];
                                g3 = pTemp[1];
                                b3 = pTemp[0];

                                //左侧
                                pTemp = pSrcBits - 3;
                                r4 = pTemp[2];
                                g4 = pTemp[1];
                                b4 = pTemp[0];

                                //右侧
                                pTemp = pSrcBits + 3;
                                r5 = pTemp[2];
                                g5 = pTemp[1];
                                b5 = pTemp[0];

                                //右下
                                pTemp = pSrcBits + stride - 3;
                                r6 = pTemp[2];
                                g6 = pTemp[1];
                                b6 = pTemp[0];

                                //正下
                                pTemp = pSrcBits + stride;
                                r7 = pTemp[2];
                                g7 = pTemp[1];
                                b7 = pTemp[0];

                                //右下
                                pTemp = pSrcBits + stride + 3;
                                r8 = pTemp[2];
                                g8 = pTemp[1];
                                b8 = pTemp[0];

                                //自己
                                pTemp = pSrcBits;
                                r9 = pTemp[2];
                                g9 = pTemp[1];
                                b9 = pTemp[0];

                                fR = (float)(r1 + r2 + r3 + r4 + r5 + r6 + r7 + r8 + r9);
                                fG = (float)(g1 + g2 + g3 + g4 + g5 + g6 + g7 + g8 + g9);
                                fB = (float)(b1 + b2 + b3 + b4 + b5 + b6 + b7 + b8 + b9);

                                fR /= 9;
                                fG /= 9;
                                fB /= 9;

                                pTargetBits[0] = (byte)fB;
                                pTargetBits[1] = (byte)fG;
                                pTargetBits[2] = (byte)fR;

                            }

                            pSrcBits += 3;
                            pTargetBits += 3;
                        }

                        pSrcBits += srcBits.Stride - width * 3;
                        pTargetBits += srcBits.Stride - width * 3;
                    }
                }

                bitmap.UnlockBits(srcBits);
                bmpReturn.UnlockBits(targetBits);

                return bmpReturn;
            }
            catch
            {
                return null;
            }

        }

        /// <summary>

        /// 将图像按 3X3 窗口进行卷积转换

        /// </summary>

        /// <param name="srcImage">位图流</param>

        /// <returns></returns>

        public static Bitmap Convolute(Bitmap srcImage)
        {
            return null;
            /*
            // 避免被零除
            int scale = 0;
            if (scale == 0) scale = 1;

            int width = srcImage.Width;

            int height = srcImage.Height;

            Bitmap dstImage = (Bitmap)srcImage.Clone();

            BitmapData srcData = srcImage.LockBits(new Rectangle(0, 0, width, height),

              ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            BitmapData dstData = dstImage.LockBits(new Rectangle(0, 0, width, height),

              ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            // 图像实际处理区域

            // 图像最外围一圈不处理

            int rectTop = 1;

            int rectBottom = height - 1;

            int rectLeft = 1;

            int rectRight = width - 1;

            unsafe
            {

                byte* src = (byte*)srcData.Scan0;

                byte* dst = (byte*)dstData.Scan0;

                int stride = srcData.Stride;

                int offset = stride - width * BPP;

                int pixel = 0;

                // 移向第一行

                src += stride;

                dst += stride;

                for (int y = rectTop; y < rectBottom; y++)
                {

                    // 移向每行第一列

                    src += BPP;

                    dst += BPP;

                    for (int x = rectLeft; x < rectRight; x++)
                    {

                        // 如果当前像素为透明色，则跳过不处理

                        if (src[3] > 0)
                        {

                            // 处理 B, G, R 三分量

                            for (int i = 0; i < 3; i++)
                            {

                                pixel =

                                  src[i - stride - BPP] * topLeft +

                                  src[i - stride] * topMid +

                                  src[i - stride + BPP] * topRight +

                                  src[i - BPP] * midLeft +

                                  src[i] * center +

                                  src[i + BPP] * midRight +

                                  src[i + stride - BPP] * bottomLeft +

                                  src[i + stride] * bottomMid +

                                  src[i + stride + BPP] * bottomRight;

                                pixel = pixel / scale + kernelOffset;

                                if (pixel < 0) pixel = 0;

                                if (pixel > 255) pixel = 255;

                                dst[i] = (byte)pixel;

                            } // i

                        }

                        // 向后移一像素

                        src += BPP;

                        dst += BPP;

                    } // x

                    // 移向下一行

                    // 这里得注意要多移一列，因最右列不处理

                    src += (offset + BPP);

                    dst += (offset + BPP);

                } // y

            }

            srcImage.UnlockBits(srcData);

            dstImage.UnlockBits(dstData);

            srcImage.Dispose();

            return dstImage;
             * */

        } // end of Convolute

        public static void SetSmoothFont(Graphics g)
        {
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            g.SmoothingMode = SmoothingMode.HighQuality;
        }

        public static byte[] GetBytesByImage(Image bp)
        {
            byte[] photo_byte = null;
            using (MemoryStream ms = new MemoryStream())
            {
                Bitmap bmp = new Bitmap(bp);
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                photo_byte = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(photo_byte, 0, Convert.ToInt32(ms.Length));
                bmp.Dispose();
            }

            return photo_byte;
        }
        public static Image GetImageByBytes(byte[] bytes)
        {
            Image photo = null;
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                ms.Write(bytes, 0, bytes.Length);
                photo = Image.FromStream(ms, true);
            }

            return photo;
        }

        
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


        public static Image CaptureControl(Control ctr)
        {
            Screen scr = Screen.PrimaryScreen;
            Rectangle rc = scr.Bounds;
            int iWidth = rc.Width;
            int iHeight = rc.Height;
            //创建一个和屏幕一样大的Bitmap

            Image bmp = new Bitmap(ctr.Width, ctr.Height);
            //从一个继承自Image类的对象中创建Graphics对象

            Graphics g = Graphics.FromImage(bmp);
            //抓屏并拷贝到myimage里

            g.CopyFromScreen(ctr.PointToScreen(new Point(0, 0)), new Point(0, 0), new Size(ctr.Width, ctr.Height));

            //bmp.Save("final.jpg");
            g.Dispose();
            return bmp;
        }
 
       
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
         public static Image ClearWhiteToTransparent(Image Img)
         {
            return SetImageColorAll(Img, Color.White, Color.Transparent, 0);
         }
         public static Image ClearBlackToTransparent(Image Img)
         {
             return SetImageColorAll(Img, Color.Black, Color.Transparent, 0);
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
               // myImageCodecInfo = null;
                myEncoderParameters = new EncoderParameters(2);
                myEncoderParameters.Param[0] = new EncoderParameter(Encoder.Quality, (long)100);
                myEncoderParameters.Param[1] = new EncoderParameter(Encoder.ColorDepth, (long)ColorDepth.Depth32Bit);
                image.Save(path, myImageCodecInfo, myEncoderParameters);
               // image.c;
                image.Dispose();
                log.Debug("保存条码图片成功！");
            }
            catch (System.Exception e)
            {
                log.Fatal(e);
                MessageBoxHelper.Show("图片正在使用中，请重新打印！");
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

        /// Resize图片
        /// </summary>
        /// <param name="bmp">原始Bitmap</param>
        /// <param name="newW">新的宽度</param>
        /// <param name="newH">新的高度</param>
        /// <param name="Mode">保留着，暂时未用</param>
        /// <returns>处理以后的图片</returns>
        public static Bitmap KiResizeImage(Bitmap bmp, int newW, int newH, int Mode)
        {
            try
            {
                Bitmap b = new Bitmap(newW, newH);
                Graphics g = Graphics.FromImage(b);

                // 插值算法的质量
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;

                g.DrawImage(bmp, new Rectangle(0, 0, newW, newH), new Rectangle(0, 0, bmp.Width, bmp.Height), GraphicsUnit.Pixel);
                g.Dispose();

                return b;
            }
            catch
            {
                return null;
            }
        }


        // ===============================

        /// <summary>
        /// 剪裁 -- 用GDI+
        /// </summary>
        /// <param name="b">原始Bitmap</param>
        /// <param name="StartX">开始坐标X</param>
        /// <param name="StartY">开始坐标Y</param>
        /// <param name="iWidth">宽度</param>
        /// <param name="iHeight">高度</param>
        /// <returns>剪裁后的Bitmap</returns>
        public static Bitmap KiCut(Bitmap b, int StartX, int StartY, int iWidth, int iHeight)
        {
            if (b == null)
            {
                return null;
            }

            int w = b.Width;
            int h = b.Height;

            if (StartX >= w || StartY >= h)
            {
                return null;
            }

            if (StartX + iWidth > w)
            {
                iWidth = w - StartX;
            }

            if (StartY + iHeight > h)
            {
                iHeight = h - StartY;
            }

            try
            {
                Bitmap bmpOut = new Bitmap(iWidth, iHeight, PixelFormat.Format24bppRgb);

                Graphics g = Graphics.FromImage(bmpOut);
                g.DrawImage(b, new Rectangle(0, 0, iWidth, iHeight), new Rectangle(StartX, StartY, iWidth, iHeight), GraphicsUnit.Pixel);
                g.Dispose();

                return bmpOut;
            }
            catch
            {
                return null;
            }
        }


    }
}
