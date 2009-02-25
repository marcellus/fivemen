using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace FT.Commons.Tools
{
    /// <summary>
    /// ����Ĺ����࣬��ʵ��
    /// </summary>
    public class ReflectHelper : BaseHelper
    {
        private static string exePath;

        private ReflectHelper()
        {
        }

        /// <summary>
        /// ��ȡ������ִ�е�·���ļ���
        /// </summary>
        /// <returns>�������ڵ�ִ��·��</returns>
        public static string GetExePath()
        {
            if (exePath == null || exePath == string.Empty)
            {
                string temp = Assembly.GetExecutingAssembly().Location;
                int i = temp.LastIndexOf("\\");
                if (i != -1)
                {
                    exePath = temp.Substring(0, i + 1);
                }
                else
                {
                    exePath = temp;
                }
            }
            Debug("��ȡ�ĳ���ִ��·���ļ���Ϊ->"+exePath);
            return exePath;
        }

        /// <summary>
        /// ������Ӧʵ��
        /// </summary>
        /// <param name="type">����</param>
        /// <returns>��Ӧʵ��</returns>
        public static object CreateInstance(string type)
        {
            return Assembly.GetExecutingAssembly().CreateInstance(type);
        }
    }
}
