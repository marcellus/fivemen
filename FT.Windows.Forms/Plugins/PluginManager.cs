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
    /// 插件管理器，自带缓存，可从一个Assembly中载入所有的插件类别
    /// </summary>
    public class PluginManager
    {
        private static ILog log = log4net.LogManager.GetLogger("FT.Windows.Forms.Plugins.PluginManager");

        private static Hashtable useCaches = new Hashtable();

        /// <summary>
        /// 现在系统使用的插件
        /// </summary>
        public static Hashtable UseCaches
        {
            get { return PluginManager.useCaches; }
            set { PluginManager.useCaches = value; }
        }

        
       
        private static Hashtable allCaches = new Hashtable();

        /// <summary>
        /// 显示系统所有的插件
        /// </summary>
        public static Hashtable AllCaches
        {
            get { return PluginManager.allCaches; }
            set { PluginManager.allCaches = value; }
        }

        /// <summary>
        /// 获取全局缓存中AllCaches对应的插件类型
        /// </summary>
        /// <param name="type">类型</param>
        /// <returns>如果不存在该插件类型，执行初始化</returns>
        public static PluginAttribute GetPluginAttribute(Type type)
        {
            if (!type.IsAssignableFrom(typeof(IPlugin)))
            {
                throw new ArgumentException("类型名称不是IPlugin类型！");
            }
            if (!allCaches.Contains(type.AssemblyQualifiedName))
            {
                AddAllCache(type);
            }
            //TODO (PluginAttribute)null会怎么样?
            return (PluginAttribute)allCaches[type.AssemblyQualifiedName];
        }

        /// <summary>
        /// 初始化现使用插件的特性，同时进入到AllCache和UseCache
        /// </summary>
        /// <param name="type">类型</param>
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
        /// 初始化现使用插件的特性，只进入到使用的Cache中，UseCache
        /// </summary>
        /// <param name="type">类型</param>
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
        /// 初始化所有插件特性,进去AllCache中
        /// </summary>
        /// <param name="type">类型</param>
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
        /// 从一个文件路径中加载所有的插件类型到插件全局All缓存中
        /// </summary>
        /// <param name="path"></param>
        private static void AddAllCache(string path)
        {
            AddAllCache(new FileInfo(path));
        }
        /// <summary>
        /// 从一个文件中加载所有的插件类型到插件全局All缓存中
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
        /// 根据插件名称获取插件的绝对路径
        /// </summary>
        /// <param name="filename">插件dll名称</param>
        /// <returns>插件的绝对路径</returns>
        private static string ConvertPath(string filename)
        {
            return Application.StartupPath + "/plugins/" + filename;
        }

        //是否已经初始化插件的信息
        private static bool HavedInitPluginInfo = false;
        //是否已经注入插件
        private static bool HavedEmmitPlugin = false;


        /// <summary>
        /// 加载所有的插件信息，不进行注入
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
        /// 把一个插件类型注入到主窗体中
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
        /// 把一个插件注入进去并生产插件的hashtable
        /// </summary>
        /// <param name="form"></param>
        /// <param name="file"></param>
        private static void EmmitFromFile(BaseMainForm form, string file)
        {
            
            EmmitFromFile(form,new FileInfo(file));
        }
        /// <summary>
        /// 把一个插件注入进去并生产插件的hashtable
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
        /// 加载所有的插件,如果已经注入则不再注入，注入同时生成HashTable插件缓存
        /// </summary>
        public static void LoadAllPluginToMainForm(BaseMainForm form)
        {
            //LoadAllPlugin();
            ///TODO:需要从配置文件中加载，免得顺序不对
            LoadAllPluginCaches();
            if (!HavedEmmitPlugin)
            {

                PluginsFileConfig config=FT.Commons.Cache.StaticCacheManager.GetConfig<PluginsFileConfig>();
                if (config.PluginTypes.Count > 0)//如果配置里面插件数量大于0
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

        #region 测试方法 只加载插件信息，不进行实际注入
        /// <summary>
        /// 根据插件dll名称加载插件类型到在使用的缓存中 ，插件信息，不进行注入
        /// </summary>
        /// <param name="filename">dll文件名</param>
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
        /// 根据插件dll名称加载插件类型，插件信息，不进行注入
        /// </summary>
        /// <param name="filename">dll文件名</param>
        public static void LoadPluginFromAssembly(string filename)
        {
           LoadPluginFromAssembly(new FileInfo(filename));
       }
        #endregion

   }
}
