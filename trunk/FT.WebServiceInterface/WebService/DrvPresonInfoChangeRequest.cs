using System;
using System.Collections.Generic;
using System.Text;

namespace FT.WebServiceInterface.WebService
{
    /// <summary>
    /// 个人信息备案变更请求
    /// </summary>
    public class DrvPresonInfoChangeRequest:DrvBaseTmriRequest
    {
        public string sfzmhm;
        public string lxdh;
        public string yzbm;
        public string lxzs;
        public string sjhm;
        public string dzyx;

        public override string ToXml()
        {
            StringBuilder sb = new StringBuilder("<?xml version=\"1.0\" encoding=\"GBK\"?>");
            sb.Append("<root>");
            sb.Append("<TempBean>");
            this.AppendTag(sb, "sfzmhm", this.sfzmhm);
            this.AppendTag(sb, "lxdh", this.lxdh);
            this.AppendTag(sb, "yzbm", this.yzbm);
            this.AppendTag(sb, "lxzs", this.lxzs);
            this.AppendTag(sb, "sjhm", this.sjhm);
            this.AppendTag(sb, "dzyx", this.dzyx); 
            sb.Append("</TempBean>");
            sb.Append("</root>");
            return sb.ToString();
        }
    }
}
