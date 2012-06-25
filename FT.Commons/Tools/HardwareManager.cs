/********************************************************************************
* File:HardwareManager.cs
* Author:austin chen
* Date:2008-4-14
* Copyright (c) fivemen company
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Management;
using System.Net.Sockets;
using System.Net;
using log4net;
namespace FT.Commons.Tools
{
    /// <summary>
    /// 硬件辅助工具类
    /// </summary>
    public class HardwareManager : BaseHelper
	{
        /// <summary>
        /// 获取机器码，先获取mac，如果获取mac出错，再获取disk序列号，如果获取disk也出错
        /// 获取cpu地址
        /// </summary>
        /// <returns>机器码</returns>
        public static string GetMachineCode()
        {
            //cantgetmac
            string tmp = GetMac();
            if (tmp == null || tmp == string.Empty || tmp == "cantgetmac")
            {
                tmp = GetDisk();
                if (tmp == null || tmp == string.Empty || tmp == "cantgetdisk")
                {
                    tmp = GetCpu();
                }
            }
            FT.Commons.Security.ISecurity md5= new FT.Commons.Security.MD5Security();
            return md5.Encrypt(tmp);
        }
        /// <summary>
        /// 获取本机的第一个IP
        /// </summary>
        /// <returns>本机的第一个IP</returns>
        public static string GetDefaultIp()
        {
            //TODO 检查当自动获取Ip的时候是否获取到127.0.0.1
            IPHostEntry ipHost = Dns.GetHostEntry(string.Empty);
            if (ipHost.AddressList.Length > 0)
            {
                return ipHost.AddressList[0].ToString();//获取本机第一个网卡的ip   
            }
            else
            {
                Debug("没有找到合适的IP,请检查是否存在正常的网卡设备！");
                return string.Empty;
                //throw new ArgumentException("没有找到合适的IP");
            }
        }

        private static string cpuNo;

        private static string diskNo;

        private static string macNo;
        /// <summary>
        /// 获取cpu的编号
        /// </summary>
        /// <returns>cpu的编号</returns>
		public static string GetCpu()
		{
            if (cpuNo == null || cpuNo == string.Empty)
            {
                try
                {
                    ManagementClass mcCpu = new ManagementClass("win32_Processor");
                    ManagementObjectCollection mocCpu = mcCpu.GetInstances();
                    foreach (ManagementObject m in mocCpu)
                    {
                        cpuNo = m["ProcessorId"].ToString();
                        return cpuNo;
                    }
                }
                catch (Exception ex)
                {
                    Info(ex);
                    cpuNo = "cantgetcpu";
                }
            }
			return cpuNo;
		}

        /// <summary>
        /// 获取硬盘的编号
        /// </summary>
        /// <returns>硬盘的编号</returns>
		public static string GetDisk()
		{
            if (diskNo == null || diskNo == string.Empty)
            {
                try
                {
                    ManagementClass mcHD = new ManagementClass("win32_logicaldisk");
                    ManagementObjectCollection mocHD = mcHD.GetInstances();
                    foreach (ManagementObject m in mocHD)
                    {
                        if (m["DeviceID"].ToString() == "C:")
                        {
                            diskNo = m["VolumeSerialNumber"].ToString();
                            return diskNo;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Info(ex);
                    cpuNo = "cantgetdisk";
                }
            }
            return diskNo;
		}

        /// <summary>
        /// 获取多个网卡的Mac地址数组
        /// </summary>
        /// <returns>多个网卡的IP的数组</returns>
        public static string[] GetMacArray()
        {
            string[] result;
           
                try
                {
                    #region 3
                    ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT MACAddress FROM Win32_NetworkAdapter WHERE ((MACAddress Is Not NULL)AND (Manufacturer <> 'Microsoft'))");
                    ManagementObjectCollection moCollection = searcher.Get();
                    int count=moCollection.Count;
                    result = new string[count];
                    ManagementObject mObject=null;
                    System.Management.ManagementObjectCollection.ManagementObjectEnumerator enumerator = moCollection.GetEnumerator();
                    int i = 0;

                    while(i<count)
                    
                    {
                        mObject = enumerator.Current as ManagementObject;
                        if (mObject["MacAddress"] == null)
                        {
                            Info("mObject[MacAddress] is null!");
                        }
                        else
                        {
                            result[i] = mObject["MACAddress"].ToString() + "";
                            // break;
                        }
                        enumerator.MoveNext();
                        i++;
                    }
                   
                    #endregion

                }




                catch (Exception ex)
                {
                    Info(ex);
                    result = new string[]{"cantgetmac"};
                }

                return result;
        }

        /// <summary>
        /// 获取网卡的编号
        /// </summary>
        /// <returns>网卡的编号</returns>
		public static String GetMac()
		{
            if (macNo == null || macNo == string.Empty)
            {
                try
                {
                    /*
                    ManagementObjectSearcher query = null;
                  ManagementObjectCollection queryCollection = null;

                    query = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration");

queryCollection = query.Get();

foreach( ManagementObject mo in queryCollection )
{
    if (mo["MacAddress"] == null)
                            {
                                Info("m[MacAddress] is null!");
                            }
                            macNo = mo["MacAddress"].ToString();
                            return macNo;
}*/
                    #region 2
                    /*       
                           ManagementClass mcMAC = new ManagementClass("Win32_NetworkAdapterConfiguration");
                           if (mcMAC == null)
                           {
                               Info("mcMAC is null!");
                           }
                           ManagementObjectCollection mocMAC = mcMAC.GetInstances();
                           if(mocMAC==null)
                           {
                               Info("mocMAC is null!");
                           }
                           foreach (ManagementObject m in mocMAC)
                           {
                               if ((bool)m["IPEnabled"])
                               {
                                   //m.Properties["MACAddress"].Value.ToString(); 
                                   if (m["MacAddress"]==null)
                                   {
                                       Info("m[MacAddress] is null!");
                                   }
                                   if (m.Properties["MACAddress"] != null)
                                   {
                                       Info("m.Properties[MACAddress] is not null!");

                                   }
                                   if (m.Properties["MACAddress"].Value!=null)
                                   {
                                       Info("m.Properties[MACAddress].Value is not null!");
                                
                                   }
                                   macNo = m["MacAddress"].ToString();
                                   return macNo;
                               }
                               else
                               {
                                   if (m["MacAddress"] == null)
                                   {
                                       Info("m[MacAddress] is null!");
                                   }
                                   macNo = m["MacAddress"].ToString();
                                   return macNo;
                               }
                           }*/
                    #endregion

                    #region 3
                    ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT MACAddress FROM Win32_NetworkAdapter WHERE ((MACAddress Is Not NULL)AND (Manufacturer <> 'Microsoft'))");
                    ManagementObjectCollection moCollection = searcher.Get();
                    foreach (ManagementObject mObject in moCollection)
                    {
                        if (mObject["MacAddress"] == null)
                        {
                            Info("mObject[MacAddress] is null!");
                        }
                        else
                        {
                            macNo = mObject["MACAddress"].ToString() + "";
                            break;
                        }
                        
                    }
                    #endregion

                }
                    



                catch (Exception ex)
                {
                    Info(ex);
                    cpuNo = "cantgetmac";
                }
            }
			return macNo;
        }
              


	}
}