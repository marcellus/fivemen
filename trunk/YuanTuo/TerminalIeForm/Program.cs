using System;
using System.Collections.Generic;

using System.Windows.Forms;

namespace TerminalIeForm
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {

            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
               // Application.Run(new SkypeForm());
                Application.Run(new YuanTuoForm());
                //Application.Run(new SingleWebForm());
                // Application.Run(new Form2());
            }
            catch (Exception ex)
            {
                log4net.LogManager.GetLogger("").Info(ex.ToString());
                Application.Exit();
            }
        }
    }
}
