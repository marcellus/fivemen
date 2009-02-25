using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace FT.Commons.Tools
{
    public class Dragger : BaseHelper
    {
        Control parent;
        Control ctr;
        Point location, current;

        public Dragger(Control theParent, Control theItemsToDrag, Point theStartingPoint)
        {
            parent = theParent;
            ctr = theItemsToDrag;
            location = theStartingPoint;
            current = location;

            // parent.Capture   =   true;  
            Cursor.Clip = parent.RectangleToScreen(parent.ClientRectangle);
        }

        public void DragTo(Point thePoint)
        {
            this.Draw(current);
            this.Draw(thePoint);
            current = thePoint;
        }

        void Draw(Point p)
        {
            int xDelta = p.X - location.X;
            int yDelta = p.Y - location.Y;
            Rectangle rt;
            if (xDelta == 0 && yDelta == 0)
                return;

            rt = ctr.Bounds;
            rt.Offset(xDelta, yDelta);
            rt = parent.RectangleToScreen(rt);
            ControlPaint.DrawReversibleFrame(rt, Color.White, FrameStyle.Thick);

        }
        public void End(Point p)
        {
            this.Draw(p);
            int xDelta = p.X - location.X;
            int yDelta = p.Y - location.Y;
            // Console.WriteLine("xDelta:" + xDelta + "yDelta:" + xDelta);
            Rectangle rt;

            rt = ctr.Bounds;
            rt.Offset(xDelta, yDelta);
            ctr.Bounds = rt;

            Cursor.Clip = Rectangle.Empty;
            parent.Capture = false;
        }
    }
}
