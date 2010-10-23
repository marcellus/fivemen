using System;

using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Reflection;
using System.IO;
using System.Collections;
using System.Data;

namespace PDA.DataInit
{
    /// <summary>
    /// 默认的静态cache管理器，不刷新的静态cache
    /// </summary>
    public class StaticCacheManager
    {

        private static Hashtable caches = new Hashtable();

        public Hashtable Caches
        {
            get { return StaticCacheManager.caches; }
        }



        private StaticCacheManager()
        {

        }
        private static string configfile = "configs.xml";

        public void WriteConfig(string key, string value)
        {


        }
        private static string ReadConfigFromFile(string key)
        {
            string result = string.Empty;
            XmlDocument doc = new XmlDocument();
            doc.Load(Path.GetDirectoryName(Assembly.Load(Assembly.GetExecutingAssembly().GetName()).GetName().CodeBase)+"\\"+configfile);
            XmlNode node = doc.SelectSingleNode("//Configs/"+key);
            if(node!=null)  
            {
                result = node.InnerText;
            }
            return result;
        }


        public static string GetConfig(string key)
        {
            if(!caches.Contains(key))
            {
                string value = ReadConfigFromFile(key);
                caches.Add(key,value);

            }
            return (string)caches[key];

        }

        public static DataTable GetDictTable(int dicttype)
        {
            return SqliteDbFactory.GetSqliteDbOperator().SelectFromSql("select dicttext,dictvalue from mydicts where dicttype=" + dicttype);
        }

        public static void BindDict(ComboBox cb, int dicttype)
        {
            cb.DisplayMember = "dicttext";
            cb.ValueMember = "dictvalue";
            cb.DataSource = GetDictTable(dicttype);
        }
    }
}
