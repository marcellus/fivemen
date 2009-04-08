using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;

namespace FT.Commons.TcpIp
{
    public class Customer
    {
        /// <summary>
        /// ��Ϣ�İ汾,Ĭ�ϰ汾1.0
        /// </summary>
        public string Version = "1.0";

        /// <summary>
        /// ��Ϣ���͵���������Ϣ,����,�汾,������
        /// </summary>
        public SenderInfo Sender;

        /// <summary>
        /// ��Ϣ�����ߵ���֯,ȫ��,�ǳ�,URL,��ϵ�绰,
        /// </summary>
        public OrgInfo Org;

        /// <summary>
        /// ��һ�����һ����������������������ж���δ���������Ϣ
        /// ���磬����һ����Ϣ��login��һ��leave����Щ���������Ϳɴ���
        /// ��Щ����������������������緢��һ��ͼƬ
        /// </summary>
        public string PreCmd;

        /// <summary>
        /// tcp���ӵĿͻ���
        /// </summary>
        public Socket Client;

        /// <summary>
        /// ��ȡ��ID
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
        /// ʹ��Socket�����Handleֵ��ΪHashCode,���������õ���������. 
        /// </summary> 
        /// <returns></returns> 
        public override int GetHashCode()
        {
            return (int)Client.Handle;
        }

        /// <summary> 
        /// ��������Session�Ƿ����ͬһ���ͻ��� 
        /// </summary> 
        /// <param name="obj"></param> 
        /// <returns></returns> 
        public override bool Equals(object obj)
        {
            Customer rightObj = (Customer)obj;

            return (int)Client.Handle == (int)rightObj.Client.Handle;

        }

        /// <summary> 
        /// ����ToString()����,����Customer��������� 
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
