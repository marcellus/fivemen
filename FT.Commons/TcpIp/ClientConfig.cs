using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using FT.Commons.Tools;
using System.IO;

namespace FT.Commons.TcpIp
{
    /// <summary>
    /// TCP�������˵�����
    /// </summary>
    [Serializable]
    public class ClientConfig : ISerializable
    {
        private const string Config_File_Name = "clientconfig.ini";
        private string ip;
        private string serverIp;

        /// <summary>
        /// ������IP
        /// </summary>
        public string ServerIp
        {
            get { return serverIp; }
            set { serverIp = value; }
        }

        /// <summary>
        /// ����IP
        /// </summary>
        public string Ip
        {
          get { return ip; }
          set { ip = value; }
        }

        private int port;

        /// <summary>
        /// �����˿�
        /// </summary>
        public int Port
        {
            get { return port; }
            set { port = value; }
        }

        /// <summary>
        /// ��ȡ������Ϣ
        /// </summary>
        /// <returns>������Ϣ</returns>
        public static ClientConfig GetConfig()
        {
            string path = ReflectHelper.GetExePath() + "\\" + Config_File_Name;
            if (File.Exists(path))
            {
                ClientConfig config = (ClientConfig)SerializeHelper.DeserializeFromFile(path);
                return config;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// ����ͻ�������
        /// </summary>
        /// <param name="config">������Ϣ</param>
        public static void SaveConfig(ClientConfig config)
        {
            string path = ReflectHelper.GetExePath() + "\\" + Config_File_Name;
            SerializeHelper.SerializeToFile(config, path);
        }

        #region ISerializable ��Ա

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Port", Port);
            info.AddValue("Ip", Ip);
            info.AddValue("ServerIp", ServerIp);
        }

        public ClientConfig()
        {
        }

        protected ClientConfig(SerializationInfo info, StreamingContext context)
        {
            this.Ip = info.GetString("Ip");
            this.Port = info.GetInt32("Port");
            this.ServerIp = info.GetString("ServerIp");
        }

        #endregion
    }
}
