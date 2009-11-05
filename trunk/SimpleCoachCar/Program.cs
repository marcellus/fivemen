using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SimpleCoachCar
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

            FT.Windows.Forms.AppicationHelper.StartLimitDays("SimpleCoachCar", SimpleCoachCar.Properties.Resources.Sunset
           , 10, "15814584509", false, null, null);
        }
    }
}