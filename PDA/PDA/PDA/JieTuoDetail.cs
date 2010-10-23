using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PDA
{
    public partial class JieTuoDetail : Form
    {
        public JieTuoDetail()
        {
            InitializeComponent();
        }

        public JieTuoDetail(DataSet ds)
        {
            InitializeComponent();
        }          

        private void txt_TrayNo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!cb_AllTary.Checked)
                {
                    this.txt_SN.Focus();
                    this.txt_TrayNo.Enabled = false;
                }
                else
                {
                    //TODO:整盘解托
                }
            }
        }

        private void btn_ClearTray_Click(object sender, EventArgs e)
        {
            this.txt_TrayNo.Text = string.Empty;
            this.txt_TrayNo.Enabled = true;
            this.txt_TrayNo.Focus();
        }

        private void txt_SN_KeyUp(object sender, KeyEventArgs e)
        {
            ClearInput();
            //TODO:解托
        }
        private void ClearInput()
        {
            txt_SN.Text = string.Empty;
        }

        private void cb_AllTary_CheckStateChanged(object sender, EventArgs e)
        {
            this.txt_TrayNo.Text = string.Empty;
            this.txt_TrayNo.Enabled = true;
            this.txt_TrayNo.Focus();
        }

        private void cb_Rollback_CheckStateChanged(object sender, EventArgs e)
        {
            ClearInput();
            if (!cb_AllTary.Checked)
            {
                txt_SN.Focus();
            }
            else
            {
                txt_TrayNo.Focus();
            }
        }
    }
}