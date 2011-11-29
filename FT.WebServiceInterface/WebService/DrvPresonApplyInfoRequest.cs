using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Orm;

namespace FT.WebServiceInterface.WebService
{
    public class DrvPresonApplyInfoRequest : DrvBaseTmriRequest
    {

        private String sn;

        public String Sn
        {
            get { return sn; }
            set { sn = value; }
        }

        [SimpleColumn(Column = "sfzmhm")]
        [Alias("身份证明号码")]
        public String Sfzmhm;

        [SimpleColumn(Column = "sfzmmc")]
        [Alias("身份证明名称")]
        public String Sfzmmc;

        [SimpleColumn(Column = "i_hmcd")]
        [Alias("身份证明号码长度")]
        public String Hmcd;

        [SimpleColumn(Column = "i_xb")]
        [Alias("性别")]
        public String Xb;


        [SimpleColumn(Column = "c_csrq")]
        [Alias("出生日期")]
        public String Csrq;


        [SimpleColumn(Column = "c_gj")]
        [Alias("国籍")]
        public String Gj;



        [SimpleColumn(Column = "c_djzsxzqh")]
        [Alias("登记住所详细区划")]
        public String Djzsxzqh;


        [SimpleColumn(Column = "c_djzsxxdz")]
        [Alias("登记住所详细地址")]
        public String Djzsxxdz;


        [SimpleColumn(Column = "c_lxzsxzqh")]
        [Alias("联系住所行政区划")]
        public String Lxzsxzqh;


        [SimpleColumn(Column = "c_lxzsxxdz")]
        [Alias("联系住所详细地址")]
        public String Lxzsxxdz;

        [SimpleColumn(Column = "c_lxzsyzbm")]
        [Alias("联系住所邮政编码")]
        public String Lxzsyzbm;

        [SimpleColumn(Column = "c_ly")]
        [Alias("来源")]
        public String Ly;

        [SimpleColumn(Column = "c_xzqh")]
        [Alias("行政区划")]
        public String Xzqh;


        [SimpleColumn(Column = "c_lxdh")]
        [Alias("联系电话")]
        public String Lxdh;


        [SimpleColumn(Column = "c_zzzm")]
        [Alias("暂住证明")]
        public String Zzzm;



        [SimpleColumn(Column = "c_zkzmbh")]
        [Alias("准考证明编号")]
        public String Zkzmbh;


        [SimpleColumn(Column = "c_dabh")]
        [Alias("档案编号")]
        public String Dabh;



        [SimpleColumn(Column = "c_zkcx")]
        [Alias("准考车型")]
        public String Zkcx;







        [SimpleColumn(Column = "c_dzyx")]
        [Alias("电子邮箱")]
        public String Dzyx;

        [SimpleColumn(Column = "c_sjhm")]
        [Alias("手机号码")]
        public String Sjhm;


        [SimpleColumn(Column = "c_sg")]
        [Alias("身高")]
        public String Sg;


        [SimpleColumn(Column = "i_zsl")]
        [Alias("左视力")]
        public String Zsl;

        [SimpleColumn(Column = "i_ysl")]
        [Alias("右视力")]
        public String Ysl;

        [SimpleColumn(Column = "i_bsl")]
        [Alias("辨色力")]
        public int Bsl;

        [SimpleColumn(Column = "i_tl")]
        [Alias("听力")]
        public int Tl;


        [SimpleColumn(Column = "i_sz")]
        [Alias("上肢")]
        public int Sz;

        [SimpleColumn(Column = "i_zxz")]
        [Alias("左下肢")]
        public int Zxz;

        [SimpleColumn(Column = "i_yxz")]
        [Alias("右下肢")]
        public int Yxz;


        [SimpleColumn(Column = "i_qgjb")]
        [Alias("躯干颈部")]
        public int Qgjb;


        [SimpleColumn(Column = "c_tjrq")]
        [Alias("体检日期")]
        public String Tjrq;


        [SimpleColumn(Column = "c_tjyymc")]
        [Alias("体检医院名称")]
        public String Tjyymc;

        [SimpleColumn(Column = "c_photo_src")]
        [Alias("图片路径")]
        public String PhotoSrc;

        [SimpleColumn(Column = "i_photo_syn")]
        [Alias("图片是否同步")]
        public int PhotoSyn;

        [SimpleColumn(Column = "c_jxmc")]
        [Alias("驾校名称")]
        public String Jxmc;

        [SimpleColumn(Column = "c_jxdm")]
        [Alias("驾校代码")]
        public String Jxdm;



        [SimpleColumn(Column = "c_lsh")]
        [Alias("流水号")]
        public String Lsh;


        [SimpleColumn(Column = "c_xm")]
        [Alias("姓名")]
        public String Xm;
        public override string ToXml()
        {
            StringBuilder sb = new StringBuilder("<?xml version=\"1.0\" encoding=\"GBK\"?>");
            sb.Append("<root>");
            sb.Append("<DrvtempMid>");
            this.AppendTag(sb, "lsh", this.Lsh);
            this.AppendTag(sb, "sfzmhm", this.Sfzmhm);
            this.AppendTag(sb, "sfzmmc", this.Sfzmmc);
            this.AppendTag(sb, "hmcd", this.Hmcd);

            //this.AppendTag(sb, "xm", System.Web.HttpUtility.UrlEncode(this.Xm,System.Text.Encoding.UTF8));
            this.AppendTag(sb, "xm", this.Xm);
            this.AppendTag(sb, "xb", this.Xb);
            this.AppendTag(sb, "csrq", this.Csrq);
            this.AppendTag(sb, "djzsxzqh", this.Djzsxzqh);

            //this.AppendTag(sb, "djzsxxdz", System.Web.HttpUtility.UrlEncode(this.Djzsxxdz, System.Text.Encoding.UTF8));

            this.AppendTag(sb, "djzsxxdz", this.Djzsxxdz);
            this.AppendTag(sb, "lxzsxzqh", this.Lxzsxzqh);

            this.AppendTag(sb, "lxzsxxdz", this.Lxzsxxdz);
            //this.AppendTag(sb, "lxzsxxdz", System.Web.HttpUtility.UrlEncode(this.Lxzsxxdz, System.Text.Encoding.UTF8));

            this.AppendTag(sb, "lxzsyzbm", this.Lxzsyzbm);

            this.AppendTag(sb, "ly", this.Ly);
            this.AppendTag(sb, "xzqh", this.Xzqh);
            this.AppendTag(sb, "lxdh", this.Lxdh);
            this.AppendTag(sb, "zzzm", this.Zzzm);

            this.AppendTag(sb, "zkzmbh", this.Zkzmbh);
            this.AppendTag(sb, "dabh", this.Dabh);
            this.AppendTag(sb, "zkcx", this.Zkcx);
            this.AppendTag(sb, "jxmc", this.Jxmc);
            //this.AppendTag(sb, "jxmc", System.Web.HttpUtility.UrlEncode(this.Jxmc, System.Text.Encoding.UTF8)); 


            this.AppendTag(sb, "dzyx", this.Dzyx);
            this.AppendTag(sb, "sjhm", this.Sjhm);
            this.AppendTag(sb, "sg", this.Sg);
            this.AppendTag(sb, "zsl", this.Zsl);


            this.AppendTag(sb, "ysl", this.Ysl);
            this.AppendTag(sb, "bsl", this.Bsl);
            this.AppendTag(sb, "tl", this.Tl);
            this.AppendTag(sb, "sz", this.Sz);

            this.AppendTag(sb, "zxz", this.Zxz);
            this.AppendTag(sb, "yxz", this.Yxz);
            this.AppendTag(sb, "qgjb", this.Qgjb);
            this.AppendTag(sb, "tjrq", this.Tjrq);


            this.AppendTag(sb, "tjyymc", this.Tjyymc);
           // this.AppendTag(sb, "tjyymc", System.Web.HttpUtility.UrlEncode(this.Tjyymc,System.Text.Encoding.UTF8));
           
            this.AppendTag(sb, "sn", this.Sn);
            sb.Append("</DrvtempMid>");
            sb.Append("</root>");
            return sb.ToString();
        }
    }
}
