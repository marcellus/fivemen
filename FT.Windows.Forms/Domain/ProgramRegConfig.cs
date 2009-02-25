using System;
using System.Collections.Generic;
using System.Text;
using FT.Commons.Tools;
using System.IO;
using System.Windows.Forms;

namespace FT.Windows.Forms.Domain
{
    /// <summary>
    /// 程序注册的配置项
    /// </summary>
    [Serializable]
    public class ProgramRegConfig
    {
        /// <summary>
        /// 注册时间
        /// </summary>
        private DateTime regDate;

        public DateTime RegDate
        {
            get { return regDate; }
            set { regDate = value; }
        }

        /// <summary>
        /// 最后使用时间
        /// </summary>
        private DateTime lastDate;

        public DateTime LastDate
        {
            get { return lastDate; }
            set { lastDate = value; }
        }

        /// <summary>
        /// 使用次数
        /// </summary>
        private int useCount;

        public int UseCount
        {
            get { return useCount; }
            set { useCount = value; }
        }

        /// <summary>
        /// 注册码
        /// </summary>
        private string keyCode = string.Empty;

        public string KeyCode
        {
            get { return keyCode; }
            set { keyCode = value; }
        }

        /// <summary>
        /// 授权码
        /// </summary>
        private string rightCode = string.Empty;

        public string RightCode
        {
            get { return rightCode; }
            set { rightCode = value; }
        }

        /// <summary>
        /// 授权公司名
        /// </summary>
        private string company = string.Empty;

        public string Company
        {
            get { return company; }
            set { company = value; }
        }
    }
}
