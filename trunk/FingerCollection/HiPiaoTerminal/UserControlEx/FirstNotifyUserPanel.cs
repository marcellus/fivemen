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
            //如果不使用遮罩
            //this.BackColor = Color.FromArgb(245, 245, 245);
            //如果使用遮罩
            this.BackColor = Color.FromArgb(174,174,174);
            this.DoubleBuffered = true;//设置本窗体
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲
            this.UpdateStyles();
        }

        private void YellowNotifyUserPanel_Paint(object sender, PaintEventArgs e)
        {
            WinFormHelper.PaintFirstRound(sender,e);
          //  WinFormHelper.PainYellowBorder(sender, e);
        }

       
    }
}
