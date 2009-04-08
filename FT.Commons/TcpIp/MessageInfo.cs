using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace FT.Commons.TcpIp
{
    /// <summary>
    /// 基本的消息类
    /// 使用的时候必须设置data、Org和Sender的基本信息，Sender信息必须全部获取
    /// </summary>
    [Serializable]
    public class MessageInfo
    {
        /// <summary>
        /// 消息的版本,默认版本1.0
        /// </summary>
        public string Version="1.0";

        /// <summary>
        /// 消息发送的软件相关信息,名称,版本,机器码
        /// </summary>
        public SenderInfo Sender ;

        /// <summary>
        /// 消息发送者的组织,全称,昵称,URL,联系电话,
        /// </summary>
        public OrgInfo Org;

        /// <summary>
        /// 发送的消息内容
        /// </summary>
        public string Data=string.Empty;

        /// <summary>
        /// 消息的内容类型，现在仅支持bmp图片和字符串,还是组合对象
        /// </summary>
        public MessageType Type=MessageType.String;

        /// <summary>
        /// 对象内容需要反序列化的类型
        /// </summary>
        public string ObjectType;

        /// <summary>
        /// 消息的发送时间
        /// </summary>
        public DateTime SendTime=System.DateTime.Now;

        /// <summary>
        /// 消息发送者的clientid
        /// </summary>
        public int ClientHandle;
    }

    /// <summary>
    /// 消息的内容类型
    /// </summary>
    public enum MessageType
    {
        /// <summary>
        /// 字符串
        /// </summary>
        String,
        /// <summary>
        /// 对象消息，仅仅是支持反序列化的对象，需要反序列化,否则反序列化会出错
        /// </summary>
        Object,
        /// <summary>
        /// bmp图片
        /// </summary>
        Bmp
    }
}
