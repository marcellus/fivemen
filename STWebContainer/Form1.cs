using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using FT.Commons.Cache;

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
            if(set.Url.Length>0)
                this.webBrowser.Navigate(set.Url);

        }

       
    }
}
