using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace FT.Commons.TcpIp
{
    /// <summary>
    /// ��������Ϣ��
    /// ʹ�õ�ʱ���������data��Org��Sender�Ļ�����Ϣ��Sender��Ϣ����ȫ����ȡ
    /// </summary>
    [Serializable]
    public class MessageInfo
    {
        /// <summary>
        /// ��Ϣ�İ汾,Ĭ�ϰ汾1.0
        /// </summary>
        public string Version="1.0";

        /// <summary>
        /// ��Ϣ���͵���������Ϣ,����,�汾,������
        /// </summary>
        public SenderInfo Sender ;

        /// <summary>
        /// ��Ϣ�����ߵ���֯,ȫ��,�ǳ�,URL,��ϵ�绰,
        /// </summary>
        public OrgInfo Org;

        /// <summary>
        /// ���͵���Ϣ����
        /// </summary>
        public string Data=string.Empty;

        /// <summary>
        /// ��Ϣ���������ͣ����ڽ�֧��bmpͼƬ���ַ���,������϶���
        /// </summary>
        public MessageType Type=MessageType.String;

        /// <summary>
        /// ����������Ҫ�����л�������
        /// </summary>
        public string ObjectType;

        /// <summary>
        /// ��Ϣ�ķ���ʱ��
        /// </summary>
        public DateTime SendTime=System.DateTime.Now;

        /// <summary>
        /// ��Ϣ�����ߵ�clientid
        /// </summary>
        public int ClientHandle;
    }

    /// <summary>
    /// ��Ϣ����������
    /// </summary>
    public enum MessageType
    {
        /// <summary>
        /// �ַ���
        /// </summary>
        String,
        /// <summary>
        /// ������Ϣ��������֧�ַ����л��Ķ�����Ҫ�����л�,�������л������
        /// </summary>
        Object,
        /// <summary>
        /// bmpͼƬ
        /// </summary>
        Bmp
    }
}
