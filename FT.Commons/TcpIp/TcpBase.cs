using System;
using System.Collections.Generic;
using System.Text;
using log4net;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;

namespace FT.Commons.TcpIp
{
    /// <summary>
    /// TcpServerHelper��TcpClientHelper�Ļ���
    /// </summary>
    public abstract class TcpBase
    {
        #region ��ʼ����
        protected ILog log = log4net.LogManager.GetLogger(typeof(TcpBase).FullName);

        protected const int bufferSize = 4 * 1024 * 1024;
        protected byte[] buffers = new byte[bufferSize];

        /// <summary>
        /// �ж��Ƿ�����
        /// </summary>
        private bool isStarted;

        /// <summary>
        /// �Ƿ�ɹ�����
        /// </summary>
        public bool IsStarted
        {
            get { return isStarted; }
            set { isStarted = value; }
        }

        private Form parent;

        /// <summary>
        /// ��Ҫ���������ã��Ա�invoke
        /// </summary>
        public Form Parent
        {
            get { return parent; }
            set { parent = value; }
        }

        protected MessageInfoHandle msgHandle;

        public MessageInfoHandle MsgHandle
        {
            get { return msgHandle; }
            set { msgHandle = value; }
        }

        // private Thread receiver;

        /// <summary>
        /// ���Ĭ�ϵ�logΪ�գ�����log4net�ӹ�
        /// </summary>
        private LogHandle logHandle;

        public LogHandle LogHandle
        {
            get { return logHandle; }
            set { logHandle = value; }
        }

        public TcpBase(MessageInfoHandle msgHandle)
        {
            this.msgHandle = msgHandle;
        }

        public TcpBase(MessageInfoHandle msgHandle, LogHandle logHandle)
        {
            this.msgHandle = msgHandle;
            this.logHandle = logHandle;
        }

        /// <summary>
        /// ������־
        /// </summary>
        /// <param name="obj"></param>
        protected void Log(object obj)
        {
            if (logHandle == null)
            {
                log.Debug("�߳�ID"+System.Threading.Thread.CurrentThread.ManagedThreadId);
                log.Debug(obj);
            }
            else
            {
                if (parent != null)
                {
                    parent.Invoke(logHandle, new object[] { "�߳�ID��" + System.Threading.Thread.CurrentThread.ManagedThreadId +"->"+ obj.ToString() });
                }
                else
                {
                    log.Error("��logHandle��Ϊ�յ�ʱ���������parent���ԣ�");
                }
                //SocketHelper.MockInvoke(logHandle, new object[] { obj.ToString() });
                //logHandle(obj.ToString());
            }
        }
        #endregion

        public abstract void  Start();

        public abstract void Stop();

        /// <summary>
        /// �������̳еķ�������������һЩ�ڲ���Ϣ���ⲿ��Ϣ��msghandle����
        /// </summary>
        /// <param name="info">��Ϣ����</param>
        /// <param name="client">�ͻ��˶���</param>
        public abstract void ParseMessage(MessageInfo info,TcpClient client);
    }
}