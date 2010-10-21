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
        public ASNScan()
        {
            InitializeComponent();
        }

        public ASNScan(DataSet ds)
        {
            InitializeComponent();
            init(ds);
        }

        private void init()
        {
            
        }

        private void init(DataSet ds)
        {
            
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            AsnDetailScan ads = new AsnDetailScan();
            ads.Show();
            ads.Closed += new EventHandler(ads_Closed);
            this.Hide();
        }

        void ads_Closed(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_ASN_KeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}