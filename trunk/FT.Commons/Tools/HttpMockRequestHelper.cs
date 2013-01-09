using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;

namespace FT.Commons.Tools
{
    /// <summary>
    /// 模拟网页请求工具
    /// </summary>
    public class HttpMockRequestHelper:BaseHelper
    {

        private HttpMockRequestHelper()
        {
        }

        public static bool CheckValidationResult(object sender,
                             System.Security.Cryptography.X509Certificates.X509Certificate certificate,
                             System.Security.Cryptography.X509Certificates.X509Chain chain,
                             System.Net.Security.SslPolicyErrors errors)
        {
            //直接确认，不然打不开   
            return true;
        }  


        /// <summary>
        /// 获取网页请求结果
        /// </summary>
        /// <param name="url">网页url</param>
        /// <returns>返回抓取的结果</returns>
        public static string GetMockRequestResult(string url)
        {

            //发起请求

            Uri uri = new Uri(url);
            if (url.StartsWith("https"))
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
                ServicePointManager.ServerCertificateValidationCallback =
                                        new System.Net.Security.RemoteCertificateValidationCallback(CheckValidationResult);


            }

            WebRequest webRequest = WebRequest.Create(uri);

            webRequest.ContentType = "text/xml; charset=utf-8";

            webRequest.Method = "GET";

            // webRequest.Timeout = GetInterfaceTimeout();

           //响应

            WebResponse webResponse = webRequest.GetResponse();

            using (StreamReader myStreamReader = new StreamReader(webResponse.GetResponseStream(), Encoding.UTF8))
            {

                string result = "";

                return result = myStreamReader.ReadToEnd();


            }

        }

        /// <summary>
        /// 获取网页请求结果
        /// </summary>
        /// <param name="url">网页url</param>
        /// <param name="datastr">发送的数据</param>
        /// <returns>返回抓取的结果</returns>
        public static string GetMockRequestResult(string url, string datastr)
        {

            //发起请求

            Uri uri = new Uri(url);
            if (url.StartsWith("https"))
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
                ServicePointManager.ServerCertificateValidationCallback =
                                        new System.Net.Security.RemoteCertificateValidationCallback(CheckValidationResult);


            }

            WebRequest webRequest = WebRequest.Create(uri);

            webRequest.ContentType = "text/xml; charset=utf-8";

            webRequest.Method = "POST";

           // webRequest.Timeout = GetInterfaceTimeout();

            using (Stream requestStream = webRequest.GetRequestStream())
            {

                byte[] paramBytes = Encoding.UTF8.GetBytes(datastr.ToString());

                requestStream.Write(paramBytes, 0, paramBytes.Length);

            }

            //响应

            WebResponse webResponse = webRequest.GetResponse();

            using (StreamReader myStreamReader = new StreamReader(webResponse.GetResponseStream(), Encoding.UTF8))
            {

                string result = "";

                return result = myStreamReader.ReadToEnd();


            }

        }
    }
}
