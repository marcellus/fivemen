using System;
using System.Collections.Generic;
using System.Text;
using FT.Commons.TcpIp;
using FT.Commons.Tools;
using FT.Commons.Win32;
using System.Net.Sockets;
using System.Net;

namespace HiPiaoInterface
{
    public  class HipiaoTcpHelper
    {
       
        private FT.Commons.Win32.WindowFormDelegate.StringHandler handler;

        

        public  void InitMsgHandle(WindowFormDelegate.StringHandler handler)
        {
            //logHandle = handle;
            if (this.handler != null)
            {
                this.handler = handler;
            }
        }
        public static string GetTicket(byte[] pack)
        {
#if DEBUG
            Console.WriteLine("客户端开始连接！");
#endif
            try
            {

                int port = 2908;

                string host = "119.10.114.212";

                IPAddress ip = IPAddress.Parse(host);

                IPEndPoint ipe = new IPEndPoint(ip, port);//把ip和端口转化为IPEndPoint实例

                Socket c = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);//创建一个Socket
#if DEBUG
                Console.WriteLine("开始连接服务器IP：" + ip + "，端口" + port + "...");
#endif

                c.Connect(ipe);//连接到服务器
#if DEBUG
                Console.WriteLine("完成连接服务器...");
#endif

                //string sendStr = str;

                

                Console.WriteLine("发送取票内容为:" + pack);

                c.Send(pack, pack.Length, 0);//发送测试信息

                string recvStr = "";

                byte[] recvBytes = new byte[1024];

                int bytes;

#if DEBUG
                Console.WriteLine("开始从服务器接收内容...");
#endif
                bytes = c.Receive(recvBytes, recvBytes.Length, 0);//从服务器端接受返回信息

                recvStr += Encoding.ASCII.GetString(recvBytes, 0, bytes);
#if DEBUG
                Console.WriteLine("从服务器接收内容长度为：" + bytes + " 内容为：" + recvStr);
#endif
                //    Console.WriteLine("发送取票获取结果内容为:{0}", recvStr);//显示服务器返回信息
#if DEBUG
                Console.WriteLine("开始断开服务器连接...");
#endif
                c.Close();
#if DEBUG
                Console.WriteLine("完成断开服务器连接");
#endif
                return recvStr;

            }

            catch (ArgumentNullException e)
            {

                Console.WriteLine("ArgumentNullException: {0}", e);

            }

            catch (SocketException e)
            {

                Console.WriteLine("SocketException: {0}", e);

            }


#if DEBUG
            Console.WriteLine("客户端连接完成！");
#endif
            return string.Empty;
        }

        public static string GetTicket(string sendStr)
        {
            byte[] content = Encoding.ASCII.GetBytes(sendStr);
            return GetTicket(content);
        }

        private bool IsStarted = false;

        private TcpClient tcpClient=null;


        public  void Start()
        {
            if (this.IsStarted)
            {
#if DEBUG
                Console.WriteLine("客户端已经连接！");
#endif
                //locked.ReleaseMutex();
                return;
            }
            else
            {
#if DEBUG
                Console.WriteLine("客户端开始连接！");
#endif
                this.tcpClient = new TcpClient();
                string ip = "119.10.114.212";
                int port = 2908;
                IPAddress remote = IPAddress.Parse(ip);

                this.tcpClient.BeginConnect(remote, port, new AsyncCallback(ConnectedEnd), this.tcpClient);
#if DEBUG
                Console.WriteLine("客户端连接完成！");
#endif

            }
        }

        /// <summary> 
        /// 数据发送完成处理函数 
        /// </summary> 
        /// <param name="iar"></param> 
        protected virtual void SendDataEnd(IAsyncResult iar)
        {
#if DEBUG
            Console.WriteLine("客户端开始发送数据");
#endif
            Socket remote = (Socket)iar.AsyncState;
            try
            {
                int sent = remote.EndSend(iar);
                if (sent > 0)
                {
#if DEBUG
                    Console.WriteLine("客户端发送成功！");
#endif

                }
                else
                {
#if DEBUG
                    Console.WriteLine("Fail" + "客户端发送失败，代码为：" + sent);
#endif
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                Console.WriteLine("Fail" + "客户端发送异常->" + ex.Message);
#endif
                Console.WriteLine(ex);
            }
            // locked.ReleaseMutex();
            //Debug.Assert(sent != 0);

        }
        public void ClosedEnd(IAsyncResult ar)
        {
#if DEBUG
            Console.WriteLine("客户端开始断开连接！");
#endif
            // Thread.Sleep(500);
            Socket socket = (Socket)ar.AsyncState;
            socket.EndDisconnect(ar);
            this.IsStarted = false;
#if DEBUG
            Console.WriteLine("客户端断开连接成功！");
#endif
            // locked.ReleaseMutex();
        }
        /// <summary>
        /// 关闭连接
        /// </summary>
        public  void Stop()
        {
            //locked.WaitOne();
            if (this.IsStarted)
            {
                // this.Log("客户端开始断开连接！");
                //this.tcpClient.GetStream().Close();
                //this.Send(TcpComand.Bye);
                // Thread.Sleep(1000);
                this.tcpClient.Client.BeginDisconnect(false, new AsyncCallback(ClosedEnd), this.tcpClient.Client);
                //this.tcpClient.Client.Close();
                //socket.EndDisconnect(ar);
                // this.IsStarted = false;   
                //this.IsStarted = false;
                //this.Log("客户端断开连接成功！");
            }
            else
            {
                Console.WriteLine("客户端还没有连接！");
                //locked.ReleaseMutex();
            }
        }

        public void Send(byte[] tmp)
        {
#if DEBUG
            Console.WriteLine("客户端开始发送消息！" + tmp);
#endif
            if (tmp != null && tmp.Length > 0)
            {

            }
            else
            {
                return;
            }
            //locked.WaitOne();
            if (this.IsStarted)
            {

                // = System.Text.Encoding.UTF8.GetBytes(str);
                try
                {
#if DEBUG
                    Console.WriteLine("客户端开始异步发送消息！" + tmp);
#endif
                    this.tcpClient.Client.BeginSend(tmp, 0, tmp.Length, SocketFlags.None, new AsyncCallback(SendDataEnd), this.tcpClient.Client);

#if DEBUG
                    Console.WriteLine("客户端完成异步发送消息");
#endif
                }
                catch (Exception ex)
                {
                    this.Stop();
#if DEBUG
                    Console.WriteLine("Fail远程主机已断开");
#endif

                }
                //SocketHelper.WriteData(this.tcpClient,info);
            }
            else
            {
#if DEBUG
                Console.WriteLine("Fail客户端连接还没有正确打开，请确认目标机器可用！");
#endif
            }
        }

        public void Send(string str)
        {
#if DEBUG
            Console.WriteLine("客户端开始发送消息！"+str);
#endif
            if (str != null && str.Length > 0)
            {

            }
            else
            {
                return;
            }
            //locked.WaitOne();
            if (this.IsStarted)
            {

                byte[] tmp = System.Text.Encoding.UTF8.GetBytes(str);
                try
                {
#if DEBUG
                    Console.WriteLine("客户端开始异步发送消息！" + str);
#endif
                    this.tcpClient.Client.BeginSend(tmp, 0, tmp.Length, SocketFlags.None, new AsyncCallback(SendDataEnd), this.tcpClient.Client);

#if DEBUG
                    Console.WriteLine("客户端完成异步发送消息");
#endif
                }
                catch (Exception ex)
                {
                    this.Stop();
#if DEBUG
                    Console.WriteLine("Fail远程主机已断开");
#endif
                    
                }
                //SocketHelper.WriteData(this.tcpClient,info);
            }
            else
            {
#if DEBUG
                Console.WriteLine("Fail客户端连接还没有正确打开，请确认目标机器可用！");
#endif
            }
        }

        public void ConnectedEnd(IAsyncResult ar)
        {

            TcpClient client = (TcpClient)ar.AsyncState;
            try
            {
#if DEBUG
                Console.WriteLine("客户端开始连接到服务器：" + client.Client.LocalEndPoint.ToString() + "端口：");
#endif
                client.EndConnect(ar);
                this.IsStarted = true;
#if DEBUG
                Console.WriteLine("客户端连接成功！");
#endif
                client.Client.BeginReceive(this.buffers, 0, bufferSize, SocketFlags.None, new AsyncCallback(ReceiveEnd), client.Client); 

            }
            catch (Exception ex)
            {
                Console.WriteLine("客户端连接失败！");
                Console.WriteLine(ex);
            }
            // locked.ReleaseMutex();
        }

        protected const int bufferSize = 4 * 1024 * 1024;
        protected byte[] buffers = new byte[bufferSize];

        // Process the client connection.
        public void ReceiveEnd(IAsyncResult ar)
        {
#if DEBUG
            Console.WriteLine("客户端开始接收服务器消息");
#endif
            Socket socket = (Socket)ar.AsyncState;
            try
            {
                int real = socket.EndReceive(ar);
                if (real == 0)
                {
                    //this.Log("客户端接收到消息长度为0,开始关闭连接！");
                    //this.Stop();
                }
                else
                {
#if DEBUG
                    Console.WriteLine("客户端接收到消息的长度为：" + real);
#endif
                    string xml = System.Text.Encoding.UTF8.GetString(this.buffers, 0, real);
#if DEBUG
                    Console.WriteLine("客户端到消息的内容为：" + xml);
#endif
                    if (this.handler != null)
                    {
                        handler(xml);
                    }
                    socket.BeginReceive(this.buffers, 0, bufferSize, SocketFlags.None, new AsyncCallback(ReceiveEnd), socket);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("客户端接收异常->" + ex.Message);
                this.IsStarted = false;
                Console.WriteLine(ex);
            }

        }
    }
}
