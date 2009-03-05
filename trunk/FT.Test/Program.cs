using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FT.Test
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
            
            //Application.Run(new BaseForm());
            Form form = new FT.Windows.CommonsPlugin.LoginForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new FT.Windows.Forms.BaseMainForm());
            }
        }
    }
}