using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using FT.Commons.Tools;

namespace HiPiaoTerminal.UserControlEx
{
    public partial class SecondNotifyUserPanel : UserControl
    {
        public SecondNotifyUserPanel()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(245, 245, 245);
        }

        private void SecondNotifyUserPanel_Paint(object sender, PaintEventArgs e)
        {
            //125,183,0
            
            WinFormHelper.PaintSecondRound(sender, e);
           // WinFormHelper.PaintRound(sender);
        }
    }
}
