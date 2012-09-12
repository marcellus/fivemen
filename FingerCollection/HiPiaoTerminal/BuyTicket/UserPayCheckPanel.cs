using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using System.Windows.Forms;
using HiPiaoInterface;
using FT.Commons.Tools;

namespace HiPiaoTerminal.BuyTicket
{
    public partial class UserPayCheckPanel : HiPiaoTerminal.UserControlEx.OperationTimeParentPanel
    {
        private List<TicketPrintObject> lists;
        private MovieObject movieInfo;
        private RoomPlanObject roomPlan;
        private MoviePlanObject moviePlan;
        private DateTime dt;

        public UserPayCheckPanel(List<TicketPrintObject> tickets,MovieObject movie,MoviePlanObject moviePlan,RoomPlanObject roomPlan,DateTime dt)
        {
            InitializeComponent();
            this.SetSepartor(false);
            
            this.lists = tickets;
            this.movieInfo = movie;
            this.moviePlan = moviePlan;
            this.roomPlan = roomPlan;
            this.dt = dt;
            if (tickets != null)
            {
                TicketPrintObject ticket = tickets[0];
                this.picAdImage.Image = movieInfo.AdImage;
                //ticket.MovieName = "假如真的是爱情有天意的话";
                if (ticket.MovieName.Length > 9)
                {
                    this.lbMovieName.Text = ticket.MovieName.Substring(0, 9) + "\n" +  ticket.MovieName.Substring(9);
                    this.lbMovieInfo.Location = new Point(this.lbMovieName.Location.X, this.lbMovieName.Location.Y + this.lbMovieName.Height + 2);
                }
                else
                {
                    this.lbMovieName.Text = ticket.MovieName;
                }
                this.lbMovieInfo.Text = string.Format(this.lbMovieInfo.Text, moviePlan.Type, moviePlan.Language, movieInfo.TotalMinutes);
                DateTime  playDate=Convert.ToDateTime(ticket.PlayDate);
                this.lbDate.Text = playDate.ToString("MM月dd日")+" "+DateTimeHelper.GetChineseXq(playDate);
                WinFormHelper.LocationAfter(this.lbDate, this.lbDateHint);
                
                this.lbTime.Text = ticket.PlayTime;
                WinFormHelper.LocationAfter(this.lbDateHint, this.lbTime);
                WinFormHelper.LocationAfter(this.lbTime, this.lbTimeHint);

                this.lbRoom.Text = ticket.RoomName;
                WinFormHelper.LocationAfter(this.lbTimeHint, this.lbRoom);

                //this.lbRoom.Location = new Point(this.lbTimeHint.Location.X + this.lbTimeHint.Width, this.lbTimeHint.Location.Y);

                int num=6;
                string seat = string.Empty;
                for (int i = 0; i < lists.Count; i++)
                {
                    if (i != 0 && i % num == 0)
                    {
                     // seat += "\n座位："
                        seat += "\n          ";
                    }
                    seat += lists[i].Seat+" ";
                    
                }
                this.lbSeats.Text = string.Format(this.lbSeats.Text, seat);
                this.lbTicketPrice.Text = ticket.Price.ToString();
                WinFormHelper.LocationAfter(this.lbTicketPrice,this.lbTicketPriceHint);
                this.lbTicketCount.Text = this.lists.Count.ToString();
                WinFormHelper.LocationAfter(this.lbTicketPriceHint, this.lbTicketCount);
                WinFormHelper.LocationAfter(this.lbTicketCount, this.lbTicketCountHint);
                this.lbTicketTotalPrice.Text = (ticket.Price * this.lists.Count).ToString();
                WinFormHelper.LocationAfter(this.lbTicketTotalPrice, this.lbTicketTotalPriceHint);
            }
            this.SetOperationTime(30);
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            GlobalTools.ReturnMain();
        }

        private void btnConfirmPay_Click(object sender, EventArgs e)
        {
            this.SetOperationTime(30);
            GlobalTools.Pop(new ConfirmPayPwdPanel(lists,this.movieInfo,this.moviePlan,this.roomPlan,this.dt),1);
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            GlobalTools.GoPanel(new MovieSeatSelectorPanel(this.roomPlan,this.movieInfo,this.moviePlan,dt));
        }
    }
}
