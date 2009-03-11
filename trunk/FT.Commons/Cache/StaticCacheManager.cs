using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using FT.Commons.Tools;
using System.IO;

namespace FT.Commons.Cache
{
    /// <summary>
    /// 默认的静态cache管理器，不刷新的静态cache
    /// </summary>
    public class StaticCacheManager
    {

        private static Hashtable caches = new Hashtable();

        public static Hashtable Caches
        {
            get { return StaticCacheManager.caches; }
        }

        /// <summary>
        /// 增驾一个对象
        /// </summary>
        /// <param name="obj">key为obj类全名，value为obj对象</param>
        public static void Add(object obj)
        {
            //CollectionBase
            Add(obj.GetType().FullName, obj);
        }

        /// <summary>
        /// 添加或者更新缓存
        /// </summary>
        /// <param name="key">关键字</param>
        /// <param name="value">具体的值</param>
        public static void Add(object key, object value)
        {
            if (caches.Contains(key))
            {
                caches[key] = value;
            }
            else
            {
                caches.Add(key, value);
            }
        }

        /// <summary>
        /// 获取某一个key的cache对象
        /// </summary>
        /// <param name="key">key</param>
        /// <returns>cache对象，如果没有为空</returns>
        public static object Get(object key)
        {
            return caches[key];
        }

        /// <summary>
        /// 获取某一个对象cache的泛型方法
        /// </summary>
        /// <typeparam name="T">泛型对象</typeparam>
        /// <returns>如果不存在会怎么样？</returns>
        public static T Get<T>()
        {
            string typename = typeof(T).FullName;
            if (!caches.Contains(typename))
            {
                Add(System.Activator.CreateInstance<T>());
            }

            return (T)Get(typename);
        }

        /// <summary>
        /// 获取某一个对象Config的cache的泛型方法
        /// </summary>
        /// <typeparam name="T">泛型对象</typeparam>
        /// <returns>如果不存在会怎么样？</returns>
        public static T GetConfig<T>()
        {
            string typename = typeof(T).FullName;
            if (!caches.Contains(typename))
            {
                string path = ReflectHelper.GetExePath() + "/config/" + typeof(T).Name + ".cfg";
                if (File.Exists(path))
                {
                    object config = SerializeHelper.DeserializeFromFile(path);
                    caches.Add(typename, config);
                }
            }
            return (T)Get<T>();
        }
        /// <summary>
        /// 删除配置文件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static void RemoveConfig<T>()
        {
            string path = ReflectHelper.GetExePath() + "/config/" + typeof(T).Name + ".cfg";
            if (File.Exists(path))
            {
                File.Delete(path);
                caches.Remove(typeof(T).FullName);
            }
        }

        /// <summary>
        /// 保存某一个对象的配置
        /// </summary>
        /// <typeparam name="T">泛型对象</typeparam>
        /// <returns>如果不存在会怎么样？</returns>
        public static void SaveConfig<T>(T config)
        {
            string dir = ReflectHelper.GetExePath() + "/config";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            string typename = typeof(T).FullName;
            string path = ReflectHelper.GetExePath() + "/config/" + typeof(T).Name + ".cfg";
            if (SerializeHelper.SerializeToFile(config,path))
            {
                Add(typename, config);
            }
        }
    }
}
