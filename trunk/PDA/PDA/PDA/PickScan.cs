using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PDA
{
    public partial class PickScan : Form
    {
        private bool hadTray;
        public PickScan(bool hadTray)
        {
            InitializeComponent();
            init(hadTray);
        }

        public PickScan(DataSet ds)
        {
            InitializeComponent();
        }

        private void init(bool hadTray)
        {
            this.hadTray = hadTray;
        }

        void pd_Closed(object sender, EventArgs e)
        {
            this.Close();
        }

        public void init(DataSet ds)
        {
           
        }

        private void txt_SO_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_MoreSO.Enabled)
                {
                    txt_MoreSO.Focus();
                }
                else
                {
                    txt_CarNo.Focus();
                }
            }
        }

        private void txt_CarNo_KeyUp(object sender, KeyEventArgs e)
        {
            if (txt_Different.Enabled)
            {
                txt_Different.Focus();
            }
            else
            {

            }
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            Form pd;
            if (hadTray)
            {
                pd = new PickDetailHadTray();
            }
            else
            {
                pd = new PickDetail();
            }
            pd.Show();
            pd.Closed += new EventHandler(pd_Closed);
            this.Hide();
        }

        private void ck_MoreSO_CheckStateChanged(object sender, EventArgs e)
        {
            txt_MoreSO.Enabled = ck_MoreSO.Checked;
        }

        private void ck_Different_CheckStateChanged(object sender, EventArgs e)
        {
            txt_Different.Enabled = ck_Different.Checked;
        }
        
    }
}