using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PDA
{
    public partial class MoveLocDeatilNew : Form
    {
        private string currentLoc;
        private MoveLoc moveLoc;
        public MoveLocDeatilNew(MoveLoc m)
        {
            InitializeComponent();

        }

        private void btn_ClearLoc_Click(object sender, EventArgs e)
        {

        }

        private void btn_Finish_Click(object sender, EventArgs e)
        {
            
        }

        private void txt_Loc_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void txt_Disk_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
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