using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PersonCard
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
            //FT.Commons.Tools.MessageBoxHelper.Show(true.ToString());
            FT.Windows.Forms.AppicationHelper.StartLimitTimes("keywords", PersonCard.Resource.bg
           , 8, "15814584509", false);
        }
    }
}