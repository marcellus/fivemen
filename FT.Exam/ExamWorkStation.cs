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
    public partial class ExamWorkStation : Form
    {
        private ArrayList topics;

        private int currentTopic = -1;
        public ExamWorkStation()
        {
            InitializeComponent();
        }
        public ExamWorkStation(ArrayList topics):this()
        {
            this.topics = topics;
            if(this.topics!=null&&this.topics.Count>0)
            {
                for (int i = 0; i < topics.Count;i++ )
                {
                    this.BuildATopicControl(topics[i] as ExamTopic);
                }
                this.ActiveTopic(0);
            }
            if(this.groupBox3.Controls.Count==0)
            {
                this.lbAnswerA.Text = string.Empty;
                this.lbAnswerB.Text = string.Empty;
                this.lbAnswerC.Text = string.Empty;
                this.lbAnswerD.Text = string.Empty;
                this.lbTopic.Text = string.Empty;
                this.btnA.Visible = false;
                this.btnB.Visible = false;
                this.btnC.Visible = false;
                this.btnD.Visible = false;
                this.btnY.Visible = true;
                this.btnN.Visible = true;

            }
        }

        private void BuildATopicControl(ExamTopic topic)
        {
            int i=this.groupBox3.Controls.Count;
            Control ctr = new TopicShow(i + 1, topic);
            if(i<=20)
            {
                //ctr.Location = new Point(this.groupBox3.Location.X + (i % 20 ) * 45, this.groupBox3.Location.Y);
                ctr.Location = new Point( (i % 20) * 45, 0);
            }
            else
            {
                //ctr.Location = new Point(this.groupBox3.Location.X + (i % 20 - 1) * 45, this.groupBox3.Location.Y + (i / 20) * 45);
                ctr.Location = new Point( (i % 20 - 1) * 45, (i / 20) * 45);
            }
            
            ctr.Click += new EventHandler(ctr_Click);
            for (int j = 0; j < ctr.Controls.Count;j++ )
            {
                ctr.Controls[j].Click += new EventHandler(ctr_Click);
            }
            this.groupBox3.Controls.Add(ctr);
        }

        void ctr_Click(object sender, EventArgs e)
        {
            Control ctr=sender as Control;

            TopicShow topicShow = ctr as TopicShow;
            if(topicShow==null)
            {
                topicShow = ctr.Parent as TopicShow;
            }
            this.ActiveTopic(topicShow.Number - 1);
        }
        private void ActiveTopic(int index)
        {
            TopicShow topicShow=null;
            if(this.currentTopic>-1)
            {
                topicShow = this.groupBox3.Controls[this.currentTopic] as TopicShow;
                topicShow.SetActive(false);
            }
            
            topicShow = this.groupBox3.Controls[index] as TopicShow;
            topicShow.SetActive(true);
            this.lbAnswer.Text = topicShow.Answer;
            this.currentTopic = index;
            if(index==0)
            {
                this.btnNext.Enabled=true;
                this.btnPrev.Enabled=false;
            }
            else if(index==this.topics.Count-1)
            {
                this.btnPrev.Enabled=true;
                this.btnNext.Enabled = false;
            }
            else 
            {
                this.btnPrev.Enabled = true;
                this.btnNext.Enabled = true;
            }
            ExamTopic tmp = this.topics[index] as ExamTopic;
            if(tmp!=null)
            {
                if (tmp.TopicType == "ÅÐ¶ÏÌâ")
                {
                    this.btnA.Visible = false;
                    this.btnB.Visible = false;
                    this.btnC.Visible = false;
                    this.btnD.Visible = false;
                    this.btnY.Visible = true;
                    this.btnN.Visible = true;
                    this.lbAnswerA.Text = string.Empty;
                    this.lbAnswerB.Text = string.Empty;
                    this.lbAnswerC.Text = string.Empty;
                    this.lbAnswerD.Text = string.Empty;

                }
                else
                {
                    this.btnA.Visible = true;
                    this.btnB.Visible = true;
                    this.btnC.Visible = true;
                    this.btnD.Visible = true;
                    this.btnY.Visible = false;
                    this.btnN.Visible = false;
                    this.lbAnswerA.Text = "A "+tmp.AnswerA;
                    this.lbAnswerB.Text = "B " + tmp.AnswerB;
                    this.lbAnswerC.Text = "C " + tmp.AnswerC;
                    this.lbAnswerD.Text = "D " + tmp.AnswerD;
                }
                this.lbTopic.Text = tmp.TopicText;
                if(this.picImage.Image!=null)
                {
                    this.picImage.Image.Dispose();
                    this.picImage.Image = null;
                }
                if(tmp.PicPath.Length>0)
                {
                    this.picImage.Image = Image.FromFile(tmp.PicPath);
                }
               
                
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            this.lbAnswer.Text = btn.Text;
            if (this.currentTopic>=0)
            {
                TopicShow topicShow = this.groupBox3.Controls[this.currentTopic] as TopicShow;
                topicShow.SetAnswer(btn.Text);
                if(this.currentTopic!=this.topics.Count-1)
                {
                    this.ActiveTopic(this.currentTopic+1);
                }
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            this.ActiveTopic(this.currentTopic - 1);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            this.ActiveTopic(this.currentTopic +1);
        }

        private void btnOver_Click(object sender, EventArgs e)
        {

        }
    }
}