using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FT.Windows.Controls
{
    public partial class SimpleLine : Control
    {
        public SimpleLine()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.UserPaint, true);
            //this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            Rectangle rec = pe.ClipRectangle;
            pe.Graphics.DrawLine(Pens.Black, 0,  rec.Height/2,
                 rec.Width, rec.Height/2);
            //pe.Graphics.DrawLine(Pens.Black, new Point(0, 100), new Point(100, 100)); 
           // pe.Graphics.DrawString("test",new Font("宋体",9),Brushes.Black,rec);
            pe.Graphics.Flush();
        }
    }
}
