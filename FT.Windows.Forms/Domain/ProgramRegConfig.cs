using System;
using System.Collections.Generic;
using System.Text;
using FT.Commons.Tools;
using System.IO;
using System.Windows.Forms;

namespace FT.Windows.Forms.Domain
{
    /// <summary>
    /// ����ע���������
    /// </summary>
    [Serializable]
    public class ProgramRegConfig
    {
        /// <summary>
        /// ע��ʱ��
        /// </summary>
        private DateTime regDate;

        public DateTime RegDate
        {
            get { return regDate; }
            set { regDate = value; }
        }

        /// <summary>
        /// ���ʹ��ʱ��
        /// </summary>
        private DateTime lastDate;

        public DateTime LastDate
        {
            get { return lastDate; }
            set { lastDate = value; }
        }

        /// <summary>
        /// ʹ�ô���
        /// </summary>
        private int useCount;

        public int UseCount
        {
            get { return useCount; }
            set { useCount = value; }
        }

        /// <summary>
        /// ע����
        /// </summary>
        private string keyCode = string.Empty;

        public string KeyCode
        {
            get { return keyCode; }
            set { keyCode = value; }
        }

        /// <summary>
        /// ��Ȩ��
        /// </summary>
        private string rightCode = string.Empty;

        public string RightCode
        {
            get { return rightCode; }
            set { rightCode = value; }
        }

        /// <summary>
        /// ��Ȩ��˾��
        /// </summary>
        private string company = string.Empty;

        public string Company
        {
            get { return company; }
            set { company = value; }
        }
    }
}
