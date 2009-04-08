using System;
using System.Collections.Generic;
using System.Text;
using log4net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Windows;
using FT.Commons.Tools;
using FT.Commons.Security;

namespace FT.Commons.TcpIp
{
    /// <summary>
    /// socket�İ����࣬�Ա������д���ٴ���Ϳ��Խ���ͨѶ
    /// </summary>
    public class SocketHelper
    {
        private static ILog log = log4net.LogManager.GetLogger(typeof(SocketHelper).FullName);

        private const int bufferSize = 4*1024*1024;
        private byte[] buffers=new byte[bufferSize];

        private MessageInfo info;


       

        /// <summary>
        /// ��һ��Socket�л�ȡһ��MessageInfo����
        /// </summary>
        /// <param name="client">TcpClient����</param>
        /// <returns>MessageInfo����Null����</returns>
        public MessageInfo GetData(TcpClient client)
        {
            
            NetworkStream stream=client.GetStream();
            IAsyncResult iar = stream.BeginRead(buffers, 0, bufferSize, new AsyncCallback(ReadFinish), stream);
            return null;
        }

        public void ReadFinish(IAsyncResult iar)
        {
            if(log.IsDebugEnabled)
                log.Debug("�߳�"+System.Threading.Thread.CurrentThread.ManagedThreadId+"��ʼ�������ݻص�");
            NetworkStream stream = (NetworkStream)iar.AsyncState;
            int real=stream.EndRead(iar);
            if (real == 0)
            {

            }
            else
            {
                //info = new MessageInfo();
                info =(MessageInfo)SerializeHelper.DeserializeFromXml(typeof(MessageInfo),
                    SecurityFactory.GetSecurity().Decrypt(System.Text.Encoding.UTF8.GetString(buffers, 0, real)));

            }
            

        }

        /// <summary>
        /// ��TcpClient��д��һ��MessageInfo����
        /// </summary>
        /// <param name="client">TcpClient����</param>
        /// <param name="info">MessageInfo����</param>
        public void WriteData(TcpClient client,MessageInfo info)
        {
            if (client!=null&&client.Connected)
            {
                string msg=SecurityFactory.GetSecurity().Encrypt(SerializeHelper.SerializeToXml(info));
                byte[] myWriteBuffer=System.Text.Encoding.UTF8.GetBytes(msg);
                NetworkStream stream=client.GetStream();
                bool flag=false;
                int i = 0;
                while (!flag)
                {
                    if (i + 1024 <= myWriteBuffer.Length)
                    {
                        stream.Write(myWriteBuffer, i, 1024);
                    }
                    else
                    {
                        stream.Write(myWriteBuffer, i, myWriteBuffer.Length - i);
                        flag = true;
                    }
                    stream.Flush();
                    i += 1024;
                }
                
                
            }
            //return string.Empty;
        }

       
    }
}
