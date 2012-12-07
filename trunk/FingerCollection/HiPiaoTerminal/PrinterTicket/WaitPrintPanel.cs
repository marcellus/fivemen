using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HiPiaoTerminal.ConfigModel;
using HiPiaoInterface;
using System.Collections;

namespace HiPiaoTerminal.PrinterTicket
{
    public partial class WaitPrintPanel : HiPiaoTerminal.UserControlEx.SecondNotifyUserPanel
    {
        public   WaitPrintPanel()
        {
            InitializeComponent();
        }
        private ArrayList tickets;
        public WaitPrintPanel(ArrayList tickets)
        {
            InitializeComponent();
            this.tickets = tickets;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            GlobalTools.PrintTickets(tickets);
          
            /*
            GlobalHardwareTools.OpenHotPrinter();
            GlobalHardwareTools.PrintTicket();
            GlobalHardwareTools.CloseHotPrinter();
             * */
            GlobalTools.ChangePanel(this.FindForm(), new SuccessPrintPanel());
        }

        private void WaitPrintPanel_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
