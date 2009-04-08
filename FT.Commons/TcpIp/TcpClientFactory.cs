using System;
using System.Collections.Generic;
using System.Text;
using FT.Commons.Tools;
using System.Windows.Forms;

namespace FT.Commons.TcpIp
{
    public class TcpClientFactory
    {
        private static TcpClientHelper clientHelper;

        private static LogHandle logHandle;

        public static void InitLogHandle(LogHandle handle)
        {
            logHandle = handle;
            if (clientHelper != null)
            {
                clientHelper.LogHandle = logHandle;
            }
        }

        public static void InitMsgHandle(MessageInfoHandle handle)
        {
            //logHandle = handle;
            if (clientHelper != null)
            {
                clientHelper.MsgHandle = handle;
            }
        }



        public static void Start()
        {
            ClientConfig config = ClientConfig.GetConfig();
            if (config == null)
            {
                return;
            }
            if (clientHelper == null)
            {
                clientHelper = new TcpClientHelper(null);
                clientHelper.Start();
            }
        }

      

        public static void InitParent(Form form)
        {
            if (clientHelper == null)
            {
                if (logHandle == null)
                {
                    MessageBoxHelper.Show("请先设置日志处理的委托！");
                    return;
                }
                clientHelper = new TcpClientHelper(null, logHandle);
            }
            if (clientHelper != null)
            {
                clientHelper.Parent = form;
            }
        }


        public static void Send(MessageInfo info)
        {
            ClientConfig config = ClientConfig.GetConfig();
            if (config == null)
            {
                MessageBoxHelper.Show("请先设置服务器连接！");
                return;
            }
            if (clientHelper == null)
            {
                if (logHandle == null)
                {
                    MessageBoxHelper.Show("请先设置日志处理的委托！");
                    return;
                }
                clientHelper = new TcpClientHelper(null,logHandle);
                //clientHelper.Start();
            }
            if (!clientHelper.IsStarted)
            {
                clientHelper.Start();
            }
            clientHelper.Send(info);
        }
    }
}
