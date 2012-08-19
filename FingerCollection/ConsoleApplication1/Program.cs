using System;
using System.Collections.Generic;
using System.Text;
using FT.Commons.Security;
using FT.Commons.WindowsService.SystemInfo;
using FT.Commons.Win32;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            /* 
             * 3D3514F23F37E13A 丰大驾校
             * 4D64496ADCEF53E0 安泰驾校
             * 13EE4553EEF0DF7E 市驾培中心
             * A59B773F9C3AA159 惠东平安
             * C4FA4E8E43E6A92F 惠东怡辉
             * 70C1D30CC159B03B 博罗鸿信
             * A60793889949C6F6 光大驾校
             * 23762878906B059C 亮丽驾校
             * AD8045BF9592308E 博罗鸿信
             * 3D00BF143CC95448 环球驾校
             * F1844D78F2236926 宏达驾校
             * 50B4238104DABA1C 
             * E48EF54511ED7D4F 市驾培中心
             * 7D66505102C8DB25 隆辉驾校
             * 84A883D2309E661D 隆辉驾校
             * DCA698218706CA2B 博罗鸿信


          
        
            ComputerMonitorHelper helper = new ComputerMonitorHelper();
              helper.CheckIsOpenPort(3389);
              helper.CheckIsOpenPort("192.168.1.10",3389);
              //FT.Commons.WindowsService.BaseWindowService serv = new FT.Commons.WindowsService.ExDiskPluginMonitorService("CDEF", 1000);
              //FT.Commons.WindowsService.BaseWindowService serv = new FT.Commons.WindowsService.NetworkMonitorService( 1000);
             // FT.Commons.WindowsService.BaseWindowService serv = new FT.Commons.WindowsService.SystemServiceMonitorService(30000);
             // FT.Commons.WindowsService.BaseWindowService serv = new FT.Commons.WindowsService.ProcessMonitorService(30000);
            
            //  serv.DoTask();
              //ComputerInitHelper.InitFolderMd5("Windows Xp","Sp3","D:\\自助终端","D:\\自助终端");
             // ComputerInitHelper.InitSystemServices();
              //ComputerInitHelper.InitSystemNetworkCard();
              Console.ReadLine();
             */
            ISecurity md5 = new MD5Security();
              ISecurity sec = FT.Commons.Security.SecurityFactory.GetSecurity();
              //string hardwarecode=FT.Commons.Tools.HardwareManager.GetMachineCode();
              string hardwarecode = "DCA698218706CA2B";

              //一友驾校
              //E7A7CA598DDDAFA6
              string company = "博罗鸿信";
              Console.WriteLine("key->" + md5.Encrypt(sec.Encrypt(hardwarecode + company + hardwarecode)));

              string path = Environment.CurrentDirectory + "//success.wav";
              SystemDefine.PlaySound(path, 0, SystemDefine.SND_ASYNC | SystemDefine.SND_FILENAME);//播放音乐
              //FT.Commons.Tools.WindowsPrinterHelper.LoopPrinter();
              string printer = @"\\192.168.1.150\Brother DCP-7030 Printer";
           // Console.WriteLine("打印机状态为："+FT.Commons.Tools.WindowsPrinterHelper.GetPrinterStat(printer).ToString());

            string cmd = ""+(char)(27)+(char)(33)+(char)(10)+"模";
            byte[] mybyte = System.Text.Encoding.Default.GetBytes(cmd);
            for (int i = 0; i < mybyte.Length; i++)
            {
                Console.WriteLine(i+"="+mybyte[i]);
            }
                Console.ReadLine();
           
        }
    }
}
