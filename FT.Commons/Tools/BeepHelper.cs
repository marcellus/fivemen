using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace FT.Commons.Tools
{
    public class BeepHelper
    {


        //导入 Windows Beep() API 函数 
        [DllImport("kernel32.dll ")]
        public static extern bool Beep(int freq, int dur);

        // 定义PlaySound()要使用的常数 

        public const int SND_FILENAME = 0x00020000;

        public const int SND_ASYNC = 0x0001;

        // 导入 Windows PlaySound() 函数 

        [DllImport("winmm.dll ")]
        public static extern bool PlaySound(string pszSound,int hmod,int fdwSound);



        static void Main(string[] args) 

        { 

        // 使用Ctrl g发出蜂鸣声 

        Console.Write( "\a "); 

        Console.WriteLine( "使用Ctrl g发出蜂鸣声... "); 

        Console.ReadLine();

        // 使用 Windows API 发出蜂鸣声 

        Beep(800, 200); 

        Console.WriteLine( "使用 Windows API 发出蜂鸣声... "); 

        Console.ReadLine();

        // 播放bells.wav文件 

        //PlaySound( "bells.wav ", 0, SND_FILENAME ¦ SND_ASYNC); 

        Console.WriteLine( "播放bells.wav文件... "); 

        Console.ReadLine(); 

        } 
    }


}
