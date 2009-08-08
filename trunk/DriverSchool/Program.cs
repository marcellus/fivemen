using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DS.Plugins.Student;

namespace DriverSchool
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            FT.Windows.Forms.AppicationHelper.BeforeStart();
            
            FT.Windows.Forms.AppicationHelper.StartLimitDays("driverschool", DriverSchool.Properties.Resources.bg
           , 10, "15814584509", true, typeof(InitButtonPanel), "操作快捷界面");
        }
    }
}