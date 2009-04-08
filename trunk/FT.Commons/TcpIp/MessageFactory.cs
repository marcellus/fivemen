using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using FT.Commons.Tools;
using System.Drawing;
using System.IO;

namespace FT.Commons.TcpIp
{
    /// <summary>
    /// 消息工厂，进行消息的一些初始化,供消息发送者调用
    /// </summary>
    public class MessageFactory
    {

        private static SenderInfo sender;
        private static OrgInfo org;

        /// <summary>
        /// 默认的发送者对象
        /// </summary>
        /// <returns>一个静态的发送者对象</returns>
        private static SenderInfo GetDefaultSender()
        {
            if (sender == null)
            {
                sender = new SenderInfo();
                sender.MachineCode = HardwareManager.GetMachineCode();
                AssemblyName an=Assembly.GetExecutingAssembly().GetName();
                sender.ProgramName = an.Name;
                sender.Version = an.Version.ToString();
                sender.Ip = HardwareManager.GetDefaultIp();
               
            }
            return sender;
        }

        /// <summary>
        /// 初始化一个默认的消息发送的组织对象
        /// </summary>
        /// <param name="orgInfo">组织对象</param>
        public static void InitOrg(OrgInfo orgInfo)
        {
            if (org == null)
            {
                org = orgInfo;

            }
        }

        /// <summary>
        /// 根据组织生成一个默认的消息对象
        /// <returns>默认的消息对象</returns>
        public static MessageInfo GetDefaultMessage()
        {
            if (org == null)
            {
                throw new ArgumentException("调用本方法前必须先调用InitOrg方法！");
            }
            MessageInfo msg = new MessageInfo();
            msg.Org = org;
            msg.Sender = GetDefaultSender();
            return msg;
        }

        /// <summary>
        /// 获取字符串的信息流
        /// </summary>
        /// <param name="msg">字符串对象</param>
        /// <returns>信息流</returns>
        public static MessageInfo GetStringMessage(string msg)
        {
            MessageInfo info = GetDefaultMessage();
            info.Type = MessageType.String;
            info.Data = msg;
            return info;
        }

        /// <summary>
        /// 获取一个对象的信息流
        /// </summary>
        /// <param name="msg">对象</param>
        /// <returns>信息流</returns>
        public static MessageInfo GetObjectMessage(object msg)
        {
            MessageInfo info = GetDefaultMessage();
            info.Type = MessageType.Object;
            info.Data = Security.SecurityFactory.GetSecurity().Encrypt(SerializeHelper.SerializeToXml(msg));
            info.ObjectType = msg.GetType().ToString();
            return info;
        }

        /// <summary>
        /// 获取bmp图像的信息流
        /// </summary>
        /// <param name="msg">bmp图片对象</param>
        /// <returns>信息流</returns>
        public static MessageInfo GetBmpMessage(Image msg)
        {
            MessageInfo info = GetDefaultMessage();
            info.Type = MessageType.Bmp;
            MemoryStream bstream = new System.IO.MemoryStream();
            msg.Save(bstream, System.Drawing.Imaging.ImageFormat.Bmp);
            byte[] tmp = bstream.ToArray();
            info.Data = System.Text.Encoding.UTF8.GetString(tmp);
            info.ObjectType = msg.GetType().ToString();
            return info;
        }
        
    }
}
