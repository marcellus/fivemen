using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ExamAppSys
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FT.Windows.Forms.AppicationHelper.StartLimitDays("keywords", ExamAppSys.Properties.Resources.bg
           , 10, "15814584509", true);
        }
    }
}