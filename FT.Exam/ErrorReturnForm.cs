using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FT.Exam
{
    public partial class ErrorReturnForm : Form
    {
        public ErrorReturnForm()
        {
            InitializeComponent();
        }
        private List<TopicShow> topics;
        public ErrorReturnForm(List<TopicShow> topics):this()
        {
            this.topics = topics;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string index=this.dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            if(this.lbNum.Text!=index)
            {
                int i = Convert.ToInt32(index);
                this.ShowTopic(i-1);
            }
            
        }

        private void ShowTopic(int index)
        {
            ExamTopic exam=topics[index].Topic;
            this.txtTopic.Text = topics[index] .Number.ToString()+":"+ exam.TopicText +
                "\r\n\r\n" + (exam.AnswerA == string.Empty ? "" : "A " + exam.AnswerA)
            + "\r\n" + (exam.AnswerB == string.Empty ? "" : "B " + exam.AnswerB)
            + "\r\n" + (exam.AnswerC == string.Empty ? "" : "C " + exam.AnswerC) +
            "\r\n" + (exam.AnswerD == string.Empty ? "" : "D " + exam.AnswerD);
            this.lbNum.Text = topics[index].Number.ToString();
            if(this.picImage.Image!=null)
                {
                    this.picImage.Image.Dispose();
                    this.picImage.Image = null;
                }
                if (exam.PicPath!=null&&exam.PicPath.Length > 0)
                {
                    this.picImage.Image = Image.FromFile(exam.PicPath);
                }
                this.lbUserAnswer.Text = topics[index].Answer;
                this.lbRealAnswer.Text = exam.Answer;
        }

        private void ErrorReturnForm_Load(object sender, EventArgs e)
        {
            if(!this.DesignMode)
            {
                TopicShow topic = null;
                for (int i = 0; i < topics.Count;i++ )
                {
                    topic=topics[i];
                    if(!topic.IsRightAnswer)
                    {
                        this.dataGridView1.Rows.Add(new string[] {
                            topic.Number.ToString(),topic.Topic.TopicText,
                            topic.Topic.Answer,
                        topic.Answer});
                        
                    }
                }
                if(this.dataGridView1.Rows.Count>0)
                {
                    string index = this.dataGridView1.Rows[0].Cells[0].Value.ToString();
                    int i = Convert.ToInt32(index);
                    this.ShowTopic(i - 1);
                }
                
                else
                {
                    this.lbNum.Text = String.Empty;
                    this.lbRealAnswer.Text = string.Empty;
                    this.lbUserAnswer.Text = string.Empty;
                }
            }
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex>=0)
            {
                string index = this.dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                if (this.lbNum.Text != index)
                {
                    int i = Convert.ToInt32(index);
                    this.ShowTopic(i - 1);
                }
            }
        }
    }
}