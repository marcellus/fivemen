using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PDA
{
    public partial class PinTuoDetail : Form
    {
        public PinTuoDetail(DataSet ds)
        {
            InitializeComponent();
        }

        public PinTuoDetail()
        {
            InitializeComponent();
        }

        private void txt_TrayNo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_SN.Focus();
            }
        }

        private void txt_SN_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_Location.Focus();
            }
        }

        private void txt_Location_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_XiaXiangJi.Enabled)
                {
                    txt_XiaXiangJi.Focus();
                }
                else
                {
                    ClearInput();
                    txt_TrayNo.Focus();
                }
            }
        }

        private void cb_XiaXiangJi_CheckStateChanged(object sender, EventArgs e)
        {
            txt_XiaXiangJi.Enabled = cb_XiaXiangJi.Checked;
        }
        private void ClearInput()
        {
            txt_TrayNo.Text = string.Empty;
            txt_SN.Text = string.Empty;
            txt_Location.Text = string.Empty;
            txt_XiaXiangJi.Text = string.Empty;
        }

        private void cb_Rollback_CheckStateChanged(object sender, EventArgs e)
        {
            ClearInput();
            txt_TrayNo.Focus();
        }

        private void txt_XiaXiangJi_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ClearInput();
                txt_TrayNo.Focus();
            }
        }
    }
}