using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace HiPiaoTerminal.TestForm
{
    public partial class RoundForm : Form
    {
        public RoundForm()
        {
            InitializeComponent();
        }

        public void SetWindowRegion()
        {
            System.Drawing.Drawing2D.GraphicsPath FormPath;
            FormPath = new System.Drawing.Drawing2D.GraphicsPath();
            Rectangle rect = new Rectangle(0, 22, this.Width, this.Height - 22);//this.Left-10,this.Top-10,this.Width-10,this.Height-10);                 
            FormPath = GetRoundedRectPath(rect, 30);
            this.Region = new Region(FormPath);
        }
        private GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {
            int diameter = radius;
            Rectangle arcRect = new Rectangle(rect.Location, new Size(diameter, diameter));
            GraphicsPath path = new GraphicsPath();
            //   左上角   
            path.AddArc(arcRect, 180, 90);
            //   右上角   
            arcRect.X = rect.Right - diameter;
            path.AddArc(arcRect, 270, 90);
            //   右下角   
            arcRect.Y = rect.Bottom - diameter;
            path.AddArc(arcRect, 0, 90);
            //   左下角   
            arcRect.X = rect.Left;
            path.AddArc(arcRect, 90, 90);
            path.CloseFigure();
            return path;
        }
        protected override void OnResize(System.EventArgs e)
        {
            this.Region = null;
            SetWindowRegion();
        }

        private void Type(Control sender, int p_1, double p_2)
        {
            GraphicsPath oPath = new GraphicsPath();
            oPath.AddClosedCurve(
                new Point[] {
            new Point(0, sender.Height / p_1),
            new Point(sender.Width / p_1, 0), 
            new Point(sender.Width - sender.Width / p_1, 0), 
            new Point(sender.Width, sender.Height / p_1),
            new Point(sender.Width, sender.Height - sender.Height / p_1), 
            new Point(sender.Width - sender.Width / p_1, sender.Height), 
            new Point(sender.Width / p_1, sender.Height),
            new Point(0, sender.Height - sender.Height / p_1) },

                (float)p_2);

            sender.Region = new Region(oPath);
        }

        private void RoundForm_Resize(object sender, EventArgs e)
        {
            this.ReDraw();
        }

        private void RoundForm_Paint(object sender, PaintEventArgs e)
        {
            this.ReDraw();
        }

        private void ReDraw()
        {
            Type(this, 20, 0.1); 
        }

        private void RoundForm_Load(object sender, EventArgs e)
        {
            
        }

        private void RoundForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
