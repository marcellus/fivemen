using System;
using System.Collections.Generic;
using System.Text;

namespace FT.Commons.Tools
{
    public class SkypeHelper:BaseHelper
    {
        static SkypeHelper()
        {
            SkypeObj = null;
            try
            {
                SkypeObj = new Skype();
            }
            catch { }

            if (SkypeObj == null)
            {
                try
                {
                    RegisterComObject("skype4com");
                    SkypeObj = new Skype();
                }
                catch (Exception ex)
                {
                    string msg = "Skype4COM.dll is not registered as COM DLL.\n" + ex.ToString();
                    MessageBox.Show(msg, WF.Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private static void RegisterComObject(string comDllName)
        {
            Process process = new Process();
            process.StartInfo = new ProcessStartInfo("regsvr32.exe", string.Format("/s {0}.dll", comDllName));
            process.Start();
            process.WaitForExit();
        }
    }
}
