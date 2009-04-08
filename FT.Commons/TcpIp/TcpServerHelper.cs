using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.IO;
using System.Net.Sockets;
using System.Collections;
using log4net;
using System.Windows.Forms;
using System.Diagnostics;
using FT.Commons.Tools;
using FT.Commons.Security;

namespace FT.Commons.TcpIp
{
    /// <summary>
    /// 单个的tcp服务器支持类
    /// </summary>
    public class TcpServerHelper:TcpBase
    {
        #region 初始定义(已完成)

        private static Mutex mut = new Mutex();
      
        public TcpServerHelper(MessageInfoHandle msgHandle):base(msgHandle)
        {
            
        }

        public TcpServerHelper(MessageInfoHandle msgHandle, LogHandle logHandle)
            : base(msgHandle, logHandle)
        {
            
        }


        private Hashtable clients = new Hashtable();

        private TcpListener listener;

        /// <summary>
        /// 现有的客户端连接，只能存放
        /// </summary>
        public Hashtable Clients
        {
            get { return clients; }
            set { clients = value; }
        }
        #endregion


        #region 事件定义(已经完成)

        /// <summary> 
        /// 客户端建立连接事件 
        /// </summary> 
        public event TcpEvent ClientConn;

        /// <summary> 
        /// 客户端关闭事件 
        /// </summary> 
        public event TcpEvent ClientClose;


        /// <summary>
        /// 事件包装
        /// </summary>
        /// <param name="customer"></param>
        private void ClientConnWrapper(Customer customer)
        {
            if (ClientConn != null)
            {
                //ClientConn();
                this.Parent.Invoke(ClientConn, new object[] { this, new TcpEventArgs(customer) });
            }
        }

        /// <summary>
        /// 事件包装
        /// </summary>
        /// <param name="customer"></param>
        private void ClientCloseWrapper(Customer customer)
        {
            if (ClientClose != null)
            {
               //ClientClose(this, new TcpEventArgs(customer));
                this.Parent.Invoke(ClientClose, new object[] { this, new TcpEventArgs(customer) });
            }
        }


        #endregion

        #region 消息接收部分

        // Process the client connection.
        public void ReceiveEnd(IAsyncResult ar)
        {
            this.Log("服务器开始接收客户端消息");
            Socket socket = (Socket)ar.AsyncState;
            try
            {

                int real = socket.EndReceive(ar);
                if (real == 0)
                {
                    this.Log("服务器接收到消息长度为0,开始关闭连接！");
                    this.CloseClient((Customer)this.clients[(int)socket.Handle]);
                    this.Log("服务器现有的客户端个数：" + this.clients.Count);
                }
                else
                {
                    this.Log("服务器接收到消息的长度为：" + real);
                    string xml = System.Text.Encoding.UTF8.GetString(this.buffers, 0, real);
                    MessageInfo info = (MessageInfo)SerializeHelper.DeserializeFromXml(typeof(MessageInfo), SecurityFactory.GetSecurity().Decrypt(xml));
                    //msgHandle.BeginInvoke(Info, null, null);
                    if (info.Type==MessageType.String&&info.Data == TcpComand.Login)
                    {
                        Customer customer = this.CopyFromMessageInfo(info);
                        customer.Client = socket;
                        this.Log("服务器开始添加客户端" + (int)socket.Handle);
                        this.clients.Add((int)socket.Handle, customer);                    
                        this.ClientConnWrapper(customer);
                        this.Log("服务器现有的客户端个数：" + this.clients.Count);
                        socket.BeginReceive(this.buffers, 0, bufferSize, SocketFlags.None, new AsyncCallback(ReceiveEnd), socket);
                    }
                    else if (info.Type == MessageType.String && info.Data == TcpComand.Bye)
                    {
                        this.Log("服务器开始移除客户端" + (int)socket.Handle);
                        Customer customer = this.clients[(int)socket.Handle] as Customer;
                        this.CloseClient(customer);
                        this.Log("服务器现有的客户端个数：" + this.clients.Count);
                        
                    }
                    else
                    {
                        Parent.Invoke(MsgHandle, new object[] { info });
                        socket.BeginReceive(this.buffers, 0, bufferSize, SocketFlags.None, new AsyncCallback(ReceiveEnd), socket);
                    }
                   
                }
            }
            catch (SocketException ex)
            {
                //客户端退出 
                if (10054 == ex.ErrorCode)
                {
                    this.Log("服务器有客户端断开连接,现有的客户端个数：" + this.clients.Count);
                    this.CloseClient((Customer)this.clients[(int)socket.Handle]);
                    
                }

            }
            catch (ObjectDisposedException ex)
            {
                //log.Info(ex);
            }


        }

        /// <summary>
        /// 从消息中获取一个Customer对象
        /// </summary>
        /// <param name="info">消息报文</param>
        /// <returns>Customer对象</returns>
        private Customer CopyFromMessageInfo(MessageInfo info)
        {
            Customer customer = new Customer();
            customer.Org = info.Org;
            customer.Sender = info.Sender;
            customer.Version = info.Version;
            return customer;
        }

        // Process the client connection.
        public void DoAcceptTcpClientCallback(IAsyncResult ar)
        {
            this.Log("服务器开始执行AcceptTcpClient的回调函数");
            if (!this.IsStarted)
            {
                this.Log("服务器接收连接回调过程中停止");
                this.RemoveAll();
                this.Log("服务器有客户端断开连接,现有的客户端个数：" + this.clients.Count);
                return;
            }
            // Get the listener that handles the client request.
            TcpListener listener = (TcpListener)ar.AsyncState;

            // End the operation and display the received data on 
            // the console.
            TcpClient client = listener.EndAcceptTcpClient(ar);
            this.Log("服务器接收到连接请求自：" + client.Client.RemoteEndPoint.ToString());
            client.Client.BeginReceive(this.buffers, 0, bufferSize, SocketFlags.None, new AsyncCallback(ReceiveEnd), client.Client);
            this.listener.BeginAcceptTcpClient(new AsyncCallback(DoAcceptTcpClientCallback), listener);
            // bool flag = true;
            // while (flag)
            //  {

            //SocketHelper helper = new SocketHelper();
            //MessageInfo info = helper.GetData(client);
            //info.ClientHandle = (int)client.Client.Handle;
            // this.ParseMessage(info,client);
            //}

            // Process the connection here. (Add the client to a
            // server table, read data, etc.)
            //Console.WriteLine("Client connected completed");
            //this.Log("");

            // Signal the calling thread to continue.
            // allDone.Set();

        }
        #endregion

        #region 连接部分(已完成)
        /// <summary>
        /// 启动监听，配置根据ServerConfig来
        /// </summary>
        public override void Start()
        {
            this.Start(ServerConfig.GetConfig());
        }

        /// <summary>
        /// 根据配置启动监听
        /// </summary>
        /// <param name="config">配置内容</param>
        public  void Start(ServerConfig config)
        {
            if (this.IsStarted)
            {
                this.Log("服务器已经开启监听！");
                return;
            }
            this.Log("服务器准备开启监听！");
            try
            {
                this.listener = new TcpListener(System.Net.IPAddress.Parse(config.Ip), config.Port);
                this.listener.Start();
                this.IsStarted = true;
                this.Log("服务器开启监听成功！");

                this.Log(string.Format("服务器在{0}端口等待客户端连接：", config.Port));
                this.listener.BeginAcceptTcpClient(new AsyncCallback(DoAcceptTcpClientCallback), listener);
   
                
            }
            catch (Exception ex)
            {
                this.Log("服务器开启监听失败！");
                this.Log(ex);
            }
            
        }
       

        


        /// <summary>
        /// 给客户端发送断开连接的信息，如果没有客户端连接情况下直接断开
        /// </summary>
        public override void Stop()
        {
            if (!this.IsStarted)
            {
                this.Log("服务器没有开启的监听！");
                return;
            }

            this.Log("服务器尝试断开连接！");
            this.IsStarted = false;
            //this.Notify(MessageFactory.GetStringMessage(TcpComand.Bye));
           // Thread.Sleep(5000);
            if (this.listener.Server.Connected)
            {
                this.listener.Server.Shutdown(SocketShutdown.Both);
            }
            /*  Customer customer;
              System.Collections.IDictionaryEnumerator enumerator = this.clients.GetEnumerator();
              while (enumerator.MoveNext())
              {
                  customer = enumerator.Value as Customer;
                  this.CloseClient(customer);
                  //customer.Client.Close();
                  //this.Log("通知客户端" + customer.Org.FullName);
                 // this.SendToClient(customer, info);
              }
            
              foreach (Customer tmp in this.clients)
               {
                   this.CloseClient(tmp);
               }*/
            //this.clients.Clear();
            this.listener.Server.Close();
            this.Log("服务器断开连接成功！");

        }

        private void RemoveAll()
        {
            Customer customer;
            System.Collections.IDictionaryEnumerator enumerator = this.clients.GetEnumerator();
            while (enumerator.MoveNext())
            {
                customer = enumerator.Value as Customer;
                if (customer != null)
                {
                    Log("服务器开始关闭客户端：" + customer.Sender.Ip);
                    this.ClientCloseWrapper(customer);
                    customer.Client.Close();
                }
            }
            this.clients.Clear();
        }

        /// <summary>
        /// 关闭单个客户端
        /// </summary>
        /// <param name="customer">客户端</param>
        public void CloseClient(Customer customer)
        {
            if (customer != null)
            {
                Log("服务器开始关闭客户端：" + customer.Sender.Ip);
                this.clients.Remove((int)customer.Client.Handle);
                this.ClientCloseWrapper(customer);
                customer.Client.Close();
            }
            
            
        }

        #endregion

        #region 消息发送部分(已完成)
        /// <summary>
        /// 发送一个对象给对应客户端
        /// </summary>
        /// <param name="msg">消息对象</param>
        /// <param name="key">客户索引</param>
        public void Send(object msg, int key)
        {
            this.Send(MessageFactory.GetObjectMessage(msg), key);
        }

        /// <summary>
        /// 给一个客户端发送字符消息
        /// </summary>
        /// <param name="msg">消息内容</param>
        /// <param name="key">客户索引</param>
        public void Send(string msg, int key)
        {
            this.Send(MessageFactory.GetStringMessage(msg), key);
        }

        /// <summary>
        /// 给单个客户发信息
        /// </summary>
        /// <param name="info">信息内容</param>
        /// <param name="index">客户索引</param>
        public void Send(MessageInfo info,int key)
        {
            Customer customer= this.clients[key]  as Customer;
            if(customer!=null)
            {

                this.Log("服务器通知客户端" + customer.Org.FullName);
                this.SendToClient(customer, info);
                //SocketHelper.WriteData(customer.Client, info);
            }
        }

        /// <summary>
        /// 通知一个对象信息
        /// </summary>
        /// <param name="msg">对象信息</param>
        public void Notify(Object msg)
        {
            this.Notify(MessageFactory.GetObjectMessage(msg));
        }

        /// <summary>
        /// 通知一个字符串信息
        /// </summary>
        /// <param name="msg">字符串</param>
        public void Notify(string msg)
        {
            this.Notify(MessageFactory.GetStringMessage(msg));
        }

        public void SendToClient(Customer customer, MessageInfo info)
        {
            string xml = SerializeHelper.SerializeToXml(info);
            byte[] tmp = System.Text.Encoding.UTF8.GetBytes(SecurityFactory.GetSecurity().Encrypt(xml));
            customer.Client.BeginSend(tmp, 0, tmp.Length, SocketFlags.None, new AsyncCallback(SendDataEnd), customer.Client);
        }

        /// <summary>
        /// 通知全体的现在连接的通知
        /// </summary>
        /// <param name="info">消息对象</param>
        public void Notify(MessageInfo info)
        {
            Customer customer = null;
           

            System.Collections.IDictionaryEnumerator enumerator = this.clients.GetEnumerator();
            while (enumerator.MoveNext())
            {
                customer = enumerator.Value as Customer;
                this.Log("服务器通知客户端" + customer.Org.FullName);
                this.SendToClient(customer, info);
            }
        }

        /// <summary> 
        /// 数据发送完成处理函数 
        /// </summary> 
        /// <param name="iar"></param> 
        protected virtual void SendDataEnd(IAsyncResult iar)
        {
            
            Socket remote = (Socket)iar.AsyncState;
            this.Log("服务器端给" + remote.RemoteEndPoint.ToString() + "发送数据");
            int sent = remote.EndSend(iar);
            if (sent > 0)
            {
                this.Log("服务器发送成功！");
            }
            else
            {
                this.Log("服务器发送失败，代码为：" + sent);
            }
            //Debug.Assert(sent != 0);

        }

        public override void ParseMessage(MessageInfo info,TcpClient client)
        {
            /*
             if (info == null)
                {
                    this.Log("获取登陆用户信息为空！");
                    System.Threading.Thread.Sleep(200);
                }
                else if (info.Data == TcpComand.Login)
                {
                    this.Log("获取到登陆用户信息！");
                    Customer customer = new Customer();
                    customer.Org = info.Org;
                    customer.Sender = info.Sender;
                    customer.Version = info.Version;
                    customer.Client = client;
                    this.clients.Add(customer, customer);
                    //flag = false;
                }
                else
                {
                    this.Parse();
                }
             */
            if (info.Type == MessageType.String && info.Data == TcpComand.Bye)
            {
                this.Log("服务器收到断开的命令");
                client.Close();
                this.clients.Remove((int)client.Client.Handle);
                this.Log("服务器成功断开链接");
                this.Log("服务器现有客户数：" + this.clients.Count);
            }
            if (info.Type == MessageType.String && info.Data == TcpComand.Login)
            {
                this.Log("服务器获取到登陆用户信息！");
                Customer customer = new Customer();
                customer.Org = info.Org;
                customer.Sender = info.Sender;
                customer.Version = info.Version;
                customer.Client = client.Client;
                this.clients.Add((int)customer.Client.Handle, customer);
                this.Log("服务器现有客户数：" + this.clients.Count);
            }
            else
            {
                if (this.Parent != null)
                {
                    this.Parent.Invoke(this.MsgHandle, new object[] { info });
                }
            }
        }
        #endregion

       
    }
}
