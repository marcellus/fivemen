using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace FT.Windows.Controls.TabControlEx
{
    public delegate bool PreRemoveTab(int indx);
    public class SimpleTabControl : TabControl
    {
        public SimpleTabControl()
            : base()
        {
            PreRemoveTabPage = null;
            //this.ItemSize =new Size(this.ItemSize.Width, TabHeight);
            this.DrawMode = TabDrawMode.OwnerDrawFixed;
        }

        public PreRemoveTab PreRemoveTabPage;

        private const int TabHeight = 100;
        private const int PicWidth = 14;
        private const int SpaceWidth = 10;

        

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            Rectangle r = e.Bounds;

            //r.l
            
            r = GetTabRect(e.Index);
            
            //r.Offset(2, 2);
            //r.Width = 5;
            //r.Height = 5;
            Brush b = new SolidBrush(Color.Black);
            //Pen p = new Pen(b);
            //Console.WriteLine("r.right"+r.Right+"top:"+r.Top+"left"+r.Left+"bottom"+r.Bottom);
            //e.Graphics.DrawLine(p, r.Right, r.Top, r.Right-10, r.Top + 10);
            //e.Graphics.DrawLine(p, r.Right-10, r.Top, r.Right, r.Top+10);
           // e.Graphics.DrawIcon(
           // Rectangle closeRec = new Rectangle(r.X + r.Width - CLOSE_WIDTH-2, r.Y+2, CLOSE_WIDTH, CLOSE_WIDTH);
            //e.Graphics.DrawImage(Fm.Properties.Resources.close,closeRec);
            
            string title = this.TabPages[e.Index].Text;

            this.TabPages[e.Index].Width += 10;
            this.TabPages[e.Index].Height += 10;
            Font f = this.Font;
            Size tmp = System.Windows.Forms.TextRenderer.MeasureText(title, f);
           // r.Size = new Size(r.Width + 10, r.Height);
            e.Graphics.DrawString(title, f, b, new PointF(r.X + 2, r.Y + (r.Height - tmp.Height) / 2));
            e.Graphics.DrawImageUnscaled(FT.Windows.Controls.Properties.Resources.close, new Point(r.X + r.Width - PicWidth - SpaceWidth, r.Y + r.Height/2-7));
        }
        /// <summary>
        /// µ¥»÷¹Ø±Õ°´Å¥¹Ø±Õ±êÇ©Ò³
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseClick(MouseEventArgs e)
        {
            Point p = e.Location;
            for (int i = 0; i < TabCount; i++)
            {
                Rectangle r = GetTabRect(i);
                Rectangle closeRec = new Rectangle(r.X + r.Width - PicWidth - SpaceWidth, r.Y + SpaceWidth, PicWidth, PicWidth);
                //Console.WriteLine(i);
                //Console.WriteLine(r.X + "y is:" + r.Y);
                //r.Offset(2, 2);
               // r.Width = 5;
               // r.Height = 5;
               // Console.WriteLine(r.X + "y is:" + r.Y);
                if (closeRec.Contains(p))
                {
                    CloseTab(i);
                }
            }
        }
        /// <summary>
        /// Ë«»÷¹Ø±Õ±êÇ©Ò³
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            base.OnMouseDoubleClick(e);
            Point p=e.Location;
            for (int i = 0; i < TabCount; i++)
            {
                Rectangle r = GetTabRect(i);
                if (r.Contains(p))
                {
                    CloseTab(i);
                }
            }
            
        }

        

        private void CloseTab(int i)
        {
            if (PreRemoveTabPage != null)
            {
                bool closeIt = PreRemoveTabPage(i);
                if (!closeIt)
                    return;
            }
            TabPages.RemoveAt(i);
        }
    }
}
