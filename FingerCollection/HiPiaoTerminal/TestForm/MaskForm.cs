﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using FT.Windows.Controls.PanelEx;

namespace HiPiaoTerminal.TestForm
{
    public partial class MaskForm : Form
    {
        public MaskForm()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll", EntryPoint = "GetWindowLong")]

        public static extern long GetWindowLong(IntPtr hwnd, int nIndex);



        [DllImport("user32.dll", EntryPoint = "SetWindowLong")]

        public static extern long SetWindowLong(IntPtr hwnd, int nIndex, long dwNewLong);



        [DllImport("user32", EntryPoint = "SetLayeredWindowAttributes")]

        private static extern int SetLayeredWindowAttributes(IntPtr Handle, int crKey, byte bAlpha, int dwFlags);



        const int GWL_EXSTYLE = -20;

        const int WS_EX_TRANSPARENT = 0x20;

        const int WS_EX_LAYERED = 0x80000;

        const int LWA_ALPHA = 2;

        private void MaskForm_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.Silver;

            this.TopMost = true;

            this.FormBorderStyle = FormBorderStyle.None;

            this.WindowState = FormWindowState.Maximized;
            

           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetWindowLong(Handle, GWL_EXSTYLE, GetWindowLong(Handle, GWL_EXSTYLE) | WS_EX_TRANSPARENT | WS_EX_LAYERED);

            SetLayeredWindowAttributes(Handle, 0, 128, LWA_ALPHA);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
