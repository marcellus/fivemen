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
            GlobalTools.SetAllKeyBoard(this.textBox1);
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            GlobalTools.SetAllKeyBoard(this.textBox2);
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
    }
}
