using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using log4net;
using System.Reflection;
using System.Windows.Forms;
using System.IO;

namespace FT.Windows.Forms.Plugins
{
    /// <summary>
    /// ������������Դ����棬�ɴ�һ��Assembly���������еĲ�����
    /// </summary>
    public class PluginManager
    {
        private static ILog log = log4net.LogManager.GetLogger("FT.Windows.Forms.Plugins.PluginManager");

        private static Hashtable caches = new Hashtable();

        /// <summary>
        /// ����չʾʹ��
        /// </summary>
        public static Hashtable Caches
        {
            get { return PluginManager.caches; }
        }

        /// <summary>
        /// ��ȡ��Ӧ�Ĳ������
        /// </summary>
        /// <param name="type">����</param>
        /// <returns>��������ڸò�����ͣ�ִ�г�ʼ��</returns>
        public static PluginAttribute GetPluginAttribute(Type type)
        {
            if (!type.IsAssignableFrom(typeof(IPlugin)))
            {
                throw new ArgumentException("�������Ʋ���IPlugin���ͣ�");
            }
            if (!caches.Contains(type.FullName))
            {
                InitPlugin(type);
            }
            //TODO (PluginAttribute)null����ô��?
            return (PluginAttribute)caches[type.FullName];
        }

        /// <summary>
        /// ��ʼ���������
        /// </summary>
        /// <param name="type">����</param>
        private static void InitPlugin(Type type)
        {
            if (!caches.Contains(type.FullName))
            {
                PluginAttribute att = Attribute.GetCustomAttribute(type, typeof(PluginAttribute)) as PluginAttribute;
                if (att != null)
                {
                    caches.Add(type.FullName, att);
                }
            }
        }

        /// <summary>
        /// ���ݲ�����ƻ�ȡ����ľ���·��
        /// </summary>
        /// <param name="filename">���dll����</param>
        /// <returns>����ľ���·��</returns>
        private static string ConvertPath(string filename)
        {
            return Application.StartupPath + "/plugins/" + filename;
        }

        /// <summary>
        /// �������еĲ��
        /// </summary>
        public static void LoadAllPlugin()
        {
            DirectoryInfo dir = new DirectoryInfo(Application.StartupPath + "/plugins");
            if (dir.Exists)
            {
                FileInfo[] files=dir.GetFiles();
                foreach (FileInfo tmp in files)
                {
                    LoadPluginFromAssembly(tmp);
                }
            }
        }

        /// <summary>
        /// �������еĲ��
        /// </summary>
        public static void LoadAllPluginToMainForm(BaseMainForm form)
        {
            DirectoryInfo dir = new DirectoryInfo(Application.StartupPath + "/plugins");
            if (dir.Exists)
            {
                FileInfo[] files = dir.GetFiles();
                foreach (FileInfo tmp in files)
                {
                    Assembly ass = Assembly.LoadFile(tmp.FullName);
                    Type[] types = ass.GetTypes();
                    foreach (Type type in types)
                    {
                        if (typeof(IPlugin).IsAssignableFrom(type))
                        {
                            IPlugin obj=System.Activator.CreateInstance(type) as IPlugin;
                            obj.Emmit(form);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// ���ݲ��dll���Ƽ��ز������
        /// </summary>
        /// <param name="filename">dll�ļ���</param>
        public static void LoadPluginFromAssembly(FileInfo info)
        {
            Assembly ass = Assembly.LoadFile(info.FullName);
            Type[] types = ass.GetTypes();
            foreach (Type type in types)
            {
                //bool tmp = typeof(IPlugin).IsAssignableFrom(type);
               // bool tmp2 = type.IsAssignableFrom(typeof(IPlugin));
               // bool tmp3 = type.GetInterface(typeof(IPlugin).FullName) != null; 
                if (typeof(IPlugin).IsAssignableFrom(type))
                {
                    InitPlugin(type);
                }
            }
        }

        /// <summary>
        /// ���ݲ��dll���Ƽ��ز������
        /// </summary>
        /// <param name="filename">dll�ļ���</param>
        public static void LoadPluginFromAssembly(string filename)
        {
            Assembly ass = Assembly.LoadFile(ConvertPath(filename));
            Type[] types=ass.GetTypes();
            foreach (Type type in types)
            {
                if (type.IsAssignableFrom(typeof(IPlugin)))
                {
                    InitPlugin(type);
                }
            }
        }

    }
}
