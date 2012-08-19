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
        public MoviePlanSelectorPanel(MovieObject movie)
        {
            InitializeComponent();
            this.movie = movie;
        }

        private void MoviePlanSelectorPanel_Load(object sender, EventArgs e)
        {
            DateTime now = System.DateTime.Now;

            this.btnToday.Text = string.Format(this.btnToday.Text, now.ToString("MM月dd日"));
            this.btnTomorrow.Text = string.Format(this.btnTomorrow.Text, now.AddDays(1).ToString("MM月dd日"));
            this.btnThreeDay.Text = string.Format(this.btnThreeDay.Text, now.AddDays(2).ToString("MM月dd日"));
            this.SetSepartor(false);
            this.SetMoiveInfo();
            this.GetPlan(System.DateTime.Now);
            this.SetOperationTime(60);

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            GlobalTools.ReturnMain();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
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
                if(movie.AdImagePath.Length>0)
                    this.picMovieAdImage.Image = Image.FromFile(movie.AdImagePath);
                this.lbLength.Text = string.Format(this.lbLength.Text, movie.TotalMinutes);
                this.lbNational.Text = string.Format(this.lbNational.Text, movie.BelongArea);
                this.lbType.Text = string.Format(this.lbType.Text, movie.Type);
            }
        }
        

        private void SetMoviePlan(MoviePlanObject plan)
        {
            this.moviePlan = plan;
            for (int i = this.panelContent.Controls.Count-1; i >=0 ; i--)
            {
                Control ctr = this.panelContent.Controls[i];
                if (ctr is RoomPlanShowPanel)
                {
                    //
                    //this.panelContent.Controls.Remove(ctr);
                    WindowFormDelegate.RemoveControlFrom(this.panelContent, ctr);
                }
            }
            if (plan == null)
            {   

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
            this.lbLanguage.Text = string.Format(this.lbLanguage.Text, plan.Language);
            List<RoomPlanObject> lists=plan.RoomPlans;
            if (lists != null && lists.Count > 0)
            {
                //this.panelContent.Controls.Clear();
                int x = 58;
                int y = 250;
                int linecount = 5;
                int picWid = 195;
                int picHeight = 88;
                int colSep = 20;
                int rowSep = 20;
                for (int i = 0; i < lists.Count; i++)
                {
                    RoomPlanShowPanel pc = new RoomPlanShowPanel(lists[i]);
                    pc.AutoScaleMode = AutoScaleMode.None;
                    pc.Width = picWid;
                    pc.Height = picHeight;
                    pc.Tag = lists[i];
                    pc.Location = new Point(x + (i % linecount) * (picWid + colSep), y + (i / linecount) * (picHeight + rowSep));
                    pc.Click += new EventHandler(pc_Click);

                    //this.panelContent.Controls.Add(pc);
                    WindowFormDelegate.AddControlTo(this.panelContent, pc);
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
        private void GetPlan(DateTime dt)
        {
            this.planDt = dt;
            Thread thread = new Thread(new ThreadStart(ThreadGetPlan));
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
            
        }

        private void btnThreeDay_Click(object sender, EventArgs e)
        {
            GetPlan(System.DateTime.Now.AddDays(2));
        }

        private void btnToday_Click(object sender, EventArgs e)
        {
            GetPlan(System.DateTime.Now);
        }
    }
}
