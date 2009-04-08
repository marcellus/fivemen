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
    /// socket的帮助类，以便调用者写很少代码就可以进行通讯
    /// </summary>
    public class SocketHelper
    {
        private static ILog log = log4net.LogManager.GetLogger(typeof(SocketHelper).FullName);

        private const int bufferSize = 4*1024*1024;
        private byte[] buffers=new byte[bufferSize];

        private MessageInfo info;


       

        /// <summary>
        /// 从一个Socket中获取一个MessageInfo对象
        /// </summary>
        /// <param name="client">TcpClient对象</param>
        /// <returns>MessageInfo或者Null对象</returns>
        public MessageInfo GetData(TcpClient client)
        {
            
            NetworkStream stream=client.GetStream();
            IAsyncResult iar = stream.BeginRead(buffers, 0, bufferSize, new AsyncCallback(ReadFinish), stream);
            return null;
        }

        public void ReadFinish(IAsyncResult iar)
        {
            if(log.IsDebugEnabled)
                log.Debug("线程"+System.Threading.Thread.CurrentThread.ManagedThreadId+"开始接收数据回调");
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
        /// 往TcpClient中写入一个MessageInfo对象
        /// </summary>
        /// <param name="client">TcpClient对象</param>
        /// <param name="info">MessageInfo对象</param>
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
