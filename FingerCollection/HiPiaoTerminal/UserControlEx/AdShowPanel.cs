using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using HiPiaoTerminal.ConfigModel;
using HiPiaoInterface;

namespace HiPiaoTerminal.UserControlEx
{
    public partial class AdShowPanel : UserControl
    {
        private string adType;

        public string AdType
        {
            get { return adType; }
            set { adType = value; }
        }
        private int interval=500;

        public int Interval
        {
            get { return interval; }
            set { interval = value;
            this.adShowTimer.Interval = value;
            }
        }
        public AdShowPanel()
        {
            InitializeComponent();
            this.DoubleBuffered = true;//设置本窗体
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲
            this.UpdateStyles();
            this.adType = "所有位置";
        }
        public AdShowPanel(string type)
        {
            InitializeComponent();
            this.DoubleBuffered = true;//设置本窗体
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲
            this.UpdateStyles();
            this.adType = type;
        }

        private void AdShowPanel_Load(object sender, EventArgs e)
        {
            try
            {
                this.BackgroundImageLayout = ImageLayout.Stretch;
                SystemConfig config = FT.Commons.Cache.StaticCacheManager.GetConfig<SystemConfig>();
                adShowTimer.Interval = config.AdSeconds ;
               // adShowTimer.Interval = interval;
                adShowTimer.Tick += new EventHandler(adShowTimer_Tick);
                adShowTimer.Start();
            }
            catch
            {
            }
        }

        void adShowTimer_Tick(object sender, EventArgs e)
        {
            adShowTimer.Stop();
            try
            {
                if (this.Visible)
                {
                    SystemConfig config = FT.Commons.Cache.StaticCacheManager.GetConfig<SystemConfig>();
                    List<AdvertisementObject> lists = HiPiaoCache.GetAdvertisement(config.Cinema);
                    int len = lists.Count;
                    if (len == 0)
                    {

                        return;
                    }
                    int currentIndex = 0;
#if DEBUG
                    //Console.WriteLine("当前广告对象的Tag内容为：" + this.Tag);
#endif
                    if (this.Tag == null)
                    {
                        //this.BackgroundImage = lists[0].AdvPic;
                        currentIndex = 0;
                    }
                    else
                    {
                        currentIndex = Convert.ToInt32(this.Tag.ToString());
                        if (currentIndex == lists.Count - 1)
                        {
                            currentIndex = 0;
                        }
                       // else if (currentIndex != 0)
                        else
                        {
                            currentIndex += 1;
                        }
                    }
                   
#if DEBUG
                    //Console.WriteLine("当前广告起始的索引为：" + currentIndex);
#endif
                    int count = 0;
                    int countindex=0;
                    for (int i = 0; i < lists.Count; i++)
                    {
                        if (lists[i].AdvWeizhiOne == adType)
                        {
                            count++;
                            countindex = i;
                        }
                    }
                    if (count == 0)
                    {
                        this.BackgroundImage = lists[0].AdvPic;
                        this.Tag ="0";
                    }
                    else if (count == 1)
                    {
                        this.BackgroundImage = lists[countindex].AdvPic;
                        this.Tag = countindex.ToString();
                    }
                    else if (count > 1)
                    {
                        for (int i = currentIndex; i < lists.Count; i++)
                        {
                            //if (true)
                            if (i > 0 && i == lists.Count - 1 && lists[i].AdvWeizhiOne != adType)
                            {
#if DEBUG
                                Console.WriteLine(System.DateTime.Now.ToString() + "最后一个广告索引都不是位置：" + adType);
#endif
                                i = 0;

                                continue;
                            }
                            if (lists[i].AdvWeizhiOne == adType)
                            {
                                this.BackgroundImage = lists[i].AdvPic;
                                this.Tag = i.ToString();
                                break;
                            }
                        }
                    }
                }
            }
            catch
            {

            }
            adShowTimer.Start();
        }
    }
}
