using System;
using System.Collections.Generic;
using System.Text;
using System.Net.NetworkInformation;

namespace FT.Commons.Tools
{
    public class WindowExHelper:BaseHelper
    {
        private WindowExHelper()
        {
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
        /// 检查网络是否有连接
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
