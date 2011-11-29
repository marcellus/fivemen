using System;
using System.Collections.Generic;
using System.Text;
using log4net;
using System.Web;
using System.Drawing;
using System.Xml;

namespace FT.WebServiceInterface.WebService
{
    public  class DrvNewInterface
    {

        protected static ILog log = log4net.LogManager.GetLogger("DrvNewInterface");
        private static TmriJaxRpcOutAccessService GetNewService()
        {
            TmriJaxRpcOutAccessService service = new TmriJaxRpcOutAccessService();
            //service.AllowAutoRedirect
            //service.RequestEncoding = System.Text.Encoding.UTF8;
            // service.SoapVersion
            log.Debug("服务默认的编码是：" + service.RequestEncoding);
            //TestLog.Log("服务的URL：" + service.Url);
            //service
            service.Url = System.Configuration.ConfigurationManager.AppSettings["DrvNewSeriveUrl"];
            log.Debug("服务的URL：" + service.Url);
            // TestLog.LogStep();
            service.Timeout = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["DrvNewSeriveTimeout"]);
            return service;
        }

        private static string GetServiceWriteSn() {
          return   System.Configuration.ConfigurationManager.AppSettings["DrvNewSeriveSn"];
        }


        private static  string  GetTextInXml(string xml, string xpath)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            XmlNode node = doc.SelectSingleNode(xpath);
            if (node != null)
            {
                return node.InnerText;
            }
            return string.Empty;
        }

        public static string[] WritePhoto(string sfzmhm, string zp)
        {

            string encodingZp = HttpUtility.UrlEncode(zp);
            //string xmlPattern = "<?xml version=\"1.0\" encoding=\"GBK\" ?><root><drvphoto><sfzmhm>{0}</sfzmhm><zp>{1}</zp></drvphoto></root>";
            string xmlDoc = "<?xml version=\"1.0\" encoding=\"GBK\" ?>"
                          + "<root>"
                          + "<drvphoto>"
                          + "<sfzmhm>" + sfzmhm + "</sfzmhm>"
                          + "<zp>" + encodingZp + "</zp>"
                          + "</drvphoto>"
                          + "</root>"
                          ;
            string re = GetNewService().writeObjectOut("02", GetServiceWriteSn(), "02C77", xmlDoc);

            string code = GetTextInXml(re, "//code");
            string retcode = GetTextInXml(re, "//retcode");
            if (code == "1" || retcode == "1")
            {
                return new string[] { "1" };
            }
            else { 
                string message = GetTextInXml(re, "//retdesc");
                return new string[] { "0", message };
            }
        }

        public static string[] WritePresign(string xmlDoc)
        {

            

            string re = GetNewService().writeObjectOut("02", GetServiceWriteSn(), "02C69", xmlDoc);

            string code = GetTextInXml(re, "//code");
            string retcode = GetTextInXml(re, "//retcode");
            if (code == "1" || retcode == "1")
            {
                return new string[] { "1" };
            }
            else
            {
                string message = GetTextInXml(re, "//retdesc");
                return new string[] { "0", message };
            }
        }

    }
}
