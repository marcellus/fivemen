using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace PDA
{
    public partial class PutAwayDetail : Form
    {
        private PutAway pa;
        public PutAwayDetail(DataSet ds)
        {
            InitializeComponent();
           
        }
        public PutAwayDetail()
        {
            InitializeComponent();

        }

        void pa_onScanFinish(object sender, EventArgs e)
        {

        }

        private void txt_Disk_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void txt_Loc_KeyUp(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Enter)
            {
                this.txt_Disk.Focus();
            }
        }

        private void btn_Finish_Click(object sender, EventArgs e)
        {

        }

        private void btn_TempSave_Click(object sender, EventArgs e)
        {

        }

        private void btn_ClearLoc_Click(object sender, EventArgs e)
        {
            this.txt_Loc.Text = string.Empty;
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