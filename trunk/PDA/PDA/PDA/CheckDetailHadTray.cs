using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace PDA
{
    public partial class CheckDetailHadTray : Form
    {
        public CheckDetailHadTray(DataSet ds)
        {
            InitializeComponent();
           
        }
        public CheckDetailHadTray()
        {
            InitializeComponent();

        }


        private void txt_Tray_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ClearInput();
                txt_Tray.Focus();
            }
        }

        private void txt_Loc_KeyUp(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Enter)
            {
                this.txt_Loc.Enabled = false;
                this.txt_Tray.Focus();
            }
        }

        

        private void btn_ClearLoc_Click(object sender, EventArgs e)
        {
            this.txt_Loc.Text = string.Empty;
            this.txt_Loc.Enabled = true;
            this.txt_Loc.Focus();
        }
          
        private void ClearInput()
        {
            txt_Tray.Text = string.Empty;
        }

        private void ck_Rollback_CheckStateChanged(object sender, EventArgs e)
        {
            ClearInput();
            if (txt_Loc.Enabled)
            {
                txt_Loc.Focus();
            }
            else
            {
                txt_Tray.Focus();
            }
        }
    }
}