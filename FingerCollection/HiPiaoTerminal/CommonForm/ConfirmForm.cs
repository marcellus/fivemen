using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using FT.Commons.Tools;

namespace HiPiaoTerminal.CommonForm
{
    public partial class ConfirmForm : Form
    {
        public ConfirmForm(string hint)
        {
            InitializeComponent();
            this.lbMsg2.Text = hint;
            GlobalTools.MaskFormKeyDown(this);
        }

        private void ConfirmForm_Paint(object sender, PaintEventArgs e)
        {
            WinFormHelper.PainYellowBorder(sender, e);
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
