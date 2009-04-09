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

       

        protected override string GetTitle()
        {
            return this.dateBetweenPanel1.BeginDate.ToShortDateString()+"-"
                + this.dateBetweenPanel1.EndDate.ToShortDateString() + "汇总表";
            //return base.GetTitle();
        }

        protected override void Search()
        {
            string sql = "select date_baoming as 报名日期, c_idcard as 身份证明号码,"
                +"c_name as 姓名,c_phone as 联系电话,"
                + "c_new_cartype as 学车类型,c_recommend as 介绍人,"
                + "c_description as 备注 from table_students";
            IDataAccess access=FT.DAL.DataAccessFactory.GetDataAccess();
            if (this.txtIdCard.Text.Trim().Length > 0)
            {
                sql += " where c_idcard like '%" + this.txtIdCard.Text.Trim() + "%'";
            }
            else
            {
                sql += " where " + access.BetweenDateString("date_baoming", this.dateBetweenPanel1.BeginDate, this.dateBetweenPanel1.EndDate);
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

