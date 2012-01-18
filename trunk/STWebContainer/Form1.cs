using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using FT.Commons.Cache;
using System.Diagnostics;

namespace STWebContainer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.webBrowser.GoBack();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            this.webBrowser.GoForward();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.webBrowser.Refresh();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            STWebContainerSetting set = StaticCacheManager.GetConfig<STWebContainerSetting>();
            this.webBrowser.Navigate(set.Url);
        }

        private void btnMaintainment_Click(object sender, EventArgs e)
        {
            //Form frm = new SettingForm();
            Form frm = new InPutPwdForm();
            frm.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            STWebContainerSetting set = StaticCacheManager.GetConfig<STWebContainerSetting>();
            if (set.Url.Length > 0)
            {
                this.webBrowser.Navigate(set.Url);
            }
            this.splitContainer2.Visible = set.IsShowToolBar;
            if (!set.IsShowToolBar)
            {
                //this.splitContainer1.Panel2.Height = 0;
                this.splitContainer1.FixedPanel = FixedPanel.None;
                this.splitContainer1.SplitterDistance = this.Height;
               // this.splitContainer1.Panel1.
            }
            if (set.IsTimer)
            {
                this.timer1.Start();
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            STWebContainerSetting set = StaticCacheManager.GetConfig<STWebContainerSetting>();
            DateTime now=System.DateTime.Now;
            if (now.Hour == set.Hour && now.Minute >= set.Minute)
            {
                this.timer1.Enabled = false;
                this.timer1.Stop();

                try
                {
                    //启动本地程序并执行命令
                    Process.Start("Shutdown.exe", " -s -t 0");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

       
    }
}
