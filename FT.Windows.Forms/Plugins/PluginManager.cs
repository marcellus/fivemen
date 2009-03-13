using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using log4net;
using System.Reflection;
using System.Windows.Forms;
using System.IO;
using FT.Commons.Tools;

namespace FT.Windows.Forms.Plugins
{
    /// <summary>
    /// ������������Դ����棬�ɴ�һ��Assembly���������еĲ�����
    /// </summary>
    public class PluginManager
    {
        private static ILog log = log4net.LogManager.GetLogger("FT.Windows.Forms.Plugins.PluginManager");

        private static Hashtable useCaches = new Hashtable();

        /// <summary>
        /// ����ϵͳʹ�õĲ��
        /// </summary>
        public static Hashtable UseCaches
        {
            get { return PluginManager.useCaches; }
            set { PluginManager.useCaches = value; }
        }

        
       
        private static Hashtable allCaches = new Hashtable();

        /// <summary>
        /// ��ʾϵͳ���еĲ��
        /// </summary>
        public static Hashtable AllCaches
        {
            get { return PluginManager.allCaches; }
            set { PluginManager.allCaches = value; }
        }

        /// <summary>
        /// ��ȡȫ�ֻ�����AllCaches��Ӧ�Ĳ������
        /// </summary>
        /// <param name="type">����</param>
        /// <returns>��������ڸò�����ͣ�ִ�г�ʼ��</returns>
        public static PluginAttribute GetPluginAttribute(Type type)
        {
            if (!type.IsAssignableFrom(typeof(IPlugin)))
            {
                throw new ArgumentException("�������Ʋ���IPlugin���ͣ�");
            }
            if (!allCaches.Contains(type.AssemblyQualifiedName))
            {
                AddAllCache(type);
            }
            //TODO (PluginAttribute)null����ô��?
            return (PluginAttribute)allCaches[type.AssemblyQualifiedName];
        }

        /// <summary>
        /// ��ʼ����ʹ�ò�������ԣ�ͬʱ���뵽AllCache��UseCache
        /// </summary>
        /// <param name="type">����</param>
        private static void AddUseAndAllCache(Type type)
        {
            if (!allCaches.Contains(type.AssemblyQualifiedName))
            {
                PluginAttribute att = Attribute.GetCustomAttribute(type, typeof(PluginAttribute)) as PluginAttribute;
                if (att != null)
                {
                    allCaches.Add(type.AssemblyQualifiedName, att);
                    useCaches.Add(type.AssemblyQualifiedName, att);
                }
            }
        }

        /// <summary>
        /// ��ʼ����ʹ�ò�������ԣ�ֻ���뵽ʹ�õ�Cache�У�UseCache
        /// </summary>
        /// <param name="type">����</param>
        private static void AddUseCache(Type type)
        {
            if (!useCaches.Contains(type.AssemblyQualifiedName))
            {
                PluginAttribute att = Attribute.GetCustomAttribute(type, typeof(PluginAttribute)) as PluginAttribute;
                if (att != null)
                {
                    useCaches.Add(type.AssemblyQualifiedName, att);
                }
            }
        }

        /// <summary>
        /// ��ʼ�����в������,��ȥAllCache��
        /// </summary>
        /// <param name="type">����</param>
        private static void AddAllCache(Type type)
        {
            if (!allCaches.Contains(type.AssemblyQualifiedName))
            {
                PluginAttribute att = Attribute.GetCustomAttribute(type, typeof(PluginAttribute)) as PluginAttribute;
                if (att != null)
                {
                    allCaches.Add(type.AssemblyQualifiedName, att);
                    
                }
            }
        }
        /// <summary>
        /// ��һ���ļ�·���м������еĲ�����͵����ȫ��All������
        /// </summary>
        /// <param name="path"></param>
        private static void AddAllCache(string path)
        {
            AddAllCache(new FileInfo(path));
        }
        /// <summary>
        /// ��һ���ļ��м������еĲ�����͵����ȫ��All������
        /// </summary>
        /// <param name="info"></param>
        private static void AddAllCache(FileInfo file)
        {
            if (!(file.FullName.EndsWith(".dll") || file.FullName.EndsWith(".exe")))
            {
                return;
            }
            if (file.Exists)
            {
                //AppDomain.CurrentDomain.Load(
                //Assembly ass = Assembly.LoadFile(file.FullName);
                Assembly ass = Assembly.LoadFrom(file.FullName);
                Type[] types = ass.GetTypes();
                foreach (Type type in types)
                {
                    AddAllCache(type);
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

        //�Ƿ��Ѿ���ʼ���������Ϣ
        private static bool HavedInitPluginInfo = false;
        //�Ƿ��Ѿ�ע����
        private static bool HavedEmmitPlugin = false;


        /// <summary>
        /// �������еĲ����Ϣ��������ע��
        /// </summary>
        private static void LoadAllPluginCaches()
        {
            if (!HavedInitPluginInfo)
            {
                DirectoryInfo dir = new DirectoryInfo(Application.StartupPath + "/plugins");
                FileInfo[] files = null;
                if (dir.Exists)
                {
                    files = dir.GetFiles();
                    foreach (FileInfo tmp in files)
                    {
                        AddAllCache(tmp);

                    }
                }
                dir = new DirectoryInfo(Application.StartupPath);
                if (dir.Exists)
                {
                    files = dir.GetFiles();
                    foreach (FileInfo tmp in files)
                    {
                        AddAllCache(tmp);
                    }
                }
                HavedInitPluginInfo = true;
            }
        }
        /// <summary>
        /// ��һ���������ע�뵽��������
        /// </summary>
        /// <param name="form"></param>
        /// <param name="type"></param>
        private static void EmmitFromType(BaseMainForm form, Type type)
        {
            if (typeof(IPlugin).IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract)
            {
                //InitPlugin(type);
                
                IPlugin obj = FT.Commons.Tools.ReflectHelper.CreateInstance(type) as IPlugin;
                if (obj != null)
                {
                    AddUseCache(type);
                    obj.Emmit(form);
                }
                
            }
        }

        /// <summary>
        /// ��һ�����ע���ȥ�����������hashtable
        /// </summary>
        /// <param name="form"></param>
        /// <param name="file"></param>
        private static void EmmitFromFile(BaseMainForm form, string file)
        {
            
            EmmitFromFile(form,new FileInfo(file));
        }
        /// <summary>
        /// ��һ�����ע���ȥ�����������hashtable
        /// </summary>
        /// <param name="form"></param>
        /// <param name="file"></param>
        private static void EmmitFromFile(BaseMainForm form, FileInfo file)
        {
            if (!file.FullName.EndsWith(".dll"))
            {
                return;
            }
            if (file.Exists && form != null)
            {
                //AppDomain.CurrentDomain.Load(
                //Assembly ass = Assembly.LoadFile(file.FullName);
                Assembly ass = Assembly.LoadFrom(file.FullName);
                Type[] types = ass.GetTypes();
                foreach (Type type in types)
                {
                    EmmitFromType(form, type);
                }
            }
        }

        /// <summary>
        /// �������еĲ��,����Ѿ�ע������ע�룬ע��ͬʱ����HashTable�������
        /// </summary>
        public static void LoadAllPluginToMainForm(BaseMainForm form)
        {
            //LoadAllPlugin();
            ///TODO:��Ҫ�������ļ��м��أ����˳�򲻶�
            LoadAllPluginCaches();
            if (!HavedEmmitPlugin)
            {

                PluginsFileConfig config=FT.Commons.Cache.StaticCacheManager.GetConfig<PluginsFileConfig>();
                if (config.PluginTypes.Count > 0)//���������������������0
                {
                    string tmp = "";
                    for (int i = 0; i < config.PluginTypes.Count;i++ )
                    {
                        tmp = config.PluginTypes[i].ToString();
                        EmmitFromType(form, System.Type.GetType(tmp));
                    }
                }
                
                else
                {
                    System.Collections.IDictionaryEnumerator enumerator = AllCaches.GetEnumerator();
                    //ListViewItem tmp = null;
                    string att = string.Empty;
                    while (enumerator.MoveNext())
                    {
                        att = enumerator.Key.ToString();
                        if (att != null)
                        {
                            EmmitFromType(form, System.Type.GetType(att));
                        }
                    }
                }
                HavedEmmitPlugin = true;
            }

        }

        #region ���Է��� ֻ���ز����Ϣ��������ʵ��ע��
        /// <summary>
        /// ���ݲ��dll���Ƽ��ز�����͵���ʹ�õĻ����� �������Ϣ��������ע��
        /// </summary>
        /// <param name="filename">dll�ļ���</param>
        public static void LoadPluginFromAssembly(FileInfo info)
        {
            Assembly ass = Assembly.LoadFrom(info.FullName);
            Type[] types = ass.GetTypes();
            foreach (Type type in types)
            {
                //bool tmp = typeof(IPlugin).IsAssignableFrom(type);
               // bool tmp2 = type.IsAssignableFrom(typeof(IPlugin));
               // bool tmp3 = type.GetInterface(typeof(IPlugin).FullName) != null; 
                if (typeof(IPlugin).IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract)
                {
                    AddUseCache(type);
                }
            }
        }

        /// <summary>
        /// ���ݲ��dll���Ƽ��ز�����ͣ������Ϣ��������ע��
        /// </summary>
        /// <param name="filename">dll�ļ���</param>
        public static void LoadPluginFromAssembly(string filename)
        {
           LoadPluginFromAssembly(new FileInfo(filename));
       }
        #endregion

   }
}
