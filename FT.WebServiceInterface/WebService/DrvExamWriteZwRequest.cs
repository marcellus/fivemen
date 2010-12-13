using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Text;

namespace FT.WebServiceInterface.WebService
{
    /// <summary>
    ///DrvExamWriteZwRequest 的摘要说明
    /// </summary>
    public class DrvExamWriteZwRequest:DrvBaseTmriRequest
    {
        public DrvExamWriteZwRequest()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        public string sfzmhm;
        public string szsxh;
        public string zwtzm;
        public string zwtpstr;
        public string bz;

        public override string ToXml()
        {
            StringBuilder sb = new StringBuilder("<?xml version=\"1.0\" encoding=\"GBK\"?>");
            sb.Append("<root>");
            sb.Append("<ksFinger>");
            this.AppendTag(sb, "sfzmhm", this.sfzmhm);
            this.AppendTag(sb, "szsxh", this.szsxh);
            this.AppendTag(sb, "zwtzm", this.zwtzm);
            this.AppendTag(sb, "zwtpstr", this.zwtpstr);
            this.AppendTag(sb, "bz", this.bz);
            sb.Append("</ksFinger>");
            sb.Append("</root>");
            return sb.ToString();
        }
    }
}
