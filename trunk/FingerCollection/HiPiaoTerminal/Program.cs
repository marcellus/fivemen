using System;
using System.Collections.Generic;
using System.Windows.Forms;
using HiPiaoTerminal.TestForm;

namespace HiPiaoTerminal
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
           // Application.Run(new MaskPanelForm());
           // Application.Run(new KeyBoardTestForm());
          //  Application.Run(new AdShowTestForm());
            
        }
    }
}
