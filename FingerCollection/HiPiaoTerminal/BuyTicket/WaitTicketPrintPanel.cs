using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using HiPiaoInterface;

namespace HiPiaoTerminal.BuyTicket
{
    public partial class WaitTicketPrintPanel : HiPiaoTerminal.UserControlEx.OperationTimeParentPanel
    {
        private List<TicketPrintObject> lists;
        public WaitTicketPrintPanel( List<TicketPrintObject>  tickets)
        {
            InitializeComponent();
            this.lists = tickets;
            
        }

        private void WaitTicketPrintPanel_Load(object sender, EventArgs e)
        {
            if (this.lists != null)
            {

                GlobalHardwareTools.OpenHotPrinter();
                for (int i = 0; i < lists.Count; i++)
                {
                    GlobalHardwareTools.PrintTicket(lists[i]);
                }
                GlobalHardwareTools.CloseHotPrinter();
               
            }
            GlobalTools.ChangePanel(this.FindForm(), new WaitSuccessPrintPanel());
        }
    }
}
