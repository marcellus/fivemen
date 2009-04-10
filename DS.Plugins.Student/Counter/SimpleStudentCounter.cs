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
            this.CreateColumn("���", 40);
            this.CreateColumn("��������", 160);
            this.CreateColumn("���֤������",140);
            this.CreateColumn("����", 80);
            this.CreateColumn("�ֻ�", 100);
            this.CreateColumn("ѧϰ����", 80);
            this.CreateColumn("�Ƽ���");
        }

        void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.dataGridView1.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1);
            //throw new Exception("The method or operation is not implemented.");
        }

       

        protected override string GetTitle()
        {
            return this.dateBetweenPanel1.BeginDate.ToShortDateString()+"��"
                + this.dateBetweenPanel1.EndDate.ToShortDateString() + "���ܱ�";
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
            if(this.txtColumn.Text.Trim().Length>0)
                this.CreateColumn(this.txtColumn.Text.Trim());
        }
    }
}

