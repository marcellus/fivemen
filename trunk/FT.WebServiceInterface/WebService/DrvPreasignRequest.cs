using System;
using System.Data;
using System.Configuration;
using System.Web;

using System.Text;
namespace FT.WebServiceInterface.WebService
{
    /// <summary>
    ///DrvPreasignRequest 的摘要说明
    /// </summary>
    public class DrvPreasignRequest : DrvBaseTmriRequest
    {
        public DrvPreasignRequest()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

       

        

        private String lsh;

        public String Lsh
        {
            get { return lsh; }
            set { lsh = value; }
        }
        private int kskm;

        public int Kskm
        {
            get { return kskm; }
            set { kskm = value; }
        }
        //一直是0
        private String xxsj = "0";

        public String Xxsj
        {
            get { return xxsj; }
            set { xxsj = value; }
        }
        //考试地点代码
        private String ksdd;

        public String Ksdd
        {
            get { return ksdd; }
            set { ksdd = value; }
        }
        //经办人姓名汉字
        private String jbr;

        public String Jbr
        {
            get { return jbr; }
            set { jbr = value; }
        }
        //驾驶学校代码
        private String dlr;

        public String Dlr
        {
            get { return dlr; }
            set { dlr = value; }
        }
        //格式yyyy-MM-dd
        private String ykrq;

        public String Ykrq
        {
            get { return ykrq; }
            set { ykrq = value; }
        }
        //考试场次代码
        private String kscc;

        public String Kscc
        {
            get { return kscc; }
            set { kscc = value; }
        }
        //科目一的时候为空
        private String kchp;

        public String Kchp
        {
            get { return kchp; }
            set { kchp = value; }
        }
        //格式yyyy-MM-dd
        private String pxshrq;

        public String Pxshrq
        {
            get { return pxshrq; }
            set { pxshrq = value; }
        }
        //身份证明号码
        private String jly;

        public String Jly
        {
            get { return jly; }
            set { jly = value; }
        }
        private String sn;

        public String Sn
        {
            get { return sn; }
            set { sn = value; }
        }

        public override string ToXml()
        {
            StringBuilder sb = new StringBuilder("<?xml version=\"1.0\" encoding=\"GBK\"?>");

            Encoding gbk=System.Text.Encoding.GetEncoding("gbk");
            Encoding gb2312=System.Text.Encoding.GetEncoding("gb2312");
            Encoding utf8=System.Text.Encoding.UTF8;
            Encoding defaultE=System.Text.Encoding.Default;
            byte[] defaultBytes=defaultE.GetBytes(this.Jbr);
            byte[] utf8Byte=Encoding.Convert(defaultE,utf8,defaultBytes);
            string utf8Str=utf8.GetString(utf8Byte);
            sb.Append("<root>");
            //sb.Append("<TempBean>");
            sb.Append("<DrvPreasign>");
            //sb.Append("<TempBean>");
            this.AppendTag(sb, "lsh", this.lsh);
            this.AppendTag(sb, "kskm", this.kskm);
            this.AppendTag(sb, "xxsj", this.xxsj);
            this.AppendTag(sb, "ksdd", this.ksdd);
            this.AppendTag(sb, "jbr", this.Jbr);
          //  this.AppendTag(sb, "jbr", System.Text.Encoding.GetEncoding("GBK").GetString(this.Jbr.ToCharArray())));
            //this.AppendTag(sb, "jbr", System.Web.HttpUtility.UrlEncode(this.jbr, System.Text.Encoding.UTF8).ToUpper());
            this.AppendTag(sb, "dlr", this.dlr);
            this.AppendTag(sb, "ykrq", this.ykrq);
            this.AppendTag(sb, "kscc", this.kscc);
           // this.AppendTag(sb, "kchp", this.Kchp);
            this.AppendTag(sb, "kchp", this.Kchp);
           // this.AppendTag(sb, "kchp", System.Web.HttpUtility.UrlEncode(this.kchp, System.Text.Encoding.UTF8).ToUpper());
            this.AppendTag(sb, "pxshrq", this.pxshrq);
            this.AppendTag(sb, "jly", this.jly);
            this.AppendTag(sb, "sn", this.sn);
            sb.Append("</DrvPreasign>");
            
            //sb.Append("</TempBean>");
            sb.Append("</root>");
            return sb.ToString();
           // return System.Text.Encoding.UTF8.GetEncoder().Convert()
           // return System.Web.HttpUtility.UrlEncode(sb.ToString(), System.Text.Encoding.UTF8);
        }

        
    }
}
