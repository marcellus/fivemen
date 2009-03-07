using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FT.Test
{
    public partial class TestNameForm : Form
    {
        public TestNameForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.ShowName(this);
        }

        private void ShowName(Control ctr)
        {
            int count = ctr.Controls.Count;
            if (count == 0)
            {
                Console.WriteLine("the control's name is " + ctr.Name);

            }
            else
            {
                for (int i = 0; i < ctr.Controls.Count; i++)
                {
                    ShowName(ctr.Controls[i]);
                }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ToolStripItem item = new ToolStripMenuItem();
            item.Text = "Ìí¼ÓµÄ²Ëµ¥";
            ToolStripMenuItem now = this.menuStrip1.Items[0] as ToolStripMenuItem;
            now.DropDownItems.Add(item);
            //item.Tag = paneltype.FullName;

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}