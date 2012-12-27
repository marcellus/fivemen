using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using HiPiaoInterface;
using FT.Windows.Controls.PanelEx;
using System.Threading;
using FT.Commons.Tools;

namespace HiPiaoTerminal.BuyTicket
{
    public partial class WaitTicketPrintPanel : HiPiaoTerminal.UserControlEx.OperationTimeParentPanel
    {
        private List<TicketPrintObject> lists;
        private MovieObject movieInfo;
         private MoviePlanObject moviePlan;
        public WaitTicketPrintPanel( List<TicketPrintObject>  tickets,MovieObject movie,MoviePlanObject moviePlan)
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            this.AutoScroll = true;
            this.lists = tickets;
            this.SetSepartor(false);
            this.movieInfo = movie;
            this.moviePlan = moviePlan;
            this.InitMovieInfo();
            
            
        }
        private void InitMovieInfo()
        {
            if (lists != null)
            {
                TicketPrintObject ticket = lists[0];
                this.picAdImage.Image = movieInfo.AdImage;
                //ticket.MovieName = "假如真的是爱情有天意的话";
                if (ticket.MovieName.Length > 9)
                {
                    this.lbMovieName.Text = ticket.MovieName.Substring(0, 9) + "\n" + ticket.MovieName.Substring(9);
                    this.lbMovieInfo.Location = new Point(this.lbMovieName.Location.X, this.lbMovieName.Location.Y + this.lbMovieName.Height + 2);
                }
                else
                {
                    this.lbMovieName.Text = ticket.MovieName;
                }
                this.lbMovieInfo.Text = string.Format(this.lbMovieInfo.Text, moviePlan.Type, moviePlan.Language, movieInfo.TotalMinutes);
                DateTime playDate = Convert.ToDateTime(ticket.PlayDate);
                this.lbDate.Text = playDate.ToString("MM月dd日") + " " + DateTimeHelper.GetChineseXq(playDate);
                WinFormHelper.LocationAfter(this.lbDate, this.lbDateHint);

                this.lbTime.Text = ticket.PlayTime;
                WinFormHelper.LocationAfter(this.lbDateHint, this.lbTime);
                WinFormHelper.LocationAfter(this.lbTime, this.lbTimeHint);

                this.lbRoom.Text = ticket.RoomName;
                WinFormHelper.LocationAfter(this.lbTimeHint, this.lbRoom);

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
                    seat += lists[i].Seat + " ";

                }
                this.lbSeats.Text = string.Format(this.lbSeats.Text, seat);
                this.lbPrice.Text = ticket.Price.ToString();
               // WinFormHelper.LocationAfter(this.lbPrice, this.lbTicketPriceHint);
                this.lbTotalNum.Text = this.lists.Count.ToString();
               // WinFormHelper.LocationAfter(this.lbTicketPriceHint, this.lbTicketCount);
                //WinFormHelper.LocationAfter(this.lbTicketCount, this.lbTicketCountHint);
                this.lbTotalPrice.Text = (ticket.Price * this.lists.Count).ToString();
              //  WinFormHelper.LocationAfter(this.lbTicketTotalPrice, this.lbTicketTotalPriceHint);

            }
        }

        private void WaitTicketPrintPanel_Load(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(PrintTask));
            thread.IsBackground = true;
            thread.Start();
            this.panel2.BringToFront();
        }

        private void PrintTask()
        {
            Thread.Sleep(3000);
            if (this.lists != null)
            {
                MyOpaqueLayerTools.ShowOpaqueLayer(this.panelHeader, 60, true);
                /*
                GlobalHardwareTools.OpenHotPrinter();
                for (int i = 0; i < lists.Count; i++)
                {
                    GlobalHardwareTools.PrintTicket(lists[i]);
                }
                GlobalHardwareTools.CloseHotPrinter();
                 * */
                GlobalTools.PrintTickets(this.lists[0].Phone, this.lists[0].ValidCode);

            }
            GlobalTools.ChangePanel(this.FindForm(), new WaitSuccessPrintPanel(this.lists,this.movieInfo,this.moviePlan));
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
           // GlobalTools.ReturnMain();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            //GlobalTools.ReturnMain();
        }
    }
}
