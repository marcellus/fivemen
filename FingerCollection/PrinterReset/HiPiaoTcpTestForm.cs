using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HiPiaoInterface;

namespace PrinterReset
{
    public partial class HiPiaoTcpTestForm : Form
    {
        public HiPiaoTcpTestForm()
        {
            InitializeComponent();
            helper.InitMsgHandle(new FT.Commons.Win32.WindowFormDelegate.StringHandler(ParseMessage));
        }

        private void ParseMessage(string str)
        {
            Console.WriteLine("处理消息："+str);
            this.txtRecieve.AppendText("\r\n" + str);
        }
        private HipiaoTcpHelper helper = new HipiaoTcpHelper();
        private void btnConnect_Click(object sender, EventArgs e)
        {
            helper.Start();
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            helper.Stop();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            helper.Send(this.txtMessage.Text.Trim());
        }

        private void btnGetTicket_Click(object sender, EventArgs e)
        {
            string msgType = "30";
            string str = this.txtMobile.Text.Trim() + "\t" + this.txtValidCode.Text.Trim() + "\t" + this.txtFlag.Text.Trim() + "\n";
            //str = msgType + str;
            //helper.Send(str);
            //HipiaoTcpHelper.GetTicket(str);
            HipiaoTcpHelper.GetTicket(HiPiaoProtocol.PackSend(msgType, str));
        }
    }
}
