using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace FT.WebServiceInterface.WebService
{
    public class DrvOldBaseResponse
    {
        public static string ParseSingleNode(string xml,string xpath)
        {
            XmlDocument doc1 = new XmlDocument();
            doc1.LoadXml(xml);
            //DrvExchangeInfo info=new DrvExchangeInfo();
            try
            {
                XmlNode node1 = doc1.SelectSingleNode(xpath);
                if (node1 == null)
                {
                    return string.Empty;
                }
                return node1.InnerText;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
        public DrvOldBaseResponse()
        {
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
            return node.InnerText;
        }

        public virtual void ParseFromXml(String xml)
        {
            this.BuildDocument(xml);
            //DrvExchangeInfo info=new DrvExchangeInfo();
            try
            {
                String code = this.SelectNode("//response/head/code");
                if (code == null || code.Length == 0)
                {
                    code = this.SelectNode("//response/head/retcode");
                }
                Code = int.Parse(code);
            }
            catch (Exception ex)
            {

            }

            Message = this.SelectNode("//response/head/message");
            if (Message == null || Message.Length == 0)
            {
                Message = this.SelectNode("//response/head/retdesc");
            }
        }

        /**
         * 接口返回的代码
         */
        private int code = -1;

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
