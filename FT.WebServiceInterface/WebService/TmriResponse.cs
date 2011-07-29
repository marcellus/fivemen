using System;
using System.Data;
using System.Configuration;
using System.Web;

using System.Xml;

namespace FT.WebServiceInterface.WebService
{
    /// <summary>
    ///TmriResponse 的摘要说明
    /// </summary>
    public class TmriResponse
    {
        public TmriResponse()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        protected System.Xml.XmlDocument doc;

        protected XmlNode node;

        protected void BuildDocument(String xml)
        {
            //saxReader = new SAXReader();
            doc = new XmlDocument();
            doc.LoadXml(xml);
            //doc = saxReader.read(new StringInputStream(xml));
        }

        protected String SelectNode(String xpathExpression)
        {
            node = doc.SelectSingleNode(xpathExpression);
            if (node == null)
            {
                return string.Empty;
            }

            return node.Value==null?node.InnerText:node.Value;
        }

        public void ParseFromXml(String xml)
        {
            this.BuildDocument(xml);
            //DrvExchangeInfo info=new DrvExchangeInfo();
            try
            {
                String code = this.SelectNode("//root/head/code");
                if (code == null || code.Length == 0)
                {
                    code = this.SelectNode("//root/head/retcode");
                }
                Code = int.Parse(code);
            }
            catch (Exception ex)
            {

            }

            Message = this.SelectNode("//root/head/message");
            if (Message == null || Message.Length == 0)
            {
                Message = this.SelectNode("//root/head/retdesc");
                
            }
            
            if (Message == null || Message.Length == 0)
            {
                Message = xml;
            }
            else
            {
                try
                {
                    Message = System.Web.HttpUtility.UrlDecode(Message);
                }
                catch (System.Exception e)
                {
                    Message = "UrlDecode返回值出错，" + e.ToString();
                }
            }
        }

        /**
         * 接口返回的代码
         */
        private int code=-1;

        public int Code
        {
            get { return code; }
            set { code = value; }
        }
        /// <summary>
        /// 是否默认的web服务错误返回的结果
        /// </summary>
        /// <returns></returns>
        public bool IsWebServiceErrorResponse()
        {
            return code == -1 && message.Length == 0;
        }

        /**
         * 接口返回的message
         */
        private String message=string.Empty;

        public String Message
        {
            get { return message; }
            set { message = value; }
        }


    }
}
