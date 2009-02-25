using System;
using System.Collections.Generic;
using System.Text;

namespace FT.Windows.Forms.Plugins
{
    /// <summary>
    /// 抽象的程序单元的特性
    /// </summary>
    public abstract class AppUnitAttribute:Attribute
    {
        public const string Default_Method = "BeginCall";
        private string developer;

        /// <summary>
        /// 本应用程序单元的开发者名字
        /// </summary>
        public string Developer
        {
            get { return developer; }
            set { developer = value; }
        }

        private string company;

        /// <summary>
        /// 本应用程序单元的所属公司名称
        /// </summary>
        public string Company
        {
            get { return company; }
            set { company = value; }
        }

        private string mainVersion;

        /// <summary>
        /// 本应用程序单元的主要版本号
        /// </summary>
        public string MainVersion
        {
            get { return mainVersion; }
            set { mainVersion = value; }
        }

        private string changeLogPath;

        /// <summary>
        /// 本应用程序单元的changelog的文件路径
        /// </summary>
        public string ChangeLogPath
        {
            get { return changeLogPath; }
            set { changeLogPath = value; }
        }

        private string email;

        /// <summary>
        /// 本应用程序单元的公司联系Email
        /// </summary>
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string url;

        /// <summary>
        /// 本应用程序单元的公司Url
        /// </summary>
        public string Url
        {
            get { return url; }
            set { url = value; }
        }

        private string tel;

        /// <summary>
        /// 本应用程序单元的公司联系电话
        /// </summary>
        public string Tel
        {
            get { return tel; }
            set { tel = value; }
        }

        private string name;

        /// <summary>
        /// 本应用程序单元的名称
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private bool isDeploy=true;

        /// <summary>
        /// 本应用程序单元是否已经处于发布使用状态
        /// </summary>
        public bool IsDeploy
        {
            get { return isDeploy; }
            set { isDeploy = value; }
        }

        private bool isGlobalization;

        /// <summary>
        /// 本应用程序单元是否有被国际化
        /// </summary>
        public bool IsGlobalization
        {
            get { return isGlobalization; }
            set { isGlobalization = value; }
        }

        private string deployDate;

        /// <summary>
        /// 发布日期
        /// </summary>
        public string DeployDate
        {
            get { return deployDate; }
            set { deployDate = value; }
        }
    }
}
