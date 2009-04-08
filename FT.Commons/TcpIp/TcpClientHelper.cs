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
    /// �ͻ��˵��õİ���
    /// </summary>
    public class TcpClientHelper:TcpBase
    {
        #region ��ʼ����
        

        public TcpClientHelper(MessageInfoHandle msgHandle):base(msgHandle)
        {
            
        }

        public TcpClientHelper(MessageInfoHandle msgHandle, LogHandle logHandle):base(msgHandle,logHandle)
        {
            
        }

        Mutex locked=new Mutex();

        /// <summary>
        /// �ͻ��˶���
        /// </summary>
        private TcpClient tcpClient;


        #endregion

        #region ���Ӳ���(�����)

        /// <summary>
        /// �ر�����
        /// </summary>
        public override void Stop()
        {
           //locked.WaitOne();
            if (this.IsStarted)
            {
               // this.Log("�ͻ��˿�ʼ�Ͽ����ӣ�");
                //this.tcpClient.GetStream().Close();
               //this.Send(TcpComand.Bye);
               // Thread.Sleep(1000);
                this.tcpClient.Client.BeginDisconnect(false, new AsyncCallback(ClosedEnd), this.tcpClient.Client);
                //this.tcpClient.Client.Close();
                //socket.EndDisconnect(ar);
               // this.IsStarted = false;   
                //this.IsStarted = false;
                //this.Log("�ͻ��˶Ͽ����ӳɹ���");
            }
            else
            {
                this.Log("�ͻ��˻�û�����ӣ�");
                //locked.ReleaseMutex();
            }
        }

        public void ClosedEnd(IAsyncResult ar)
        {
            this.Log("�ͻ��˿�ʼ�Ͽ����ӣ�");
           // Thread.Sleep(500);
            Socket socket = (Socket)ar.AsyncState;
            socket.EndDisconnect(ar);
            this.IsStarted = false;
            this.Log("�ͻ��˶Ͽ����ӳɹ���");
           // locked.ReleaseMutex();
        }
        /// <summary>
        /// ����Ĭ�ϵĿͻ������ý�������
        /// </summary>
        public override void Start()
        {
            this.Start(ClientConfig.GetConfig());

        }
        /// <summary>
        /// �������ý�������,���ӳɹ�������һ��Login����
        /// </summary>
        /// <param name="config">����</param>
        public void Start(ClientConfig config)
        {
            //locked.WaitOne();
            if (this.IsStarted)
            {
                this.Log("�ͻ����Ѿ����ӣ�");
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
                this.Log("�ͻ��˿�ʼ���ӵ���������" + client.Client.LocalEndPoint.ToString() + "�˿ڣ�");
                client.EndConnect(ar);
                this.IsStarted = true;
                this.Log("�ͻ������ӳɹ���");
                client.Client.BeginReceive(this.buffers, 0, bufferSize, SocketFlags.None, new AsyncCallback(ReceiveEnd), client.Client);
                
                this.Send(MessageFactory.GetStringMessage(TcpComand.Login));
              
            }
            catch (Exception ex)
            {
                this.Log("�ͻ�������ʧ�ܣ�");
                log.Info(ex);
            }
           // locked.ReleaseMutex();
        }
        #endregion

        #region ��Ϣ���Ͳ���(�����)
        /// <summary>
        /// ����һ����Ϣ����
        /// </summary>
        /// <param name="info">��Ϣ����</param>
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
                    this.Log("FailԶ�������ѶϿ�");
                }
                //SocketHelper.WriteData(this.tcpClient,info);
            }
            else
            {
                this.Log("Fail�ͻ������ӻ�û����ȷ�򿪣���ȷ��Ŀ��������ã�");
            }
        }

        /// <summary> 
        /// ���ݷ�����ɴ����� 
        /// </summary> 
        /// <param name="iar"></param> 
        protected virtual void SendDataEnd(IAsyncResult iar)
        {
            
            this.Log("�ͻ��˿�ʼ��������");
            Socket remote = (Socket)iar.AsyncState;
            try
            {
                int sent = remote.EndSend(iar);
                if (sent > 0)
                {
                    this.Log("�ͻ��˷��ͳɹ���");
                    
                    if (!isLogMsg)
                    {
                        this.Log("Success");
                        //this.isLogMsg=
                    }
                }
                else
                {
                    this.Log("Fail" + "�ͻ��˷���ʧ�ܣ�����Ϊ��" + sent);
                }
            }
            catch (Exception ex)
            {
                this.Log("Fail"+"�ͻ��˷����쳣->" + ex.Message);
                log.Info(ex);
            }
           // locked.ReleaseMutex();
            //Debug.Assert(sent != 0);

        }


        /// <summary>
        /// ����һ���ַ�����Ϣ��������
        /// </summary>
        /// <param name="msg">�ַ���</param>
        public void Send(string msg)
        {
            this.Send(MessageFactory.GetStringMessage(msg));
        }

        /// <summary>
        /// ����һ��������Ϣ����������
        /// </summary>
        /// <param name="msg">��Ϣ����</param>
        public void Send(object msg)
        {
            this.Send(MessageFactory.GetObjectMessage(msg));
        }
        #endregion

        #region ��Ϣ���ղ���
        // Process the client connection.
        public void ReceiveEnd(IAsyncResult ar)
        {
            this.Log("�ͻ��˿�ʼ���շ�������Ϣ");
            Socket socket = (Socket)ar.AsyncState;
            try
            {
                int real = socket.EndReceive(ar);
                if (real == 0)
                {
                    //this.Log("�ͻ��˽��յ���Ϣ����Ϊ0,��ʼ�ر����ӣ�");
                    //this.Stop();
                }
                else
                {
                    this.Log("�ͻ��˽��յ���Ϣ�ĳ���Ϊ��" + real);
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
                this.Log("�ͻ��˽����쳣->" + ex.Message);
                this.IsStarted = false;
                log.Info(ex);
            }

        }
        /// <summary>
        /// �Ӷ�������ȡһ����Ϣ
        /// </summary>
        /// <returns>��Ϣ����</returns>
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
