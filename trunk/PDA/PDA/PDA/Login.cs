
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
using PDA.DataInit;

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
            if (cb_UpdateUserData.Checked)
            {
                if (!UpdateUserData()) { return; }
            }
            string sql = string.Format("select rightstr from myUsers where name='{0}' and pwd = '{1}'", txt_User.Text.Trim(), txt_Pwd.Text.Trim());
            DataTable dt = SqliteDbFactory.GetSqliteDbOperator().SelectFromSql(sql);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("登陆失败，请检查用户名和密码！");
                return;
            }
            string[] functions = dt.Rows[0]["rightstr"].ToString().Split(",".ToCharArray());
            Program.UserID = this.txt_User.Text;
            Function_List fl = new Function_List(functions);
            fl.Show();
            fl.Closed += new EventHandler(fl_Closed);
            this.Hide();
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
        private bool UpdateUserData()
        {
            DataSet ds = new DB().GetUserAndFunction();
            if (ds == null || ds.Tables.Count < 2)
            {
                MessageBox.Show("获取数据失败，请检查网络！");
                return false;
            }

            ds.Tables["User"].Columns.Add("rightstr", typeof(string));

            foreach (DataRow dr in ds.Tables["Function"].Rows)
            {
                DataRow[] drs = ds.Tables["User"].Select(string.Format("USER_CODE = '{0}'", dr["USER_CODE"]));
                if (drs.Length == 0) { continue; }
                drs[0]["rightstr"] = drs[0]["rightstr"] is DBNull ? dr["FUNCTION_CODE"].ToString() : drs[0]["rightstr"].ToString() + "," + dr["FUNCTION_CODE"].ToString();
            }

            StringBuilder sql = new StringBuilder();
            sql.Append("delete from myUsers;");
            sql.Append("insert into myUsers(name,pwd,rightstr) ");
            foreach (DataRow dr in ds.Tables["User"].Rows)
            {
                sql.AppendFormat(System.Globalization.CultureInfo.CurrentCulture, "select '{0}','{1}','{2}' union all ", dr["USER_CODE"], dr["USER_PWD"], dr["rightstr"]);
            }
            sql.Length = sql.Length - "union all ".Length;
            SqliteDbFactory.GetSqliteDbOperator().BatchExecute(sql.ToString().Split(";".ToCharArray()));
            return true;
        }
    }
}