using System;
using System.Collections.Generic;
using System.Text;
using FT.Commons.Security;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            ISecurity md5 = new MD5Security();
            ISecurity sec = FT.Commons.Security.SecurityFactory.GetSecurity();
            //string hardwarecode=FT.Commons.Tools.HardwareManager.GetMachineCode();
            string hardwarecode = "2CD8FE761D868BF6";
            string company = "顺诚驾校";
            Console.WriteLine("key->"+md5.Encrypt(sec.Encrypt(hardwarecode + company + hardwarecode)));
            Console.ReadLine();
             * */
            //FT.Commons.WindowsService.BaseWindowService serv = new FT.Commons.WindowsService.ExDiskPluginMonitorService("CDEF", 1000);
            //FT.Commons.WindowsService.BaseWindowService serv = new FT.Commons.WindowsService.NetworkMonitorService( 1000);
           // FT.Commons.WindowsService.BaseWindowService serv = new FT.Commons.WindowsService.SystemServiceMonitorService(30000);
            FT.Commons.WindowsService.BaseWindowService serv = new FT.Commons.WindowsService.ProcessMonitorService(30000);
            
            serv.DoTask();
            Console.ReadLine();
        }
    }
}
