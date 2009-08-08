using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FT.Commons
{
    public partial class CustomConfirmBox : DevExpress.XtraEditors.XtraForm
    {
        public CustomConfirmBox()
        {
            InitializeComponent();
        }

        public CustomConfirmBox(string text)
        {
            InitializeComponent();
            this.lbHint.Text = text;
        }

        private void CustomConfirmBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            if (this.DialogResult != DialogResult.Yes && this.DialogResult != DialogResult.No)
            {
                this.DialogResult = DialogResult.No;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
        }
    }
}