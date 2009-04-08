using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.IO;
using FT.Commons.Tools;

namespace FT.Commons.TcpIp
{
    /// <summary>
    /// TCP�������˵�����
    /// </summary>
    [Serializable]
    public class ServerConfig:ISerializable
    {
        private const string Config_File_Name = "serverconfig.ini";

        private int port;

        private string ip;

        /// <summary>
        /// ������IP����ö�IP���
        /// </summary>
        public string Ip
        {
            get { return ip; }
            set { ip = value; }
        }

        /// <summary>
        /// �����˿�
        /// </summary>
        public int Port
        {
            get { return port; }
            set { port = value; }
        }

        private bool defaultOpen;

        /// <summary>
        /// Ĭ���Ƿ��������������������
        /// </summary>
        public bool DefaultOpen
        {
            get { return defaultOpen; }
            set { defaultOpen = value; }
        }

        /// <summary>
        /// ��ȡ������Ϣ
        /// </summary>
        /// <returns>������Ϣ</returns>
        public static ServerConfig GetConfig()
        {
            string path = ReflectHelper.GetExePath() + "\\" + Config_File_Name;
            if (File.Exists(path))
            {
                ServerConfig config = (ServerConfig)SerializeHelper.DeserializeFromFile(path);
                return config;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// �������������
        /// </summary>
        /// <param name="config">������Ϣ</param>
        public static void SaveConfig(ServerConfig config)
        {
            string path = ReflectHelper.GetExePath() + "\\" + Config_File_Name;
            SerializeHelper.SerializeToFile(config, path);
        }

        #region ISerializable ��Ա

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Ip", Ip);
            info.AddValue("Port", Port);
            info.AddValue("DefaultOpen", DefaultOpen);
        }

        public ServerConfig()
        {
        }

        protected ServerConfig(SerializationInfo info, StreamingContext context)
        {
            this.DefaultOpen = info.GetBoolean("DefaultOpen");
            this.Port = info.GetInt32("Port");
            this.Ip = info.GetString("Ip");
        }

        #endregion
    }
}
