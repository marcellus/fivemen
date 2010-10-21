using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PDA
{
    public partial class FeedBackScan : Form
    {
        public FeedBackScan()
        {
            InitializeComponent();
        }

        public FeedBackScan(DataSet ds)
        {
            InitializeComponent();
        }

        private void txt_FeedBackBill_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            FeedBackDetail fbd = new FeedBackDetail(ReturnDisk.DataSource);
            fbd.Show();
            fbd.Closed += new EventHandler(fbd_Closed);
            this.Hide();
        }

        void fbd_Closed(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {

        }

        private void btn_TempSave_Click(object sender, EventArgs e)
        {

        }

        private void txt_Num_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void txt_ParentDisk_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void btn_Save_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            DiskList dl = new DiskList();
            dl.Show();
            dl.Closed += new EventHandler(dl_Closed);
            this.Hide();
        }

        void dl_Closed(object sender, EventArgs e)
        {
            this.Show();
        }
    }
}