using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Text;

namespace FT.WebServiceInterface.WebService
{
    /// <summary>
    ///DrvExamWritePhotoRequest 的摘要说明
    /// </summary>
    public class DrvExamWritePhotoRequest : DrvBaseTmriRequest
    {
        public DrvExamWritePhotoRequest()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        public string sfzmhm;

        public string zpstr;

        public override string ToXml()
        {
            StringBuilder sb = new StringBuilder("<?xml version=\"1.0\" encoding=\"GBK\"?>");
            sb.Append("<root>");
            sb.Append("<ksPhoto>");
            this.AppendTag(sb, "sfzmhm", this.sfzmhm);
            this.AppendTag(sb, "zpstr", this.zpstr);
            sb.Append("</ksPhoto>");
            sb.Append("</root>");
            return sb.ToString();
        }
    }
}
