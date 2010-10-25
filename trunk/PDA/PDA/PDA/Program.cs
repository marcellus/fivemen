using System;

using System.Collections.Generic;
using System.Windows.Forms;
using System.Collections;

namespace PDA
{
    static class Program
    {
        public static string UserID="testuser";
        public static string UserName = string.Empty;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [MTAThread]
        static void Main()
        {
            ArrayList al = new ArrayList();
            al.Add("01");
            al.Add("02");
            al.Add("03");
            al.Add("04");
            al.Add("05");
            al.Add("06");
            al.Add("07");
            al.Add("08");
            al.Add("09");
            al.Add("10");
            //Application.Run(new DiskList(al));
            //Application.Run(new Function_List(al.ToArray()));
            Application.Run(new Login());
            //Application.Run(new DataInit.SqliteTestForm());
        }
    }
}