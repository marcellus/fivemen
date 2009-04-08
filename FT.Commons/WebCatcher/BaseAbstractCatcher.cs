using System;
using System.Collections.Generic;
using System.Text;
using FT.Commons.Cache;
using log4net;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Configuration;
using System.Collections;


namespace FT.Commons.WebCatcher
{
    public abstract class BaseAbstractCatcher:ICatcher
    {
        protected static ILog log = log4net.LogManager.GetLogger("FT.Commons.WebCatcher.BaseAbstractCatcher");
        protected CatcherConfig config;
        public BaseAbstractCatcher()
        {
            config = StaticCacheManager.GetConfig<CatcherConfig>();
            if (config.Url == null || config.Url.Length == 0)
            {
                throw new ArgumentException("蜘蛛要捕获的URL不得为空！");
            }
        }

        #region 基本操作
        protected static CookieContainer ccDomain = null;
        

        private HttpWebRequest myRequest;
        /// <summary>
        /// 获取网页的源码
        /// </summary>
        /// <param name="url">网页地址</param>
        /// <returns>源码</returns>
        public string GetPageSource(string url)
        {
            string result = string.Empty;
            try
            {
                log.Debug("开始抓取网页：" + url);
                myRequest = (HttpWebRequest)WebRequest.Create(url);
                if (config.LoginWithCookie&&config.UID.Length>0)
                {
                    if (ccDomain == null)
                    {
                        this.LoginGenerateCookie();
                        log.Debug("发生错误，Cookie未赋值或丢失！");
                        
                    }
                    myRequest.CookieContainer = ccDomain;
                }
                
                
                myRequest.Timeout = 30000;
                WebResponse myResponse = myRequest.GetResponse();
                Stream st = myResponse.GetResponseStream();
                StreamReader sr = new StreamReader(st, Encoding.UTF8);
                result = sr.ReadToEnd();
                log.Debug("网页结果为：" + result);
                sr.Close();
            }
            catch (Exception exc)
            {

                log.Error(exc.StackTrace);
            }
            log.Debug("结束抓取网页：" + url);
            return result;
        }
        #endregion

        #region 统计变量
        private int successCount=0;

        private int errorCount=0;

        private int allCount=0;


        #endregion
        #region ICatcher 成员

        public List<string> GetUrls()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public abstract void ParseOne(string url);
        public void Parse()
        {
            if (config.ParaType == "无")
            {
                this.ParseOne(config.Url);
            }
            else if (config.ParaType == "整数")
            {
                int begin = Convert.ToInt32(config.Begin);
                int end = Convert.ToInt32(config.End);
                for (int i = begin; i <= end; i++)
                {
                    this.ParseOne(string.Format(config.Url, i));
                }
            }
            else if (config.ParaType == "日期")
            {
                DateTime begin = Convert.ToDateTime(config.Begin);
                DateTime end = Convert.ToDateTime(config.End);
                TimeSpan ts = end - begin;
                int days = ts.Days;
                for (int i = 0; i <= days; i++)
                {
                    this.ParseOne(string.Format(config.Url, begin.AddDays(i).ToString("yyyyMMdd")));
                }
            }
        }

        public void WriteConsole(string str)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        private WebClient client;

        public string Download(string url)
        {
            string result = string.Empty;
            int pos = url.IndexOf('/', 3);
            int poslast = url.LastIndexOf('/');
            string path = config.DownDir + "/" + url.Substring(pos, poslast - pos);
            string file = url.Substring(poslast);
            DirectoryInfo dir = new DirectoryInfo(path);
            if (!dir.Exists)
            {
                dir.Create();
            }
            path += file;
            try
            {
                if (client == null)
                {
                    client = new WebClient();
                }
                
                client.DownloadFile(url, path);
                //TODO: 根据type调整路径
                result = "调整后的图片路径";
                log.Debug("从" + url + "下载到" + path + "成功！");
            }
            catch (Exception exc)
            {
                log.Debug("从" + url + "下载到" + path + "失败！");
                log.Error(exc);
            }
            return result;
        }

        public void LoginGenerateCookie()
        {
            try
            {
                string strCookieContent = string.Format(config.CookieFormat, new string[] { config.UID, config.Pwd });
                if (log.IsDebugEnabled)
                    log.Debug("格式化后Cookie字符串为：" + strCookieContent);
                ccDomain = new CookieContainer();
                byte[] bCookieData = new ASCIIEncoding().GetBytes(strCookieContent);
                HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(config.LoginUrl);
                myRequest.Method = "POST";
                myRequest.ContentType = "application/x-www-form-urlencoded";
                myRequest.ContentLength = bCookieData.Length;
                myRequest.UserAgent = "Microsoft Internet Explorer";
                Stream st = myRequest.GetRequestStream();
                st.Write(bCookieData, 0, bCookieData.Length);
                st.Close();
                myRequest.CookieContainer = ccDomain;
                HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
                ccDomain.Add(myResponse.Cookies);
                //return true;

            }
            catch (Exception exc)
            {
                log.Error("模拟登陆失败！" + exc.StackTrace);
                //return false;
            }
        }

        public void Login()
        {
            if (ccDomain == null)
            {
                this.LoginGenerateCookie();
            }
        }

        public int Count()
        {
            return allCount;
        }

        public int Success()
        {
            return successCount;
        }

        public List<string> SuccessUrl()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int Error()
        {
            return errorCount;
        }

        public List<string> ErrorUrl()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public bool IsLogin
        {
            get
            {
                return ccDomain != null;
            }
        }

        public bool LoginEveryTime
        {
            get { return config.LoginWithCookie; }
        }

        public string UserId
        {
            get
            {
                return config.UID;
            }
        }

        public string Pwd
        {
            get
            {
                return config.Pwd;
            }
           
        }

        #endregion
    }
}
