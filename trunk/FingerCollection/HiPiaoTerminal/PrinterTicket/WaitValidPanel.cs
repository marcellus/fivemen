using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HiPiaoInterface;
using HiPiaoTerminal.CommonForm;

namespace HiPiaoTerminal.PrinterTicket
{
    public partial class WaitValidPanel : HiPiaoTerminal.UserControlEx.SecondNotifyUserPanel
    {
        private string mobile;
        private string valid;
        public WaitValidPanel(string mobile,string valid)
        {
            InitializeComponent();
            this.mobile = mobile;
            this.valid = valid;
        }

        private void WaitValidPanel_Load(object sender, EventArgs e)
        {
            FT.Commons.Tools.WinFormHelper.CenterHor(this.pictureBox1);
            //this.FindForm().FormClosed += new FormClosedEventHandler(WaitValidPanel_FormClosed);
            //this.FindForm().FormClosing += new FormClosingEventHandler(WaitValidPanel_FormClosing);
            timer1.Start();

        }

        void WaitValidPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (retCode == 1)
            {
                GlobalTools.Pop("该影票已出过票！");
            }
            else if (retCode == 2)
            {
                GlobalTools.Pop("输入错误，请修改！");
            }
            else
            {
                GlobalTools.PopNetError();
            }
        }

        void WaitValidPanel_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (retCode == 1)
            {
                GlobalTools.Pop("该影票已出过票！");
            }
            else if (retCode == 2)
            {
                GlobalTools.Pop("输入错误，请修改！");
            }
            else
            {
                GlobalTools.PopNetError();
            }
        }

        private void ChangePanel(Control panel)
        {
            Form frm = this.FindForm();
            frm.Controls.Remove(this);
            frm.Controls.Add(panel);
        }

        private int retCode = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            try{
            TicketPrintObject ticket = HiPiaoInterface.HiPiaoOperatorFactory.GetMockHiPiaoOperator().GetTicket(mobile, valid);
            GlobalHardwareTools.ticket = ticket;
            
            if (ticket != null)
            {
                if (ticket.IsPrinted == false)
                {
                    //this.pictureBox1.Image = Properties.Resources.Print_Wait_Print;
                    //this.un
                   // System.Threading.Thread.Sleep(2000);
                   // this.pictureBox1.Image = Properties.Resources.Print_Wait_Success;
                  //  System.Threading.Thread.Sleep(2000);
                   // this.FindForm().Close();
                    GlobalTools.ChangePanel(this.FindForm(), new WaitPrintPanel());
                }
                else
                {
                    //retCode = 1;
                    //this.FindForm().Close();
                    GlobalTools.ChangePanel(this.FindForm(), new MessagePanelFirst("该影票已出过票！"));
                    
                   
                   
                }
            }
            else 
            {
               // retCode = 2;
               // this.FindForm().Close();
                GlobalTools.ChangePanel(this.FindForm(), new InputErrorPanel());
               // GlobalTools.ReturnTicketPrint();
                
            }
            }
            catch
            {
                //retCode = 3;
               // this.FindForm().Close();
               // System.Threading.Thread.Sleep(1000);
                GlobalTools.ChangePanel(this.FindForm(), new MessagePanelFirst("网络故障，请向影院工作人员垂询！", "或拨打400-601-556"));
               
            }
        }
    }
}
