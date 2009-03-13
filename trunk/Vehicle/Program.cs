using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Vehicle
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
            //Application.Run(new Form1());
            FT.Windows.Forms.AppicationHelper.StartLimitTimes("keywords", Vehicle.Properties.Resources.bg
            , 8, "15814584509", false);
        }
    }
}