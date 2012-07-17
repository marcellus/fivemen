using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using FT.Commons.Tools;
using System.Diagnostics;
using System.ServiceProcess;
using System.Management;

namespace FT.Commons.WindowsService.SystemInfo
{
    public class ComputerInitHelper
    {

       
        
        public static void InitSystemNetworkCard()
        {
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapter");

            ManagementObjectCollection moc = mc.GetInstances();
            Console.WriteLine("查找到的连接数量为->" + moc.Count);
            int i = 0;
            foreach (ManagementObject mo in moc)
            {

                object val = mo["NetConnectionStatus"];

                if (val == null) //断开的。
                {
                }
                else
                {
                    string name = (string)mo["Name"];
                    Console.WriteLine("{0}\n\tConnection   Status:{1} ", name, (ushort)val);
                    ushort state = (ushort)val;
                    if (state == 2)
                    {
                        i++;
                    }
                }


            }
            if (i > 1)
            {
                string logStr = "发现可用网络连接的个数为>" + i;
                Console.WriteLine(logStr);
                
            }
        }

        public static ComputerInfo GetComputerInfo()
        {
            ComputerInfo info = new ComputerInfo();
            info.System = Environment.OSVersion.ToString();
            info.SystemVersion = Environment.Version.ToString();
            info.Name = Environment.MachineName;
            //info.Mac = Environment.UserName;
            info.Ip = HardwareManager.GetDefaultIp();
            info.Mac = HardwareManager.GetMac();
            return info;
        }

        public static void InitComputerInfo()
        {
            InitComputerInfo(null);
        }

        public static void InitComputerInfo(InitComputerInfoDelegate handler)
        {
            ComputerInfo info = GetComputerInfo();
            if (handler != null)
            {
                handler(info);
            }
            else
            {
                Console.WriteLine(info.ToString());
            }
        }

        public static void InitSystemServices(string system,string systemVersion,InitServicesDelegate handler)
        {
            ServiceController[] services = ServiceController.GetServices();
            for (int i = 0; i < services.Length; i++)
            {
                if (handler != null)
                {
                    handler(system, systemVersion, services[i]);
                }
                else
                {
                    MonitorServiceInfo service = new MonitorServiceInfo(system, systemVersion, services[i]);
                    Console.WriteLine(service);
                }

                //service.ServicePath
            }
        }


        public static void InitSystemServices(string system,string systemVersion)
        {
            InitSystemServices(system, systemVersion, null);
        }

        

        private static void swith(int state)
        {
            throw new NotImplementedException();
        }

        public static void InitFolderMd5(string system, string systemVersion, string parentPath, string dirPath,InitFileMd5Delegate initFileMd5)
        {
             DirectoryInfo dir = new DirectoryInfo(dirPath);
            if (dir.Exists)
            {
                FileInfo[] files=dir.GetFiles();
                for (int i = 0; i < files.Length; i++)
                {
                    if (initFileMd5 != null)
                    {
                        initFileMd5(system, systemVersion, parentPath, files[i]);
                    }
                    else
                    {
                        InitFileMd5(system, systemVersion, parentPath, files[i]);
                    }
                }
                DirectoryInfo[] dirs = dir.GetDirectories();
                for (int i = 0; i < dirs.Length; i++)
                {
                    InitFolderMd5(system, systemVersion, parentPath,dirs[i].FullName,initFileMd5);
                }
            }
        }

        public static void InitFolderMd5(string system,string systemVersion,string parentPath,string dirPath)
        {
            InitFolderMd5(system, systemVersion, parentPath, dirPath, null);
        }

        public static void InitFileMd5(string system,string systemVersion,string dirPath,FileInfo file)
        {
            MonitorFileInfo result = new MonitorFileInfo(system,systemVersion,dirPath,file);
           
            Console.WriteLine(result.ToString());
        }

        public static void InitProcess(string system, string systemVersion, InitProcessDelegate handler)
        {

        }
    }
}
