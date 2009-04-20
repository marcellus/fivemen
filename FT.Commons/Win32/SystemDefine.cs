using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace FT.Commons.Win32
{
    /// <summary>
    /// ϵͳ��һЩapi
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

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]//SendMessageTimeout����user32.dll�ж����
        public static extern IntPtr SendMessageTimeout(
        IntPtr windowHandle,
        uint Msg,
        IntPtr wParam,
        IntPtr lParam,
        SendMessageTimeoutFlags flags,
        uint timeout,
        out IntPtr result
        );

        [Flags]
        public enum SendMessageTimeoutFlags : uint
        {
            SMTO_NORMAL = 0x0000,
            SMTO_BLOCK = 0x0001,
            SMTO_ABORTIFHUNG = 0x0002,
            SMTO_NOTIMEOUTIFNOTHUNG = 0x0008
        }
        /// <summary>
        /// �������������
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        //��ҪAPI�������ע�⣺��������Ϊstatic extern
        public static extern int ExitWindowsEx(int x, int y);


        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern uint RegisterWindowMessage(string lpString);

        public static void ModifySystemEnvPath()
        {
            
            //�������÷���ϵͳ��Ϣ���Ͳ�Ҫ���������������
            const int HWND_BROADCAST = 0xffff;
            IntPtr a = new IntPtr(HWND_BROADCAST);
            // DWORD dwMsgResult = 0L;
            const uint WM_SETTINGCHANGE = 0;
            
            uint lMsg = RegisterWindowMessage("Environment");
            System.UInt32 dwMsgResult1 = 0;
            IntPtr s;
            SendMessageTimeout(a, WM_SETTINGCHANGE, IntPtr.Zero, new IntPtr(lMsg), SendMessageTimeoutFlags.SMTO_ABORTIFHUNG, 5000, out s); 

        }
        
    }
}
