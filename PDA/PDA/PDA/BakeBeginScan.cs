using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PDA
{
    public partial class BakeBeginScan : Form
    {
        public BakeBeginScan()
        {
            InitializeComponent();
            this.txt_Disk.Focus();
        }

        private void txt_Disk_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txt_Detail.Text = string.Empty;
                try
                {
                    string msg = new DB().GetAndSaveDiskForBegin(this.txt_Disk.Text.ToUpper().Trim(),"BAKE");
                    this.txt_Detail.Text = msg.Replace("\n", "\r\n");
                }
                catch (Exception ex)
                {
                    this.txt_Detail.Text = ex.Message;
                }
                this.txt_Disk.Text = string.Empty;
                this.txt_Disk.Focus();
            }
        }
    }
}