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
    /// Ĭ�ϵľ�̬cache����������ˢ�µľ�̬cache
    /// </summary>
    public class StaticCacheManager
    {

        private static Hashtable caches = new Hashtable();

        public static Hashtable Caches
        {
            get { return StaticCacheManager.caches; }
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        /// <param name="obj">keyΪobj��ȫ����valueΪobj����</param>
        public static void Add(object obj)
        {
            //CollectionBase
            Add(obj.GetType().FullName, obj);
        }

        /// <summary>
        /// ��ӻ��߸��»���
        /// </summary>
        /// <param name="key">�ؼ���</param>
        /// <param name="value">�����ֵ</param>
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
        /// ��ȡĳһ��key��cache����
        /// </summary>
        /// <param name="key">key</param>
        /// <returns>cache�������û��Ϊ��</returns>
        public static object Get(object key)
        {
            return caches[key];
        }

        /// <summary>
        /// ��ȡĳһ������cache�ķ��ͷ���
        /// </summary>
        /// <typeparam name="T">���Ͷ���</typeparam>
        /// <returns>��������ڻ���ô����</returns>
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
        /// ��ȡĳһ������Config��cache�ķ��ͷ���
        /// </summary>
        /// <typeparam name="T">���Ͷ���</typeparam>
        /// <returns>��������ڻ���ô����</returns>
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
        /// ɾ�������ļ�
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
        /// ����ĳһ�����������
        /// </summary>
        /// <typeparam name="T">���Ͷ���</typeparam>
        /// <returns>��������ڻ���ô����</returns>
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
