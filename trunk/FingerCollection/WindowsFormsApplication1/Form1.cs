using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region 屏蔽按键
        //委托 
        public delegate int HookProc(int nCode, int wParam, IntPtr lParam);
        static int hHook = 0;
        public const int WH_KEYBOARD_LL = 13;

        //LowLevel键盘截获，如果是WH_KEYBOARD＝2，并不能对系统键盘截取，Acrobat Reader会在你截取之前获得键盘。 
        HookProc KeyBoardHookProcedure;

        //键盘Hook结构函数 
        [StructLayout(LayoutKind.Sequential)]
        public class KeyBoardHookStruct
        {
            public int vkCode;
            public int scanCode;
            public int flags;
            public int time;
            public int dwExtraInfo;
        }

        private void BaseMaskKeyForm_Load(object sender, EventArgs e)
        {
            Hook_Start();
        }

        private void BaseMaskKeyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hook_Clear();
        }

        #endregion
        #region DllImport
        //设置钩子 
        [DllImport("user32.dll")]
        public static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        //抽掉钩子 
        public static extern bool UnhookWindowsHookEx(int idHook);
        [DllImport("user32.dll")]
        //调用下一个钩子 
        public static extern int CallNextHookEx(int idHook, int nCode, int wParam, IntPtr lParam);

        [DllImport("kernel32.dll")]
        public static extern int GetCurrentThreadId();

        [DllImport("kernel32.dll")]
        public static extern IntPtr GetModuleHandle(string name);

        public void Hook_Start()
        {
            // 安装键盘钩子 
            if (hHook == 0)
            {
                KeyBoardHookProcedure = new HookProc(KeyBoardHookProc);

                //hHook = SetWindowsHookEx(2, 
                //            KeyBoardHookProcedure, 
                //          GetModuleHandle(Process.GetCurrentProcess().MainModule.ModuleName), GetCurrentThreadId()); 

                hHook = SetWindowsHookEx(WH_KEYBOARD_LL,
                          KeyBoardHookProcedure,
                        GetModuleHandle(Process.GetCurrentProcess().MainModule.ModuleName), 0);

                //如果设置钩子失败. 
                if (hHook == 0)
                {
                    Hook_Clear();
                    //throw new Exception("设置Hook失败!"); 
                }
            }
        }

        //取消钩子事件 
        public void Hook_Clear()
        {
            bool retKeyboard = true;
            if (hHook != 0)
            {
                retKeyboard = UnhookWindowsHookEx(hHook);
                hHook = 0;
            }
            //如果去掉钩子失败. 
            if (!retKeyboard) throw new Exception("UnhookWindowsHookEx failed.");
        }

        //这里可以添加自己想要的信息处理 
        public static int KeyBoardHookProc(int nCode, int wParam, IntPtr lParam)
        {
            
            if (nCode >= 0)
            {
               
                KeyBoardHookStruct kbh = (KeyBoardHookStruct)Marshal.PtrToStructure(lParam, typeof(KeyBoardHookStruct));
                //MessageBox.Show("按键代码为：" + kbh.vkCode.ToString());
                if (kbh.vkCode == 91)  // 截获左win(开始菜单键) 
                {
                    return 1;
                }
                if (kbh.vkCode == 92)// 截获右win 
                {
                    return 1;
                }
                if (kbh.vkCode == (int)Keys.Escape && (int)Control.ModifierKeys == (int)Keys.Control) //截获Ctrl+Esc 
                {
                    return 1;
                }
                if (kbh.vkCode == (int)Keys.F4 && (int)Control.ModifierKeys == (int)Keys.Alt)  //截获alt+f4 
                {
                    return 1;
                }
                if (kbh.vkCode == (int)Keys.Tab && (int)Control.ModifierKeys == (int)Keys.Alt) //截获alt+tab 
                {
                    return 1;
                }
                if (kbh.vkCode == (int)Keys.Escape && (int)Control.ModifierKeys == (int)Keys.Control + (int)Keys.Shift) //截获Ctrl+Shift+Esc 
                {
                    return 1;
                }
                if (kbh.vkCode == (int)Keys.Space && (int)Control.ModifierKeys == (int)Keys.Alt)  //截获alt+空格 
                {
                    return 1;
                }
                if (kbh.vkCode == 241//F1
                     || kbh.vkCode == (int)Keys.F2
                || kbh.vkCode == (int)Keys.F3
                || kbh.vkCode == (int)Keys.F4
                || kbh.vkCode == (int)Keys.F5
                || kbh.vkCode == (int)Keys.F6
                || kbh.vkCode == (int)Keys.F7
                || kbh.vkCode == (int)Keys.F8
                || kbh.vkCode == (int)Keys.F9
                || kbh.vkCode == (int)Keys.F10
                || kbh.vkCode == (int)Keys.F11
                || kbh.vkCode == (int)Keys.F12)                  //截获F1 -F12
                {
                    return 1;
                }
                if ((int)Control.ModifierKeys == (int)Keys.Control + (int)Keys.Alt + (int)Keys.Delete)      //截获Ctrl+Alt+Delete 
                {
                    return 1;
                }
                //if ((int)Control.ModifierKeys == (int)Keys.Control + (int)Keys.Shift)      //截获Ctrl+Shift 
                //{ 
                //    return 1; 
                //} 

                //if (kbh.vkCode == (int)Keys.Space && (int)Control.ModifierKeys == (int)Keys.Control + (int)Keys.Alt)  //截获Ctrl+Alt+空格 
                //{ 
                //    return 1; 
                //} 
            }
            return CallNextHookEx(hHook, nCode, wParam, lParam);
        }

        #endregion

        
    }
}
