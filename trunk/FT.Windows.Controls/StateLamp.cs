using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FT.Windows.Controls
{
    public partial class StateLamp : Control
    {
        private const int Default_Radius = 10;

        private int radius = Default_Radius;

        /// <summary>
        /// 圆形的半径
        /// </summary>
        public int Radius
        {
            get { return radius; }
            set {
                if (value != Radius)
                {
                    this.AdjustSize(value);
                    this.Invalidate();
                }

                radius = value; }
        }

        private void AdjustSize(int radius)
        {
            //this.Width = 2 * Radius;
            //this.Height = 2 * Radius;
            this.Size = new Size(2 * radius, 2 * radius);
        }

        private bool isRunning = false;

        /// <summary>
        /// 是否允许通信，红灯停，绿灯行,为false的时候为红灯，默认红灯
        /// </summary>
        public bool IsRunning
        {
            get { return isRunning; }
            set {
                if (value != IsRunning)
                {
                    this.Invalidate();
                }
                isRunning = value; }
        }


        public StateLamp()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.AdjustSize(this.radius);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            // TODO: 在此处添加自定义绘制代码
            //base.OnPaint(pe);
            Pen pen = null;
            Brush brush=null;
            if (IsRunning)
            {
                brush=Brushes.Green;
                pen = Pens.Green;
            }
            else
            {
                brush=Brushes.Red;
                pen = Pens.Red;
            }
            //Rectangle rec=new Rectangle(this.Location, new Size(2 * Radius, 2 * Radius));
            Rectangle rec = pe.ClipRectangle;
            //pe.Graphics.DrawEllipse(pen,rec );
            pe.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            pe.Graphics.FillEllipse(brush, rec);
            //pe.Graphics.DrawString("测文本试", new Font("宋体", 9), brush, rec);
            pe.Graphics.Flush();
            // 调用基类 OnPaint
            
        }
    }
}
