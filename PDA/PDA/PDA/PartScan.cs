using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PDA
{
    public partial class PartScan : Form
    {
        PartDisk pd;
        public PartScan()
        {
            InitializeComponent();            
        }

        private void txt_ParentDisk_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void txt_SonDisk_KeyUp(object sender, KeyEventArgs e)
        {
           
        }

        private void btn_TempSave_Click(object sender, EventArgs e)
        {

        }

        private void btn_Save_Click(object sender, EventArgs e)
        {


        }

        private void txt_Num_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void btn_ClearLoc_Click(object sender, EventArgs e)
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