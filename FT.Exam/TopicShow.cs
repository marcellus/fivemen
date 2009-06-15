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
        /// �����Ƿ񼤻����߿�Ϊ��ɫ��
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
        /// �Ƿ���ȷ�ش�
        /// </summary>
        public bool IsRightAnswer
        {
            get
            {
                return this.topic.Answer == this.lbAnswer.Text;
            }
        }
        /// <summary>
        /// ��Ŀ�Ĵ�
        /// </summary>
        public string Answer
        {
            get
            {

                return this.lbAnswer.Text.Trim();
            }
        }
    }
}
