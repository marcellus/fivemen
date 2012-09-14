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
    public partial class WaitSuccessPrintPanel : HiPiaoTerminal.UserControlEx.OperationTimeParentPanel
    {
        
        public WaitSuccessPrintPanel()
        {
            InitializeComponent(); 
        }

        private void WaitSuccessPrintPanel_Load(object sender, EventArgs e)
        {
            GlobalTools.Pop(new SuccessBuyTicketPanel());
        }

        
    }
}
