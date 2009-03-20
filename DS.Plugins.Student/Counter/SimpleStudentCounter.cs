using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Commons.Tools;
using FT.DAL;

namespace DS.Plugins.Student
{
    public partial class SimpleStudentCounter : FT.Windows.Forms.DataCounterControl
    {
        public SimpleStudentCounter()
        {
            InitializeComponent();
        }

        private void cbWeek_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cbWeek.Checked)
            {
                this.dateBegin.Value = DateTimeHelper.GetMonday();
                this.dateEnd.Value = DateTimeHelper.GetSunday();
                this.cbMonth.Checked = this.cbSeason.Checked = !this.cbWeek.Checked;
            }
            //this.Search();
        }

        private void cbMonth_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cbMonth.Checked)
            {
                this.dateBegin.Value = DateTimeHelper.GetMonthFirstDay();
                this.dateEnd.Value = DateTimeHelper.GetMonthLastDay();
                this.cbWeek.Checked = this.cbSeason.Checked = !this.cbMonth.Checked;
            }
            //this.Search();
        }

        private void cbSeason_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected override string GetTitle()
        {
            return this.dateBegin.Value.ToShortDateString()+"-"
                +this.dateEnd.Value.ToShortDateString()+"���ܱ�";
            //return base.GetTitle();
        }

        protected override void Search()
        {
            string sql = "select date_baoming as ��������, c_idcard as ���֤������,"
                +"c_name as ����,c_phone as ��ϵ�绰,"
                + "c_new_cartype as ѧ������,c_recommend as ������,"
                + "c_description as ��ע from table_students";
            IDataAccess access=FT.DAL.DataAccessFactory.GetDataAccess();
            if (this.txtIdCard.Text.Trim().Length > 0)
            {
                sql += " where c_idcard like '%" + this.txtIdCard.Text.Trim() + "%'";
            }
            else
            {
                sql += " where "+access.BetweenDateString("date_baoming", this.dateBegin.Value, this.dateEnd.Value);
            }
            DataTable dt = access
            .SelectDataTable(sql,"tmp");
            if (dt != null)
            {
                this.dataGridView1.DataSource = dt;
            }
            //base.Search();
        }
    }
}

