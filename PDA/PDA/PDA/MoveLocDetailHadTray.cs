using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PDA
{
    public partial class MoveLocDetailHadTray : Form
    {
        public MoveLocDetailHadTray()
        {
            InitializeComponent();

        }
                
        private void txt_TrayNo_KeyUp(object sender, KeyEventArgs e)
        {
            if (!this.ck_Rollback.Checked)
            {
                this.txt_NewLoc.Focus();
            }
            else
            {
                this.txt_TrayNo.Text = string.Empty;
            }
        }

        private void txt_NewLoc_KeyUp(object sender, KeyEventArgs e)
        {
            ClearInput();
            txt_TrayNo.Focus();
        }
                
        private void ClearInput()
        {
            this.txt_TrayNo.Text = string.Empty;
            this.txt_NewLoc.Text = string.Empty;
        }

        private void ck_Rollback_CheckStateChanged(object sender, EventArgs e)
        {
            ClearInput();
            this.txt_TrayNo.Focus();
        }
    }
}