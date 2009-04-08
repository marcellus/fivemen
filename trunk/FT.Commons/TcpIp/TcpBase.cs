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
    /// TcpServerHelper和TcpClientHelper的基类
    /// </summary>
    public abstract class TcpBase
    {
        #region 初始定义
        protected ILog log = log4net.LogManager.GetLogger(typeof(TcpBase).FullName);

        protected const int bufferSize = 4 * 1024 * 1024;
        protected byte[] buffers = new byte[bufferSize];

        /// <summary>
        /// 判断是否启动
        /// </summary>
        private bool isStarted;

        /// <summary>
        /// 是否成功启动
        /// </summary>
        public bool IsStarted
        {
            get { return isStarted; }
            set { isStarted = value; }
        }

        private Form parent;

        /// <summary>
        /// 需要父窗体引用，以便invoke
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
        /// 如果默认的log为空，则由log4net接管
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
        /// 处理日志
        /// </summary>
        /// <param name="obj"></param>
        protected void Log(object obj)
        {
            if (logHandle == null)
            {
                log.Debug("线程ID"+System.Threading.Thread.CurrentThread.ManagedThreadId);
                log.Debug(obj);
            }
            else
            {
                if (parent != null)
                {
                    parent.Invoke(logHandle, new object[] { "线程ID：" + System.Threading.Thread.CurrentThread.ManagedThreadId +"->"+ obj.ToString() });
                }
                else
                {
                    log.Error("当logHandle不为空的时候必须设置parent属性！");
                }
                //SocketHelper.MockInvoke(logHandle, new object[] { obj.ToString() });
                //logHandle(obj.ToString());
            }
        }
        #endregion

        public abstract void  Start();

        public abstract void Stop();

        /// <summary>
        /// 子类必须继承的方法，用来处理一些内部消息，外部消息供msghandle处理
        /// </summary>
        /// <param name="info">消息内容</param>
        /// <param name="client">客户端对象</param>
        public abstract void ParseMessage(MessageInfo info,TcpClient client);
    }
}