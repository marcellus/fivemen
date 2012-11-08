using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace HiPiaoTerminal.TestForm
{
    public partial class KeyBoardTestForm : Form
    {
        public KeyBoardTestForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            GlobalTools.SetAllKeyBoardWithForm(this.textBox1,1);
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            GlobalTools.SetAllKeyBoardWithForm(this.textBox2, 1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KeyBoardTestForm form = new KeyBoardTestForm();
            form.Show();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            //GlobalTools.HideAllKeyBoard();
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            //GlobalTools.HideAllKeyBoard();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form frm = new TestPopForm();
            frm.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
