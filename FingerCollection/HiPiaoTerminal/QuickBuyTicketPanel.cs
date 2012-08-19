using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace HiPiaoTerminal
{
    public partial class QuickBuyTicketPanel : UserControl
    {
        public QuickBuyTicketPanel()
        {
            InitializeComponent();
        }

        private void QuickBuyTicketPanel_Load(object sender, EventArgs e)
        {
            GlobalTools.RegistUpdateUnOperationTime(null);
        }
    }
}
