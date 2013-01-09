using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;

namespace FT.Commons.Tools
{
    /// <summary>
    /// json解析工具
    /// </summary>
    public class JsonHelper:BaseHelper
    {
        private JsonHelper()
        {
        }
        /// <summary>
        /// 对象转换成json字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToJson(object obj)
        {
            JsonSerializer serializer = new JsonSerializer();
            StringWriter sw = new StringWriter();
            serializer.Serialize(new JsonTextWriter(sw), obj);
            return sw.GetStringBuilder().ToString();

        }
        /// <summary>
        /// json字符串转换成字符
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T FromJson<T>(string json)
        {
            JsonSerializer serializer = new JsonSerializer();
            StringReader sr = new StringReader(json);
             T obj = (T)serializer.Deserialize(new JsonTextReader(sr),typeof(T));
             return obj;
        }
    }
}
