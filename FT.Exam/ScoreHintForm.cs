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
            this.lbName.Text = name+"����/Ůʿ";
            int score = 0;
            for (int i = 0; i < topics.Count;i++ )
            {
                if(topics[i].IsRightAnswer)
                    score += topics[i].Score;
            }
            this.lbScore.Text = "����ǰ�Ŀ��Գɼ�Ϊ" + score + "�֡�";
            if(score<90)
            {
                this.lbHint.Text = "���ź������ο��������ϸ�";
                this.lbHint3.Text="ף���´ο��Ժϸ�";
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