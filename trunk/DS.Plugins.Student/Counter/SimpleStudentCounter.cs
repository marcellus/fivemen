using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Commons.Tools;
using FT.DAL;
using System.Collections;

namespace DS.Plugins.Student
{
    public partial class SimpleStudentCounter : FT.Windows.Forms.DataCounterControl
    {
        public SimpleStudentCounter()
        {
            InitializeComponent();
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.RowPostPaint += new DataGridViewRowPostPaintEventHandler(dataGridView1_RowPostPaint);
            this.ClearColumns();
            this.CreateColumn("序号", 40);
            this.CreateColumn("报名日期", 160);
            this.CreateColumn("身份证明号码",140);
            this.CreateColumn("姓名", 80);
            this.CreateColumn("联系电话1", 100);
            this.CreateColumn("学习车型", 80);
            this.CreateColumn("推荐人");

            object obj = FT.Commons.Tools.ReflectHelper.CreateInstance(typeof(StudentInfo));
            if (obj != null)
            {
                DataTable dt = FT.DAL.Orm.SimpleOrmCache.GetConditionDT(obj.GetType());
                if (dt != null)
                {
                    this.cbColumn.DataSource = dt;
                    this.cbColumn.DisplayMember = "text";
                    this.cbColumn.ValueMember = "value";
                }
            }
        }

        void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.dataGridView1.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1);
            //throw new Exception("The method or operation is not implemented.");
        }

       

        protected override string GetTitle()
        {
            return this.dateBetweenPanel1.BeginDate.ToShortDateString()+"至"
                + this.dateBetweenPanel1.EndDate.ToShortDateString() + "汇总表";
            //return base.GetTitle();
        }

        protected override void Search()
        {
            string condition = " where c_idcard like '%"+this.txtIdCard.Text.Trim()+"%'"
                + " and c_recommend like '%"+this.txtRecommend.Text.Trim()+"%'";
            IDataAccess access = FT.DAL.DataAccessFactory.GetDataAccess();
            condition += " and " + access.BetweenDateString("date_baoming", this.dateBetweenPanel1.BeginDate,
                this.dateBetweenPanel1.EndDate);

            ArrayList arraylist=FT.DAL.Orm.SimpleOrmOperator.QueryConditionList<StudentInfo>(condition);

            if (arraylist != null&&arraylist.Count>0)
            {
                this.dataGridView1.DataSource = arraylist;
            }
            //base.Search();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string column=this.cbColumn.Text.Trim();
            if(column.Length>0&&!this.dataGridView1.Columns.Contains(column))
                this.CreateColumn(column);
        }

        private void btnDeleteColumn_Click(object sender, EventArgs e)
        {
            string column = this.cbColumn.Text.Trim();
            for(int i=0;i<this.dataGridView1.Columns.Count;i++)
                {
                    if(this.dataGridView1.Columns[i].HeaderText==column)
                    {
                        this.dataGridView1.Columns.RemoveAt(i);
                       // break;
                    }
                }
        }
    }
}

