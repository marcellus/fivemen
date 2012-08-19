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
    public partial class RoomPlanShowPanel : UserControl
    {
        private RoomPlanObject plan;
        public RoomPlanShowPanel(RoomPlanObject plan)
        {
            InitializeComponent();
            this.plan = plan;
        }

        private void RoomPlanShowPanel_Load(object sender, EventArgs e)
        {
            if (this.plan != null)
            {
                this.lbPrice.Text = string.Format(this.lbPrice.Text, plan.SPrice);
                this.lbRoomName.Text = plan.RoomName;
                this.lbTimes.Text = plan.Playtime;
            }
        }

        private void lbTimes_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }
    }
}
