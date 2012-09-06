using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PrinterTest
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void panel1_Enter(object sender, EventArgs e)
        {
            Console.WriteLine("panel-Enter");
        }

        private void panel1_Leave(object sender, EventArgs e)
        {
            Console.WriteLine("panel-Leave");
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            Console.WriteLine("textbox-Leave");
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            Console.WriteLine("textbox-enter");
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("textbox-click");
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("panel-click");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("picturebox-click");
        }

        private void panel2_Leave(object sender, EventArgs e)
        {
            Console.WriteLine("pane2-leave");
        }

        private void panel2_Enter(object sender, EventArgs e)
        {
            Console.WriteLine("panel2-enter");
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            Console.WriteLine("panel2-click");
        }
    }
}
