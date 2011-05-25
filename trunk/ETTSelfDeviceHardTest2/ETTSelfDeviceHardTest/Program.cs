using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ETTSelfDeviceHardTest
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
            //FT.Windows.Forms.AppicationHelper.BeforeStart();
           // FT.Windows.Forms.AppicationHelper.StartSimpleMonitor("ETTSelfDeviceHardTest", new Form1(), false);
            Application.Run(new Form1());
        }
    }
}
