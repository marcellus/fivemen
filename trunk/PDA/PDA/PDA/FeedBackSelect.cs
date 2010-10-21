using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PDA
{
    public partial class FeedBackSelect : Form
    {
        public FeedBackSelect()
        {
            InitializeComponent();
        }

        private void btn_ReadTempFile_Click(object sender, EventArgs e)
        {
            DataSet ds = MySerialization.DeSerialize(ReturnDisk.TempFileUrl);
            FeedBackDetail fbd = new FeedBackDetail(ds);
            fbd.Show();
            fbd.Closed += new EventHandler(fbd_Closed);
            this.Hide();
        }

        void fbd_Closed(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_NewFeedBackBill_Click(object sender, EventArgs e)
        {
            FeedBackScan fbs = new FeedBackScan();
            fbs.Show();
            fbs.Closed += new EventHandler(fbs_Closed);
            this.Hide();
        }

        void fbs_Closed(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}