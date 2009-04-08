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
    /// ������tcp������֧����
    /// </summary>
    public class TcpServerHelper:TcpBase
    {
        #region ��ʼ����(�����)

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
        /// ���еĿͻ������ӣ�ֻ�ܴ��
        /// </summary>
        public Hashtable Clients
        {
            get { return clients; }
            set { clients = value; }
        }
        #endregion


        #region �¼�����(�Ѿ����)

        /// <summary> 
        /// �ͻ��˽��������¼� 
        /// </summary> 
        public event TcpEvent ClientConn;

        /// <summary> 
        /// �ͻ��˹ر��¼� 
        /// </summary> 
        public event TcpEvent ClientClose;


        /// <summary>
        /// �¼���װ
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
        /// �¼���װ
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

        #region ��Ϣ���ղ���

        // Process the client connection.
        public void ReceiveEnd(IAsyncResult ar)
        {
            this.Log("��������ʼ���տͻ�����Ϣ");
            Socket socket = (Socket)ar.AsyncState;
            try
            {

                int real = socket.EndReceive(ar);
                if (real == 0)
                {
                    this.Log("���������յ���Ϣ����Ϊ0,��ʼ�ر����ӣ�");
                    this.CloseClient((Customer)this.clients[(int)socket.Handle]);
                    this.Log("���������еĿͻ��˸�����" + this.clients.Count);
                }
                else
                {
                    this.Log("���������յ���Ϣ�ĳ���Ϊ��" + real);
                    string xml = System.Text.Encoding.UTF8.GetString(this.buffers, 0, real);
                    MessageInfo info = (MessageInfo)SerializeHelper.DeserializeFromXml(typeof(MessageInfo), SecurityFactory.GetSecurity().Decrypt(xml));
                    //msgHandle.BeginInvoke(Info, null, null);
                    if (info.Type==MessageType.String&&info.Data == TcpComand.Login)
                    {
                        Customer customer = this.CopyFromMessageInfo(info);
                        customer.Client = socket;
                        this.Log("��������ʼ��ӿͻ���" + (int)socket.Handle);
                        this.clients.Add((int)socket.Handle, customer);                    
                        this.ClientConnWrapper(customer);
                        this.Log("���������еĿͻ��˸�����" + this.clients.Count);
                        socket.BeginReceive(this.buffers, 0, bufferSize, SocketFlags.None, new AsyncCallback(ReceiveEnd), socket);
                    }
                    else if (info.Type == MessageType.String && info.Data == TcpComand.Bye)
                    {
                        this.Log("��������ʼ�Ƴ��ͻ���" + (int)socket.Handle);
                        Customer customer = this.clients[(int)socket.Handle] as Customer;
                        this.CloseClient(customer);
                        this.Log("���������еĿͻ��˸�����" + this.clients.Count);
                        
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
                //�ͻ����˳� 
                if (10054 == ex.ErrorCode)
                {
                    this.Log("�������пͻ��˶Ͽ�����,���еĿͻ��˸�����" + this.clients.Count);
                    this.CloseClient((Customer)this.clients[(int)socket.Handle]);
                    
                }

            }
            catch (ObjectDisposedException ex)
            {
                //log.Info(ex);
            }


        }

        /// <summary>
        /// ����Ϣ�л�ȡһ��Customer����
        /// </summary>
        /// <param name="info">��Ϣ����</param>
        /// <returns>Customer����</returns>
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
            this.Log("��������ʼִ��AcceptTcpClient�Ļص�����");
            if (!this.IsStarted)
            {
                this.Log("�������������ӻص�������ֹͣ");
                this.RemoveAll();
                this.Log("�������пͻ��˶Ͽ�����,���еĿͻ��˸�����" + this.clients.Count);
                return;
            }
            // Get the listener that handles the client request.
            TcpListener listener = (TcpListener)ar.AsyncState;

            // End the operation and display the received data on 
            // the console.
            TcpClient client = listener.EndAcceptTcpClient(ar);
            this.Log("���������յ����������ԣ�" + client.Client.RemoteEndPoint.ToString());
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

        #region ���Ӳ���(�����)
        /// <summary>
        /// �������������ø���ServerConfig��
        /// </summary>
        public override void Start()
        {
            this.Start(ServerConfig.GetConfig());
        }

        /// <summary>
        /// ����������������
        /// </summary>
        /// <param name="config">��������</param>
        public  void Start(ServerConfig config)
        {
            if (this.IsStarted)
            {
                this.Log("�������Ѿ�����������");
                return;
            }
            this.Log("������׼������������");
            try
            {
                this.listener = new TcpListener(System.Net.IPAddress.Parse(config.Ip), config.Port);
                this.listener.Start();
                this.IsStarted = true;
                this.Log("���������������ɹ���");

                this.Log(string.Format("��������{0}�˿ڵȴ��ͻ������ӣ�", config.Port));
                this.listener.BeginAcceptTcpClient(new AsyncCallback(DoAcceptTcpClientCallback), listener);
   
                
            }
            catch (Exception ex)
            {
                this.Log("��������������ʧ�ܣ�");
                this.Log(ex);
            }
            
        }
       

        


        /// <summary>
        /// ���ͻ��˷��ͶϿ����ӵ���Ϣ�����û�пͻ������������ֱ�ӶϿ�
        /// </summary>
        public override void Stop()
        {
            if (!this.IsStarted)
            {
                this.Log("������û�п����ļ�����");
                return;
            }

            this.Log("���������ԶϿ����ӣ�");
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
                  //this.Log("֪ͨ�ͻ���" + customer.Org.FullName);
                 // this.SendToClient(customer, info);
              }
            
              foreach (Customer tmp in this.clients)
               {
                   this.CloseClient(tmp);
               }*/
            //this.clients.Clear();
            this.listener.Server.Close();
            this.Log("�������Ͽ����ӳɹ���");

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
                    Log("��������ʼ�رտͻ��ˣ�" + customer.Sender.Ip);
                    this.ClientCloseWrapper(customer);
                    customer.Client.Close();
                }
            }
            this.clients.Clear();
        }

        /// <summary>
        /// �رյ����ͻ���
        /// </summary>
        /// <param name="customer">�ͻ���</param>
        public void CloseClient(Customer customer)
        {
            if (customer != null)
            {
                Log("��������ʼ�رտͻ��ˣ�" + customer.Sender.Ip);
                this.clients.Remove((int)customer.Client.Handle);
                this.ClientCloseWrapper(customer);
                customer.Client.Close();
            }
            
            
        }

        #endregion

        #region ��Ϣ���Ͳ���(�����)
        /// <summary>
        /// ����һ���������Ӧ�ͻ���
        /// </summary>
        /// <param name="msg">��Ϣ����</param>
        /// <param name="key">�ͻ�����</param>
        public void Send(object msg, int key)
        {
            this.Send(MessageFactory.GetObjectMessage(msg), key);
        }

        /// <summary>
        /// ��һ���ͻ��˷����ַ���Ϣ
        /// </summary>
        /// <param name="msg">��Ϣ����</param>
        /// <param name="key">�ͻ�����</param>
        public void Send(string msg, int key)
        {
            this.Send(MessageFactory.GetStringMessage(msg), key);
        }

        /// <summary>
        /// �������ͻ�����Ϣ
        /// </summary>
        /// <param name="info">��Ϣ����</param>
        /// <param name="index">�ͻ�����</param>
        public void Send(MessageInfo info,int key)
        {
            Customer customer= this.clients[key]  as Customer;
            if(customer!=null)
            {

                this.Log("������֪ͨ�ͻ���" + customer.Org.FullName);
                this.SendToClient(customer, info);
                //SocketHelper.WriteData(customer.Client, info);
            }
        }

        /// <summary>
        /// ֪ͨһ��������Ϣ
        /// </summary>
        /// <param name="msg">������Ϣ</param>
        public void Notify(Object msg)
        {
            this.Notify(MessageFactory.GetObjectMessage(msg));
        }

        /// <summary>
        /// ֪ͨһ���ַ�����Ϣ
        /// </summary>
        /// <param name="msg">�ַ���</param>
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
        /// ֪ͨȫ����������ӵ�֪ͨ
        /// </summary>
        /// <param name="info">��Ϣ����</param>
        public void Notify(MessageInfo info)
        {
            Customer customer = null;
           

            System.Collections.IDictionaryEnumerator enumerator = this.clients.GetEnumerator();
            while (enumerator.MoveNext())
            {
                customer = enumerator.Value as Customer;
                this.Log("������֪ͨ�ͻ���" + customer.Org.FullName);
                this.SendToClient(customer, info);
            }
        }

        /// <summary> 
        /// ���ݷ�����ɴ����� 
        /// </summary> 
        /// <param name="iar"></param> 
        protected virtual void SendDataEnd(IAsyncResult iar)
        {
            
            Socket remote = (Socket)iar.AsyncState;
            this.Log("�������˸�" + remote.RemoteEndPoint.ToString() + "��������");
            int sent = remote.EndSend(iar);
            if (sent > 0)
            {
                this.Log("���������ͳɹ���");
            }
            else
            {
                this.Log("����������ʧ�ܣ�����Ϊ��" + sent);
            }
            //Debug.Assert(sent != 0);

        }

        public override void ParseMessage(MessageInfo info,TcpClient client)
        {
            /*
             if (info == null)
                {
                    this.Log("��ȡ��½�û���ϢΪ�գ�");
                    System.Threading.Thread.Sleep(200);
                }
                else if (info.Data == TcpComand.Login)
                {
                    this.Log("��ȡ����½�û���Ϣ��");
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
                this.Log("�������յ��Ͽ�������");
                client.Close();
                this.clients.Remove((int)client.Client.Handle);
                this.Log("�������ɹ��Ͽ�����");
                this.Log("���������пͻ�����" + this.clients.Count);
            }
            if (info.Type == MessageType.String && info.Data == TcpComand.Login)
            {
                this.Log("��������ȡ����½�û���Ϣ��");
                Customer customer = new Customer();
                customer.Org = info.Org;
                customer.Sender = info.Sender;
                customer.Version = info.Version;
                customer.Client = client.Client;
                this.clients.Add((int)customer.Client.Handle, customer);
                this.Log("���������пͻ�����" + this.clients.Count);
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
