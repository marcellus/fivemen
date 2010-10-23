using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PDA
{
    public partial class ASNScan : Form
    {
        private bool hadTray;
        public ASNScan(bool hadTray)
        {
            InitializeComponent();
            init(hadTray);
        }

        public ASNScan(DataSet ds)
        {
            InitializeComponent();
            init(ds);
        }

        private void init(bool hadTray)
        {
            this.hadTray = hadTray;
        }

        private void init(DataSet ds)
        {
            
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            Form ads;
            //TODO:保存界面信息
            if (this.hadTray)
            {
                ads = new AsnDetailScanHadTray();
            }
            else
            {
                ads = new AsnDetailScan();
            }
            ads.Show();
            ads.Closed += new EventHandler(ads_Closed);
            this.Hide();
        }

        void ads_Closed(object sender, EventArgs e)
        {
            this.Close();
        }
                
        private void chk_Different_CheckStateChanged(object sender, EventArgs e)
        {
            this.txt_Different.Enabled = this.ck_Different.Checked;
        }
    }
}