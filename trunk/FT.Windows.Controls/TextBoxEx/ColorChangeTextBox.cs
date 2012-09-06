using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using FT.Commons.Tools;

namespace FT.Windows.Controls.TextBoxEx
{
    public class ColorChangeTextBox:TextBox
    {
        public ColorChangeTextBox()
        {
            
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //WinFormHelper.PaintRound(this);
            if (this.Focus() || this.Text.Trim().Length > 0)
            {
                WinFormHelper.PaintFirstRound(this, e);
            }
            else
            {
                WinFormHelper.PaintSecondRound(this,e);
            }
        }
    }
}
