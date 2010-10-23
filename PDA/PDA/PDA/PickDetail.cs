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
    public partial class PickDetail : Form
    {
        public PickDetail()
        {
            InitializeComponent();
           
        }
        
        private void txt_XiaXiangJi_KeyUp(object sender, KeyEventArgs e)
        {
            clearInput();
            txt_SN.Focus();
        }       

        private void cb_Rollback_CheckStateChanged(object sender, EventArgs e)
        {
            clearInput();
            txt_SN.Focus();
        }

        private void cb_XiaXiangJi_CheckStateChanged(object sender, EventArgs e)
        {
            txt_XiaXiangJi.Enabled = cb_XiaXiangJi.Checked;
        }

        private void txt_SN_KeyUp(object sender, KeyEventArgs e)
        {
            if (cb_Rollback.Checked)
            {
                clearInput();
                //TODO:逻辑处理
                return;
            }
            if (txt_XiaXiangJi.Enabled)
            {
                txt_XiaXiangJi.Focus();
            }
            else
            {
                clearInput();
                //TODO:逻辑处理
            }
        }
        private void clearInput()
        {
            txt_XiaXiangJi.Text = string.Empty;
            txt_SN.Text = string.Empty;
        }

    }
}