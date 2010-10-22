using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

namespace PDA.DataInit
{
    public partial class DataGridForm : Form
    {
        public DataGridForm()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            this.dataGrid1.DataSource = SqliteDbFactory.GetSqliteDbOperator().SelectFromTableName("dept");
            
        }
    }
}