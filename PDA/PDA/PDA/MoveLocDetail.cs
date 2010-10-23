using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PDA
{
    public partial class MoveLocDetail : Form
    {
        public MoveLoc moveLoc;
        public MoveLocDetail(string loc)
        {
            InitializeComponent();
        }
        public MoveLocDetail()
        {
            InitializeComponent();
        }
        

        private void txt_Product_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txt_Count.Text = "1";
                if (!this.ck_Rollback.Checked)
                {
                    this.txt_NewLoc.Focus();
                }
                else
                {
                    this.txt_Count.Text = string.Empty;
                    this.txt_Product.Text = string.Empty;
                }
            }
        }               

        private void txt_OldLoc_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txt_Product.Focus();
            }
        }

        private void txt_NewLoc_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ClearInput();
                this.txt_OldLoc.Focus();
            }
        }

        private void ck_Rollback_CheckStateChanged(object sender, EventArgs e)
        {
            ClearInput();
            if (ck_Rollback.Checked)
            {
                this.txt_Product.Focus();
            }
            else
            {
                this.txt_OldLoc.Focus();
            }
        }

        private void ClearInput()
        {
            this.txt_NewLoc.Text = string.Empty;
            this.txt_Product.Text = string.Empty;
            this.txt_Count.Text = string.Empty;
            this.txt_OldLoc.Text = string.Empty;
        }

    }
}