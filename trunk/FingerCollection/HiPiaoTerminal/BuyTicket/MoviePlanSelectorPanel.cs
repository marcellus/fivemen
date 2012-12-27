using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HiPiaoInterface;
using HiPiaoTerminal.ConfigModel;
using FT.Commons.Tools;
using FT.Commons.Win32;
using System.Threading;

namespace HiPiaoTerminal.BuyTicket
{
    public partial class MoviePlanSelectorPanel : HiPiaoTerminal.UserControlEx.OperationTimeParentPanel
    {
        private MovieObject movie;
        private DateTime dt;
        public MoviePlanSelectorPanel(MovieObject movie)
        {
            InitializeComponent();
            this.movie = movie;
            this.dt = System.DateTime.Now;
            CheckForIllegalCrossThreadCalls = false;
        }

        public MoviePlanSelectorPanel(MovieObject movie,DateTime dt)
        {
            InitializeComponent();
            this.movie = movie;
            this.dt = dt;

            this.btnToday.Image = Properties.Resources.BuyTicket_Select_Day_Two;
            this.btnTomorrow.Image = Properties.Resources.BuyTicket_Select_Day_Two;
            this.btnThreeDay.Image = Properties.Resources.BuyTicket_Select_Day_Two;
            TimeSpan ts=dt.Subtract(System.DateTime.Now.AddHours(-1));
            if (ts.Days == 0)
            {
                btnToday.Image = Properties.Resources.BuyTicket_Select_Day_Today;
            }
            else if (ts.Days ==1)
            {
                btnTomorrow.Image = Properties.Resources.BuyTicket_Select_Day_Today;
            }
            else
            {
                btnThreeDay.Image = Properties.Resources.BuyTicket_Select_Day_Today;
            }
            CheckForIllegalCrossThreadCalls = false;
        }

        private void MoviePlanSelectorPanel_Load(object sender, EventArgs e)
        {
            DateTime now = System.DateTime.Now;

            this.btnToday.Text = string.Format(this.btnToday.Text, now.ToString("MM月dd日"));
            this.btnTomorrow.Text = string.Format(this.btnTomorrow.Text, now.AddDays(1).ToString("MM月dd日"));
            this.btnThreeDay.Text = string.Format(this.btnThreeDay.Text, now.AddDays(2).ToString("MM月dd日"));
            this.SetSepartor(false);
            this.SetMoiveInfo();
            //if()
            this.GetPlan(dt);
            this.SetOperationTime(60);

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.ExitThread();
            GlobalTools.ReturnMain();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.ExitThread();
            GlobalTools.GoPanel(new MovieSelectorPanel());
        }

      

        private MoviePlanObject moviePlan;



        private void SetMoiveInfo()
        {
            if (movie != null)
            {
                this.lbName.Text = movie.Name;
                this.lbOtherName.Text = movie.OtherName;
                this.lbDirector.Text = string.Format(this.lbDirector.Text,movie.Director);
                this.lbScreenWriter.Text = string.Format(this.lbScreenWriter.Text,movie.ScreenWriter);
                this.lbMainActor.Text =string.Format(this.lbMainActor.Text, movie.MainActors);
                if (movie.AdImagePath.Length > 0)
                {
                    this.picMovieAdImage.BackgroundImage = Image.FromFile(movie.AdImagePath);
                    //this.picMovieAdImage.
                }
                this.lbLength.Text = string.Format(this.lbLength.Text, movie.TotalMinutes);
                this.lbNational.Text = string.Format(this.lbNational.Text, movie.BelongArea);
                this.lbType.Text = string.Format(this.lbType.Text, movie.Type.Trim());
            }
        }
        

        private void SetMoviePlan(MoviePlanObject plan)
        {
            this.moviePlan = plan;
            for (int i = this.panelContent.Controls.Count-1; i >=0 ; i--)
            {
                Control ctr = this.panelContent.Controls[i];
                if (ctr.Name == "picNoPlanHint")
                {
                    WindowFormDelegate.RemoveControlFrom(this.panelContent, ctr);
                }
                else if (ctr is RoomPlanShowPanel)
                {
                    //
                    //this.panelContent.Controls.Remove(ctr);
                    WindowFormDelegate.RemoveControlFrom(this.panelContent, ctr);
                }
                //this.picNoPlanHint.Visible = false;
            }
            if (plan == null)
            {
               // 274, 257
                PictureBox pic = new PictureBox();
                pic.Name = "picNoPlanHint";
                pic.BackgroundImage = Properties.Resources.BuyTick_No_Plan;
                pic.Width = 745;
                pic.Height = 374;
                pic.Location = new Point(274, 257);
                //this.panelContent.Controls.Clear();
                WindowFormDelegate.AddControlTo(this.panelContent, pic);
               // this.panelContent.Controls.Add(pic);
                //this..Visible = true;
                return;
            }
            if (movie.OtherName.Length>0)
            {
                this.lbOtherName.Visible = false;

            }
            else
            {
                this.lbOtherName.Visible = true;
                if(plan.Type.Length>0)
                    this.lbOtherName.Text = movie.OtherName + "(" + plan.Type + ")";
            }
            this.lbLanguage.Text = string.Format("语言：{0}", plan.Language);
            this.lbLanguage.ForeColor = Color.FromArgb(85, 85, 85);
            List<RoomPlanObject> lists=plan.RoomPlans;
            if (lists != null && lists.Count > 0)
            {
                //this.panelContent.Controls.Clear();
                int x = 57;
                int y = 274; 
                int linecount = 5;
                int picWid = 195;
                int picHeight = 88;
                int colSep = 14;
                int rowSep = 14;
                int controlCount = 0;
                bool isToday=this.planDt.Day==System.DateTime.Now.Day;
                int hourNow=System.DateTime.Now.Hour;
                int minuteNow=System.DateTime.Now.Minute+5;
                
                for (int i = 0; i < lists.Count; i++)
                {

                    try
                    {
                        string tttt = lists[i].Playtime;
                        string[] times = tttt.Split(':');
                        int hour = Convert.ToInt32(times[0]);
                        int minute = Convert.ToInt32(times[1]);
                        if (isToday && (hour == hourNow && minute < minuteNow))
                        {
                            continue;
                        }
                    }
                    catch(Exception ex)
                    {
                        GlobalTools.Log(ex);
                    }
                    RoomPlanShowPanel pc = new RoomPlanShowPanel(lists[i]);
                    pc.AutoScaleMode = AutoScaleMode.None;
                    pc.Width = picWid;
                    pc.Height = picHeight;
                    pc.Tag = lists[i];
                    pc.Location = new Point(x + (controlCount % linecount) * (picWid + colSep), y + (controlCount / linecount) * (picHeight + rowSep));
                    pc.Click += new EventHandler(pc_Click);

                    //this.panelContent.Controls.Add(pc);
                    WindowFormDelegate.AddControlTo(this.panelContent, pc);
                    controlCount++;
                }
            }
        }

        void pc_Click(object sender, EventArgs e)
        {
            RoomPlanShowPanel ctr=sender as RoomPlanShowPanel;
            RoomPlanObject roomPlan = ctr.Tag as RoomPlanObject;
            GlobalTools.GoPanel(new MovieSeatSelectorPanel(roomPlan,movie, moviePlan, planDt));
            //MessageBoxHelper.Show("准备选座！");
            //throw new NotImplementedException();
        }

        private DateTime planDt=System.DateTime.Now;
        private Thread thread;

        private void ExitThread()
        {
            try
            {
                thread.Abort();
            }
            catch
            {
            }
        }
        private void GetPlan(DateTime dt)
        {
            this.ExitThread();
            this.planDt = dt;
            thread = new Thread(new ThreadStart(ThreadGetPlan));
            thread.IsBackground = true;
            thread.Start();
           
        }

        private void ThreadGetPlan()
        {

            this.lbProcessHint.Visible = true;
            this.processPanel1.Visible = true;
            this.processPanel1.StartProcess();
           
            
            SystemConfig config = FT.Commons.Cache.StaticCacheManager.GetConfig<SystemConfig>();
            MoviePlanObject plan = HiPiaoCache.GetMoviePlanVii(config.Province, config.City, movie.Id, config.CinemaId, planDt);
            this.SetMoviePlan(plan);
            this.processPanel1.StopProcess();
            this.lbProcessHint.Visible = false;
            this.processPanel1.Visible = false;
        }

        private void btnTomorrow_Click(object sender, EventArgs e)
        {
            GetPlan(System.DateTime.Now.AddDays(1));
            this.btnToday.Image = Properties.Resources.BuyTicket_Select_Day_Two;
            this.btnTomorrow.Image = Properties.Resources.BuyTicket_Select_Day_Today;
            this.btnThreeDay.Image = Properties.Resources.BuyTicket_Select_Day_Two;
            
        }

        private void btnThreeDay_Click(object sender, EventArgs e)
        {
            GetPlan(System.DateTime.Now.AddDays(2));
            this.btnToday.Image = Properties.Resources.BuyTicket_Select_Day_Two;
            this.btnTomorrow.Image = Properties.Resources.BuyTicket_Select_Day_Two;
            this.btnThreeDay.Image = Properties.Resources.BuyTicket_Select_Day_Today;
        }

        private void btnToday_Click(object sender, EventArgs e)
        {
            GetPlan(System.DateTime.Now);
            this.btnToday.Image = Properties.Resources.BuyTicket_Select_Day_Today; 
            this.btnTomorrow.Image = Properties.Resources.BuyTicket_Select_Day_Two;
            this.btnThreeDay.Image = Properties.Resources.BuyTicket_Select_Day_Two;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Point pt = MousePosition;
            pt = pictureBox1.PointToClient(pt);
#if DEBUG
            Console.WriteLine("点击横幅区域为X：" + pt.X + "---Y:" + pt.Y.ToString());
#endif
            //点击的是选影片
            if (pt.X > 144 && pt.X < 295 && pt.Y > 5 && pt.Y < 74)
            {
                //btnReturn_Click(null, null);
                this.ExitThread();
                GlobalTools.GoPanel(new MovieSelectorPanel());
                // MovieSelectorPanel(
            }
        }
    }
}
