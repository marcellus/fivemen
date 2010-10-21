using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PDA
{
    public partial class AsnDetailScan : Form
    {
        private ASN asn;
        public AsnDetailScan()
        {

            InitializeComponent();
           
        }

        void asn_onScanFinish(object sender, EventArgs e)
        {
            MessageBox.Show(asn.CurrentDisk.BillNo + "已完成扫描！");
        }

        private void txt_PN_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void txt_Disk_KeyUp(object sender, KeyEventArgs e)
        {
           
        }

        private void btn_Finish_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_TempSave_Click(object sender, EventArgs e)
        {
            
        }

        private void txt_Loc_KeyUp(object sender, KeyEventArgs e)
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