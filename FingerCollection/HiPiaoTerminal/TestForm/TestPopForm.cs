using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HiPiaoTerminal.TestForm
{
    public partial class TestPopForm : Form
    {
        public TestPopForm()
        {
            InitializeComponent();
        }

        private void TestPopForm_Load(object sender, EventArgs e)
        {

        }

        private void TestPopForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
