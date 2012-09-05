using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HiPiaoTerminal.BuyTicket
{
    public partial class UserPayCheckPanel : HiPiaoTerminal.UserControlEx.OperationTimeParentPanel
    {
        public UserPayCheckPanel()
        {
            InitializeComponent();
            this.SetSepartor(false);
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            GlobalTools.ReturnMain();
        }

        private void btnConfirmPay_Click(object sender, EventArgs e)
        {
            GlobalTools.Pop(new UserPayCheckPanel(),1);
        }
    }
}
