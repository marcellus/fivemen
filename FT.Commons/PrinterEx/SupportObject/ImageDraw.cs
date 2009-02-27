using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace FT.Commons.PrinterEx.SupportObject
{
    /// <summary>
    /// �ɻ�ͼ��ͼƬ�������û�ж���ͼƬ�ĸ߶Ȼ��߿�ȣ���ô��ʹ��ͼƬ��ԭʼ��С���л�ͼ
    /// ͼƬĬ��û�б߿�
    /// </summary>
    public class ImageDraw:BaseDraw
    {
        private Image image;

        public Image Image
        {
            get { return image; }
            set { image = value; }
        }

        private int width;

        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        private int height;

        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        public ImageDraw( Rectangle rec, Image image)
            : base(rec)
        {
            this.width = image.Width;
            this.height = image.Height;
            this.Rectangle = new Rectangle(this.Rectangle.X, this.Rectangle.Y, this.width, this.height);
            this.Border = BordersEdgeStyle.None;
            this.image = image;
        }



        protected override void DrawContent(Graphics graphics)
        {
           graphics.DrawImage(image, this.Rectangle);
            //throw new Exception("The method or operation is not implemented.");
        }

        public override bool IsFinish()
        {
            return true;
        }
    }
}
