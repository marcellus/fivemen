using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using PDA;
using System.Diagnostics;

namespace PDA
{
    public partial class Begin : Form
    {
        public Begin()
        {
            InitializeComponent();
            padInit();
        }

        [DllImport("CoreDll")]

        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("aygshell.dll")]

        private static extern uint SHFullScreen(IntPtr hwndRequester, uint dwState);

        [DllImport("coredll.dll")]

        private static extern IntPtr GetCapture();

        [DllImport("CoreDll")]

        private static extern bool ShowWindow(IntPtr hwnd, int nCmdShow);

        private void padInit()
        {
            Capture = true;

            HideHHTaskBar();

            IntPtr hwnd = GetCapture();

            Capture = false;

            SHFullScreen(hwnd, 0x0002 | 0x0008 | 0x0020);//全屏化窗口   

        }
       
        public void HideHHTaskBar()
        {

            IntPtr lpClassName = FindWindow("HHTaskBar", null);

            ShowWindow(lpClassName, 0); //隐藏任务栏   

        }

        private void button1_Click(object sender, EventArgs e)
        {
            IntPtr lpClassName = FindWindow("HHTaskBar", null);

            ShowWindow(lpClassName, 1); //显示任务栏

            Login l = new Login();
            l.Show();
            this.Hide();
            l.Closed += new EventHandler(l_Closed);
        }

        void l_Closed(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}