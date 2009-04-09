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
                + this.dateBetweenPanel1.EndDate.ToShortDateString() + "���ܱ�";
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

