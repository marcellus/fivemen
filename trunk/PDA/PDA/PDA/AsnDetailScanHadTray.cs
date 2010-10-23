using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PDA
{
    public partial class AsnDetailScanHadTray : Form
    {
        public AsnDetailScanHadTray()
        {

            InitializeComponent();
           
        }

        void asn_onScanFinish(object sender, EventArgs e)
        {
            
        }

        private void txt_TrayNo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txt_TrayNo.Text = string.Empty;
                //TODO:逻辑处理
            }
        }

        
        private void ck_Rollback_CheckStateChanged(object sender, EventArgs e)
        {
            this.txt_TrayNo.Text = string.Empty;
            this.txt_TrayNo.Focus();
        }
    }
}