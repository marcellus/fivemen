using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Commons.Win32;
using HiPiaoInterface;
using System.Collections;

namespace HiPiaoTerminal.BuyTicket
{
    public partial class FullScreenSeatSelectorForm : Form
    {
        private MovieSeatSelectorPanel seatPanel;
        private int addWidth=10;
        public FullScreenSeatSelectorForm(MovieSeatSelectorPanel seatPanel,int addWidth)
        {
            InitializeComponent();
            this.seatPanel = seatPanel;
            this.addWidth = addWidth;
            if (seatPanel.Movie != null && seatPanel.MoviePlan != null)
            {
                this.lbMovieName.Text = seatPanel.Movie.Name;
                this.lbMovieDetail.Text = string.Format(this.lbMovieDetail.Text, seatPanel.MoviePlan.Type, seatPanel.MoviePlan.Language, seatPanel.Movie.TotalMinutes);


            }
            if (seatPanel.RoomPlan != null)
            {
                this.lbPrice.Text = string.Format(this.lbPrice.Text, seatPanel.RoomPlan.SPrice);
                this.lbPlanInfo.Text = string.Format(this.lbPlanInfo.Text, seatPanel.Dt.ToString("yyyy-MM-dd"), seatPanel.RoomPlan.Playtime, seatPanel.RoomPlan.RoomName);
                
            }
            this.InitSeat(seatPanel.SeatList);
            this.RefreshSelectedPanel();
            
        }

        public void RefreshSelectedPanel()
        {
           
            SeatObject seat = null;
            System.Collections.IDictionaryEnumerator enumerator = seatPanel.selectedSeat.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                seat = enumerator.Value as SeatObject;
                this.panelSeats.Controls[seat.SeatId].BackColor = seatPanel.selectedColor;
            }
            this.selectedSeatTmp = this.seatPanel.selectedSeat.Clone() as Hashtable;

        }

        private void InitSeat(List<SeatObject> lists)
        {
            if (lists == null || lists.Count == 0)
            {
                return;
            }
            
           
            //75, 78 height=29
            int x = 0;
            int y = 0;
            int lineOneY = lists[0].YPoint;
#if DEBUG
            Console.WriteLine("第一行" + lists[0].XPoint + "-" + lists[0].YPoint);
#endif

            int picWid = 25+addWidth;
            int picHeight = 25+addWidth;
            Font font = new Font("宋体", 9);
            for (int i = 0; i < lists.Count; i++)
            {
                Label lb = new Label();
                lb.Name = lists[i].SeatId;
                lb.BackColor = Color.Transparent;
                lb.Text = lists[i].SeatNo.ToString();
                lb.AutoSize = false;
                if (lists[i].LockState == "0")
                {
                    lb.BackColor = seatPanel.emptyColor;
                }
                else
                {
                    lb.BackColor = seatPanel.selledColor;
                }
                lb.ForeColor = Color.White;
                lb.Font = font;
                // lb.autos
                lb.Width = picWid;
                lb.Height = picHeight;
                lb.TextAlign = ContentAlignment.MiddleCenter;
                lb.Tag = lists[i];
                //this.panelContent.Controls.Add(lb);
                lb.Location = new Point(x + lists[i].XPoint + addWidth * (lists[i].SeatNo - 1), y + lists[i].YPoint + addWidth * (lists[i].RowNum - 1) - lineOneY);
                lb.Click += new EventHandler(lb_Click);
                //  WindowFormDelegate.AddControlTo(this.panelContent,lb);
                WindowFormDelegate.AddControlTo(this.panelSeats, lb);


            }

        }

        public Hashtable selectedSeatTmp = new Hashtable();

        void lb_Click(object sender, EventArgs e)
        {
            Control ctr = sender as Control;
            SeatObject seat = ctr.Tag as SeatObject;
            //253,208,0
            if (seat.LockState == "0")
            {
                if (ctr.BackColor.R == (byte)125)
                {
                    if (this.selectedSeatTmp.Count < 8)
                    {
                        selectedSeatTmp.Add(seat.SeatId, seat);
                        ctr.BackColor = seatPanel.selectedColor;
                    }
                    //seatPanel.RefreshSelectedPanel();
                }
                else if (ctr.BackColor.R == (byte)253)
                {
                    selectedSeatTmp.Remove(seat.SeatId);
                    ctr.BackColor = seatPanel.emptyColor;
                    //seatPanel.RefreshSelectedPanel();
                }
                else
                {
                    //this.selectedSeat.Add(seat.SeatId, seat);
                    // ctr.BackColor = Color.FromArgb(253, 208, 0);
                    // this.RefreshSelectedPanel();
                    //this.selectedSeat.Remove(seat.SeatId);
                }
            }

            //MessageBoxHelper.Show("选中位置");
            //throw new NotImplementedException();
        }

        private void lbPrice_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            
            seatPanel.RemoveAllSelected();
            seatPanel.selectedSeat = this.selectedSeatTmp;
            seatPanel.RefreshSelectedPanel();
            this.Close();
        }
    }
}
