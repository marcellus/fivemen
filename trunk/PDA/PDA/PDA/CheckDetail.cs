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
    public partial class CheckDetail : Form
    {
        public CheckDetail(DataSet ds)
        {
            InitializeComponent();
           
        }
        public CheckDetail()
        {
            InitializeComponent();

        }

        
        private void txt_Product_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ClearInput();
                txt_Product.Focus();
            }
        }

        private void txt_Loc_KeyUp(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Enter)
            {
                if (!ck_Rollback.Checked)
                {
                    this.txt_Product.Focus();
                    this.txt_Loc.Enabled = false;
                }
                else
                {
                    ClearInput();
                }
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
            txt_Product.Text = string.Empty;
        }

        private void ck_Rollback_CheckStateChanged(object sender, EventArgs e)
        {
            ClearInput();
            if (this.txt_Loc.Enabled)
            {
                txt_Loc.Focus();
            }
            else
            {
                this.txt_Product.Focus();
            }
        }
    }
}