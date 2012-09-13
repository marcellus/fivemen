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
    public partial class FirstRoundNotifyForm : Form
    {
        public FirstRoundNotifyForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true;//设置本窗体
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲
            this.UpdateStyles();
           // WinFormHelper.PaintFirstRound(this);
        }

        private void FirstRoundNotifyForm_Paint(object sender, PaintEventArgs e)
        {
           // WinFormHelper.PaintFirstRound(this);
            WinFormHelper.PaintFirstRound(sender,e);
           // WinFormHelper.PainYellowBorder(sender, e);
        }
    }
}
