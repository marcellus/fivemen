using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HiPiaoInterface;

namespace HiPiaoTerminal.Account
{
    public partial class SingleFeeDetailPanel : HiPiaoTerminal.UserControlEx.SecondNotifyUserPanel
    {
        public SingleFeeDetailPanel()
        {
            InitializeComponent();
        }

        public SingleFeeDetailPanel(BuyRecordObject record)
        {
            InitializeComponent();
            //record.BuyTime;
            TicketObject ticket=record.Tickets[0]; 
            string movieName = ticket.Movie.Name;
            this.lbCinema.Text = string.Format(this.lbCinema.Text, record.Tickets[0].Seat.Room.Cinema.Name);

            this.lbMovieName.Text = string.Format(this.lbMovieName.Text, movieName,ticket.Movie.Type==null|| ticket.Movie.Type.Length == 0 ? "" : "(" + ticket.Movie.Type + ")");
            DateTime playDate = Convert.ToDateTime(ticket.PlayTime);
            this.lbDate.Text = string.Format(this.lbDate.Text, ticket.PlayTime.ToString("yyyy-MM-dd / HH:mm"));


            //this.lbRoom.Location = new Point(this.lbTimeHint.Location.X + this.lbTimeHint.Width, this.lbTimeHint.Location.Y);

            int num = 4;
            string seat = string.Empty;
            string[] seatArray = record.Tickets[0].Seat.SeatId.Split(',');
            for (int i = 0; i < seatArray.Length; i++)
            {
                if (i != 0 && i % num == 0)
                {
                    // seat += "\n座位："
                    seat += "\n              ";
                }
                if (i == 0)
                {
                    seat += seatArray[i];
                }
                else
                {
                    seat += "、" + seatArray[i];
                }

            }

            int totalPrice = record.TotalPrice;
           

            // WinFormHelper.LocationAfter(this.lbPrice, this.lbTicketPriceHint);
            this.lbNum.Text = string.Format(this.lbNum.Text, record.Tickets.Count.ToString());
            // WinFormHelper.LocationAfter(this.lbTicketPriceHint, this.lbTicketCount);
            //WinFormHelper.LocationAfter(this.lbTicketCount, this.lbTicketCountHint);
            this.lbRoom.Text = string.Format(this.lbRoom.Text, ticket.Seat.Room.Name, seat);

            this.lbAllFee.Text = string.Format(this.lbAllFee.Text, totalPrice.ToString());
            FT.Commons.Tools.WinFormHelper.VerLocationAfter(this.lbRoom, this.lbAllFee, 14);
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }
    }
}
