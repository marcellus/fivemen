using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.DAL.Orm;
using FT.DAL;
using System.Collections;
using FT.Commons.Tools;

namespace FT.Exam
{
    public partial class UserLoginFirstForm : Form
    {
        public UserLoginFirstForm()
        {
            InitializeComponent();
        }

        private void UserLoginFirstForm_Load(object sender, EventArgs e)
        {
            this.Text =  Application.ProductName +"("+ Application.ProductVersion+")";
            this.lbAllCount.Text = "题库共有"
            +FT.DAL.Orm.SimpleOrmOperator.QueryCounts(typeof(ExamTopic), "").ToString()+"题";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ArrayList list = SimpleOrmOperator.QueryConditionList<ExamUser>(" where c_idcard='"+DALSecurityTool.TransferInsertField(this.txtIdCard.Text.Trim())+"'");
            if(list==null||list.Count==0)
            {

                MessageBox.Show("对不起，不存在该学员，请咨询管理员！");
            }
            else
            {
                // 判断是否考试合格次数超过了配置的考试合格次数限制
                ArrayList topics= this.GetRandomTopic();
                this.Hide();
                ExamWorkStation form = new ExamWorkStation(topics,list[0] as ExamUser,this.checkTrain.Checked);
                form.ShowDialog();
                
            }
            
        }

        public ArrayList GetRandomTopic()
        {
             ArrayList topics=null;
            if(this.checkExam.Checked)
            {
                ///TODO:随机抽题
                string sql = "select top 100 * from table_exam_topic "
                    + " order by id asc";
                topics = FT.DAL.Orm.SimpleOrmOperator.QueryList(typeof(ExamTopic), sql);
            }
            else
            {
                try
                {
                    int from = Convert.ToInt32(this.txtFrom.Text.Trim());
                    if (from > 1)
                    {
                        from--;
                    }
                    else{
                        from = 1;
                    }
                    int count = Convert.ToInt32(this.txtEndNum.Text.Trim());
                    int all = from + count;
                    string sql = "select top " + count + " * from ( select top " + all + " * from table_exam_topic "
                        + " order by id asc) order by id desc";
                    topics = FT.DAL.Orm.SimpleOrmOperator.QueryList(typeof(ExamTopic), sql);
                }
                catch (System.Exception e)
                {
                    MessageBoxHelper.Show("对不起，题目数必须是整数！");
                }
                

            }
            return topics;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void checkTrain_CheckedChanged(object sender, EventArgs e)
        {
            this.checkExam.Checked = !this.checkTrain.Checked;
            this.ChangeCheck();
        }

        private void ChangeCheck()
        {
            bool check=this.checkTrain.Checked;
            this.lbTrain1.Visible = check;
            this.lbTrain2.Visible = check;
            this.lbTrain3.Visible = check;
            this.txtFrom.Visible = check;
            this.txtEndNum.Visible = check;
            this.lbAllCount.Visible = check;
        }

        private void checkExam_CheckedChanged(object sender, EventArgs e)
        {
            this.checkTrain.Checked = !this.checkExam.Checked;
            this.ChangeCheck();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ArrayList list = SimpleOrmOperator.QueryConditionList<ExamUser>(" where c_idcard='" + DALSecurityTool.TransferInsertField(this.txtIdCard.Text.Trim()) + "'");
            if (list == null || list.Count == 0)
            {

                MessageBox.Show("对不起，不存在该学员，请咨询管理员！");
            }
            else
            {

                ExamLogSearch ctr = new ExamLogSearch();
                Form tmp = new Form();
                tmp.WindowState = FormWindowState.Maximized;
                    tmp.ShowIcon = false;
                    tmp.Text = "模拟考试记录列表";
                    tmp.ShowInTaskbar = true;
                    tmp.StartPosition = FormStartPosition.CenterScreen;
                   ctr.SetUserIdCard(this.txtIdCard.Text.Trim());
                    ctr.Dock = DockStyle.Fill;
                    tmp.Controls.Add(ctr);
                    tmp.ShowDialog();
            }
        }
    }
}