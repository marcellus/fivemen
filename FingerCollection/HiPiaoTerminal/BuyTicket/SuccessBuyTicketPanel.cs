using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HiPiaoTerminal.BuyTicket
{
    public partial class SuccessBuyTicketPanel : HiPiaoTerminal.UserControlEx.SecondNotifyUserPanel
    {
        public SuccessBuyTicketPanel()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
            GlobalTools.ReturnMain();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
            this.FindForm().Close();
            GlobalTools.QuitAccount();
        }
    }
}
