using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections;
using System.Net;
using System.Net.Sockets;

namespace FT.Commons.WindowsService.SystemInfo
{
    public class ComputerMonitorHelper
    {
        private StringBuilder sb = new StringBuilder();

        private bool showCheckDetail;

        public bool ShowCheckDetail
        {
            get { return showCheckDetail; }
            set { showCheckDetail = value; }
        }

        public  bool CheckExDIsk()
        {
            return false;
        }

        public  bool CheckInternetConnection()
        {
            return false;
        }

        public  bool CheckTwoConnection()
        {
            return false;
        }
        public  bool CheckTwoNetworkCard()
        {
            return false;
        }

        public  bool CheckProcess()
        {
            return false;
        }
        public  bool CheckProcessWithModule()
        {
            return false;
        }
        public  bool CheckServices()
        {
            return false;
        }
        public  bool CheckHardwareInfo()
        {
            return false;
        }
        public bool CheckIsOpenPort(string ip, int port)
        {
            string log = string.Empty;

           
            
           
            System.Net.IPAddress myIpAddress = IPAddress.Parse(ip);
            System.Net.IPEndPoint myIpEndPoint = new IPEndPoint(myIpAddress, 8000);

            try
            {
                System.Net.Sockets.TcpClient tcpClient = new TcpClient();
                tcpClient.Connect(myIpEndPoint);//对远程计算机的指定端口提出TCP连接请求
                tcpClient.Close();
               
                Console.WriteLine("IP为{0}的计算机{1}端口开放了TCP服务！！！", ip, port);
                return true;
            }
            catch { }
            try
            {
                System.Net.Sockets.UdpClient udpClient = new UdpClient();
                udpClient.Connect(myIpEndPoint);//对远程计算机的指定端口提出UDP连接请求
                udpClient.Close();
                
                Console.WriteLine("IP为{0}的计算机{1}端口开放了UDP服务！！！", ip, port);
                return true;
            }
            catch
            {

            }
            return false;
        }
        public bool CheckIsOpenPort(int port)
        {
            string strHostName = Dns.GetHostName(); //得到本机的主机名 
            IPHostEntry ipEntry = Dns.GetHostEntry(strHostName); //取得本机IP  
            string ip = ipEntry.AddressList[0].ToString();
            return CheckIsOpenPort(ip, port);
        }

        public  bool CheckPorts()
        {
            return false;
        }
        public  bool CheckFolderChange()
        {
            return false;
        }
        public  bool CheckFolderMd5Change()
        {
            return false;
        }

        public  bool CheckAll()
        {
            return false;
        }

        public FileInfo GetHardwareReport()
        {
            return new FileInfo("");
        }
        public FileInfo GetCheckDetailResult()
        {
            return new FileInfo("");
        }

        public  Hashtable GetProcessesInfo()
        {
            return null;

        }
        public  Hashtable GetProcessModulesInfo(int proId)
        {
            return null;
        }
        public  Hashtable GetHardwaresInfo()
        {
            return null;

        }

        public  Hashtable GetServicesInfo()
        {
            return null;
        }

        
    }
}
