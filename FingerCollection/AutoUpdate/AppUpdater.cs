using System;
using System.Web;
using System.IO;
using System.Net;
using System.Xml;
using System.Collections;
using System.Windows.Forms;
using System.ComponentModel;

namespace AutoUpdate
{
	/// <summary>
	/// updater 的摘要说明。
	/// </summary>
	public class AppUpdater:IDisposable
	{
		#region 成员与字段属性
		private string _updaterUrl;
		private bool disposed = false;
		private IntPtr handle;
		private Component component = new Component();
		[System.Runtime.InteropServices.DllImport("Kernel32")]
		private extern static Boolean CloseHandle(IntPtr handle);


		public string UpdaterUrl
		{
			set{_updaterUrl = value;}
			get{return this._updaterUrl;}
		}
		#endregion

		/// <summary>
		/// AppUpdater构造函数
		/// </summary>
		public AppUpdater()
		{
			this.handle = handle;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		private void Dispose(bool disposing)
		{
			if(!this.disposed)
			{
				if(disposing)
				{
				
					component.Dispose();
				}
				CloseHandle(handle);
				handle = IntPtr.Zero;            
			}
			disposed = true;         
		}

		~AppUpdater()      
		{
			Dispose(false);
		}


		/// <summary>
		/// 检查更新文件
		/// </summary>
		public int CheckForUpdate(string serverXmlFile,string localXmlFile,out Hashtable updateFileList)
		{
			updateFileList = new Hashtable();
			if(!File.Exists(localXmlFile) || !File.Exists(serverXmlFile))
			{
				return -1;
			}
			
			XmlFiles serverXmlFiles = new XmlFiles(serverXmlFile);
			XmlFiles localXmlFiles = new XmlFiles(localXmlFile);
			
			XmlNodeList newNodeList = serverXmlFiles.GetNodeList("AutoUpdater/Files");
			XmlNodeList oldNodeList = localXmlFiles.GetNodeList("AutoUpdater/Files");//5+1+a+s+p+x

			int k = 0;
			for(int i = 0;i < newNodeList.Count;i++)
			{
				string [] fileList = new string[3];

				string newFileName = newNodeList.Item(i).Attributes["Name"].Value.Trim();
				string newVer = newNodeList.Item(i).Attributes["Ver"].Value.Trim();
				
				ArrayList oldFileAl = new ArrayList();
				for(int j = 0;j < oldNodeList.Count;j++)
				{
					string oldFileName = oldNodeList.Item(j).Attributes["Name"].Value.Trim();
					string oldVer = oldNodeList.Item(j).Attributes["Ver"].Value.Trim();
					
					oldFileAl.Add(oldFileName);
					oldFileAl.Add(oldVer);

				}
				int pos = oldFileAl.IndexOf(newFileName);
				if(pos == -1)
				{
					fileList[0] = newFileName;
					fileList[1] = newVer;
					updateFileList.Add(k,fileList);
					k++;
				}
				else if(pos > -1 && newVer.CompareTo(oldFileAl[pos+1].ToString())>0 )
				{
					fileList[0] = newFileName;
					fileList[1] = newVer;
					updateFileList.Add(k,fileList);
					k++;
				}
				
			}
			return k;
		}
	
		/// <summary>
		/// 检查更新文件
		/// </summary>
		public int CheckForUpdate()
		{
			string localXmlFile = Application.StartupPath + "\\UpdateList.xml";
			if(!File.Exists(localXmlFile))
			{
				return -1;
			}

			XmlFiles updaterXmlFiles = new XmlFiles(localXmlFile );

			string tempUpdatePath = Environment.GetEnvironmentVariable("Temp") + "\\"+ "_"+ updaterXmlFiles.FindNode("//Application").Attributes["applicationId"].Value+"_"+"y"+"_"+"x"+"_"+"m"+"_"+"\\";
			this.UpdaterUrl = updaterXmlFiles.GetNodeValue("//Url") + "UpdateList.xml";
			this.DownAutoUpdateFile(tempUpdatePath);

			string serverXmlFile = tempUpdatePath  +"\\UpdateList.xml";
			if(!File.Exists(serverXmlFile))
			{
				return -1;
			}
			
			XmlFiles serverXmlFiles = new XmlFiles(serverXmlFile);
			XmlFiles localXmlFiles = new XmlFiles(localXmlFile);
			
			XmlNodeList newNodeList = serverXmlFiles.GetNodeList("AutoUpdater/Files");
			XmlNodeList oldNodeList = localXmlFiles.GetNodeList("AutoUpdater/Files");

			int k = 0;
			for(int i = 0;i < newNodeList.Count;i++)
			{
				string [] fileList = new string[3];

				string newFileName = newNodeList.Item(i).Attributes["Name"].Value.Trim();
				string newVer = newNodeList.Item(i).Attributes["Ver"].Value.Trim();
				
				ArrayList oldFileAl = new ArrayList();
				for(int j = 0;j < oldNodeList.Count;j++)
				{
					string oldFileName = oldNodeList.Item(j).Attributes["Name"].Value.Trim();
					string oldVer = oldNodeList.Item(j).Attributes["Ver"].Value.Trim();
					
					oldFileAl.Add(oldFileName);
					oldFileAl.Add(oldVer);

				}
				int pos = oldFileAl.IndexOf(newFileName);
				if(pos == -1)
				{
					fileList[0] = newFileName;
					fileList[1] = newVer;
					k++;
				}
				else if(pos > -1 && newVer.CompareTo(oldFileAl[pos+1].ToString())>0 )
				{
					fileList[0] = newFileName;
					fileList[1] = newVer;
					k++;
				}
				
			}
			return k;
		}

        public static WebClient CreateClient()
        {
            WebClient client = new WebClient();
            
            client.Proxy = null;
            return client;
        }

        public static WebRequest Create(string url)
        {
            
            WebRequest req = WebRequest.Create(url);
            if (timeout > 0)
            {
                req.Timeout = timeout;
            }
            req.Proxy = null;
            //req.ImpersonationLevel=System.Security.Principal.TokenImpersonationLevel.Impersonation
            return req;
            
            //HttpWebRequest hwr = (HttpWebRequest)WebRequest.Create(url);
            //hwr.ContentType = @"application/x-www-form-urlencoded";

            //hwr.Accept = "*/*";
            //hwr.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.1; Trident/4.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0)";
            ////Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.1; Trident/4.0; QQDownload 618; Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1) ; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; InfoPath.2)
            //hwr.Headers.Add("x-flash-version", "10,0,32,18");
            //hwr.Headers.Add(HttpRequestHeader.AcceptEncoding, "*/*");
            //hwr.Headers.Add(HttpRequestHeader.AcceptLanguage, "zh-CN");
            //hwr.Headers.Add(HttpRequestHeader.CacheControl, "no-cache");
            //hwr.KeepAlive = true;
            //return hwr;
            
            
        }

        public static int timeout = 0;

		/// <summary>
		/// 返回下载更新文件的临时目录
		/// </summary>
		public bool DownAutoUpdateFile(string downpath)
		{
            bool result = false;
			if(!System.IO.Directory.Exists(downpath))
				System.IO.Directory.CreateDirectory(downpath);
			string serverXmlFile = downpath+@"UpdateList.xml";


            WebRequest req=null;
            WebResponse res=null;
            try
            {
                TempLog.Debug("下载更新配置文件UpdateList.xml,创建WebRequest");
                req = AppUpdater.Create(this.UpdaterUrl);
                TempLog.Debug("下载更新配置文件UpdateList.xml,完成WebRequest");
                res = req.GetResponse();
                TempLog.Debug("下载更新配置文件UpdateList.xml,完成WebRequest获取GetResponse");
                if (res.ContentLength > 0)
                {
                    WebClient wClient = AppUpdater.CreateClient();
                    TempLog.Debug("下载更新配置文件UpdateList.xml,开始下载");
                    wClient.DownloadFile(this.UpdaterUrl, serverXmlFile);
                    TempLog.Debug("下载更新配置文件UpdateList.xml,完成下载");
                    result = true;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (res != null)
                {
                   res.Close();
                   req.Abort();
                }
            }
		
			
            return result;
		}
	}
}
