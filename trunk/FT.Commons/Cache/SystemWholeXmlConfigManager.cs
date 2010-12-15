using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Xml;
using System.Reflection;
using System.IO;
using FT.Commons.Tools;
using log4net;

namespace FT.Commons.Cache
{
     /// <summary>
    /// 默认的静态cache管理器，不刷新的静态cache
    /// </summary>
    public class SystemWholeXmlConfigManager
    {
        protected static ILog log = log4net.LogManager.GetLogger("SystemWholeXmlConfigManager");
        private static Hashtable caches = new Hashtable();

        public static Hashtable Caches
        {
            get { return SystemWholeXmlConfigManager.caches; }
        }



        private SystemWholeXmlConfigManager()
        {

        }
        private static string configfile = "whole-configs.xml";

        /// <summary>
        /// 保存配置文件
        /// </summary>
        private static void SaveConfig()
        {
            string path = Path.GetDirectoryName(Assembly.Load(Assembly.GetExecutingAssembly().GetName()).GetName().CodeBase) + "\\" + configfile;
            if (path.StartsWith("file:\\"))
            {
                path = path.Substring(6);
            }
            if (log.IsDebugEnabled)
            {
                log.Debug("保存的全局配置文件路径为："+path);
                log.Debug("保存的全局配置数量个数为："+caches.Count);
            }
            SerializeHelper.SerializeToFile(caches, path);
        }
        /// <summary>
        /// 对新增或者修改的配置项进行保存配置
        /// </summary>
        /// <param name="config">新增或者修改的配置项</param>
        public static void SaveConfig(SystemWholeXmlConfig config)
        {
            EnsureLoaded();
            caches[config.Key]=config;
            SaveConfig();
        }

        /// <summary>
        /// 对现有的配置项进行删除
        /// </summary>
        /// <param name="config">需要删除的配置项的key</param>
        public static void RemoveConfig(string  key)
        {
            EnsureLoaded();
            caches.Remove(key);
            SaveConfig();
        }

        
        public static void LoadConfigFromFile()
        {
            string path = Path.GetDirectoryName(Assembly.Load(Assembly.GetExecutingAssembly().GetName()).GetName().CodeBase) + "\\" + configfile;
            if (path.StartsWith("file:\\"))
            {
                path = path.Substring(6);
            }
            if (log.IsDebugEnabled)
            {
                log.Debug("获取的全局配置文件路径为：" + path);
            }
            if (File.Exists(path))
            {
                object config = SerializeHelper.DeserializeFromFile(path);
                SystemWholeXmlConfigManager.caches = config as Hashtable;
                log.Debug("获取的全局配置项数量为：" + caches.Count);
            }
        }

        public static void EnsureLoaded()
        {
            if (caches.Count == 0)
            {
                LoadConfigFromFile();

            }
        }

        /// <summary>
        /// 获取有效的配置项
        /// </summary>
        /// <param name="key">配置项的key</param>
        /// <returns>配置项的value</returns>
        public static string GetConfig(string key)
        {
            EnsureLoaded();
            if (!caches.Contains(key))
            {
                return string.Empty;
            }
            else
            {
                SystemWholeXmlConfig config=((SystemWholeXmlConfig)caches[key]);
                if(config.Valid==1)
                {
                    return config.Value;
                }
                return string.Empty;
            }

        }
    }
}
