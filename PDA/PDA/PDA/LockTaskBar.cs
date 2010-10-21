using System;

using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace PDA
{
    public class LockTaskBar
    {
        [DllImport("CoreDll.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(string className, string WindowsName);

        [DllImport("coredll.dll", EntryPoint = "EnableWindow")]
        public static extern bool EnableWindow(IntPtr hwnd, bool bEnable);

        [DllImport("aygshell.dll")]
        private static extern uint SHFullScreen(IntPtr hwndRequester, uint dwState);

        [DllImport("coredll.dll")]
        private static extern IntPtr GetCapture();

        /// <summary>
        /// this is for enable and disable task bar. 
        /// Basically this is provide access control Start menu.
        /// </summary>
        /// <param name="HHTaskBar">HHTaskBar</param>
        /// <param name="enabled">default false</param>
        /// <returns></returns>
        public static bool Execute(string HHTaskBar, bool enabled)
        {
            bool IsState = false;
            try
            {
                IntPtr hwnd = FindWindow(HHTaskBar, null);

                if (!hwnd.Equals(IntPtr.Zero))
                {
                    if (enabled)
                    {
                        IsState = EnableWindow(hwnd, false);
                    }
                    else
                    {
                        IsState = EnableWindow(hwnd, true);
                    }
                }
            }
            catch (DllNotFoundException dllex)
            {
                throw dllex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return IsState;
        }
    }

}
