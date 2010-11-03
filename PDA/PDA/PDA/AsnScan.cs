using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PDA.DataInit;

namespace PDA
{
    public partial class ASNScan : Form
    {
        private bool hadTray;
        public ASNScan(bool hadTray)
        {
            InitializeComponent();
            init(hadTray);
            StaticCacheManager.BindDict(this.cb_Company, 1);
            StaticCacheManager.BindDict(this.cb_Storage, 2);
            StaticCacheManager.BindDict(this.cb_ASNType, 3);
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
            //if (this.hadTray)
            //{
            //    ads = new AsnDetailScanHadTray(this.txt_ASN.Text, cb_Company.Text, cb_Company.SelectedValue.ToString(), cb_Storage.Text, cb_Storage.SelectedValue.ToString(), txt_CarNo.Text, cb_ASNType.Text, txt_Different.Text);
            //}
            //else
            //{
                ads = new AsnDetailScan(this.txt_ASN.Text, cb_Company.Text, cb_Company.SelectedValue.ToString(), cb_Storage.Text, cb_Storage.SelectedValue.ToString(), txt_CarNo.Text, cb_ASNType.Text, txt_Different.Text);
            //}
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
            if (this.txt_Different.Enabled) this.txt_Different.Focus();
            else txt_Different.Text = string.Empty;
        }

        
    }
}