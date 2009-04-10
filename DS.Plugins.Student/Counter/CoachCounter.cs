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
    public partial class CoachCounter : FT.Windows.Forms.DataCounterControl
    {
        public CoachCounter()
        {
            InitializeComponent();
            this.dataGridView1.AutoGenerateColumns = false;
            //this.dataGridView1.RowPostPaint += new DataGridViewRowPostPaintEventHandler(dataGridView1_RowPostPaint);
            this.ClearColumns();
            this.CreateColumn("��������", 100);
            this.CreateColumn("��Ŀ", 80);
            this.CreateColumn("�����˴�", 80);
            this.CreateColumn("�ϸ��˴�", 140);
            this.CreateColumn("���ϸ��˴�", 140);
            this.CreateColumn("�ϸ���").DefaultCellStyle.Format="N2";
            
        }

        void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string str = this.dataGridView1.Rows[e.RowIndex].Cells[this.dataGridView1.Columns.Count - 1].FormattedValue.ToString();
            this.dataGridView1.Rows[e.RowIndex].Cells[this.dataGridView1.Columns.Count-1].Value = str+"%";
            //throw new Exception("The method or operation is not implemented.");
        }

        private void checkSubject_CheckedChanged(object sender, EventArgs e)
        {
            this.ClearColumns();
            this.CreateColumn("��������", 100);
            if (this.checkSubject.Checked)
            {

                this.CreateColumn("��Ŀ", 80);
            }
            else
            {
                
                
            }
            this.CreateColumn("�����˴�", 80);
            this.CreateColumn("�ϸ��˴�", 140);
            this.CreateColumn("���ϸ��˴�", 140);

            this.CreateColumn("�ϸ���").DefaultCellStyle.Format="N2";
        }

        protected override void Search()
        {
            string sql = string.Empty;
            if (this.checkSubject.Checked)
            {
                sql = "select c_coach as ��������,c_subject as ��Ŀ,count(*) as �����˴�,sum(iif(c_result='�ϸ�',1,0)) as �ϸ��˴�"
            + ",sum(iif(c_result='�ϸ�',0,1)) as ���ϸ��˴�";
            }
            else
            {
                sql = "select c_coach as ��������,count(*) as �����˴�,sum(iif(c_result='�ϸ�',1,0)) as �ϸ��˴�"
            + ",sum(iif(c_result='�ϸ�',0,1)) as ���ϸ��˴�";
            }

            IDataAccess access = FT.DAL.DataAccessFactory.GetDataAccess();
            sql += " from table_student_exam where c_coach like '%" +
                this.txtName.Text.Trim() + "%' and " + access.BetweenDateString("c_examdate", this.dateBetweenPanel1.BeginDate,
                this.dateBetweenPanel1.EndDate);
            sql += " group by c_coach";
            if (this.checkSubject.Checked)
            {
            sql+=",c_subject";
            }
            else{
            }

            DataTable dt = access
            .SelectDataTable(sql, "tmp");

            
            if (dt != null)
            {
                int count1 = 0;
                int count2 = 0;
                int count3 = 0;
                int col = 1;
                if (this.checkSubject.Checked)
                {
                    col = 2;
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    try
                    {
                        count1 += Convert.ToInt32(dt.Rows[i].ItemArray[col].ToString());
                        count2 += Convert.ToInt32(dt.Rows[i].ItemArray[col+1].ToString());
                        count3 += Convert.ToInt32(dt.Rows[i].ItemArray[col+2].ToString());
                    }
                    catch
                    {
                    }
                }
                
                if (col == 1)
                {
                    dt.Rows.Add(new object[] { "�ϼ�",  count1, count2, count3});

                    
                   
                }
                else
                {
                    dt.Rows.Add(new object[] { "�ϼ�", "�ϼ�", count1,count2,count3 });
                    
                }
                DataColumn hegelv = new DataColumn();
                hegelv.DataType = typeof(Decimal);
                hegelv.ColumnName = "�ϸ���";
                hegelv.Expression = "�ϸ��˴�*100/�����˴�";
                dt.Columns.Add(hegelv);
                this.dataGridView1.DataSource = dt;
            }
        }

        protected override string GetTitle()
        {
            return this.dateBetweenPanel1.BeginDate.ToShortDateString() + "��"
                + this.dateBetweenPanel1.EndDate.ToShortDateString() + "����ͳ��";
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            Form form = new DetailForm();
            form.Text = this.GetTitle() + "��ϸ��Ϣ";
            StudentExamSearch search = new StudentExamSearch();
            search.Dock = DockStyle.Fill;
            IDataAccess access = FT.DAL.DataAccessFactory.GetDataAccess();
            string condition = access.BetweenDateString("c_examdate", this.dateBetweenPanel1.BeginDate,
                this.dateBetweenPanel1.EndDate);
            search.SetConditions(condition);
            form.Controls.Add(search);
            form.Show();
        }
    }
}

