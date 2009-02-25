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
    /// 插件管理器，自带缓存，可从一个Assembly中载入所有的插件类别
    /// </summary>
    public class PluginManager
    {
        private static ILog log = log4net.LogManager.GetLogger("FT.Windows.Forms.Plugins.PluginManager");

        private static Hashtable caches = new Hashtable();

        /// <summary>
        /// 用来展示使用
        /// </summary>
        public static Hashtable Caches
        {
            get { return PluginManager.caches; }
        }

        /// <summary>
        /// 获取对应的插件类型
        /// </summary>
        /// <param name="type">类型</param>
        /// <returns>如果不存在该插件类型，执行初始化</returns>
        public static PluginAttribute GetPluginAttribute(Type type)
        {
            if (!type.IsAssignableFrom(typeof(IPlugin)))
            {
                throw new ArgumentException("类型名称不是IPlugin类型！");
            }
            if (!caches.Contains(type.FullName))
            {
                InitPlugin(type);
            }
            //TODO (PluginAttribute)null会怎么样?
            return (PluginAttribute)caches[type.FullName];
        }

        /// <summary>
        /// 初始化插件特性
        /// </summary>
        /// <param name="type">类型</param>
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
        /// 根据插件名称获取插件的绝对路径
        /// </summary>
        /// <param name="filename">插件dll名称</param>
        /// <returns>插件的绝对路径</returns>
        private static string ConvertPath(string filename)
        {
            return Application.StartupPath + "/plugins/" + filename;
        }

        /// <summary>
        /// 加载所有的插件
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
        /// 加载所有的插件
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
        /// 根据插件dll名称加载插件类型
        /// </summary>
        /// <param name="filename">dll文件名</param>
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
        /// 根据插件dll名称加载插件类型
        /// </summary>
        /// <param name="filename">dll文件名</param>
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
