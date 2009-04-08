using System;
using System.Collections.Generic;
using System.Text;

namespace FT.Commons.TcpIp
{
    /// <summary>
    /// �����Ĳ�������
    /// </summary>
    public class TcpComand
    {
        /// <summary>
        /// �ͻ������ӳ��η��͵�����
        /// </summary>
        public static readonly string Login = "LOGIN";
        /// <summary>
        /// ������Ҫ�Ͽ��ͻ������ӵ�֪ͨ���Լ��ͻ��˶Ͽ����ӵ�ʱ������
        /// </summary>
        public static readonly string Bye = "BYE";
        
    }

    public delegate void MessageInfoHandle(MessageInfo info);

    public delegate void LogHandle(string log);
}
