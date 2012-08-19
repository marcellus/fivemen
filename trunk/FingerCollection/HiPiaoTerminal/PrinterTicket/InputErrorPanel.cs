using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HiPiaoTerminal.PrinterTicket
{
    public partial class InputErrorPanel : HiPiaoTerminal.UserControlEx.FirstNotifyUserPanel
    {
        public InputErrorPanel()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
            GlobalTools.ReturnMain();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
            GlobalTools.ReturnTicketPrint();
        }
    }
}
