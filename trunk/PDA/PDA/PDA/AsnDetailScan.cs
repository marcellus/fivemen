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
        public AsnDetailScan()
        {

            InitializeComponent();
           
        }

        void asn_onScanFinish(object sender, EventArgs e)
        {
            
        }

        private void txt_SN_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_Optional.Enabled)
                {
                    txt_Optional.Focus();
                }
                else
                {
                    ClearInput();
                    //TODO:处理逻辑
                }
            }
        }

        private void txt_Optional_KeyUp(object sender, KeyEventArgs e)
        {
            ClearInput();
            txt_SN.Focus();
        }

        
        private void ck_Optional_CheckStateChanged(object sender, EventArgs e)
        {
            txt_Optional.Enabled = ck_Optional.Checked;
        }

        private void ck_Rollback_CheckStateChanged(object sender, EventArgs e)
        {
            ClearInput();
            this.txt_SN.Focus();
        }
        private void ClearInput()
        {
            this.txt_SN.Text = string.Empty;
            this.txt_Optional.Text = string.Empty;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show("hello pc"+this.tabControl1.SelectedIndex.ToString());
        }
    }
}