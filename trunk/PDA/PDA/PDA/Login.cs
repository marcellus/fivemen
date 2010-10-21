
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Collections;

namespace PDA
{
    public partial class Login : Form
    {

        [DllImport("CoreDll")]

        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("aygshell.dll")]

        private static extern uint SHFullScreen(IntPtr hwndRequester, uint dwState);

        [DllImport("coredll.dll")]

        private static extern IntPtr GetCapture();

        [DllImport("CoreDll")]

        private static extern bool ShowWindow(IntPtr hwnd, int nCmdShow);

        public Login()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            //LockTaskBar.Execute("HHTaskBar", true);
            //padInit();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            //DataSet ds = new DB().GetUserRightList(this.txt_User.Text.ToUpper(), this.txt_Pwd.Text);
            //if (ds == null)
            //{
            //    MessageBox.Show("获取数据失败，请检查网络！");
            //}
            //else
            //{
            //    if (ds.Tables["user"].Rows.Count == 0)
            //    {
            //        MessageBox.Show("登陆失败，请检查用户名和密码！");
            //    }
            //    else
            //    {
                    ArrayList al = new ArrayList();
                    //for (int i = 0; i < ds.Tables["right"].Rows.Count; i++)
                    //{
                    //    al.Add(ds.Tables["right"].Rows[i]["FUNCTION_CODE"].ToString());
                    //}
                    //Program.UserID = this.txt_User.Text;
                    Function_List fl = new Function_List(al);
                    fl.Show();
                    fl.Closed += new EventHandler(fl_Closed);
                    this.Hide();
                //}
            //}
        }

        private void padInit()
        {
            Capture = true;
            HideHHTaskBar();
            IntPtr hwnd = GetCapture();
            Capture = false;
            SHFullScreen(hwnd, 0x0002 | 0x0008 | 0x0020);//全屏化窗口   
        }

        void fl_Closed(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_User_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txt_Pwd.Focus();
            }
        }

        private void txt_Pwd_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_OK_Click(this.btn_OK, new EventArgs());
            }
        }

        public void HideHHTaskBar()
        {
            IntPtr lpClassName = FindWindow("HHTaskBar", null);
            ShowWindow(lpClassName, 0); //隐藏任务栏   
        }
    }
}