using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SKYPE4COMLib;
using FT.Commons.Tools;

namespace TerminalIeForm
{
    public partial class SkypeForm : Form
    {
        public SkypeForm()
        {
            InitializeComponent();
        }
      //  發送聊天訊息


        private void button6_Click(object sender, EventArgs e)
        {
            SKYPE4COMLib.SkypeClass skype = new SkypeClass();
            skype.MessageStatus += new _ISkypeEvents_MessageStatusEventHandler(skype_MessageStatus);
            ChatMessage message = skype.SendMessage("帳號", "內容");
        }
        //傳送手機簡訊：
//
//這兩個事件SmsTargetStatusChangedEventHandler及SmsMessageStatusChangedEventHandler可以好好觀察一下，用來確認簡訊發送狀況


            private void button5_Click(object sender, EventArgs e)
            {
                SKYPE4COMLib.SkypeClass skype = new SkypeClass();
                skype.SmsTargetStatusChanged += new _ISkypeEvents_SmsTargetStatusChangedEventHandler(skype_SmsTargetStatusChanged);
                skype.SmsMessageStatusChanged += new _ISkypeEvents_SmsMessageStatusChangedEventHandler(skype_SmsMessageStatusChanged);
                SmsMessage message = skype.CreateSms(TSmsMessageType.smsMessageTypeOutgoing, "輸入電話號碼");
                message.Body = "測試內容";
                message.Send();
            }


        private void btnDial_Click(object sender, EventArgs e)
        {
            SkypeHelper.CallTimeLimit( this.txtMobile.Text.Trim(), 10);
            this.BringToFront();
           /*
            SkypeClass skype = new SkypeClass();
            CommandClass cmd = new CommandClass();
            skype._ISkypeEvents_Event_Command += new _ISkypeEvents_CommandEventHandler(skype__ISkypeEvents_Event_Command);
            cmd.Command = "OPEN IM " + "拨号";//打開Skype視窗;
            skype.SendCommand(cmd);

            cmd.Command = "CALL " + this.txtMobile.Text.Trim();//撥號
            skype.SendCommand(cmd);
            * */
           // oSkype.
            //oSkype.SendMessage(this.txtMobile.Text.Trim(), "this is a test message!");

        }

        void skype__ISkypeEvents_Event_Command(Command pCommand)
        {
          // pCommand.
        }

      //  撥打電話


        private void button7_Click(object sender, EventArgs e)
        {
            SkypeClass skype = new SkypeClass();
            CommandClass cmd = new CommandClass();
            skype._ISkypeEvents_Event_Command += new _ISkypeEvents_CommandEventHandler(skype__ISkypeEvents_Event_Command);
            cmd.Command = "OPEN IM " + "撥號";//打開Skype視窗;
            skype.SendCommand(cmd);

            cmd.Command = "CALL " + "撥號";//撥號
            skype.SendCommand(cmd);
        }


        void skype_SmsMessageStatusChanged(SmsMessage pMessage, TSmsMessageStatus Status)
        {
            switch (Status)
            {
                case TSmsMessageStatus.smsMessageStatusComposing:
                    break;
                case TSmsMessageStatus.smsMessageStatusDelivered:
                    break;
                case TSmsMessageStatus.smsMessageStatusFailed:
                    break;
                case TSmsMessageStatus.smsMessageStatusRead:
                    break;
                case TSmsMessageStatus.smsMessageStatusReceived:
                    break;
                case TSmsMessageStatus.smsMessageStatusSendingToServer:
                    break;
                case TSmsMessageStatus.smsMessageStatusSentToServer:
                    break;
                case TSmsMessageStatus.smsMessageStatusSomeTargetsFailed:
                    break;
                case TSmsMessageStatus.smsMessageStatusUnknown:
                    break;
                default:
                    break;
            }
        }
        //取消拨号

        private void button8_Click(object sender, EventArgs e)
        {
            SkypeClass skype = new SkypeClass();
            CommandClass cmd = new CommandClass();
            cmd.Command = "SEARCH ACTIVECALLS";//搜尋ID
            skype.SendCommand(cmd);

            int id = skype.ActiveCalls[1].Id;
            cmd.Command = "SET CALL " + id + " STATUS FINISHED";//根據ID掛斷電話
            skype.SendCommand(cmd);
        }

        void skype_MessageStatus(ChatMessage pMessage, TChatMessageStatus Status)
        {
            switch (Status)
            {
                case TChatMessageStatus.cmsRead:
                    break;
                case TChatMessageStatus.cmsReceived:
                    break;
                case TChatMessageStatus.cmsSending:
                    break;
                case TChatMessageStatus.cmsSent:
                    break;
                case TChatMessageStatus.cmsUnknown:
                    break;
                default:
                    break;
            }
        }

        void skype_SmsTargetStatusChanged(SmsTarget pTarget, TSmsTargetStatus Status)
        {
            switch (Status)
            {
                case TSmsTargetStatus.smsTargetStatusAcceptable:
                    break;
                case TSmsTargetStatus.smsTargetStatusAnalyzing:
                    break;
                case TSmsTargetStatus.smsTargetStatusDeliveryFailed:
                    break;
                case TSmsTargetStatus.smsTargetStatusDeliveryPending:
                    break;
                case TSmsTargetStatus.smsTargetStatusDeliverySuccessful:
                    break;
                case TSmsTargetStatus.smsTargetStatusNotRoutable:
                    break;
                case TSmsTargetStatus.smsTargetStatusUndefined:
                    break;
                case TSmsTargetStatus.smsTargetStatusUnknown:
                    break;
                default:
                    break;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            SkypeClass skype = new SkypeClass();
            CommandClass cmd = new CommandClass();
            cmd.Command = "SEARCH ACTIVECALLS";//搜尋ID
            skype.SendCommand(cmd);

            int id = skype.ActiveCalls[1].Id;
            cmd.Command = "SET CALL " + id + " STATUS FINISHED";//根據ID掛斷電話
            skype.SendCommand(cmd);
        }
    }
}
