using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace FT.Commons.TcpIp
{
    /// <summary>
    /// ��Ϣ�еķ��������Ϣ
    /// </summary>
    [Serializable]
    public class SenderInfo
    {
        /// <summary>
        /// �������������
        /// </summary>
        public string ProgramName;

        /// <summary>
        /// ���͵�����İ汾
        /// </summary>
        public string Version;

        /// <summary>
        /// ���͵�������ڻ����Ļ�����
        /// </summary>
        public string MachineCode;

        /// <summary>
        /// ������IP��ַ
        /// </summary>
        public string Ip;

    }
}
