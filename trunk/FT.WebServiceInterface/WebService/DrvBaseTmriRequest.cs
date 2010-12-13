using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Text;
using log4net;
namespace FT.WebServiceInterface.WebService
{
    /// <summary>
    ///DrvBaseRequest 的摘要说明
    /// </summary>
    public abstract class DrvBaseTmriRequest
    {
        protected static ILog log = log4net.LogManager.GetLogger("DrvBaseTmriRequest");
        public DrvBaseTmriRequest()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        public string GetConfig(string key)
        {
            string result=System.Configuration.ConfigurationManager.AppSettings[key];
            log.Debug("获取配置："+key);
            log.Debug("值："+result);
            return result;
        }

        public string GetXtlb()
        {
            //string tmp = this.GetType().FullName + "_xtlb";
           
            return GetConfig(this.GetType().FullName+"_xtlb");
        }
        public string GetJkxlh()
        {
            return GetConfig(this.GetType().FullName + "_jkxlh");
        }
        public string GetJkid()
        {
            return GetConfig(this.GetType().FullName + "_jkid");
        }

        public abstract string ToXml();

        protected void AppendTag(StringBuilder sb, String tag, Object value)
        {
            if (value != null)
            {
                sb.Append("<" + tag + ">");

                sb.Append(value.ToString());
                sb.Append("</" + tag + ">");
            }
            else
            {
                sb.Append("<" + tag + ">");
                sb.Append("</" + tag + ">");
            }
        }
    }
}
