using System;
using System.Collections.Generic;
using System.Text;
using System.Net.NetworkInformation;
using System.Net;
using System.Net.Sockets;

namespace FT.Commons.Tools
{
    public class WindowExHelper:BaseHelper
    {
        private WindowExHelper()
        {
        }
        /*
           byte[] mac = new byte[6];
            mac[0] = 0x00;
            mac[1] = 0x01;
            mac[2] = 0x80;
            mac[3] = 0x79;
            mac[4] = 0x08;
            mac[5] = 0xD8;

            WakeUp(mac);


         */

        /// <summary>
        /// 远程开机，网卡需要具备远程唤醒功能
        /// </summary>
        /// <param name="mac">网卡物理地址字符串</param>
        public static void WakeUp(string mac)
        {
            byte[] result = strToToHexByte(mac.Replace(":","").Replace("：","").Replace("-",""));
            WakeUp(result);
            
        }

        private static byte[] strToToHexByte(string hexString)
        {
            hexString = hexString.Replace(" ", "");
            if ((hexString.Length % 2) != 0)
                hexString += " ";
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return returnBytes;
        }


        /// <summary>
        /// 远程开机，网卡需要具备远程唤醒功能
        /// </summary>
        /// <param name="mac">网卡物理地址字符数组</param>
        public static void WakeUp(byte[] mac)
        {
            UdpClient client = new UdpClient();
            client.Connect(IPAddress.Broadcast, 9090);
            byte[] packet = new byte[17 * 6];

            for (int i = 0; i < 6; i++)
                packet[i] = 0xFF;

            for (int i = 1; i <= 16; i++)
                for (int j = 0; j < 6; j++)
                    packet[i * 6 + j] = mac[j];

            int result = client.Send(packet, packet.Length);
        }


        /// <summary>
        /// 关闭计算机
        /// </summary>
        public static void CloseComputer()
        {
            System.Diagnostics.Process bootProcess = new System.Diagnostics.Process();
            bootProcess.StartInfo.FileName = "shutdown";
            bootProcess.StartInfo.Arguments = "/s  /t 0 /f";
            bootProcess.Start();

        }
        /// <summary>
        /// 检查网络是否能ping通
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool CanConnectionTo(string strIpOrDName)
        {
            try
            {
                Ping objPingSender = new Ping();
                PingOptions objPinOptions = new PingOptions();
                objPinOptions.DontFragment = true;
                string data = "";
                byte[] buffer = Encoding.UTF8.GetBytes(data);
                int intTimeout = 120;
                PingReply objPinReply = objPingSender.Send(strIpOrDName, intTimeout, buffer, objPinOptions);
                string strInfo = objPinReply.Status.ToString();
                if (strInfo == "Success")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
