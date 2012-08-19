using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace FT.Windows.Controls.FormEx
{
    public partial class AdShowForm : Form
    {
        public AdShowForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                    ControlStyles.ResizeRedraw |
                    ControlStyles.AllPaintingInWmPaint, true);

        }

        private bool IsIn = true;
        private int CurrentIndex = 0;

        private int stopTimes = 3000;

        public int StopTimes
        {
            get { return stopTimes; }
            set { stopTimes = value; }
        }


        private void BeginCycleImage()
        {
            while (true)
            {

                if (IsIn)
                {
                    DateTime begin = System.DateTime.Now;
                    InImage(CurrentIndex);
                    DateTime end = System.DateTime.Now;
                    double c = end.Subtract(begin).TotalMilliseconds;
                    Console.WriteLine("淡入图像花费时间:" + c.ToString());
                    System.Threading.Thread.Sleep(StopTimes);
                }
                else
                {
                    DateTime begin = System.DateTime.Now;
                    OutImage(CurrentIndex);
                    DateTime end = System.DateTime.Now;
                    double c = end.Subtract(begin).TotalMilliseconds;
                    Console.WriteLine("淡出图像花费时间:" + c.ToString());
                    System.Threading.Thread.Sleep(100);
                }
                
            }

        }
        private void OutImage(int index)
        {
            //淡出显示图像
            try
            {
                for (double d = 0.99; d >= 0.01; d -= 0.02)
                {
                    System.Threading.Thread.Sleep(inteval);
                    Application.DoEvents();
                    this.Opacity = d;
                    this.Refresh();
                }
                IsIn = true;
                if (CurrentIndex < this.lists.Count - 1)
                {
                    CurrentIndex++;
                }
                else
                {
                    CurrentIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "信息提示");
            }

        }

        private int inteval = 50;

        /// <summary>
        /// 淡入淡出时间
        /// </summary>
        public int Inteval
        {
            get { return inteval; }
            set { inteval = value; }
        }

        private void InImage(int index)
        {
            //淡入显示图像
            try
            {
                this.BackgroundImage = lists[index];
                
                for (double d = 0.01; d < 1; d += 0.02)
                {
                    System.Threading.Thread.Sleep(inteval);
                    Application.DoEvents();
                    this.Opacity = d;
                    this.Refresh();
                }
                IsIn = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "信息提示");
            }

        }

        private Thread cycleThread;

        private List<Image> lists = new List<Image>();

        /// <summary>
        /// 设置要展示的广告内容图片
        /// </summary>
        public List<Image> Lists
        {
            get { return lists; }
            set
            {
                if (
                cycleThread
                    != null)
                {
                    cycleThread.Abort();
                }
                lists = value;
                if (lists.Count > 0)
                {
                    cycleThread = new Thread(new ThreadStart(BeginCycleImage));
                    cycleThread.IsBackground = true;
                    cycleThread.Start();
                }

            }
        }
    }


}
