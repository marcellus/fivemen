using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Commons.Bar;

namespace FT.Windows.ExternalTool
{
    public partial class Code39Test : Form
    {
        public Code39Test()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Code39 code = new Code39();
            Bitmap map=code.CreateBarCode(this.txtOrgCode.Text.Trim());

            this.panelCode39.CreateGraphics().DrawImage(map, 0, 0);
        }
    }
}