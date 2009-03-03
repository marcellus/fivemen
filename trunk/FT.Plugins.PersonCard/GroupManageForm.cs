using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.DAL.Orm;
using FT.Commons.Tools;


namespace FT.Plugins.PersonCard
{
    public partial class GroupManageForm : Form
    {
        public GroupManageForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            GroupBrowser form = new GroupBrowser();
            form.ShowInTaskbar = false;
            form.ShowDialog();
        }

        private void GroupManageForm_Load(object sender, EventArgs e)
        {
            this.dataGridView1.AutoGenerateColumns = false;
            Group group = SimpleOrmOperator.Query<Group>(1);
            DataGridViewRow row;
            if (group != null)
            {
                foreach (Group tmp in new Group[] { group })
                {
                    row = new DataGridViewRow();
                    DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell();
                    cell.Value = tmp.Name;
                    DataGridViewTextBoxCell cell2 = new DataGridViewTextBoxCell();
                    cell2.Value = tmp.Description;
                    row.Cells.Add(cell);
                    row.Cells.Add(cell2);
                    row.Tag = tmp;
                    this.dataGridView1.Rows.Add(row);
                }
            }
        }

       

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Form form = new GroupBrowser(this.dataGridView1.Rows[e.RowIndex].Tag);
                form.ShowInTaskbar = false;
                form.ShowDialog();
            }
        }

    }
}