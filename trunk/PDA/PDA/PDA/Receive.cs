using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PDA
{
    public partial class Receive : Form
    {
        public Receive()
        {
            InitializeComponent();
        }

        private void btn_ScanNewASN_Click(object sender, EventArgs e)
        {
            ASNScan asnscan = new ASNScan();
            asnscan.Show();
            asnscan.Closed += new EventHandler(asnscan_Closed);
            this.Hide();
        }

        void asnscan_Closed(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_ReadTempFile_Click(object sender, EventArgs e)
        {
            DataSet ds = MySerialization.DeSerialize(ASN.TempFileUrl);
            ASNScan asnscan = new ASNScan(ds);
            asnscan.Show();
            asnscan.Closed += new EventHandler(asnscan_Closed);
            this.Hide();
        }
    }
}