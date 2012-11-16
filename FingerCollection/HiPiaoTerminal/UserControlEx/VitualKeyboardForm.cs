using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Commons.Tools;

namespace HiPiaoTerminal.UserControlEx
{
    public partial class VitualKeyboardForm : Form
    {
        public VitualKeyboardForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true;//设置本窗体
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲
            this.UpdateStyles();
            //GlobalTools.MaskFormKeyDown(this);
        }

        private void vitualKeyBoardPanel21_Load(object sender, EventArgs e)
        {
           // this.vitualKeyBoardPanel21.ShowWithForm = true;
            this.vitualKeyBoardPanel31.ShowWithForm = true;
        }


        public TextBox InputTextBox
        {
            get
            {
                return this.vitualKeyBoardPanel31.InputTextBox;
            }
            set
            {
                this.vitualKeyBoardPanel31.InputTextBox=value;
            }
        }

        private void VitualKeyboardForm_Paint(object sender, PaintEventArgs e)
        {
          //  Color color = Color.FromArgb(241, 241, 241);
          //  WinFormHelper.PaintRound(sender, color, 1, e);
        }

        private void VitualKeyboardForm_Load(object sender, EventArgs e)
        {

        }

        private void VitualKeyboardForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4 && e.Modifiers == Keys.Alt)
            {
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.F1
                || e.KeyCode == Keys.F2
                || e.KeyCode == Keys.F3
                || e.KeyCode == Keys.F4
                || e.KeyCode == Keys.F5
                || e.KeyCode == Keys.F6
                || e.KeyCode == Keys.F7
                || e.KeyCode == Keys.F8
                || e.KeyCode == Keys.F9
                || e.KeyCode == Keys.F10
                || e.KeyCode == Keys.F11
                || e.KeyCode == Keys.F12
                || e.KeyCode == Keys.LWin
                || e.KeyCode == Keys.RWin
                || e.KeyCode == Keys.Alt
                || e.KeyCode == Keys.Control
                )
            {
                e.Handled = true;
            }
        }

        private void vitualKeyBoardPanel31_KeyDown(object sender, KeyEventArgs e)
        {
            VitualKeyboardForm_KeyDown(sender, e);
        }
    }
}
