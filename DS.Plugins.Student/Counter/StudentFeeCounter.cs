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
    public partial class StudentFeeCounter : FT.Windows.Forms.DataCounterControl
    {
        public StudentFeeCounter()
        {
            InitializeComponent();
            this.dataGridView1.AutoGenerateColumns = false;
            this.ClearColumns();
            this.CreateColumn("�������", 120);
            this.CreateColumn("���");
        }

        protected override void Search()
        {
            string sql = "select c_feetype as �������,sum(i_fee) as ���";


            IDataAccess access = FT.DAL.DataAccessFactory.GetDataAccess();
            sql += " from table_student_fee where " + access.BetweenDateString("date_fee", this.dateBetweenPanel1.BeginDate,
                this.dateBetweenPanel1.EndDate);
            sql += " group by c_feetype";

            DataTable dt = access
            .SelectDataTable(sql, "tmp");


            if (dt != null)
            {
                int count = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    try
                    {
                        count += Convert.ToInt32(dt.Rows[i].ItemArray[1].ToString());
                    }
                    catch
                    {
                    }
                }
                dt.Rows.Add(new object[] { "�ϼ�", count });
                this.dataGridView1.DataSource = dt;
            }
        }

        protected override string GetTitle()
        {
            return this.dateBetweenPanel1.BeginDate.ToShortDateString() + "��"
                + this.dateBetweenPanel1.EndDate.ToShortDateString() + "ѧ������ͳ��";
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            Form form = new DetailForm();
            form.Text = this.GetTitle() + "��ϸ��Ϣ";
            StudentFeeSearch search = new StudentFeeSearch();
            search.Dock = DockStyle.Fill;
            IDataAccess access = FT.DAL.DataAccessFactory.GetDataAccess();
            string condition = access.BetweenDateString("date_fee", this.dateBetweenPanel1.BeginDate,
                this.dateBetweenPanel1.EndDate);
            search.SetConditions(condition);
            form.Controls.Add(search);
            form.Show();
        }
    }
}

