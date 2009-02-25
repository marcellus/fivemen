using System;
using System.Collections.Generic;
using System.Text;

namespace FT.Windows.Forms.Domain
{
    /// <summary>
    /// Description:
    /// ��λ��Ϣ��ֵ����
    /// </summary>
    [Serializable]
    public class CompanyInfo
    {
        private string nickName;

        /// <summary>
        /// ���û��ȡ��λ���
        /// </summary>
        /// <value>��λ���</value>
        public string NickName
        {
            get { return nickName; }
            set { nickName = value; }
        }
        private string no;

        /// <summary>
        /// ���û��ȡ��λ���
        /// </summary>
        /// <value>��λ���</value>
        public string No
        {
            get { return no; }
            set { no = value; }
        }

        private string name;

        /// <summary>
        /// ���û��ȡ��λ����
        /// </summary>
        /// <value>��λ����</value>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string address;

        /// <summary>
        /// ���û��ȡ��λ��ַ
        /// </summary>
        /// <value>��λ��ַ</value>
        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        private string phone;

        /// <summary>
        /// ���û��ȡ��λ�绰
        /// </summary>
        /// <value>��λ�绰</value>
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        private string fax;

        /// <summary>
        /// ���û��ȡ�������
        /// </summary>
        /// <value>�������</value>
        public string Fax
        {
            get { return fax; }
            set { fax = value; }
        }

        private string postCode;

        /// <summary>
        /// ���û��ȡ��λ�ʱ�
        /// </summary>
        /// <value>��λ�ʱ�</value>
        public string PostCode
        {
            get { return postCode; }
            set { postCode = value; }
        }

        private string email;

        /// <summary>
        /// ���û��ȡ��λEmail
        /// </summary>
        /// <value>��λEmail</value>
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string url;

        /// <summary>
        /// ���û��ȡ��λ��ַ
        /// </summary>
        /// <value>��λ��ַ</value>
        public string Url
        {
            get { return url; }
            set { url = value; }
        }

        private string busIdType;

        /// <summary>
        /// ��λ��Ӫ֤������
        /// </summary>
        public string BusIdType
        {
            get { return busIdType; }
            set { busIdType = value; }
        }

        private string busId;

        /// <summary>
        /// ��λ��Ӫ֤��ĺ���
        /// </summary>
        public string BusId
        {
            get { return busId; }
            set { busId = value; }
        }
    }
}
