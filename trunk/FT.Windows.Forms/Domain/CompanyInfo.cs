using System;
using System.Collections.Generic;
using System.Text;

namespace FT.Windows.Forms.Domain
{
    /// <summary>
    /// Description:
    /// 单位信息的值对象
    /// </summary>
    [Serializable]
    public class CompanyInfo
    {
        private string nickName;

        /// <summary>
        /// 设置或获取单位简称
        /// </summary>
        /// <value>单位简称</value>
        public string NickName
        {
            get { return nickName; }
            set { nickName = value; }
        }
        private string no;

        /// <summary>
        /// 设置或获取单位编号
        /// </summary>
        /// <value>单位编号</value>
        public string No
        {
            get { return no; }
            set { no = value; }
        }

        private string name;

        /// <summary>
        /// 设置或获取单位名称
        /// </summary>
        /// <value>单位名称</value>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string address;

        /// <summary>
        /// 设置或获取单位地址
        /// </summary>
        /// <value>单位地址</value>
        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        private string phone;

        /// <summary>
        /// 设置或获取单位电话
        /// </summary>
        /// <value>单位电话</value>
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        private string fax;

        /// <summary>
        /// 设置或获取传真号码
        /// </summary>
        /// <value>传真号码</value>
        public string Fax
        {
            get { return fax; }
            set { fax = value; }
        }

        private string postCode;

        /// <summary>
        /// 设置或获取单位邮编
        /// </summary>
        /// <value>单位邮编</value>
        public string PostCode
        {
            get { return postCode; }
            set { postCode = value; }
        }

        private string email;

        /// <summary>
        /// 设置或获取单位Email
        /// </summary>
        /// <value>单位Email</value>
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string url;

        /// <summary>
        /// 设置或获取单位网址
        /// </summary>
        /// <value>单位网址</value>
        public string Url
        {
            get { return url; }
            set { url = value; }
        }

        private string busIdType;

        /// <summary>
        /// 单位经营证书的类别
        /// </summary>
        public string BusIdType
        {
            get { return busIdType; }
            set { busIdType = value; }
        }

        private string busId;

        /// <summary>
        /// 单位经营证书的号码
        /// </summary>
        public string BusId
        {
            get { return busId; }
            set { busId = value; }
        }
    }
}
