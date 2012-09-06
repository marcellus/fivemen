using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using FT.Commons.Tools;

namespace FT.Windows.Controls.PanelEx
{
    public partial class ColorChangeTextPanel : UserControl
    {
        public ColorChangeTextPanel()
        {
            InitializeComponent();
        }

        private void ColorChangeTextPanel_Paint(object sender, PaintEventArgs e)
        {
            
            if (this.textBox1.Focused || this.textBox1.Text.Length > 0)
            {
                WinFormHelper.PaintSecondRound(sender, e);
                //WinFormHelper.PainYellowBorder(sender,e);
            }
            else
            {
                WinFormHelper.PaintFirstRound(sender, e);
            }
        }

        private void ColorChangeTextPanel_Resize(object sender, EventArgs e)
        {
            //this.textBox1.Width = this.Width - this.pictureBox1.Width-1;
           // this.textBox1.Height=this.pictureBox1.Height = this.Height;
        }

        private void ColorChangeTextPanel_Leave(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void ColorChangeTextPanel_Enter(object sender, EventArgs e)
        {
            this.Invalidate();
        }
    }
}
