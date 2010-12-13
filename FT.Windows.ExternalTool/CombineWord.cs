using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FT.Windows.ExternalTool
{
    public partial class CombineWord : Form
    {
        public CombineWord()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            object dest=this.textBox3.Text.Trim();
            object template="c:\\template.doc";
           /* FT.Commons.Com.WordSupport.SimpleWord.Combine(new string[] { "c:\\0.doc",
                 "c:\\1.doc",
                "c:\\2.doc",
                "c:\\3.doc",
                "c:\\4.doc",
                "c:\\5.doc",
                "c:\\6.doc",
                "c:\\7.doc",
                "c:\\8.doc",
                "c:\\9.doc" }, ref dest);
            */
        }
    }
}