using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace FT.Commons.TcpIp
{
    /// <summary>
    /// 消息中的发送软件信息
    /// </summary>
    [Serializable]
    public class SenderInfo
    {
        /// <summary>
        /// 发送软件的名称
        /// </summary>
        public string ProgramName;

        /// <summary>
        /// 发送的软件的版本
        /// </summary>
        public string Version;

        /// <summary>
        /// 发送的软件所在机器的机器码
        /// </summary>
        public string MachineCode;

        /// <summary>
        /// 发送者IP地址
        /// </summary>
        public string Ip;

    }
}
