using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CodeBarReader
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
            FT.Windows.Forms.AppicationHelper.StartLimitTimes("keywords"
                , CodeBarReader.Properties.Resources.bg
           , 8, "15814584509", false);
        }
    }
}