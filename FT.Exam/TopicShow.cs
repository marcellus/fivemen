using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace FT.Exam
{
    public partial class TopicShow : UserControl
    {
        public TopicShow()
        {
            InitializeComponent();
        }
        private ExamTopic topic;
        private int num;
        public TopicShow(int num,ExamTopic topic):this()
        {
            this.topic = topic;
            this.num = num;
            this.lbNum.Text = num.ToString();
            this.lbAnswer.Text = string.Empty;
        }

        public ExamTopic Topic
        {
            get
            {
                return topic;
            }
        }

        public int Score
        {
            get
            {
                return this.topic.Score;
            }
        }

        public int Number
        {
            get
            {
                return this.num;
            }
        }
        public void SetAnswer(string result)
        {
            this.lbAnswer.Text = result;
        }
        /// <summary>
        /// 设置是否激活，激活边框为绿色的
        /// </summary>
        /// <param name="actived"></param>
        public void SetActive(bool actived)
        {
            if(actived)
            {
                this.BackColor = Color.AntiqueWhite;
                //this.BorderStyle.CompareTo()

            }
            else
            {
                this.BackColor = SystemColors.Control;
            }
        }

        /// <summary>
        /// 是否正确回答
        /// </summary>
        public bool IsRightAnswer
        {
            get
            {
                string tmp = this.topic.Answer;
                if(tmp=="Y")
                {
                    tmp = "√";
                }
                if (tmp == "N")
                {
                    tmp = "×";
                }
                return tmp == this.lbAnswer.Text;
            }
        }
        /// <summary>
        /// 用户填写的题目的答案
        /// </summary>
        public string Answer
        {
            get
            {
                string tmp = this.lbAnswer.Text.Trim();
                if (tmp == "√")
                {
                    tmp = "Y";
                }
                if (tmp == "×")
                {
                    tmp = "N";
                }
                return tmp;
            }
        }
    }
}
