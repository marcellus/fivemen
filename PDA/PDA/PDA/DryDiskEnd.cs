using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PDA
{
    public partial class DryDiskEnd : Form
    {
        public DryDiskEnd()
        {
            InitializeComponent();
            this.txt_Disk.Focus();
        }

        private void txt_Disk_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txt_Detail.Text = string.Empty;
                string msg = string.Empty;
                try
                {
                    msg = new DB().GetAndSaveDiskForEnd(this.txt_Disk.Text.ToUpper().Trim(), "DRY");
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