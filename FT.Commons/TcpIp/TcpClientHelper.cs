using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.IO;
using System.Net;
using System.Threading;
using log4net;
using System.Windows.Forms;
using System.Diagnostics;
using FT.Commons.Tools;
using FT.Commons.Security;


namespace FT.Commons.TcpIp
{
    /// <summary>
    /// 客户端调用的帮助
    /// </summary>
    public class TcpClientHelper:TcpBase
    {
        #region 初始定义
        

        public TcpClientHelper(MessageInfoHandle msgHandle):base(msgHandle)
        {
            
        }

        public TcpClientHelper(MessageInfoHandle msgHandle, LogHandle logHandle):base(msgHandle,logHandle)
        {
            
        }

        Mutex locked=new Mutex();

        /// <summary>
        /// 客户端对象
        /// </summary>
        private TcpClient tcpClient;


        #endregion

        #region 连接部分(已完成)

        /// <summary>
        /// 关闭连接
        /// </summary>
        public override void Stop()
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
                this.Log("客户端还没有连接！");
                //locked.ReleaseMutex();
            }
        }

        public void ClosedEnd(IAsyncResult ar)
        {
            this.Log("客户端开始断开连接！");
           // Thread.Sleep(500);
            Socket socket = (Socket)ar.AsyncState;
            socket.EndDisconnect(ar);
            this.IsStarted = false;
            this.Log("客户端断开连接成功！");
           // locked.ReleaseMutex();
        }
        /// <summary>
        /// 根据默认的客户端配置进行连接
        /// </summary>
        public override void Start()
        {
            this.Start(ClientConfig.GetConfig());

        }
        /// <summary>
        /// 根据配置进行连接,连接成功并发送一个Login命令
        /// </summary>
        /// <param name="config">配置</param>
        public void Start(ClientConfig config)
        {
            //locked.WaitOne();
            if (this.IsStarted)
            {
                this.Log("客户端已经连接！");
                //locked.ReleaseMutex();
                return;
            }
            else
            {
                this.tcpClient = new TcpClient();
                IPAddress remote = IPAddress.Parse(config.ServerIp);
                
                this.tcpClient.BeginConnect(remote, config.Port,new AsyncCallback(ConnectedEnd),this.tcpClient);
               
               
            }
        }

        private bool isLogMsg = true;

        public void ConnectedEnd(IAsyncResult ar)
        {

            TcpClient client = (TcpClient)ar.AsyncState;
            try
            {
                this.Log("客户端开始连接到服务器：" + client.Client.LocalEndPoint.ToString() + "端口：");
                client.EndConnect(ar);
                this.IsStarted = true;
                this.Log("客户端连接成功！");
                client.Client.BeginReceive(this.buffers, 0, bufferSize, SocketFlags.None, new AsyncCallback(ReceiveEnd), client.Client);
                
                this.Send(MessageFactory.GetStringMessage(TcpComand.Login));
              
            }
            catch (Exception ex)
            {
                this.Log("客户端连接失败！");
                log.Info(ex);
            }
           // locked.ReleaseMutex();
        }
        #endregion

        #region 消息发送部分(已完成)
        /// <summary>
        /// 发送一则消息对象
        /// </summary>
        /// <param name="info">消息对象</param>
        public void Send(MessageInfo info)
        {
            if (info.Data == TcpComand.Login)
            {
                isLogMsg = true;
            }
            else
            {
                isLogMsg = false;
            }
            //locked.WaitOne();
            if (this.IsStarted)
            {
                string xml = SerializeHelper.SerializeToXml(info);
                byte[] tmp = System.Text.Encoding.UTF8.GetBytes(
                    SecurityFactory.GetSecurity().Encrypt(xml));
                try
                {
                    this.tcpClient.Client.BeginSend(tmp, 0, tmp.Length, SocketFlags.None, new AsyncCallback(SendDataEnd), this.tcpClient.Client);
                }
                catch (Exception ex)
                {
                    this.Stop();
                    this.Log("Fail远程主机已断开");
                }
                //SocketHelper.WriteData(this.tcpClient,info);
            }
            else
            {
                this.Log("Fail客户端连接还没有正确打开，请确认目标机器可用！");
            }
        }

        /// <summary> 
        /// 数据发送完成处理函数 
        /// </summary> 
        /// <param name="iar"></param> 
        protected virtual void SendDataEnd(IAsyncResult iar)
        {
            
            this.Log("客户端开始发送数据");
            Socket remote = (Socket)iar.AsyncState;
            try
            {
                int sent = remote.EndSend(iar);
                if (sent > 0)
                {
                    this.Log("客户端发送成功！");
                    
                    if (!isLogMsg)
                    {
                        this.Log("Success");
                        //this.isLogMsg=
                    }
                }
                else
                {
                    this.Log("Fail" + "客户端发送失败，代码为：" + sent);
                }
            }
            catch (Exception ex)
            {
                this.Log("Fail"+"客户端发送异常->" + ex.Message);
                log.Info(ex);
            }
           // locked.ReleaseMutex();
            //Debug.Assert(sent != 0);

        }


        /// <summary>
        /// 发送一则字符串消息给服务器
        /// </summary>
        /// <param name="msg">字符串</param>
        public void Send(string msg)
        {
            this.Send(MessageFactory.GetStringMessage(msg));
        }

        /// <summary>
        /// 发送一个对象消息给服务器端
        /// </summary>
        /// <param name="msg">消息对象</param>
        public void Send(object msg)
        {
            this.Send(MessageFactory.GetObjectMessage(msg));
        }
        #endregion

        #region 消息接收部分
        // Process the client connection.
        public void ReceiveEnd(IAsyncResult ar)
        {
            this.Log("客户端开始接收服务器消息");
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
                    this.Log("客户端接收到消息的长度为：" + real);
                    string xml = System.Text.Encoding.UTF8.GetString(this.buffers, 0, real);
                    MessageInfo info = (MessageInfo)SerializeHelper.DeserializeFromXml(typeof(MessageInfo),
                        SecurityFactory.GetSecurity().Decrypt(xml));
                    //msgHandle.BeginInvoke(Info, null, null);
                    if (info.Type == MessageType.String && info.Data == TcpComand.Bye)
                    {
                        this.Stop();
                    }
                    else
                    {
                        IntPtr formhandle = FT.Commons.Win32.SystemDefine.GetForegroundWindow();
                        Parent.Invoke(MsgHandle, new object[] { info });
                        socket.BeginReceive(this.buffers, 0, bufferSize, SocketFlags.None, new AsyncCallback(ReceiveEnd), socket);
                    }
                }
            }
            catch (Exception ex)
            {
                this.Log("客户端接收异常->" + ex.Message);
                this.IsStarted = false;
                log.Info(ex);
            }

        }
        /// <summary>
        /// 从对象流读取一则消息
        /// </summary>
        /// <returns>消息对象</returns>
        public MessageInfo Accept()
        {
            return null;
           // return SocketHelper.GetData(this.tcpClient);
        }
        public override void ParseMessage(MessageInfo info,TcpClient client)
        {
            if (info.Type ==MessageType.String&&info.Data==TcpComand.Bye)
            {
                this.Stop();
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
