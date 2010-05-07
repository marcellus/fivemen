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
    /// ���л��Ĺ���
    /// </summary>
    public class SerializeHelper : BaseHelper
    {
        /// <summary>
        ///  ��һ������ִ�����л�
        /// </summary>
        /// <param name="obj">��Ҫ���л��Ķ���</param>
        /// <returns>���л�����ַ���</returns>
        public static string SerializeToXml(object obj)
        {
            Debug("��ʼ���л�����->"+obj.GetType().FullName+"���ַ���");
            XmlSerializer serialize = new XmlSerializer(obj.GetType());
            //TODO �ڴ������Ƿ���Ҫclose��
            StringWriter writer = new StringWriter();
           // MemoryStream writer=new MemoryStream();
            serialize.Serialize(writer, obj);
            string result=writer.ToString();
            writer.Close();
            Debug("���л������ַ����ɹ���");
            return result;
        }

        /// <summary>
        /// ��һ��xml�ַ����з����л�һ���������
        /// </summary>
        /// <param name="xml">�����л����ַ���</param>
        /// <returns>�������</returns>
        public static object DeserializeFromXml(Type type,string xml)
        {
            Debug("��ʼ���ַ���->"+xml+"-�����л�����"+type.FullName);
            StringReader reader = new StringReader(xml);
            XmlSerializer serialize = new XmlSerializer(type);
            object obj= serialize.Deserialize(reader);
            Debug("���ַ��������л�����ɹ���");
            return obj;
        }

        /// <summary>
        /// ���л�һ�������ļ���
        /// </summary>
        /// <param name="obj">����</param>
        /// <param name="filename">�ļ���</param>
        /// <returns>�Ƿ���ȷ���л�</returns>
        public static bool SerializeToFile(object obj,string filename)
        {
            Debug("��ʼ���л����ļ�->" + filename);
            Stream stream=null;
            try
            {
                
                IFormatter formatter = new BinaryFormatter();
                stream = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, obj);
                stream.Close();
                Debug("���л����ļ���ϣ�");
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
        /// ���ļ������л�һ���������
        /// </summary>
        /// <param name="filename">�ļ�����</param>
        /// <returns>�����л��Ľ������</returns>
        public static object DeserializeFromFile(string filename)
        {
            Debug("��ʼ���ļ�->" + filename+"-�����л�");
            IFormatter formatter = new BinaryFormatter();
            Stream stream =null;
            object obj = null;
            try
            {
                stream= new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
                obj= formatter.Deserialize(stream);
                stream.Close();
                Debug("���ļ������л��ɹ���");
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
