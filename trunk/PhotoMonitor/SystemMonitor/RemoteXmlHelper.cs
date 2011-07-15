using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace PhotoMonitor
{
    class RemoteXmlHelper
    {

        public static string toXml_02C77(string sfzmhm, string zp)
        {
            if (sfzmhm == null || sfzmhm.Length == 0 || zp == null || zp.Length == 0)
            {
                return "";
            }
            //新接口写图片必须转码,切记切记
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
            return xmlDoc;
            // return HttpUtility.UrlEncode(xmlDoc);
        }
    }
}
