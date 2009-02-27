using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace FT.Commons.PrinterEx.SupportObject
{
    /// <summary>
    /// 单个可绘图对象，默认有四边边框
    /// 背景色，默认白色
    /// 边框颜色，文字格式使用打印配置静态变量，可在一个应用程序启动的时候进行初始化
    /// </summary>
    public abstract class BaseDraw:IDraw
    {


        /// <summary>
        /// 默认的边框样式为all
        /// </summary>
        private BordersEdgeStyle border = PrintCommonSetting.Default_Border_Style;

        /// <summary>
        /// 默认的边框的样式
        /// </summary>
        public BordersEdgeStyle Border
        {
          get { return border; }
          set { border = value; }
        }

        

        private Rectangle rectangle;

        /// <summary>
        /// 可打印的矩形范围
        /// </summary>
        public Rectangle Rectangle
        {
            get { return rectangle; }
            set { rectangle = value; }
        }

        private Pen fontPen = PrintCommonSetting.Default_Font_Pen;

        public Pen FontPen
        {
            get { return fontPen; }
            set { fontPen = value; }
        }

        private Pen borderPen = PrintCommonSetting.Default_Border_Pen;

        public Pen BorderPen
        {
            get { return borderPen; }
            set { borderPen = value; }
        }


        private Color bgColor= Color.White;

        public Color BgColor
        {
            get { return bgColor; }
            set { bgColor = value; }
        }

        /// <summary>
		/// 画矩形左端线
		/// </summary>
		/// <param name="g"></param>
		/// <param name="rec"></param>
		protected void DrawLeftLine(Graphics g,Pen pen,Rectangle rec)
		{
			int X = rec.Left;
			int Y1 = rec.Top;
			int Y2 = rec.Bottom;
           //this.rectangle.Height = 100;
			//画网格左端横线
			g.DrawLine(pen,X,Y1,X,Y2);
		}

		/// <summary>
		/// 画矩形右端线
		/// </summary>
		/// <param name="g"></param>
		/// <param name="rec"></param>
		protected void DrawRightLine(Graphics g,Pen pen,Rectangle rec)
		{
			int X = rec.Right;
			int Y1 = rec.Top;
			int Y2 = rec.Bottom;

			//画网格右端横线
			g.DrawLine(pen,X,Y1,X,Y2);
		}

		/// <summary>
		/// 画矩形顶端线
		/// </summary>
		/// <param name="g"></param>
		/// <param name="rec"></param>
		protected void DrawTopLine(Graphics g,Pen pen,Rectangle rec)
		{
			int X1 = rec.Left;
			int X2 = rec.Right;
			int Y = rec.Top;

			//画网格顶端横线
			g.DrawLine(pen,X1,Y,X2,Y);
		}

		/// <summary>
		/// 画矩形底端线
		/// </summary>
		/// <param name="g"></param>
		/// <param name="rec"></param>
		protected void DrawBottomLine(Graphics g,Pen pen,Rectangle rec)
		{
			int X1 = rec.Left;
			int X2 = rec.Right;
			int Y = rec.Bottom;

			//画网格底端横线
			g.DrawLine(pen,X1,Y,X2,Y);
		}

		/// <summary>
		/// 画左上角到右下角的对角线
		/// </summary>
		/// <param name="g"></param>
		/// <param name="rec"></param>
		protected void DrawDiagonalDownLine(Graphics g,Pen pen,Rectangle rec)
		{
			int X1 = rec.X;			//左上角坐标
			int Y1 = rec.Y;
			int X2 = rec.Right;		//右下角
			int Y2 = rec.Bottom;

			//画网格底端横线
			g.DrawLine(pen,X1,Y1,X2,Y2);
		}

		/// <summary>
		/// 画左下角到右上角的对角线
		/// </summary>
		/// <param name="g"></param>
		/// <param name="rec"></param>
		protected void DrawDiagonalUpLine(Graphics g,Pen pen,Rectangle rec)
		{
			int X1 = rec.X;			//左下角坐标
			int Y1 = rec.Bottom;
			int X2 = rec.Right;		//右下角
			int Y2 = rec.Top;
            //this.Rectangle.Width = 100;
			//画网格底端横线
			g.DrawLine(pen,X1,Y1,X2,Y2);
		}

		protected void DrawBackColor(Graphics g,Brush brush,Rectangle rec)
		{
			//填充矩形
			g.FillRectangle(brush,rec);
		}

        public BaseDraw()
        {
        }


        /// <summary>
        /// 至少要设置一个打印范围
        /// </summary>
        /// <param name="rec"></param>
        public BaseDraw(Rectangle rec)
        {
            this.rectangle = rec;
        }

        public Point ConvertPoint(Decimal x, Decimal y)
        {
            return new Point(ConvertPixel(x), ConvertPixel(y));
        }

        /// <summary>
        /// 把像素转换成厘米
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public int ConvertPixel(decimal x)
        {
            return (int)(x * 0.3937m * 100);
        }




        #region IDraw 成员

        /// <summary>
        /// 子类必须继承能绘画内容的对象
        /// </summary>
        protected abstract void DrawContent(Graphics graphics);

        public  void Draw(Graphics graphics)
        {
            if (graphics == null || this.rectangle == null)
            {
                throw new ArgumentException("打印异常，没有设置graphics或者rec！");
            }
            this.DrawContent(graphics);
            switch (this.border)
            {
                case BordersEdgeStyle.Left:
                    DrawLeftLine(graphics, this.borderPen, this.rectangle);
                    break;
                case BordersEdgeStyle.Right:
                    DrawRightLine(graphics, this.borderPen, this.rectangle);
                    break;
                case BordersEdgeStyle.Top:
                    DrawTopLine(graphics, this.borderPen, this.rectangle);
                    break;
                case BordersEdgeStyle.Bottom:
                    DrawBottomLine(graphics, this.borderPen, this.rectangle);
                    break;
                case BordersEdgeStyle.DiagonalDown:
                    DrawDiagonalDownLine(graphics, this.borderPen, this.rectangle);
                    break;
                case BordersEdgeStyle.DiagonalUp:
                    DrawDiagonalUpLine(graphics, this.borderPen, this.rectangle);
                    break;
                case BordersEdgeStyle.None:
                    break;
                default:	//默认绘画四边
                    graphics.DrawRectangle(this.borderPen, rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
                    break;
            }

            //只有改变颜色才画背景
            if (this.bgColor!= Color.White)
            {
                graphics.FillRectangle(new SolidBrush(this.bgColor),this.rectangle);
            }
        }

        #endregion

        #region IDraw 成员

        /// <summary>
        /// 计算是否需要分页由组合打印对象计算，单个打印对象不进行计算
        /// </summary>
        /// <returns>如果返回false就需要分页打印</returns>
        public abstract bool IsFinish();

        #endregion
    }
}
