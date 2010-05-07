using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FT.Commons.Tools
{
    /// <summary>
    /// 序列化的工具
    /// </summary>
    public class SerializeHelper : BaseHelper
    {
        /// <summary>
        ///  对一个对象执行序列化
        /// </summary>
        /// <param name="obj">需要序列化的对象</param>
        /// <returns>序列化后的字符串</returns>
        public static string SerializeToXml(object obj)
        {
            Debug("开始序列化对象->"+obj.GetType().FullName+"到字符串");
            XmlSerializer serialize = new XmlSerializer(obj.GetType());
            //TODO 内存流的是否需要close？
            StringWriter writer = new StringWriter();
           // MemoryStream writer=new MemoryStream();
            serialize.Serialize(writer, obj);
            string result=writer.ToString();
            writer.Close();
            Debug("序列化对象到字符串成功！");
            return result;
        }

        /// <summary>
        /// 从一个xml字符串中反序列化一个对象出来
        /// </summary>
        /// <param name="xml">待序列化的字符串</param>
        /// <returns>结果对象</returns>
        public static object DeserializeFromXml(Type type,string xml)
        {
            Debug("开始从字符串->"+xml+"-反序列化对象"+type.FullName);
            StringReader reader = new StringReader(xml);
            XmlSerializer serialize = new XmlSerializer(type);
            object obj= serialize.Deserialize(reader);
            Debug("从字符串反序列化对象成功！");
            return obj;
        }

        /// <summary>
        /// 序列化一个对象到文件中
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="filename">文件名</param>
        /// <returns>是否正确序列化</returns>
        public static bool SerializeToFile(object obj,string filename)
        {
            Debug("开始序列化到文件->" + filename);
            Stream stream=null;
            try
            {
                
                IFormatter formatter = new BinaryFormatter();
                stream = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, obj);
                stream.Close();
                Debug("序列化到文件完毕！");
                return true;
            }
            catch (Exception ex)
            {
                if (stream != null)
                    stream.Close();
                Info(ex);
                return false;
            }
        }

        /// <summary>
        /// 从文件反序列化一个对象出来
        /// </summary>
        /// <param name="filename">文件名称</param>
        /// <returns>反序列化的结果对象</returns>
        public static object DeserializeFromFile(string filename)
        {
            Debug("开始从文件->" + filename+"-反序列化");
            IFormatter formatter = new BinaryFormatter();
            Stream stream =null;
            object obj = null;
            try
            {
                stream= new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
                obj= formatter.Deserialize(stream);
                stream.Close();
                Debug("从文件反序列化成功！");
            }
            catch (Exception ex)
            {
                if (stream != null)
                    stream.Close();
                Info(ex);
                throw ex;
            }
            return obj;

        }
    }
}
