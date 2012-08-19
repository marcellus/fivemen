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
    public partial class MovieSelectorPanel : HiPiaoTerminal.UserControlEx.OperationTimeParentPanel
    {
        public MovieSelectorPanel()
        {
            InitializeComponent();
        }

        private void MovieSelectorPanel_Load(object sender, EventArgs e)
        {
            DateTime now = System.DateTime.Now;
            
            this.btnToday.Text=string.Format(this.btnToday.Text,now.ToString("MM月dd日"));
            this.btnTomorrow.Text = string.Format(this.btnTomorrow.Text, now.AddDays(1).ToString("MM月dd日"));
            this.btnThreeDay.Text = string.Format(this.btnThreeDay.Text, now.AddDays(2).ToString("MM月dd日"));
            this.SetSepartor(false);
            SystemConfig config = FT.Commons.Cache.StaticCacheManager.GetConfig<SystemConfig>();
            List<MovieObject> hotmovies=HiPiaoCache.GetHotMovie(config.Province, config.City);
            this.InitMovies(hotmovies);
            this.SetOperationTime(60);
        }

        //private static Font MovieNameColor=new Font("",

        private void InitMovies(List<MovieObject> lists)
        {
            if (lists != null && lists.Count > 0)
            {
                this.panelContent.Controls.Clear();
                int x=100;
                int y=0;
                int col=0;
                int row=0;
                int linecount=6;
                for (int i = 0; i < lists.Count; i++)
                {
                    PictureBox pc = new PictureBox();
                    pc.Width = picWid;
                    pc.Height = picHeight;
                    pc.Tag = lists[i];
                    if(lists[i].AdImagePath.Length>0)
                        pc.Image = Image.FromFile(lists[i].AdImagePath);
                    pc.Location =new Point( x + (i % linecount)*(picWid+colSep),y + (i / linecount) * (picHeight + rowSep));
                    Label lb = new Label();
                    lb.AutoSize = false;
                    lb.Width = picWid;
                    lb.Location = new Point(pc.Location.X,pc.Location.Y + picHeight);
                    lb.ForeColor = Color.FromArgb(69, 68, 68);
                    lb.TextAlign = ContentAlignment.MiddleCenter;
                    lb.Font = new Font("方正兰亭黑简体",18);
                    lb.Text = lists[i].Name;
                    pc.Click += new EventHandler(pc_Click);
                    
                    this.panelContent.Controls.Add(pc);
                    this.panelContent.Controls.Add(lb);
                }
            }
        }

        void pc_Click(object sender, EventArgs e)
        {
            PictureBox pic=sender as PictureBox;
            MovieObject movie = pic.Tag as MovieObject;
            GlobalTools.GoPanel(new MoviePlanSelectorPanel(movie));
        }

        private static int colSep = 20;
        private static int rowSep = 40;

        private static int picWid=156;
        private static int picHeight=216;

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            GlobalTools.ReturnMain();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            GlobalTools.ReturnMain();
        }
    }
}
