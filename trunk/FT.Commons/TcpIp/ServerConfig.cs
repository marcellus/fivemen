using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.IO;
using FT.Commons.Tools;

namespace FT.Commons.TcpIp
{
    /// <summary>
    /// TCP服务器端的配置
    /// </summary>
    [Serializable]
    public class ServerConfig:ISerializable
    {
        private const string Config_File_Name = "serverconfig.ini";

        private int port;

        private string ip;

        /// <summary>
        /// 服务器IP，免得多IP情况
        /// </summary>
        public string Ip
        {
            get { return ip; }
            set { ip = value; }
        }

        /// <summary>
        /// 监听端口
        /// </summary>
        public int Port
        {
            get { return port; }
            set { port = value; }
        }

        private bool defaultOpen;

        /// <summary>
        /// 默认是否随程序启动而启动监听
        /// </summary>
        public bool DefaultOpen
        {
            get { return defaultOpen; }
            set { defaultOpen = value; }
        }

        /// <summary>
        /// 获取配置信息
        /// </summary>
        /// <returns>配置信息</returns>
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
        /// 保存服务器配置
        /// </summary>
        /// <param name="config">配置信息</param>
        public static void SaveConfig(ServerConfig config)
        {
            string path = ReflectHelper.GetExePath() + "\\" + Config_File_Name;
            SerializeHelper.SerializeToFile(config, path);
        }

        #region ISerializable 成员

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
