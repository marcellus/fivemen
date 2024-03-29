﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HiPiaoInterface;
using HiPiaoTerminal.CommonForm;
using HiPiaoTerminal.ConfigModel;
using System.Collections;
using FT.Commons.Tools;

namespace HiPiaoTerminal.PrinterTicket
{
    public partial class WaitValidPanel : HiPiaoTerminal.UserControlEx.SecondNotifyUserPanel
    {
        private string mobile;
        private string validCode;
        public WaitValidPanel(string mobile,string valid)
        {
            InitializeComponent();
            this.mobile = mobile;
            this.validCode = valid;
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
            /*
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
             * */
        }

        void WaitValidPanel_FormClosed(object sender, FormClosedEventArgs e)
        {
            /*
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
             * */
        }

        private void ChangePanel(Control panel)
        {
            Form frm = this.FindForm();
            
            frm.MaximizeBox = true;
            frm.MinimizeBox = true;
            frm.FormBorderStyle = FormBorderStyle.Sizable;
            frm.StartPosition = FormStartPosition.Manual;
            frm.WindowState = FormWindowState.Normal;
            frm.Parent = null;
            // MessageBox.Show("1-现有窗体宽度为Width：" + frm.Width.ToString() + ":Height:" + frm.Height.ToString());
            frm.MaximumSize = new Size(panel.Width, panel.Height);
            frm.MinimumSize = new Size(panel.Width, panel.Height);
            frm.Width = panel.Width;
            frm.Height = panel.Height;
            frm.Controls.Clear();
            frm.Controls.Add(panel);
            panel.Dock = DockStyle.Fill;
            //frm.StartPosition = FormStartPosition.CenterScreen;

            WinFormHelper.CenterForm(frm);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Hide();
            frm.Show();
        }

        private void ChangeHint(string msg1, string msg2)
        {
            GlobalTools.ChangePanel(this.FindForm(),new TicketPrintMessagePanel(msg1,msg2));

        }

        private void ChangeHint(string msg1)
        {
            GlobalTools.ChangePanel(this.FindForm(), new TicketPrintMessagePanel(msg1));

        }


        private int retCode = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
             try
                {
            SystemConfig config = FT.Commons.Cache.StaticCacheManager.GetConfig<SystemConfig>();
            ArrayList tickets = new ArrayList();
            if (config.IsDingXin)
            {
                tickets = HipiaoTcpHelper.GetDingxinTicket("1", "13269402753", "694540");
               // tickets = HipiaoTcpHelper.GetDingxinTicket(config.CinemaId, mobile, validCode);
            }
            else
            {
                //this.ChangeHint("该影票已出过票！");
                //this.ChangeHint("网络故障，请向影院工作人员垂询！", "或拨打400-601-556");
                //  GlobalTools.ChangePanel(this.FindForm(), new MessagePanelFirst("该影票已出过票！"));
                //  GlobalTools.ChangePanel(this.FindForm(), new InputErrorPanel());
                //  GlobalTools.ChangePanel(this.FindForm(), new MessagePanelFirst("网络故障，请向影院工作人员垂询！", "或拨打400-601-556"));
                //  return;
               


                    string msgType = "30";
                    //string str = this.txtMobile.Text.Trim() + "\t" + this.txtValidCode.Text.Trim() + "\t" + this.txtFlag.Text.Trim() + "\n";
                    string str = "1,2,3,4,5,6,7\r1,2,3\r" + mobile + "\t" + validCode + "\t0\n";
                    //str = msgType + str;
                    //helper.Send(str);
                    //HipiaoTcpHelper.GetTicket(str);
                    //SystemConfig config = FT.Commons.Cache.StaticCacheManager.GetConfig<SystemConfig>();
                   tickets = HipiaoTcpHelper.GetTicket(config.CinemaServerIp, config.CinemaServerPort, HiPiaoProtocol.PackSend(msgType, str));
                    //TicketPrintObject ticket = HiPiaoInterface.HiPiaoOperatorFactory.GetMockHiPiaoOperator().GetTicket(mobile, valid);
                    // GlobalHardwareTools.ticket = ticket;
                   

            }
            if (tickets != null && tickets.Count > 0 && ((TicketPrintObject)tickets[0]).PrintTime != null)
            {
                if (((TicketPrintObject)tickets[0]).IsPrinted == false)
                {
                    //this.pictureBox1.Image = Properties.Resources.Print_Wait_Print;
                    //this.un
                    // System.Threading.Thread.Sleep(2000);
                    // this.pictureBox1.Image = Properties.Resources.Print_Wait_Success;
                    //  System.Threading.Thread.Sleep(2000);
                    // this.FindForm().Close();
                    GlobalTools.ChangePanel(this.FindForm(), new WaitPrintPanel(tickets));
                }
                else
                {
                    //retCode = 1;
                    //this.FindForm().Close();
                    this.ChangeHint("该影票已出过票！");
                    //  GlobalTools.ChangePanel(this.FindForm(), new MessagePanelFirst("该影票已出过票！"));



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
             catch(Exception ex)
             {
                 Console.WriteLine(ex);
                 //retCode = 3;
                 // this.FindForm().Close();
                 // System.Threading.Thread.Sleep(1000);
                 // this.ChangePanel(new MessagePanelFirst("网络故障，请向影院工作人员垂询！", "或拨打400-601-556"));
                 //  GlobalTools.ChangePanel(this.FindForm(), new MessagePanelFirst("网络故障，请向影院工作人员垂询！", "或拨打400-601-556"));
                 this.ChangeHint("网络故障，请向影院工作人员垂询！", "或拨打400-601-556");

             }
        }
    }
}
