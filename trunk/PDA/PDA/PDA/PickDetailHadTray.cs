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
    public partial class PickDetailHadTray : Form
    {
        public PickDetailHadTray()
        {
            InitializeComponent();
           
        }

        private void cb_Rollback_CheckStateChanged(object sender, EventArgs e)
        {
            txt_TrayNo.Text = string.Empty;
            txt_TrayNo.Focus();
        }

        private void txt_TrayNo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {                
                //TODO:逻辑处理
            }
        }
    }
}