using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace FT.Commons.Print
{
    /// <summary>
    /// 对象打印类，打印某一个对象继承该类
    /// </summary>
    public abstract class ObjectPrinter:IPrinter
    {
        [NonSerialized]
        protected static Pen dashedPen=new Pen(Color.Black);

        [NonSerialized]
        protected static int lineHeight=40;


        static ObjectPrinter()
        {
            dashedPen.DashStyle=System.Drawing.Drawing2D.DashStyle.Dot;
        }
        private int current=1;

        private Graphics myGraphics = null;

        /// <summary>
        /// 子类必须设置
        /// </summary>

        protected Graphics MyGraphics
        {
            get { return myGraphics; }
            set { myGraphics = value; }
        }

        #region IPrinter 成员

        /// <summary>
        /// 获取打印的当前页，一个对象也许可以分多页打印
        /// </summary>
        /// <returns>当前页数</returns>
        public int GetCurrentPage()
        {
            return current;
        }

        /// <summary>
        /// 获取一个打印对象能打印多少页，子类必须继承
        /// </summary>
        /// <returns></returns>
        public abstract int GetTotalPage();
        /// <summary>
        /// 如果有多页，next则对当前对象页数进行加一
        /// </summary>
        public void Next()
        {
            if (current < this.GetTotalPage())
            {
                current++;
            }
        }

        /// <summary>
        /// 判断是否有更多的页
        /// </summary>
        /// <returns><c>true</c> 如果有更多的页; 否则, <c>false</c>.</returns>
        public bool HasMorePage()
        {
            return this.current < this.GetTotalPage();
        }

        /// <summary>
        /// 最后一页
        /// </summary>
        public void ToLastPage()
        {
            this.current = this.GetTotalPage();
        }

        /// <summary>
        /// 第一页
        /// </summary>
        public void ToFirstPage()
        {
            this.current = 1;
        }

        /// <summary>
        /// 上一页
        /// </summary>
        public void Preview()
        {
            if (this.current > 1)
            {
                this.current--;
            }
        }

        /// <summary>
        /// 打印出实例当前页的图片
        /// </summary>
        /// <returns>当前页生成的图片</returns>
        public abstract System.Drawing.Image Paint();


        /// <summary>
        /// 输出当前实力到graphics上，供打印机调用
        /// </summary>
        /// <returns>打印使用</returns>
        public abstract void PaintPrinter();

        /// <summary>
        /// 黑色钢笔，绘制曲线或直线用
        /// </summary>
        [NonSerialized]
        protected static Pen blackPen = new Pen(Color.Black);

        /// <summary>
        /// 第一标题字体
        /// </summary>
        [NonSerialized]
        protected static Font h1Font = new Font("宋体", 14,FontStyle.Bold);

        /// <summary>
        /// 第二标题字体
        /// </summary>
        [NonSerialized]
        protected static Font h2Font = new Font("宋体", 12, FontStyle.Bold);

        /// <summary>
        /// 第三标题字体
        /// </summary>
        [NonSerialized]
        protected static Font h3Font = new Font("宋体", 10, FontStyle.Bold);

        /// <summary>
        /// 大小为12的body字体
        /// </summary>
        [NonSerialized]
        protected static Font body12Font = new Font("宋体", 12);

        /// <summary>
        /// 大小为9的body字体
        /// </summary>
        [NonSerialized]
        protected static Font body9Font = new Font("宋体", 9);

        /// <summary>
        /// 大小为10的body字体
        /// </summary>
        [NonSerialized]
        protected static Font body10Font = new Font("宋体", 10);

        /// <summary>
        /// 大小为11的body字体
        /// </summary>
        [NonSerialized]
        protected static Font body11Font = new Font("宋体", 11);

        /// <summary>
        /// 大小为13的body字体
        /// </summary>
        [NonSerialized]
        protected static Font body13Font = new Font("宋体", 13);

        /// <summary>
        /// 大小为14的body字体
        /// </summary>
        [NonSerialized]
        protected static Font body14Font = new Font("宋体", 14);

        /// <summary>
        /// 大小为15的body字体
        /// </summary>
        [NonSerialized]
        protected static Font body15Font = new Font("宋体", 15);

        /// <summary>
        /// 黑色笔刷
        /// </summary>
        [NonSerialized]
        protected static SolidBrush blackBrush = new SolidBrush(Color.Black);


        /// <summary>
        /// 获取单个汉字的宽度
        /// </summary>
        /// <param name="graphics">graphics对象</param>
        /// <param name="font">字体</param>
        /// <returns>单个汉字的宽度</returns>
        protected float GetSingleChineseWidth(Font font)
        {
            //if (chineseWidth <= 0)
             return myGraphics.MeasureString("测", font).Width;
           
        }

        /// <summary>
        /// 获取单个汉字的长度
        /// </summary>
        /// <param name="graphics">graphics对象</param>
        /// <param name="font">字体</param>
        /// <returns>单个汉字的长度</returns>
        protected float GetSingleChineseHeight(Font font)
        {
            return myGraphics.MeasureString("测", font).Height;
        }

        [NonSerialized]
        private const int checkBoxWidth=15;

        /// <summary>
        /// Draws the check box.
        /// </summary>
        /// <param name="p">The p.</param>
        /// <param name="check">if set to <c>true</c> [check].</param>
        protected void DrawCheckBox(Point p, bool check)
        {

            myGraphics.DrawRectangle(blackPen, p.X, p.Y, checkBoxWidth, checkBoxWidth);
            if (check)
            {
                myGraphics.DrawLine(blackPen, p.X, p.Y + checkBoxWidth / 2, p.X + checkBoxWidth / 2, p.Y + checkBoxWidth);
                myGraphics.DrawLine(blackPen, p.X + checkBoxWidth / 2, p.Y + checkBoxWidth, p.X + checkBoxWidth, p.Y + 1);
            }
        }
        [NonSerialized]
        private const int dashedRecWidth=30;


        /// <summary>
        /// Draws the dashed.
        /// </summary>
        /// <param name="p">The p.</param>
        protected void DrawDashed(Point p)
        {
            myGraphics.DrawRectangle(dashedPen, p.X, p.Y, dashedRecWidth, dashedRecWidth);
        }

        /// <summary>
        /// Draw12s the string.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="p">The p.</param>
        protected void Draw12String(string text,Point p)
        {
            DrawStringHor(text, body12Font, p);
        }

        /// <summary>
        /// Draw9s the string.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="p">The p.</param>
        protected void Draw9String(string text, Point p)
        {
            DrawStringHor(text, body9Font, p);
        }

        protected void Draw10String(string text, Point p)
        {
            DrawStringHor(text, body10Font, p);
        }

        protected void Draw11String(string text, Point p)
        {
            DrawStringHor(text, body11Font, p);
        }

        protected void Draw13String(string text, Point p)
        {
            DrawStringHor(text, body13Font, p);
        }

        protected void Draw14String(string text, Point p)
        {
            DrawStringHor(text, body14Font, p);
        }

        protected void Draw15String(string text, Point p)
        {
            DrawStringHor(text, body15Font, p);
        }

        /// <summary>
        /// Draws the string ver.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="font">The font.</param>
        /// <param name="p">The p.</param>
        protected void DrawStringVer(string text,Font font, Point p)
        {
            RectangleF drawRectStr = new RectangleF(p.X,p.Y, this.GetSingleChineseWidth(font), this.GetSingleChineseHeight(font)*text.Length);
            MyGraphics.DrawString(text, font, blackBrush, drawRectStr);
        }

        /// <summary>
        /// Draws the string ver.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="font">The font.</param>
        /// <param name="p">The p.</param>
        protected void DrawStringVerAndHor(string text, Font font, Point p)
        {
            //int height = (int)this.GetSingleChineseHeight(font);
            //int width=(int)this.GetSingleChineseWidth(font);

           // MyGraphics.TranslateTransform(50.0f,50.0f);
            MyGraphics.RotateTransform(90);                    //<---
            MyGraphics.DrawString(text, font, Brushes.Black, p);
            MyGraphics.ResetTransform();
            //StringFormat sf = new StringFormat();
            //sf.FormatFlags = StringFormatFlags.DirectionVertical;
            //MyGraphics.DrawString("一二三四", font, Brushes.Blue, p, sf); 


           // StringFormat   sf=new   StringFormat(StringFormatFlags.DirectionRightToLeft);  
           // RectangleF drawRectStr = new RectangleF(p.X, p.Y, this.GetSingleChineseWidth(font), height* text.Length);
           // MyGraphics.DrawString(text, font, blackBrush, drawRectStr, sf);
            /*
            for (int i = 0; i < text.Length; i++)
            {
                MyGraphics.DrawString(text[i].ToString(), font, blackBrush,new RectangleF(p.X,p.Y+height*i,height,width),sf);
            }
             * */
            //myGraphics.DrawString(
                
        }

        /// <summary>
        /// Draws the string ver.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="font">The font.</param>
        /// <param name="p">The p.</param>
        protected void DrawImageVerAndHor(string path,  Point p)
        {
            MyGraphics.RotateTransform(90);                    //<---
            //MyGraphics.DrawString(text, font, Brushes.Black, p);
            myGraphics.DrawImage(Image.FromFile(path), p);
            MyGraphics.ResetTransform();
            

        }

        /// <summary>
        /// 画出水平的字符串
        /// </summary>
        /// <param name="text">需要描绘的字符串</param>
        /// <param name="font">字体</param>
        /// <param name="p">起始坐标</param>
        protected void DrawStringHor(string text, Font font, Point p)
        {
            MyGraphics.DrawString(text, font, blackBrush, p);
        }

        /// <summary>
        /// 画出水平的字符串
        /// </summary>
        /// <param name="text">需要描绘的字符串</param>
        /// <param name="font">字体</param>
        /// <param name="p">起始坐标</param>
        protected void DrawCompany(string text, Point p)
        {
            MyGraphics.DrawString(text, new Font("黑体", 12), blackBrush, p);
        }

        

       /* protected void PaintString(System.Drawing.Graphics graphics,string text)
        {
            Point ulCorner = new Point(100, 100);
            Point urCorner = new Point(550, 100);
            Point llCorner = new Point(100, 1000);
            Point[] destPara = { ulCorner, urCorner, llCorner };
            graphics.DrawImage(this.Paint(), destPara);
            // Create string to draw.
            String drawString = "申请人信息";

            SizeF size=graphics.MeasureString(drawString, h1Font);
           

            // Create rectangle for drawing.
            float x = 150.0F;
            float y = 150.0F;
            float width = 50.0F;
            float height = 200.0F;
            RectangleF drawRect = new RectangleF(x, y, width, height);
            RectangleF drawRectStr = new RectangleF(x+(width-size.Width)/2, y+(height-size.Height)/2, size.Width, size.Height);

            // Draw rectangle to screen.
            graphics.DrawRectangle(blackPen, x, y, width, height);

            // Draw string to screen.
            graphics.DrawString(drawString, h1Font, blackBrush, drawRectStr);

        }
        * */

        /// <summary>
        /// 打印主要使用的方法
        /// </summary>
        /// <param name="graphics">高质量化</param>
        public void Paint(Graphics graphics)
        {
            this.MyGraphics = graphics;
            MyGraphics.CompositingQuality = CompositingQuality.HighQuality;
            MyGraphics.SmoothingMode = SmoothingMode.HighQuality;
            MyGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            MyGraphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            this.PaintPrinter();
        }

        #endregion



        #region IPrinter 成员


        public string GetDocName()
        {
            return "打印机压力测试页";
        }



        #endregion
    }
}
