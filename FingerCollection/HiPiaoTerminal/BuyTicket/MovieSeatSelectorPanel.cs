using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HiPiaoInterface;
using FT.Commons.Tools;
using System.Threading;
using FT.Commons.Win32;
using System.Collections;
using HiPiaoTerminal.ConfigModel;

namespace HiPiaoTerminal.BuyTicket
{
    public partial class MovieSeatSelectorPanel : HiPiaoTerminal.UserControlEx.OperationTimeParentPanel
    {
        private RoomPlanObject roomPlan;

        public RoomPlanObject RoomPlan
        {
            get { return roomPlan; }
            set { roomPlan = value; }
        }
        private MovieObject movie;

        public MovieObject Movie
        {
            get { return movie; }
            set { movie = value; }
        }
        private DateTime dt;

        public DateTime Dt
        {
            get { return dt; }
            set { dt = value; }
        }
        private MoviePlanObject moviePlan;

        public MoviePlanObject MoviePlan
        {
            get { return moviePlan; }
            set { moviePlan = value; }
        }

        public void RefreshSeat()
        {
            this.panelSeat.Controls.Clear();
            this.LoadSeat();
        }
        public MovieSeatSelectorPanel(RoomPlanObject roomPlan,MovieObject movie,MoviePlanObject moviePlan,DateTime dt)
        {
            InitializeComponent();
            this.roomPlan = roomPlan;
            this.movie = movie;
            this.dt = dt;
            this.moviePlan = moviePlan;
            CheckForIllegalCrossThreadCalls = false;
            this.SetOperationTime(60);
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            GlobalTools.GoPanel(new MoviePlanSelectorPanel(movie));
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            GlobalTools.ReturnMain();
        }


        public Hashtable selectedSeat = new Hashtable();

        public ArrayList selectedSeatLine = new ArrayList();

        

        public Hashtable SelectedSeat
        {
            get { return selectedSeat; }
            set { selectedSeat = value; }
        }

        private void MovieSeatSelectorPanel_Load(object sender, EventArgs e)
        {
            
            if (movie != null&&moviePlan!=null)
            {
                if (movie.Name.Length >8)
                {
                    this.lbMovieName.Text = movie.Name.Substring(0, 8);
                    this.toolTip1.SetToolTip(this.lbMovieName, movie.Name);
                }
                else
                {
                    this.lbMovieName.Text = movie.Name;
                    this.toolTip1.SetToolTip(this.lbMovieName,string.Empty);
                }
                this.lbMovieDetail.Text = string.Format(this.lbMovieDetail.Text, moviePlan.Type, moviePlan.Language, movie.TotalMinutes);
               

            }
            this.lbTotalNum.Text = selectedSeat.Count.ToString() + "张";
            if (roomPlan != null)
            {
                this.lbPrice.Text = string.Format(this.lbPrice.Text, roomPlan.SPrice);
                this.lbPlanInfo.Text = string.Format(this.lbPlanInfo.Text, dt.ToString("yyyy-MM-dd"), roomPlan.Playtime, roomPlan.RoomName);
                LoadSeat();
            }
           
        }
        private void LoadSeat()
        {
            Thread thread = new Thread(new ThreadStart(ThreadLoadSeat));
            thread.Start();
        }

        private void ThreadLoadSeat()
        {
            this.lbProcessHint.Visible = true;
            this.processPanel1.Visible = true;
            this.processPanel1.StartProcess();
            InitSeat(HiPiaoCache.GetSeatList(roomPlan.PlanId));
            this.processPanel1.StopProcess();
            this.lbProcessHint.Visible = false;
            this.processPanel1.Visible = false;
            
        }
        public List<SeatObject> SeatList;
        private void InitSeat(List<SeatObject> lists)
        {
            if (lists == null || lists.Count == 0)
            {
                return;
            }
            SeatList = lists;
            //75, 78 height=29
                int x = 0;
                int y =0;
                int lineOneY = lists[0].YPoint;
#if DEBUG
                Console.WriteLine("第一行"+lists[0].XPoint+"-"+lists[0].YPoint);
#endif

                int picWid = 25;
                int picHeight = 25;
                Font font = new Font("方正兰亭纤黑简体", 9,FontStyle.Bold);
                for (int i = 0; i < lists.Count; i++)
                {
                    Label lb = new Label();
                    lb.Name = lists[i].SeatId;
                    lb.BackColor = Color.Transparent;
                    lb.Text = lists[i].SeatNo.ToString();
                    lb.AutoSize = false;
                    if (lists[i].LockState == "0")
                    {
                        lb.BackColor = emptyColor;
                    }
                    else
                    {
                        lb.BackColor = selledColor;
                    }
                    lb.ForeColor = Color.White;
                    lb.Font = font;
                   // lb.autos
                    lb.Width = picWid;
                    lb.Height = picHeight;
                    lb.TextAlign = ContentAlignment.MiddleCenter;
                    lb.Tag = lists[i];
                    //this.panelContent.Controls.Add(lb);
                    lb.Location = new Point(x + lists[i].XPoint, y + lists[i].YPoint - lineOneY);
                    lb.Click += new EventHandler(lb_Click);
                   //  WindowFormDelegate.AddControlTo(this.panelContent,lb);
                    WindowFormDelegate.AddControlTo(this.panelSeat, lb);

                  
                }
            
        }

        public void AddSeat(SeatObject seat)
        {
            this.selectedSeat.Add(seat.SeatId, seat);
            this.selectedSeatLine.Add(seat);
            this.panelSeat.Controls[seat.SeatId].BackColor = selectedColor;
        }
        
        public void RemoveSeat(string  seatid)
        {
            this.selectedSeat.Remove(seatid);
            this.panelSeat.Controls[seatid].BackColor = emptyColor;
            SeatObject tmp=null;
            for (int i = 0; i < this.selectedSeatLine.Count; i++)
            {
                tmp = this.selectedSeatLine[i] as SeatObject;
                if (tmp.SeatId == seatid)
                {
                    this.selectedSeatLine.RemoveAt(i);
                    break;
                }
            }
        }

        void lb_Click(object sender, EventArgs e)
        {
            Control ctr=sender as Control;
            SeatObject seat = ctr.Tag as SeatObject;
            //253,208,0
            if (seat.LockState == "0")
            {
                if (ctr.BackColor.R == (byte)125)
                {
                    if (this.selectedSeat.Count < 8)
                    {
                        this.AddSeat(seat);
                        
                        this.RefreshSelectedPanel();
                    }
                }
                else if (ctr.BackColor.R == (byte)253)
                {
                    this.RemoveSeat(seat.SeatId);
                    
                    this.RefreshSelectedPanel();
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

        public Color selectedColor = Color.FromArgb(253, 208, 0);
        public Color emptyColor = Color.FromArgb(125, 183, 0);
        public Color selledColor = Color.FromArgb(164, 0, 0);

        void lbTmp_Click(object sender, EventArgs e)
        {
            Control ctr = sender as Control;
            string seatId = ctr.Tag.ToString();
            this.RemoveSeat(seatId);
            //this.selectedSeat.Remove(seatId);
            this.panelSeat.Controls[seatId].BackColor = emptyColor;
            this.RefreshSelectedPanel();
            
        }

        public void RefreshSelectedPanel()
        {
            this.panelSelectedSeat.Controls.Clear();

            this.lbTotalNum.Text = selectedSeat.Count.ToString() + "张";
            //{0:C2}
            this.lbTotalPrice.Text = string.Format("{0}.00",(roomPlan.SPrice * selectedSeat.Count));
           // int sep =10;
            //int y = 35;
           // int x=10;

            int sep = 4;
            int y = 4;
            int x = 4;
            SeatObject seat = null;
           // System.Collections.IDictionaryEnumerator enumerator = selectedSeat.GetEnumerator();
            int i = 0;
            Font font = new Font("方正兰亭纤黑简体", 12,FontStyle.Bold);
           // while (enumerator.MoveNext())
            for (int j = 0; j < this.selectedSeatLine.Count;j++ )
            {
                //seat = enumerator.Value as SeatObject;
                seat = this.selectedSeatLine[j] as SeatObject;
                this.panelSeat.Controls[seat.SeatId].BackColor = selectedColor;
                Label lbTmp = new Label();
                lbTmp.Font = font;
                lbTmp.ForeColor = Color.FromArgb(80, 79, 79);
                lbTmp.AutoSize = false;
                lbTmp.Width = 194;
                lbTmp.Height = 37;
                lbTmp.Image = Properties.Resources.BuyTicket_Seat_Select_Hint;
                lbTmp.TextAlign = ContentAlignment.MiddleLeft;
                lbTmp.Text = string.Format("座位号：{0}排{1}号", seat.RowNum, seat.SeatNo);
                lbTmp.Click += new EventHandler(lbTmp_Click);
                lbTmp.Tag = seat.SeatId;
                lbTmp.Location = new Point(x, y + (lbTmp.Height + sep) * i);

                this.panelSelectedSeat.Controls.Add(lbTmp);  // Hashtable值
                i++;
            }

        }

        public void RemoveAllSelected()
        {
            System.Collections.IDictionaryEnumerator enumerator = selectedSeat.GetEnumerator();
            SeatObject seat=null;
            while (enumerator.MoveNext())
            {
                seat = enumerator.Value as SeatObject;
                this.panelSeat.Controls[seat.SeatId].BackColor = emptyColor;
            }
            selectedSeat.Clear();
            this.selectedSeatLine.Clear();
            this.panelSelectedSeat.Controls.Clear();
        }



        private void btnPay_Click(object sender, EventArgs e)
        {
            if (selectedSeat.Count == 0)
            {
                return;
            }

            if (GlobalTools.GetLoginUser().Balance < Convert.ToDouble(this.lbTotalPrice.Text))
            {
                GlobalTools.Pop(new BuyMoneyHint());
                return;
            }
            List<TicketPrintObject> tickets = new List<TicketPrintObject>();
            System.Collections.IDictionaryEnumerator enumerator = selectedSeat.GetEnumerator();
            TicketPrintObject ticket = null;
            SeatObject seat = null;
            SystemConfig config=FT.Commons.Cache.StaticCacheManager.GetConfig<SystemConfig>();
            while (enumerator.MoveNext())
            {
                ticket = new TicketPrintObject();
                seat = enumerator.Value as SeatObject;
                ticket.Seat = string.Format("{0}排{1}号", seat.RowNum, seat.SeatNo); ;
                ticket.MovieName = movie.Name;
                ticket.Cinema =config.Cinema;
                ticket.TicketId = "0000FED001";
                ticket.RoomName = roomPlan.RoomName;
                ticket.Price = Convert.ToInt32(roomPlan.SPrice);
                ticket.PrintTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                ticket.PlayTime = roomPlan.Playtime;
                ticket.PlayDate = Convert.ToDateTime(roomPlan.Playtime).ToString("yyyy.MM.dd");
                ticket.PlanId = roomPlan.PlanId;
                //ticket.PlanId = roomPlan.PlanId.Substring(0, 16);
                ticket.SeatId = seat.SeatId;
                tickets.Add(ticket);
                    
            }
            //GlobalTools.Pop(new CosumeDetailPanel(tickets, movie, moviePlan));
           // GlobalTools.GoPanel(new WaitTicketPrintPanel(tickets, movie, moviePlan));
            GlobalTools.GoPanel(new UserPayCheckPanel(tickets,movie,moviePlan,roomPlan,dt));
        }

        /// <summary>
        /// 检查位置顺序
        /// </summary>
        /// <returns></returns>
        private bool CheckLeftToRight()
        {
            if (SeatList.Count > 1)
            {
                if (SeatList[0].SeatNo > SeatList[1].SeatNo)
                {
                    return SeatList[0].XPoint > SeatList[1].XPoint;
                }
                else
                {
                    return SeatList[0].XPoint <= SeatList[1].XPoint;
                }
            }
            else
            {
                return false;
            }
            
        }

        private void panelSeat_DoubleClick(object sender, EventArgs e)
        {
            if (this.panelSeat.Controls.Count > 0)
            {
                FullScreenSeatSelectorForm form = new FullScreenSeatSelectorForm(this,8,this.CheckLeftToRight());
               // form.StartPosition=F
                form.ShowDialog();
            }
        }

        private void btnDoubleToFullScreen_Click(object sender, EventArgs e)
        {

        }

        private void lbTotalNum_Click(object sender, EventArgs e)
        {

        }
        Font fontHint = new Font("方正兰亭纤黑简体", 18,FontStyle.Bold);

        private void toolTip1_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();

            e.Graphics.DrawString(e.ToolTipText, fontHint, Brushes.Black, new PointF(0, 0));
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {
            if (this.toolTip1.Tag!=null)
            e.ToolTipSize = e.AssociatedControl.CreateGraphics().MeasureString(this.toolTip1.Tag.ToString(), fontHint).ToSize();
        }

       
    }
}
