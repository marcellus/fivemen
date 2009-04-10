using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.DAL;

namespace DS.Plugins.Student
{
    public partial class StudentCounter : FT.Windows.Forms.DataCounterControl
    {
        public StudentCounter()
        {
            InitializeComponent();
            this.dataGridView1.AutoGenerateColumns = false;
            this.ClearColumns();
            this.CreateColumn("ʱ��", 140);
            this.CreateColumn("����");
        }

        private void checkDay_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkDay.Checked)
                this.checkMonth.Checked = false;
        }

        private void checkMonth_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkMonth.Checked)
                this.checkDay.Checked = false;
        }

        protected override void Search()
        {
            string sql = "select ";
            if (this.checkDay.Checked)
            {
                sql += "format(date_baoming,\"yyyy-MM-dd\") as ʱ��,count(*) as ����";
            }
            else
            {
                sql += "format(date_baoming,\"yyyy-MM\") as ʱ��,count(*) as ����";
            }
          
            IDataAccess access = FT.DAL.DataAccessFactory.GetDataAccess();
            sql += " from table_students where " + access.BetweenDateString("date_baoming", this.dateBetweenPanel1.BeginDate,
                this.dateBetweenPanel1.EndDate);
            if (this.checkDay.Checked)
            {
                sql += " group by format(date_baoming,\"yyyy-MM-dd\")";
            }
            else
            {
                sql += " group by format(date_baoming,\"yyyy-MM\")";
            }
            DataTable dt = access
            .SelectDataTable(sql, "tmp");
            if (dt != null)
            {
                this.dataGridView1.DataSource = dt;
            }
        }

        protected override string GetTitle()
        {
            string tmp = this.checkDay.Checked ? "����" : "����";
            return this.dateBetweenPanel1.BeginDate.ToShortDateString() + "��"
                + this.dateBetweenPanel1.EndDate.ToShortDateString() +tmp +"ͳ�Ʊ�";
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            Form form =new  DetailForm();
            form.Text = this.GetTitle()+"��ϸ��Ϣ";
            StudentSearch search = new StudentSearch();
            search.Dock = DockStyle.Fill;
            IDataAccess access = FT.DAL.DataAccessFactory.GetDataAccess();
            string condition = access.BetweenDateString("date_baoming", this.dateBetweenPanel1.BeginDate,
                this.dateBetweenPanel1.EndDate);
            search.SetConditions(condition);
            form.Controls.Add(search);
            form.Show();
        }
    }
}

