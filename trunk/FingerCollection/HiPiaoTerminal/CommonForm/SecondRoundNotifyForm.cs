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
            this.BackColor = Color.Green;
            this.DoubleBuffered = true;//设置本窗体
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲
            this.UpdateStyles();
           // WinFormHelper.PaintSecondRound(this);
        }

        private void SecondRoundNotifyForm_Paint(object sender, PaintEventArgs e)
        {
           // WinFormHelper.PaintSecondRound(this);
            WinFormHelper.PaintSecondRound(sender,e);
            //WinFormHelper.PainSecondBorder(sender, e);
        }
    }
}
