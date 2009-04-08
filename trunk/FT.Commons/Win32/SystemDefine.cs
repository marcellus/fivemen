using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace FT.Commons.Win32
{
    /// <summary>
    /// 系统的一些api
    /// </summary>
    public class SystemDefine
    {
        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

       // [DllImport("user32.dll", CallingConvention = CallingConvention.StdCall)]
      // public static extern IntPtr SetWindowsHookEx(WH_Codes idHook, HookProc lpfn,
           // IntPtr pInstance, int threadId);

        [DllImport("user32.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int CallNextHookEx(IntPtr pHookHandle, int nCode,
            Int32 wParam, IntPtr lParam);

        [DllImport("user32.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern bool UnhookWindowsHookEx(IntPtr pHookHandle);


    }
}
