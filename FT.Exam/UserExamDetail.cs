using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace FT.Exam
{
    public partial class UserExamDetail : Form
    {
        public UserExamDetail()
        {
            InitializeComponent();
            this.dataGridView1.AutoGenerateColumns=false;
        }
        public UserExamDetail(string logid):this()
        {
            ArrayList logs = FT.DAL.Orm.SimpleOrmOperator.QueryConditionList<ExamLog>(" where id=" + logid);
            if(logs!=null&&logs.Count>0)
            {
                ExamLog log = logs[0] as ExamLog;
                this.lbWelcome.Text = "���֤��Ϊ"+log.IdCard+"��"
                    +log.Name+"��"+log.ExamDate+"ʱ������ϸ��¼�����Է���Ϊ��"+log.Score;
                string sql = "select b.c_topictext as ��������,b.c_answer as ��׼��,a.answer as ������,b.c_answer_a as ��A,b.c_answer_b as ��B"
                + ",b.c_answer_c as ��C,b.c_answer_d as ��D "
                + ",b.c_picpath as ͼƬ·�� from table_exam_log_detail as a left join table_exam_topic as b on a.topicid=b.id where a.logid=" + logid + " order by a.id asc";
                DataTable dt = FT.DAL.DataAccessFactory.GetDataAccess().SelectDataTable(sql, "tmp");
                if (dt != null)
                {
                    int colIndex=dt.Columns.Count;
                    dt.Columns.Add("���");
                    for (int i = 1; i <= dt.Rows.Count;i++ )
                    {
                        dt.Rows[i - 1][colIndex] = i.ToString();
                    }
                    this.dataGridView1.DataSource = dt;
                   
                }
            }
            
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && this.dataGridView1.Rows.Count > 0)
                {
                    this.ShowTopic(e.RowIndex);
                }
            }
            catch (System.Exception ex)
            {
            	
            }
            
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
             if (e.RowIndex >= 0 )
             {
                 this.ShowTopic(e.RowIndex);
             }
            
        }

        private void ShowTopic(int index)
        {
            DataGridViewCellCollection cells=this.dataGridView1.Rows[index].Cells;
            
            string topicId = cells[0].Value.ToString();
            string topicText = cells[1].Value.ToString();
            string answer = cells[2].Value.ToString();
            string useranswer = cells[3].Value.ToString();
            string answerA = cells[4].Value.ToString();
            string answerB = cells[5].Value.ToString();
            string answerC = cells[6].Value.ToString();
            string answerD = cells[7].Value.ToString();
            string picPath = cells[8].Value.ToString();
            this.txtTopic.Text = topicId + ":" + topicText +
                "\r\n\r\n" + (answerA == string.Empty ? "" : "A " + answerA)
            + "\r\n" + (answerB == string.Empty ? "" : "B " + answerB)
            + "\r\n" + (answerC == string.Empty ? "" : "C " + answerC) +
            "\r\n" + (answerD == string.Empty ? "" : "D " + answerD);

            if (this.picImage.Image != null)
            {
                this.picImage.Image.Dispose();
                this.picImage.Image = null;
            }
            if (picPath != null &&picPath.Length > 0)
            {
                this.picImage.Image = Image.FromFile(picPath);
            }
            this.lbNum.Text = topicId;
            this.lbUserAnswer.Text = useranswer;
            this.lbRealAnswer.Text = answer;
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if(e.RowIndex>-1)
            {
                DataGridViewCellCollection cells=this.dataGridView1.Rows[e.RowIndex].Cells;
                if(cells[2].Value.ToString()!=cells[3].Value.ToString())
                {
                    this.dataGridView1.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                }
            }
        }
    }
}