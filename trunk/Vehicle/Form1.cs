using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vehicle
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MyButton btn = new MyButton();
            btn.Text = "Mytest≤‚ ‘∞¥≈•";
            btn.AutoSize = true;
            this.Controls.Add(btn);
            
        }
    }
}