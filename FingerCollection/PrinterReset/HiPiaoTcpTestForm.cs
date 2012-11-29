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

        //手机号：15910606127
//取票码：865672
        //554042

        private void btnGetTicket_Click(object sender, EventArgs e)
        {
            string msgType = "30";
            //string str = this.txtMobile.Text.Trim() + "\t" + this.txtValidCode.Text.Trim() + "\t" + this.txtFlag.Text.Trim() + "\n";
            string str = "1,2,3,4,5,6,7\r1,2,3\r" + this.txtMobile.Text.Trim() + "\t" + this.txtValidCode.Text.Trim() + "\t1\n";
            //str = msgType + str;
            //helper.Send(str);
            //HipiaoTcpHelper.GetTicket(str);
            int port = 2908;
            string host = "119.10.114.212";
            HipiaoTcpHelper.GetTicket(host,port,HiPiaoProtocol.PackSend(msgType, str));
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
             Point p2 = textBox1.GetPositionFromCharIndex(textBox1.Text.Length - 1);
            Console.WriteLine("坐标为:"+p2.X+"  Y="+p2.Y);
            this.label1.BringToFront();
            this.label1.BackColor = this.textBox1.BackColor;
            this.label1.Location = new Point(p2.X+8, p2.Y);
        }
    }
}
