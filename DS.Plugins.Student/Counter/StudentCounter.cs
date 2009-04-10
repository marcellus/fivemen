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
            this.CreateColumn("时间", 140);
            this.CreateColumn("人数");
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
                sql += "format(date_baoming,\"yyyy-MM-dd\") as 时间,count(*) as 人数";
            }
            else
            {
                sql += "format(date_baoming,\"yyyy-MM\") as 时间,count(*) as 人数";
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
            string tmp = this.checkDay.Checked ? "按天" : "按月";
            return this.dateBetweenPanel1.BeginDate.ToShortDateString() + "至"
                + this.dateBetweenPanel1.EndDate.ToShortDateString() +tmp +"统计表";
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            Form form =new  DetailForm();
            form.Text = this.GetTitle()+"详细信息";
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

