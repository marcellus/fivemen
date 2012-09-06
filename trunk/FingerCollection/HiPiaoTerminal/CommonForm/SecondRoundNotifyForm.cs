using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Commons.Tools;

namespace HiPiaoTerminal.CommonForm
{
    public partial class SecondRoundNotifyForm : Form
    {
        public SecondRoundNotifyForm()
        {
            InitializeComponent();
        }

        private void SecondRoundNotifyForm_Paint(object sender, PaintEventArgs e)
        {
            WinFormHelper.PaintSecondRound(sender,e);
            //WinFormHelper.PainSecondBorder(sender, e);
        }
    }
}
