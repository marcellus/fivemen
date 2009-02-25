using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace FT.Windows.Controls.ButtonEx
{
    public class MyButtonObject : UserControl
    {
        // Draw the new button.
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Pen myPen = new Pen(Color.Black);
            // Draw the button in the form of a circle
            graphics.DrawEllipse(myPen, 0, 0, 100, 100);
            myPen.Dispose();
        }
    }

}
