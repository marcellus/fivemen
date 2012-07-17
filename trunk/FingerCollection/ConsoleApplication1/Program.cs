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
              string hardwarecode = "A60793889949C6F6";

              //一友驾校
              //E7A7CA598DDDAFA6
              string company = "光大驾校";
              Console.WriteLine("key->" + md5.Encrypt(sec.Encrypt(hardwarecode + company + hardwarecode)));

              string path = Environment.CurrentDirectory + "//success.wav";
              SystemDefine.PlaySound(path, 0, SystemDefine.SND_ASYNC | SystemDefine.SND_FILENAME);//播放音乐
              Console.ReadLine();
           
        }
    }
}
