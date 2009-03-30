using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FT.Test
{
    public partial class ComboBoxTestForm : Form
    {
        public ComboBoxTestForm()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ComboBoxTestForm_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("text");
                dt.Columns.Add("value");
                dt.Rows.Add(new string[] { "×ÖÄ¸C", "C" });
                dt.Rows.Add(new string[] {"×ÖÄ¸A","A" });
                dt.Rows.Add(new string[] { "×ÖÄ¸B", "B" });
                dt.Rows.Add(new string[] { "×ÖÄ¸A2", "A" });
                this.comboBox1.DisplayMember = "text";
                this.comboBox1.ValueMember = "value";
                this.comboBox1.DataSource = dt;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.comboBox1.SelectedValue = "A";
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.comboBox1.SelectedValue = "M";
        }
    }
}