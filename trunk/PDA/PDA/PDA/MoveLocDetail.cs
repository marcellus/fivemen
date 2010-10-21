using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PDA
{
    public partial class MoveLocDetail : Form
    {
        public MoveLoc moveLoc;
        public MoveLocDetail(string loc)
        {
            InitializeComponent();
        }
        public MoveLocDetail()
        {
            InitializeComponent();
        }
        private void btn_Finish_Click(object sender, EventArgs e)
        {
            MoveLocDeatilNew mn = new MoveLocDeatilNew(this.moveLoc);
            mn.Closed += new EventHandler(mn_Closed);
            mn.Show();
            this.Hide();
        }

        void mn_Closed(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_Disk_KeyUp(object sender, KeyEventArgs e)
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