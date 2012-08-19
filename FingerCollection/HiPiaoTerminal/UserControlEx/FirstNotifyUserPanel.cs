using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using FT.Commons.Tools;

namespace HiPiaoTerminal.UserControlEx
{
    public partial class FirstNotifyUserPanel : UserControl
    {
        public FirstNotifyUserPanel()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(245, 245, 245);
        }

        private void YellowNotifyUserPanel_Paint(object sender, PaintEventArgs e)
        {
            //WinFormHelper.PaintRound(sender);
            WinFormHelper.PainYellowBorder(sender, e);
        }

       
    }
}
