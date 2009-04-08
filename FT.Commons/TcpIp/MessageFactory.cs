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
    /// ��Ϣ������������Ϣ��һЩ��ʼ��,����Ϣ�����ߵ���
    /// </summary>
    public class MessageFactory
    {

        private static SenderInfo sender;
        private static OrgInfo org;

        /// <summary>
        /// Ĭ�ϵķ����߶���
        /// </summary>
        /// <returns>һ����̬�ķ����߶���</returns>
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
        /// ��ʼ��һ��Ĭ�ϵ���Ϣ���͵���֯����
        /// </summary>
        /// <param name="orgInfo">��֯����</param>
        public static void InitOrg(OrgInfo orgInfo)
        {
            if (org == null)
            {
                org = orgInfo;

            }
        }

        /// <summary>
        /// ������֯����һ��Ĭ�ϵ���Ϣ����
        /// <returns>Ĭ�ϵ���Ϣ����</returns>
        public static MessageInfo GetDefaultMessage()
        {
            if (org == null)
            {
                throw new ArgumentException("���ñ�����ǰ�����ȵ���InitOrg������");
            }
            MessageInfo msg = new MessageInfo();
            msg.Org = org;
            msg.Sender = GetDefaultSender();
            return msg;
        }

        /// <summary>
        /// ��ȡ�ַ�������Ϣ��
        /// </summary>
        /// <param name="msg">�ַ�������</param>
        /// <returns>��Ϣ��</returns>
        public static MessageInfo GetStringMessage(string msg)
        {
            MessageInfo info = GetDefaultMessage();
            info.Type = MessageType.String;
            info.Data = msg;
            return info;
        }

        /// <summary>
        /// ��ȡһ���������Ϣ��
        /// </summary>
        /// <param name="msg">����</param>
        /// <returns>��Ϣ��</returns>
        public static MessageInfo GetObjectMessage(object msg)
        {
            MessageInfo info = GetDefaultMessage();
            info.Type = MessageType.Object;
            info.Data = Security.SecurityFactory.GetSecurity().Encrypt(SerializeHelper.SerializeToXml(msg));
            info.ObjectType = msg.GetType().ToString();
            return info;
        }

        /// <summary>
        /// ��ȡbmpͼ�����Ϣ��
        /// </summary>
        /// <param name="msg">bmpͼƬ����</param>
        /// <returns>��Ϣ��</returns>
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
