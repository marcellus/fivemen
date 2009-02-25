using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FT.Test
{
    public partial class GridViewTest : Form
    {
        public GridViewTest()
        {
            InitializeComponent();
            this.dataGridView1.DataSource = this.Mock();
            DataGridView dataGridView1 = new DataGridView();
            DataGridViewRolloverCellColumn col =
                new DataGridViewRolloverCellColumn();
            dataGridView1.Columns.Add(col);
            dataGridView1.Rows.Add(new string[] { "" });
            dataGridView1.Rows.Add(new string[] { "" });
            dataGridView1.Rows.Add(new string[] { "" });
            dataGridView1.Rows.Add(new string[] { "" });
            this.Controls.Add(dataGridView1);
            this.Text = "DataGridView rollover-cell demo";

        }

        private DataTable Mock()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("name");
            dt.Columns.Add("sex");
            for (int i = 0; i < 10; i++)
            {
                dt.Rows.Add(new string[] {"name"+i,"sex"+i });
            }
            return dt;
        }
    }
}