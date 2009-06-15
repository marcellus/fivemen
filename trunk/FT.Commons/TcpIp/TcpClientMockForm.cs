using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Commons.Tools;

namespace FT.Commons.TcpIp
{
    public partial class TcpClientMockForm : Form
    {
        public TcpClientMockForm()
        {
            InitializeComponent();
            FormHelper.InitHabitToForm(this);
            OrgInfo org = new OrgInfo();
            org.FullName = "MockOrg";
            org.NickName = "Mock";
            org.Telephone = "MockPhone";
            org.Url = "MockUrl";
            MessageFactory.InitOrg(org);
            TcpClientFactory.Start();
            TcpClientFactory.InitMsgHandle(new MessageInfoHandle(NotifyMsg));
            TcpClientFactory.InitLogHandle(new LogHandle(LogParse));
            TcpClientFactory.InitParent(this);
            TcpFactory.InitMsgHandle(new MessageInfoHandle(MsgParse));
        }

        private void MsgParse(MessageInfo info)
        {
           Console.WriteLine(info.Data);
           //this.txtAccept.AppendText("服务器收到消息");
           //this.txtLog.AppendText("\r\n" + info.Data);
        }

        public void LogParse(string log)
        {
            if (log.IndexOf("Success") != -1)
            {
                MessageBoxHelper.Show("发送成功！");
            }
            else if (log.IndexOf("Fail") != -1)
            {
                MessageBoxHelper.Show(log);
            }
            //this.lbLog.Text = log;
        }

        public void NotifyMsg(MessageInfo info)
        {
            this.txtAccept.AppendText("\r\n收到" + info.Org.NickName + "服务器消息：\r\n\r\n" + info.Data);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (this.txtMessage.Text.Length > 0)
            {
                TcpClientFactory.Send(MessageFactory.GetStringMessage(this.txtMessage.Text.Trim()));
            }
        }

        private void btnConsole_Click(object sender, EventArgs e)
        {
            TcpFactory.Show();
        }
    }
}