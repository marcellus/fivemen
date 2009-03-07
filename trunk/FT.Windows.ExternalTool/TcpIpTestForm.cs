using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Commons.Tools;
using System.Threading;

namespace FT.Windows.ExternalTool
{
    public partial class TcpIpTestForm : Form
    {
        private TcpClientHelper tcpClientHelper;
        private TcpServerHelper tcpServerHelper;
        public TcpIpTestForm()
        {
            InitializeComponent();
            MessageInfoHandle handle = new MessageInfoHandle(ParseMessage);
            LogHandle log = new LogHandle(Log);
            tcpClientHelper = new TcpClientHelper(handle, log);
            tcpServerHelper = new TcpServerHelper(handle,log);
            this.tcpServerHelper.Parent = this;
            this.tcpClientHelper.Parent = this;
            OrgInfo org=new OrgInfo();
            org.FullName = "XX组织";
            org.NickName = "泰达驾校";
            org.Telephone = "tel";
            org.Url = "url";
            MessageFactory.InitOrg(org);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form form = new ClientConfigForm();
            form.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form form = new TcpServerConfig();
            form.ShowDialog();

        }

        private void TcpIpTestForm_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
           // Thread thread = new Thread(new ThreadStart(this.tcpServerHelper.Start));
           // thread.Start();  
            this.tcpServerHelper.Start();
        }

       

        private void ParseMessage(MessageInfo info)
        {
            this.txtLog.AppendText("\r\n"+info.Data);
        }

        private void Log(string str)
        {
            this.txtLog.AppendText("\r\n"+str);
        }

        private void button4_Click(object sender, EventArgs e)
        { 
            //Thread thread = new Thread(new ThreadStart(this.tcpClientHelper.Start));
            //thread.Start();  
            this.tcpClientHelper.Start();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(this.txtMsg.Text.Trim().Length>0)
            {
                this.tcpClientHelper.Send(this.txtMsg.Text.Trim());
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (this.txtNotify.Text.Trim().Length > 0)
            {
                this.tcpServerHelper.Notify(this.txtNotify.Text.Trim());
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
           // Thread thread = new Thread(new ThreadStart(this.tcpServerHelper.Stop));
           // thread.Start();  
            this.tcpServerHelper.Stop();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.tcpClientHelper.Stop();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            MessageBox.Show(System.Threading.Thread.CurrentThread.ManagedThreadId.ToString());
        }

        private void button10_Click(object sender, EventArgs e)
        {
            TcpFactory.Show();
        }
    }
}