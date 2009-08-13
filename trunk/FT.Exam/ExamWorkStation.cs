using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using FT.Commons.Tools;

namespace FT.Exam
{
    public partial class ExamWorkStation : Form
    {
        private ArrayList topics;
        private List<TopicShow> topicsControl=new List<TopicShow>();
        private int currentTopic = -1;
        public ExamWorkStation()
        {
            InitializeComponent();
        }
        private ExamUser user;
        //默认为false，模拟考试
        private bool isTrain = false;
        public ExamWorkStation(ExamUser user, bool isTrain)
            : this()
        {
            this.user = user;
            if(user!=null)
            {
                this.lbWelcome.Text = "欢迎您，身份证明号码为" +
                    user.IdCard + "的" + user.Name + "，您的考试次数为" +
                    user.AllCount.ToString() + "合格次数为" +
user.PassCount.ToString() + "不合格次数为" +
user.NotPassCount.ToString();
            }
            this.isTrain = isTrain;
        }
        public ExamWorkStation(ArrayList topics, ExamUser user, bool isTrain)
            : this(user, isTrain)
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
            TopicShow ctr = new TopicShow(i + 1, topic);
            this.topicsControl.Add(ctr);
            if(i<=19)
            {
                //ctr.Location = new Point(this.groupBox3.Location.X + (i % 20 ) * 45, this.groupBox3.Location.Y);
                ctr.Location = new Point(5+(i % 20) * 45-(i>0?1*i:0), 20);
            }
            else
            {
                //ctr.Location = new Point(this.groupBox3.Location.X + (i % 20 - 1) * 45, this.groupBox3.Location.Y + (i / 20) * 45);
                ctr.Location = new Point(5 + (i % 20) * 45 - (i%20 > 0 ? (i%20) : 0), 20 + (i / 20) * 45-(i/20));
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
                if (tmp.TopicType == "1")
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
                if(tmp.PicPath!=null&&tmp.PicPath.Length>0)
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
            if (MessageBoxHelper.Confirm("请再次确认是否要交卷结束考试！"))
            {
                ScoreHintForm form =new  ScoreHintForm(this.user.Name,this.topicsControl);
                form.ShowDialog();
            }

        }

        private void ExamWorkStation_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.isTrain&&user!=null&&MessageBoxHelper.Confirm("是否需要保存本次模拟考试成绩？"))
            {
                int score = 0;
                int pass = 0, nopass = 0;
                for (int i = 0; i < topicsControl.Count; i++)
                {
                    if (topicsControl[i].IsRightAnswer)
                        score += topicsControl[i].Score;
                }
                if (score < 90)
                {
                    nopass = 1;
                }
                else
                {
                    pass = 1;
                }
                string sql = "update table_exam_user set i_all_count=i_all_count+1,i_pass_count=i_pass_count+"
                    + pass + ",i_not_pass_count=i_not_pass_count+"
                    + nopass + " where c_idcard='" + user.IdCard + "'";
                //FT.DAL.DataAccessFactory.GetDataAccess().ExecuteSql(sql);
                /*if()*/
                //开始保存考试记录并统计考试合格或者错误率
                string[] sqls = new string[topicsControl.Count+1];
                sqls[0] = sql;
                ExamLog log = new ExamLog();
                log.ExamDate=System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                log.IdCard=user.IdCard;
                log.Name=user.Name;
                log.Score=score;
                if(FT.DAL.Orm.SimpleOrmOperator.Create(log))
                {
                    for (int i = 0; i < topicsControl.Count; i++)
                    {
                        sqls[i + 1] = "insert into table_exam_log_detail(logid,topicid,answer) values("+
                            log.Id.ToString()+","+topicsControl[i].Topic.Id.ToString()+",'"+
                            topicsControl[i].Answer+ "')";
                    }

                }
                FT.DAL.DataAccessFactory.GetDataAccess().ExecuteTransaction(sqls);
                
               
                //Environment.Exit(0);
                //Application.Exit();
            }
            else{
                //Environment.Exit(0);
                //Application.Exit();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ExamLogSearch ctr = new ExamLogSearch();
            Form tmp = new Form();
            tmp.WindowState = FormWindowState.Maximized;
            tmp.ShowIcon = false;
            tmp.Text = "模拟考试记录列表";
            tmp.ShowInTaskbar = true;
            tmp.StartPosition = FormStartPosition.CenterScreen;
            ctr.SetUserIdCard(user.IdCard);
            ctr.Dock = DockStyle.Fill;
            tmp.Controls.Add(ctr);
            tmp.ShowDialog();
        }
    }
}