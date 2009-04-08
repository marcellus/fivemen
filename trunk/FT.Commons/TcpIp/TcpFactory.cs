using System;
using System.Collections.Generic;
using System.Text;
using FT.Commons.Tools;

namespace FT.Commons.TcpIp
{
    public class TcpFactory
    {
        private static TcpWatcherForm watcher;

        private static MessageInfoHandle msgHandle;

        private static bool isFirst=false;

        public static void InitMsgHandle(MessageInfoHandle handle)
        {
            msgHandle = handle;
        }

        /// <summary>
        /// 供所有程序启动时候调用，如果设置为自动打开，则默认打开，注意先设置MsgHandle
        /// </summary>
        public static void InitFirst()
        {
            ServerConfig config = ServerConfig.GetConfig();
            if (config != null && config.DefaultOpen)
            {
                if (msgHandle == null)
                {
                    MessageBoxHelper.Show("请先调用InitMsgHandle设置消息接收处理委托！");
                    return;
                }
                watcher = new TcpWatcherForm(msgHandle);
                watcher.Show();
                watcher.Hide();
                //System.Threading.Thread.Sleep(200);
                // watcher.Start();
            }
          
        }

        public static void Show()
        {
            /*
            ServerConfig config=ServerConfig.GetConfig();
            if (config == null)
            {
                MessageBoxHelper.Show("请先设置监听端口！");
                return;
            }*/
            if (msgHandle == null)
            {
                MessageBoxHelper.Show("请先调用InitMsgHandle设置消息接收处理委托！");
                return;
            }
            if (watcher == null)
            {
                watcher = new TcpWatcherForm(msgHandle);
                watcher.ShowInTaskbar = true;
                watcher.Show();
            }
            else
            {
                watcher.Show();
            }
            
        }
    }
}
