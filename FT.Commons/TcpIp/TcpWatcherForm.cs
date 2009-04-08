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
    public partial class TcpWatcherForm : Form
    {
        private TcpServerHelper tcpServerHelper;

        private MessageInfoHandle msgHandle = null;

        /// <summary>
        /// 消息处理器
        /// </summary>
        public MessageInfoHandle MsgHandle
        {
            get { return msgHandle; }
            set { msgHandle = value; }
        }

        public TcpWatcherForm(MessageInfoHandle msgHandle)
        {
            InitializeComponent();
            if (msgHandle == null)
            {
                this.msgHandle = new MessageInfoHandle(ParseMessage);
            }
            else
            {
                this.msgHandle = msgHandle;
            }
            LogHandle log = new LogHandle(Log);
            tcpServerHelper = new TcpServerHelper(this.msgHandle, log);
            this.tcpServerHelper.Parent = this;
            this.tcpServerHelper.ClientClose += new TcpEvent(tcpServerHelper_ClientClose);
            this.tcpServerHelper.ClientConn += new TcpEvent(tcpServerHelper_ClientConn);
            /*
            如果需要给客户端发送消息则使用这个
            OrgInfo org = new OrgInfo();
            org.FullName = "XX组织";
            org.NickName = "xx";
            org.Telephone = "tel";
            org.Url = "url";
            MessageFactory.InitOrg(org);
             */
        }

        void tcpServerHelper_ClientConn(object sender, TcpEventArgs e)
        {
            Customer customer = e.Client;
            ListViewItem item = new ListViewItem(new string[] { customer.GetId().ToString(), customer.Org.NickName, customer.Sender.ProgramName, customer.Version });
            item.Tag=customer.GetId().ToString();
            this.listView1.Items.Add(item);
           // this.listView1.Items.RemoveByKey
        }

        void tcpServerHelper_ClientClose(object sender, TcpEventArgs e)
        {
            ListViewItem item;
            for (int i = 0; i < this.listView1.Items.Count;i++ )
            {
                item = this.listView1.Items[i];
                if (item.Tag.ToString() == e.Client.GetId().ToString())
                {
                    this.listView1.Items.RemoveAt(i);
                    break;
                }
            }
            //throw new Exception("The method or operation is not implemented.");
        }

        private void ParseMessage(MessageInfo info)
        {
            this.txtContext.AppendText("\r\n"+info.Data);
        }


        private void Log(string str)
        {
            if (this.txtContext.Text.Length > 2000)
            {
                this.txtContext.Text = string.Empty;
            }
            this.txtContext.AppendText("\r\n" + str);
        }

        private void TcpWatcherForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //起隐藏作用，并不关闭
            this.Hide();
            e.Cancel = true;
        }

        public void Start()
        {
            this.tcpServerHelper.Start();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            this.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            this.tcpServerHelper.Stop();
        }

        private void TcpWatcherForm_Load(object sender, EventArgs e)
        {
            ServerConfig config=ServerConfig.GetConfig();
            if (config == null)
            {
                MessageBoxHelper.Show("请先设置监听端口！");
                return;
            }
            if (config != null && config.DefaultOpen)
            {
                this.Start();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.txtContext.Text = string.Empty;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form form = new TcpServerConfigForm();
            form.ShowInTaskbar = false;
            form.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string msg = this.txtMsg.Text.Trim();
            if (msg.Length > 0)
            {
                this.tcpServerHelper.Notify(msg);
            }
            else
            {
                MessageBoxHelper.Show("不能发送空消息！");
                this.txtMsg.Focus();
            }
        }
    }
}