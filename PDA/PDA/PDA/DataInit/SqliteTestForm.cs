using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;

namespace PDA.DataInit
{
    public partial class SqliteTestForm : Form
    {
        public SqliteTestForm()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //SqliteDbFactory.GetSqliteDbOperator().CreateDb();
            //MessageBox.Show("创建数据库成功！");
            CreateTablesForm form = new CreateTablesForm();
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = SqliteDbFactory.GetSqliteDbOperator().ExecuteNonQuery("insert into dept(deptid,deptname) values(1,'name1')");
            if(i>0)
            {
                MessageBox.Show("插入数据成功！"+i);

            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataGridForm frm = new DataGridForm();
            frm.Show();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

        private void button4_Click(object sender, EventArgs e)
        {
             SqliteDbFactory.GetSqliteDbOperator().CreateTable("create table dept(deptid integer,deptname varchar(30))");
            MessageBox.Show("创建数据表成功！");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int i =  SqliteDbFactory.GetSqliteDbOperator().ExecuteNonQuery("update dept set deptname=deptname+'modify' where deptid=1");
            if (i > 0)
            {
                MessageBox.Show("修改数据成功！"+i);

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int i = SqliteDbFactory.GetSqliteDbOperator().ExecuteNonQuery("delete from dept where deptid=1");
            if (i > 0)
            {
                MessageBox.Show("修改数据成功！"+i);

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
             SqliteDbFactory.GetSqliteDbOperator().DropTable("dept");
            MessageBox.Show("Drop表成功！" );
        }
    }
}