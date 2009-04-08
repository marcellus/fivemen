using System;
using System.Collections.Generic;
using System.Text;

namespace FT.Commons.TcpIp
{
    /// <summary>
    /// 基本的操作命令
    /// </summary>
    public class TcpComand
    {
        /// <summary>
        /// 客户端连接初次发送的命令
        /// </summary>
        public static readonly string Login = "LOGIN";
        /// <summary>
        /// 服务器要断开客户端连接的通知，以及客户端断开连接的时候命令
        /// </summary>
        public static readonly string Bye = "BYE";
        
    }

    public delegate void MessageInfoHandle(MessageInfo info);

    public delegate void LogHandle(string log);
}
