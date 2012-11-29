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

        public static bool CheckSocket(string host, int port)
        {
            try
            {

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

              
#if DEBUG

                Console.WriteLine("开始断开服务器连接...");
#endif
                c.Close();
#if DEBUG
                Console.WriteLine("完成断开服务器连接");
#endif
                return true;

            }

            catch (ArgumentNullException e)
            {

                return false;

            }

            catch (SocketException e)
            {

                return false;

            }
            return false;
        }


        public static List<TicketPrintObject> GetTicket(string host,int port,byte[] pack)
        {
#if DEBUG
            Console.WriteLine("客户端开始连接！");
#endif
            try
            {

               // int port = 2908;
               // string host = "119.10.114.212";

               // string host = "58.62.144.227";
             //   int port = 2907;

               // string host = "10.12.23.216";
                //   int port = 2907;

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
                Console.WriteLine("Hex输出为:"+GetHexOutput(pack));

                c.Send(pack, pack.Length, 0);//发送测试信息

                string recvStr = "";

                byte[] recvBytes = new byte[1024];

                int bytes;

#if DEBUG
                Console.WriteLine("开始从服务器接收内容...");

#endif
                int readTime=0;
                byte[] heads1=new byte[5];
                byte[] heads2 = new byte[22];
                c.Receive(heads1, heads1.Length, SocketFlags.None);
                c.Receive(heads2, heads2.Length, SocketFlags.None);
                byte[] lens=new byte[4];
                Array.Copy(heads2,1, lens,0, lens.Length);
                int len = HiPiaoProtocol.GetDataPackageLen(lens);
#if DEBUG
                byte[] dataLength = BitConverter.GetBytes(1484);
                Console.WriteLine("changdu:" + GetHexOutput(dataLength));
                Console.WriteLine("Hex输出为:" + GetHexOutput(heads1));
                Console.WriteLine("获取报文包头并解析的长度为" + len );
                Console.WriteLine("Hex输出为:" + GetHexOutput(heads2));
#endif
                byte[] allpackage = new byte[len];
                c.Receive(allpackage);

                string tmpstr = Encoding.GetEncoding("GBK").GetString(allpackage, 0, len);
                string[] tmpstr1 = tmpstr.Split('\r');
                string[] tmpstr2 = tmpstr1[1].Split('\n');
                GetTicketPrintObject[] ticketsObjects=new GetTicketPrintObject[(tmpstr2.Length/16)*16];
                GetTicketPrintObject tmpTicket = null;
                for (int i = 0; i < tmpstr2.Length; i++)
                {
                    string[] tmpstr3 = tmpstr2[i].Split('\t');
                    if (tmpstr3.Length != 7)
                    {
                        break;
                    }
                    else
                    {
                        tmpTicket = new GetTicketPrintObject();
                        tmpTicket.Id = tmpstr3[0];
                        tmpTicket.Id2 = tmpstr3[1];
                        tmpTicket.X = Convert.ToInt32(tmpstr3[2]);
                        tmpTicket.Y = Convert.ToInt32(tmpstr3[3]);
                        tmpTicket.FontWeight = Convert.ToInt32(tmpstr3[4]);
                        tmpTicket.IsBold = tmpstr3[5] == "1";
                        tmpTicket.Content=tmpstr3[6];
                        ticketsObjects[i] = tmpTicket;
                    }
                    #if DEBUG
                    if (tmpstr3.Length == 7)
                    {
                        Console.WriteLine("票据唯一标识:" + tmpstr3[0]);
                        Console.WriteLine("正副券标识:" + tmpstr3[1]);
                        Console.WriteLine("打印X坐标:" + tmpstr3[2]);
                        Console.WriteLine("打印Y坐标:" + tmpstr3[3]);
                        Console.WriteLine("字体大小:" + tmpstr3[4]);
                        Console.WriteLine("是否加粗:" + tmpstr3[5]);
                        Console.WriteLine("打印项内容:" + tmpstr3[6]);
                    }
                   
                    #endif
                }
#if DEBUG
                Console.WriteLine("从服务器接收内容长度为：" + allpackage + " 内容为：" + tmpstr);
                Console.WriteLine("Hex输出为:" + GetHexOutput(allpackage));
#endif
               // for()
                /*

                while (readTime<3)
                {
                   // bytes = c.Receive(recvBytes, recvBytes.Length, 0);//从服务器端接受返回信息
                    //c.Receive(
                   
                    bytes = c.Receive(recvBytes);


                    byte[] data = new byte[bytes];
                    Array.Copy(recvBytes, data, data.Length);

                    recvStr += Encoding.ASCII.GetString(recvBytes, 0, bytes);
#if DEBUG
                    Console.WriteLine("从服务器第"+readTime.ToString()+"次接收内容长度为：" + bytes + " 内容为：" + recvStr);
                    Console.WriteLine("Hex输出为:" + GetHexOutput(data));
#endif
                    //    Console.WriteLine("发送取票获取结果内容为:{0}", recvStr);//显示服务器返回信息

                    readTime++;
                }
                 * * */
#if DEBUG

                Console.WriteLine("开始断开服务器连接...");
#endif
                c.Close();
#if DEBUG
                Console.WriteLine("完成断开服务器连接");
#endif
               // return recvStr;

                List<TicketPrintObject> tickets = new List<TicketPrintObject>();
                TicketPrintObject ticketPrintObject = null;
                int startindex = 0;

                for (int i = 0; i < tmpstr2.Length / 16; i++)
                {
                    startindex = i * 16;
                    ticketPrintObject = new TicketPrintObject();
                    ticketPrintObject.Cinema = ticketsObjects[startindex + 0].Content;
                    ticketPrintObject.UniqueId = ticketsObjects[startindex + 0].Id;
                    ticketPrintObject.IsPrinted = false;
                    ticketPrintObject.MovieName = ticketsObjects[startindex + 1].Content.Substring(3);
                    ticketPrintObject.TicketId = ticketsObjects[startindex + 2].Content.Substring(3) ;
                   // string ttt = ticketsObjects[startindex + 3].Content.Substring(4);
                    
                    ticketPrintObject.Price =Convert.ToInt32( Convert.ToDouble(ticketsObjects[startindex + 3].Content.Substring(4)));

                    ticketPrintObject.PlayTime = ticketsObjects[startindex + 4].Content;

                    ticketPrintObject.RoomName = ticketsObjects[startindex + 6].Content.Substring(3);

                    ticketPrintObject.Seat = ticketsObjects[startindex + 7].Content.Substring(3);

                    ticketPrintObject.PlayDate = ticketsObjects[startindex + 8].Content.Substring(3);

                    ticketPrintObject.PrintTime = ticketsObjects[startindex + 15].Content.Substring(5);

                    ticketPrintObject.MiddleFee = ticketsObjects[startindex + 14].Content.Substring(5);

                    ticketPrintObject.ChangCi = ticketsObjects[startindex + 13].Content;

                    ticketPrintObject.SeatId = string.Empty;
                    
                    tickets.Add(ticketPrintObject);
                }
                return tickets;


            }

            catch (ArgumentNullException e)
            {

                Console.WriteLine("ArgumentNullException: {0}", e);
                return null;

            }

            catch (SocketException e)
            {

                Console.WriteLine("SocketException: {0}", e);
                return null;

            }


#if DEBUG
            Console.WriteLine("客户端连接完成！");
#endif
            return null;
        }

        /// <summary>
        /// 把指定的二进制值显示为适合记入日志的文本串
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static  string GetHexOutput(byte[] data)
        {
            if (data == null) return "";
            string result = "";
            int start = 0;
            while (start < data.Length)
            {
                if (!result.Equals("")) result += "\r\n";
                int len = data.Length - start;
                if (len > 16) len = 16;
                string strByte = BitConverter.ToString(data, start, len);
                strByte = strByte.Replace('-', ' ');
                if (len > 8)
                {
                    strByte = strByte.Substring(0, 23) + "-" + strByte.Substring(24);
                }
                if (len < 16)
                {
                    strByte += new string(' ', (16 - len) * 3);
                }
                strByte += "  ";
                for (int i = 0; i < len; i++)
                {
                    char c = Convert.ToChar(data[start + i]);
                    if (char.IsControl(c))
                    {
                        c = '.';
                    }
                    strByte += c;
                }
                result += strByte;
                start += len;
            }
            return result;
        }

        public static List<TicketPrintObject> GetTicket(string host,int port,string sendStr)
        {
            byte[] content = Encoding.ASCII.GetBytes(sendStr);
            return GetTicket(host,port,content);
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
