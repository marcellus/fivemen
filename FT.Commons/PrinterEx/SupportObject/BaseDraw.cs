using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace FT.Commons.PrinterEx.SupportObject
{
    /// <summary>
    /// �����ɻ�ͼ����Ĭ�����ı߱߿�
    /// ����ɫ��Ĭ�ϰ�ɫ
    /// �߿���ɫ�����ָ�ʽʹ�ô�ӡ���þ�̬����������һ��Ӧ�ó���������ʱ����г�ʼ��
    /// </summary>
    public abstract class BaseDraw:IDraw
    {


        /// <summary>
        /// Ĭ�ϵı߿���ʽΪall
        /// </summary>
        private BordersEdgeStyle border = PrintCommonSetting.Default_Border_Style;

        /// <summary>
        /// Ĭ�ϵı߿����ʽ
        /// </summary>
        public BordersEdgeStyle Border
        {
          get { return border; }
          set { border = value; }
        }

        

        private Rectangle rectangle;

        /// <summary>
        /// �ɴ�ӡ�ľ��η�Χ
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
		/// �����������
		/// </summary>
		/// <param name="g"></param>
		/// <param name="rec"></param>
		protected void DrawLeftLine(Graphics g,Pen pen,Rectangle rec)
		{
			int X = rec.Left;
			int Y1 = rec.Top;
			int Y2 = rec.Bottom;
           //this.rectangle.Height = 100;
			//��������˺���
			g.DrawLine(pen,X,Y1,X,Y2);
		}

		/// <summary>
		/// �������Ҷ���
		/// </summary>
		/// <param name="g"></param>
		/// <param name="rec"></param>
		protected void DrawRightLine(Graphics g,Pen pen,Rectangle rec)
		{
			int X = rec.Right;
			int Y1 = rec.Top;
			int Y2 = rec.Bottom;

			//�������Ҷ˺���
			g.DrawLine(pen,X,Y1,X,Y2);
		}

		/// <summary>
		/// �����ζ�����
		/// </summary>
		/// <param name="g"></param>
		/// <param name="rec"></param>
		protected void DrawTopLine(Graphics g,Pen pen,Rectangle rec)
		{
			int X1 = rec.Left;
			int X2 = rec.Right;
			int Y = rec.Top;

			//�����񶥶˺���
			g.DrawLine(pen,X1,Y,X2,Y);
		}

		/// <summary>
		/// �����ε׶���
		/// </summary>
		/// <param name="g"></param>
		/// <param name="rec"></param>
		protected void DrawBottomLine(Graphics g,Pen pen,Rectangle rec)
		{
			int X1 = rec.Left;
			int X2 = rec.Right;
			int Y = rec.Bottom;

			//������׶˺���
			g.DrawLine(pen,X1,Y,X2,Y);
		}

		/// <summary>
		/// �����Ͻǵ����½ǵĶԽ���
		/// </summary>
		/// <param name="g"></param>
		/// <param name="rec"></param>
		protected void DrawDiagonalDownLine(Graphics g,Pen pen,Rectangle rec)
		{
			int X1 = rec.X;			//���Ͻ�����
			int Y1 = rec.Y;
			int X2 = rec.Right;		//���½�
			int Y2 = rec.Bottom;

			//������׶˺���
			g.DrawLine(pen,X1,Y1,X2,Y2);
		}

		/// <summary>
		/// �����½ǵ����ϽǵĶԽ���
		/// </summary>
		/// <param name="g"></param>
		/// <param name="rec"></param>
		protected void DrawDiagonalUpLine(Graphics g,Pen pen,Rectangle rec)
		{
			int X1 = rec.X;			//���½�����
			int Y1 = rec.Bottom;
			int X2 = rec.Right;		//���½�
			int Y2 = rec.Top;
            //this.Rectangle.Width = 100;
			//������׶˺���
			g.DrawLine(pen,X1,Y1,X2,Y2);
		}

		protected void DrawBackColor(Graphics g,Brush brush,Rectangle rec)
		{
			//������
			g.FillRectangle(brush,rec);
		}

        public BaseDraw()
        {
        }


        /// <summary>
        /// ����Ҫ����һ����ӡ��Χ
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
        /// ������ת��������
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public int ConvertPixel(decimal x)
        {
            return (int)(x * 0.3937m * 100);
        }




        #region IDraw ��Ա

        /// <summary>
        /// �������̳��ܻ滭���ݵĶ���
        /// </summary>
        protected abstract void DrawContent(Graphics graphics);

        public  void Draw(Graphics graphics)
        {
            if (graphics == null || this.rectangle == null)
            {
                throw new ArgumentException("��ӡ�쳣��û������graphics����rec��");
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
                default:	//Ĭ�ϻ滭�ı�
                    graphics.DrawRectangle(this.borderPen, rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
                    break;
            }

            //ֻ�иı���ɫ�Ż�����
            if (this.bgColor!= Color.White)
            {
                graphics.FillRectangle(new SolidBrush(this.bgColor),this.rectangle);
            }
        }

        #endregion

        #region IDraw ��Ա

        /// <summary>
        /// �����Ƿ���Ҫ��ҳ����ϴ�ӡ������㣬������ӡ���󲻽��м���
        /// </summary>
        /// <returns>�������false����Ҫ��ҳ��ӡ</returns>
        public abstract bool IsFinish();

        #endregion
    }
}
