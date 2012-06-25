using System;
using System.Collections.Generic;
using System.Text;

namespace FT.Commons.WindowsService
{
    public class MonitorLogType
    {
        private MonitorLogType()
        {
        }
        /// <summary>
        /// 考台监控类型
        /// </summary>
        public static string ExDiskWatch="外设存储器监控";
        public static string ServiceWatch = "启动服务监控";
        public static string NetworkWatch = "网络连接监控";
        public static string ThreadWatch = "线程数量监控";

        public static string FolderWatch="文件夹监控";
        public static string ProcessWatch="进程监控";
        public static string BHOWatch="BHO监控";
        public static string SystemLogonWatch="系统登陆监控";
        
        public static string TcpIpPackWatch = "TCP/IP数据包监控";
        public static string PortWatch = "端口监控";
        public static string HardwareChangeWatch="硬件变更监控";
        
        public static string MD5FolderWatch="MD5文件夹监控";
        

        ///服务器监控类型
        public static string DbLogonWatch = "数据库登陆监控";
       
        
    }
}
