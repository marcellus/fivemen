using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FT.Test
{
    public partial class TabControlExTest : Form
    {
        public TabControlExTest()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.simpleTabControl1.TabPages.Add("测试中文文本    ");
        }

        private void TabControlExTest_Load(object sender, EventArgs e)
        {
           // this.tabControl1.TabPages[0]. = 300;
            Control ctr=this.tabControl1.TabPages[0];
            ctr.SetBounds(ctr.Location.X, ctr.Location.Y, 300, 30);
            ctr.Controls.Add(new Button());
        }
    }
}