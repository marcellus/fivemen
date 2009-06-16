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
    public partial class ScoreHintForm : Form
    {
        public ScoreHintForm()
        {
            InitializeComponent();
        }
        private List<TopicShow> topics;
        public ScoreHintForm(string name, List<TopicShow> topics)
            : this()
        {
            this.lbName.Text = name+"先生/女士";
            int score = 0;
            for (int i = 0; i < topics.Count;i++ )
            {
                if(topics[i].IsRightAnswer)
                    score += topics[i].Score;
            }
            this.lbScore.Text = "您当前的考试成绩为" + score + "分。";
            if(score<90)
            {
                this.lbHint.Text = "很遗憾，本次考试您不合格，";
                this.lbHint3.Text="祝您下次考试合格！";
            }
            this.topics = topics;
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnErrorReturn_Click(object sender, EventArgs e)
        {
            this.Close();
            ErrorReturnForm form = new ErrorReturnForm(topics);
            form.ShowDialog();
        }
    }
}