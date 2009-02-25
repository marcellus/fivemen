using System;
using System.Collections.Generic;
using System.Text;

namespace FT.Windows.Forms.Plugins
{
    /// <summary>
    /// ����ĳ���Ԫ������
    /// </summary>
    public abstract class AppUnitAttribute:Attribute
    {
        public const string Default_Method = "BeginCall";
        private string developer;

        /// <summary>
        /// ��Ӧ�ó���Ԫ�Ŀ���������
        /// </summary>
        public string Developer
        {
            get { return developer; }
            set { developer = value; }
        }

        private string company;

        /// <summary>
        /// ��Ӧ�ó���Ԫ��������˾����
        /// </summary>
        public string Company
        {
            get { return company; }
            set { company = value; }
        }

        private string mainVersion;

        /// <summary>
        /// ��Ӧ�ó���Ԫ����Ҫ�汾��
        /// </summary>
        public string MainVersion
        {
            get { return mainVersion; }
            set { mainVersion = value; }
        }

        private string changeLogPath;

        /// <summary>
        /// ��Ӧ�ó���Ԫ��changelog���ļ�·��
        /// </summary>
        public string ChangeLogPath
        {
            get { return changeLogPath; }
            set { changeLogPath = value; }
        }

        private string email;

        /// <summary>
        /// ��Ӧ�ó���Ԫ�Ĺ�˾��ϵEmail
        /// </summary>
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string url;

        /// <summary>
        /// ��Ӧ�ó���Ԫ�Ĺ�˾Url
        /// </summary>
        public string Url
        {
            get { return url; }
            set { url = value; }
        }

        private string tel;

        /// <summary>
        /// ��Ӧ�ó���Ԫ�Ĺ�˾��ϵ�绰
        /// </summary>
        public string Tel
        {
            get { return tel; }
            set { tel = value; }
        }

        private string name;

        /// <summary>
        /// ��Ӧ�ó���Ԫ������
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private bool isDeploy=true;

        /// <summary>
        /// ��Ӧ�ó���Ԫ�Ƿ��Ѿ����ڷ���ʹ��״̬
        /// </summary>
        public bool IsDeploy
        {
            get { return isDeploy; }
            set { isDeploy = value; }
        }

        private bool isGlobalization;

        /// <summary>
        /// ��Ӧ�ó���Ԫ�Ƿ��б����ʻ�
        /// </summary>
        public bool IsGlobalization
        {
            get { return isGlobalization; }
            set { isGlobalization = value; }
        }

        private string deployDate;

        /// <summary>
        /// ��������
        /// </summary>
        public string DeployDate
        {
            get { return deployDate; }
            set { deployDate = value; }
        }
    }
}
