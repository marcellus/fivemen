using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HiPiaoInterface;
using HiPiaoTerminal.ConfigModel;

namespace HiPiaoTerminal.BuyTicket
{
    public partial class CosumeDetailPanel : HiPiaoTerminal.UserControlEx.SecondNotifyUserPanel
    {
        private List<TicketPrintObject> lists;
        private MovieObject movieInfo;
        private MoviePlanObject moviePlan;
        public CosumeDetailPanel(List<TicketPrintObject> tickets, MovieObject movie, MoviePlanObject moviePlan)
        {
            InitializeComponent(); 
            this.lists = tickets;
            this.movieInfo = movie;
            this.moviePlan = moviePlan;
            this.InitMovieInfo();
        }

        private void InitMovieInfo()
        {
            if (lists != null)
            {
                SystemConfig config = FT.Commons.Cache.StaticCacheManager.GetConfig<SystemConfig>();
                this.lbCinema.Text = string.Format(this.lbCinema.Text, config.Cinema);
                TicketPrintObject ticket = lists[0];
                string movieName = ticket.MovieName;
                if (movieName.Length > 9)
                {
                    movieName = movieName.Substring(0, 9) + "...";
                    //this.lbMovieName.Location = new Point(this.lbMovieName.Location.X, this.lbMovieName.Location.Y + this.lbMovieName.Height + 2);
                }
                else
                {
                  //  movieName = movieName;
                }
                
                this.lbMovieName.Text = string.Format(this.lbMovieName.Text, ticket.MovieName, moviePlan.Type.Length==0?"":"("+moviePlan.Type+")");
                DateTime playDate = Convert.ToDateTime(ticket.PlayDate);
                this.lbDate.Text = string.Format(this.lbDate.Text,System.DateTime.Now.Year.ToString()+"-"+playDate.ToString("MM-dd"),ticket.PlayTime);
               

                //this.lbRoom.Location = new Point(this.lbTimeHint.Location.X + this.lbTimeHint.Width, this.lbTimeHint.Location.Y);

                int num = 6;
                string seat = string.Empty;
                for (int i = 0; i < lists.Count; i++)
                {
                    if (i != 0 && i % num == 0)
                    {
                        // seat += "\n座位："
                        seat += "\n          ";
                    }
                    seat += lists[i].Seat + "、";

                }
                this.lbRoom.Text = string.Format(this.lbRoom.Text, ticket.RoomName,seat);
                int totalPrice=(ticket.Price * this.lists.Count);
                int ye = Convert.ToInt32(GlobalTools.GetLoginUser().Balance) - totalPrice;
                this.lbAccountMoney.Text = string.Format(this.lbAccountMoney.Text, ye);
                // WinFormHelper.LocationAfter(this.lbPrice, this.lbTicketPriceHint);
                this.lbNum.Text = string.Format(this.lbNum.Text,this.lists.Count.ToString());
                // WinFormHelper.LocationAfter(this.lbTicketPriceHint, this.lbTicketCount);
                //WinFormHelper.LocationAfter(this.lbTicketCount, this.lbTicketCountHint);
                this.lbAllFee.Text = string.Format(this.lbAllFee.Text,totalPrice.ToString());
                //  WinFormHelper.LocationAfter(this.lbTicketTotalPrice, this.lbTicketTotalPriceHint);

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
            GlobalTools.Pop(new SuccessBuyTicketPanel());
        }
    }
}
