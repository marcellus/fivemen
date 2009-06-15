using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FT.Commons
{
    public partial class CustomMessageBox : Form
    {
        public CustomMessageBox(string text)
        {
            InitializeComponent();
            this.lbHint.Text = text;
        }

        public CustomMessageBox(string text,string caption)
        {
            InitializeComponent();
            this.lbHint.Text = text;
            if(caption!=null&&caption.Length>0)
                this.Text = caption;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}