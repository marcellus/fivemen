using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;

namespace FT.Commons.TcpIp
{
    public class Customer
    {
        /// <summary>
        /// 消息的版本,默认版本1.0
        /// </summary>
        public string Version = "1.0";

        /// <summary>
        /// 消息发送的软件相关信息,名称,版本,机器码
        /// </summary>
        public SenderInfo Sender;

        /// <summary>
        /// 消息发送者的组织,全称,昵称,URL,联系电话,
        /// </summary>
        public OrgInfo Org;

        /// <summary>
        /// 上一条命令，一般服务器根据上条命令来判断如何处理下条消息
        /// 比如，发送一个消息，login，一个leave，这些根据命令本身就可处理，
        /// 有些命令比如根据上条命令处理，比如发送一个图片
        /// </summary>
        public string PreCmd;

        /// <summary>
        /// tcp连接的客户端
        /// </summary>
        public Socket Client;

        /// <summary>
        /// 获取主ID
        /// </summary>
        /// <returns></returns>
        public int GetId()
        {
            if (Client == null)
            {
                return -1;
            }
            return (int)Client.Handle;
        }

        /// <summary> 
        /// 使用Socket对象的Handle值作为HashCode,它具有良好的线性特征. 
        /// </summary> 
        /// <returns></returns> 
        public override int GetHashCode()
        {
            return (int)Client.Handle;
        }

        /// <summary> 
        /// 返回两个Session是否代表同一个客户端 
        /// </summary> 
        /// <param name="obj"></param> 
        /// <returns></returns> 
        public override bool Equals(object obj)
        {
            Customer rightObj = (Customer)obj;

            return (int)Client.Handle == (int)rightObj.Client.Handle;

        }

        /// <summary> 
        /// 重载ToString()方法,返回Customer对象的特征 
        /// </summary> 
        /// <returns></returns> 
        public override string ToString()
        {
            string result = string.Format("Customer:{0},IP:{1}",
                (int)Client.Handle, Client.RemoteEndPoint.ToString());

            //result.C 
            return result;
        }
    }
}
