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
using FT.Commons.Cache;
using FT.Windows.CommonsPlugin;

namespace FT.Exam
{
    public partial class UserLoginFirstForm : Form
    {
        public UserLoginFirstForm()
        {
            InitializeComponent();
            DictManager.BindCarType(this.cbLearnCar);
            this.cbLearnCar.Text = "C1";
        }

        private void UserLoginFirstForm_Load(object sender, EventArgs e)
        {
            this.Text =  Application.ProductName +"("+ Application.ProductVersion+")";
            this.lbAllCount.Text = "��⹲��"
            +FT.DAL.Orm.SimpleOrmOperator.QueryCounts(typeof(ExamTopic), "").ToString()+"��";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string learncar = this.cbLearnCar.Text.Trim().ToUpper();
            if(learncar.Length==0)
            {
                MessageBoxHelper.Show("�Բ��𣬱�����������ļ����ͺţ�");
                return;

            }
            ArrayList list = SimpleOrmOperator.QueryConditionList<ExamUser>(" where c_idcard='"+DALSecurityTool.TransferInsertField(this.txtIdCard.Text.Trim())+"'");
            if(list==null||list.Count==0)
            {

                MessageBoxHelper.Show("�Բ��𣬲����ڸ�ѧԱ������ѯ����Ա��");
                return;
            }
            else
            {
                ExamUser user=list[0] as ExamUser; 
                ExamPolicy policy=StaticCacheManager.GetConfig<ExamPolicy>();
                if (this.checkExam.Checked&&policy.IsLimit && user.PassCount >= policy.SuccessTimes)
                {
                    MessageBoxHelper.Show("�Բ������Ѿ��ϸ���"+user.PassCount.ToString()+"�Σ��޷��ٴν��п���!");
                    return;
                }
                
                // �ж��Ƿ��Ժϸ�������������õĿ��Ժϸ��������
                ArrayList topics = this.GetRandomTopic(learncar);
                //this.Hide();
                ExamWorkStation form = new ExamWorkStation(topics,user,this.checkTrain.Checked);
                form.ShowDialog();
                
            }
            
        }

        public ArrayList GetRandomTopic(string learncar)
        {
             ArrayList topics=null;
            if(this.checkExam.Checked)
            {
                Random d = new Random();
                int tmpint = Convert.ToInt32(d.NextDouble() * 1000) + 1;
                
                ///TODO:�������
                string sql = "select * from (select top 40 * from table_exam_topic "
                   + "where c_topictype='1' and c_range like '%" +
                    FT.DAL.DALSecurityTool.TransferInsertField(learncar) + "%'" + " order by rnd(-1*"+tmpint+"*id)) order by id asc ";
                topics = FT.DAL.Orm.SimpleOrmOperator.QueryList(typeof(ExamTopic), sql);

                sql = "select * from (select top 60 * from table_exam_topic "
                  + "where c_topictype='2' and c_range like '%" +
                   FT.DAL.DALSecurityTool.TransferInsertField(learncar) + "%'" + " order by rnd(-1*" + tmpint + "*id)) order by id asc ";
                ArrayList topicstmp = FT.DAL.Orm.SimpleOrmOperator.QueryList(typeof(ExamTopic), sql);
                if(topicstmp!=null&&topicstmp.Count>0)
                {
                    for(int i=0;i<topicstmp.Count;i++)
                    {
                        topics.Add(topicstmp[i]);
                    }
                }
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
                        + "where c_range like '%" +
                    FT.DAL.DALSecurityTool.TransferInsertField(learncar) + "%'" 
                    + " order by id asc) order by id desc";
                    topics = FT.DAL.Orm.SimpleOrmOperator.QueryList(typeof(ExamTopic), sql);
                }
                catch (System.Exception e)
                {
                    MessageBoxHelper.Show("�Բ�����Ŀ��������������");
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

                MessageBox.Show("�Բ��𣬲����ڸ�ѧԱ������ѯ����Ա��");
            }
            else
            {

                ExamLogSearch ctr = new ExamLogSearch();
                Form tmp = new Form();
                tmp.WindowState = FormWindowState.Maximized;
                    tmp.ShowIcon = false;
                    tmp.Text = "ģ�⿼�Լ�¼�б�";
                    tmp.ShowInTaskbar = true;
                    tmp.StartPosition = FormStartPosition.CenterScreen;
                   ctr.SetUserIdCard(this.txtIdCard.Text.Trim());
                    ctr.Dock = DockStyle.Fill;
                    tmp.Controls.Add(ctr);
                    tmp.ShowDialog();
            }
        }

        private void cbLearnCar_TextChanged(object sender, EventArgs e)
        {
            string learncar = this.cbLearnCar.Text.Trim().ToUpper();
            this.lbAllCount.Text = "��⹲��"
            + FT.DAL.Orm.SimpleOrmOperator.QueryCounts(typeof(ExamTopic), " where c_range like '%"+
             FT.DAL.DALSecurityTool.TransferInsertField(learncar) + "%' ").ToString() + "��";
        }
    }
}