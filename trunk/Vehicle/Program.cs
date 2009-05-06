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
            //Application.Run(new Form2());
            FT.Windows.Forms.AppicationHelper.StartLimitDays("keywords", Vehicle.Properties.Resources.bg
            , 10, "15814584509", true);
        }
    }
}