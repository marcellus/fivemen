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
        /// �����г�������ʱ����ã��������Ϊ�Զ��򿪣���Ĭ�ϴ򿪣�ע��������MsgHandle
        /// </summary>
        public static void InitFirst()
        {
            ServerConfig config = ServerConfig.GetConfig();
            if (config != null && config.DefaultOpen)
            {
                if (msgHandle == null)
                {
                    MessageBoxHelper.Show("���ȵ���InitMsgHandle������Ϣ���մ���ί�У�");
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
                MessageBoxHelper.Show("�������ü����˿ڣ�");
                return;
            }*/
            if (msgHandle == null)
            {
                MessageBoxHelper.Show("���ȵ���InitMsgHandle������Ϣ���մ���ί�У�");
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
