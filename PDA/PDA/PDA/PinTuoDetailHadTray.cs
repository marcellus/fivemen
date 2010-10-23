using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PDA
{
    public partial class PinTuoDetailHadTray : Form
    {
        public PinTuoDetailHadTray(DataSet ds)
        {
            InitializeComponent();
        }

        public PinTuoDetailHadTray()
        {
            InitializeComponent();
        }

        private void txt_TrayNo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_OldTrayNo.Focus();
            }
        }
                
        private void ClearInput()
        {
            txt_TrayNo.Text = string.Empty;
            txt_OldTrayNo.Text = string.Empty;
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

        private void txt_OldTrayNo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == e.KeyCode)
            {
                ClearInput();
                txt_TrayNo.Focus();
            }
        }
    }
}