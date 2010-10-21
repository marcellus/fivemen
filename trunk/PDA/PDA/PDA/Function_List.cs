using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace PDA
{
    public partial class Function_List : Form
    {
        public Function_List(ArrayList al)
        {
            InitializeComponent();
        }

        void this_Closed(object sender, EventArgs e)
        {
            //this.Close();
            this.Show();
        }


        private void btn_MoveLot_Click(object sender, EventArgs e)
        {
            MoveLotScan mls = new MoveLotScan();
            mls.Show();
            mls.Closed += new EventHandler(this_Closed);
            this.Hide();
        }

        private void btn_Pingtuo_Click(object sender, EventArgs e)
        {
            FeedBackDetail fbd = new FeedBackDetail();
            fbd.Show();
            fbd.Closed += new EventHandler(this_Closed);
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FeedBackScan fbs = new FeedBackScan();
            fbs.Show();
            fbs.Closed += new EventHandler(this_Closed);
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PartScan ps = new PartScan();
            ps.Show();
            ps.Closed += new EventHandler(this_Closed);
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PutAwayDetail pad = new PutAwayDetail();
            pad.Show();
            pad.Closed += new EventHandler(this_Closed);
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MoveLocDetail mld = new MoveLocDetail();
            mld.Show();
            mld.Closed += new EventHandler(this_Closed);
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            PickScan ps = new PickScan();
            ps.Show();
            ps.Closed += new EventHandler(this_Closed);
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ASNScan asns = new ASNScan();
            asns.Show();
            asns.Closed += new EventHandler(this_Closed);
            this.Hide();
        }
    }
}