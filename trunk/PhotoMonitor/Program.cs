using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PhotoMonitor
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
            Application.Run(new Form1());
            //FT.Windows.Forms.AppicationHelper.StartLimitDays("JxcSys", null
          //, 10, "15814584509", false);
        }
    }
}