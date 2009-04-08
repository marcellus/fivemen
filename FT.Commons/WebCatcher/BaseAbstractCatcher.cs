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
                throw new ArgumentException("֩��Ҫ�����URL����Ϊ�գ�");
            }
        }

        #region ��������
        protected static CookieContainer ccDomain = null;
        

        private HttpWebRequest myRequest;
        /// <summary>
        /// ��ȡ��ҳ��Դ��
        /// </summary>
        /// <param name="url">��ҳ��ַ</param>
        /// <returns>Դ��</returns>
        public string GetPageSource(string url)
        {
            string result = string.Empty;
            try
            {
                log.Debug("��ʼץȡ��ҳ��" + url);
                myRequest = (HttpWebRequest)WebRequest.Create(url);
                if (config.LoginWithCookie&&config.UID.Length>0)
                {
                    if (ccDomain == null)
                    {
                        this.LoginGenerateCookie();
                        log.Debug("��������Cookieδ��ֵ��ʧ��");
                        
                    }
                    myRequest.CookieContainer = ccDomain;
                }
                
                
                myRequest.Timeout = 30000;
                WebResponse myResponse = myRequest.GetResponse();
                Stream st = myResponse.GetResponseStream();
                StreamReader sr = new StreamReader(st, Encoding.UTF8);
                result = sr.ReadToEnd();
                log.Debug("��ҳ���Ϊ��" + result);
                sr.Close();
            }
            catch (Exception exc)
            {

                log.Error(exc.StackTrace);
            }
            log.Debug("����ץȡ��ҳ��" + url);
            return result;
        }
        #endregion

        #region ͳ�Ʊ���
        private int successCount=0;

        private int errorCount=0;

        private int allCount=0;


        #endregion
        #region ICatcher ��Ա

        public List<string> GetUrls()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public abstract void ParseOne(string url);
        public void Parse()
        {
            if (config.ParaType == "��")
            {
                this.ParseOne(config.Url);
            }
            else if (config.ParaType == "����")
            {
                int begin = Convert.ToInt32(config.Begin);
                int end = Convert.ToInt32(config.End);
                for (int i = begin; i <= end; i++)
                {
                    this.ParseOne(string.Format(config.Url, i));
                }
            }
            else if (config.ParaType == "����")
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
                //TODO: ����type����·��
                result = "�������ͼƬ·��";
                log.Debug("��" + url + "���ص�" + path + "�ɹ���");
            }
            catch (Exception exc)
            {
                log.Debug("��" + url + "���ص�" + path + "ʧ�ܣ�");
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
                    log.Debug("��ʽ����Cookie�ַ���Ϊ��" + strCookieContent);
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
                log.Error("ģ���½ʧ�ܣ�" + exc.StackTrace);
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
