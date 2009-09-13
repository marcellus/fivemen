using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Commons.Tools;
using FT.Windows.Forms;
using System.Collections;

namespace DS.Plugins.Student
{
    public partial class StudentExamBrowser : FT.Windows.Forms.DataBrowseForm
    {
        public StudentExamBrowser()
        {
            InitializeComponent();
            this.InitComBox();
        }

        private String subject = string.Empty;
        public StudentExamBrowser(String subject)
        {
            InitializeComponent();
            this.subject = subject;
            
            this.InitComBox();
            this.cbSubject.Text = subject;
        }
        #region �������ʵ�ֵ�
        public StudentExamBrowser(object entity):base(entity)
        {
            InitializeComponent();
           // this.students.Add(entity);
            this.InitComBox();
           
        }
        public StudentExamBrowser(object entity, IRefreshParent refresher)
            : base(entity, refresher)
        {
            InitializeComponent();
            //this.students.Add(entity);
            this.InitComBox();
        }

        private void InitComBox()
        {
            if (!this.DesignMode)
            {
                this.cbResult.SelectedIndex = 0;
                //ArrayList lists = FT.DAL.Orm.SimpleOrmOperator.QueryListAll(typeof(CarInfo));
                //if (lists.Count > 0)
                //{
                //    //this.cbGroup
                //    this.cbHmhp.DataSource = lists;
                //    this.cbHmhp.DisplayMember = "�������";
                //    this.cbHmhp.ValueMember = "�������";
                //    this.cbHmhp.SelectedIndex = 0;
                //}
                //FT.Windows.CommonsPlugin.DictManager.BindSubject(this.cbSubject);
                SubjectHelper.BindSubject(this.cbSubject);
                
            }
            //this.cbSex.SelectedIndex = 0;
        }

        /// <summary>
        /// ����ʵ������,��ʵ�������һ��Id������
        /// </summary>
        /// <returns>ʵ�����</returns>
        protected override object GetEntity()
        {
            return new StudentExam();
            //   return null;
        }
        #endregion

        private ArrayList students = new ArrayList();

        private void BindIdCard(string id)
        {
            this.students = FT.DAL.Orm.SimpleOrmOperator.QueryConditionList<StudentInfo>(" where c_idcard like '%"+id+"%' and c_state<>'��ѧ' and c_state<>'�ϸ��ҵ'");

            this.cbIdCard.ValueMember = "����֤������";
            this.cbIdCard.DisplayMember = "����֤������";
            this.cbIdCard.DataSource = students;
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void SearchStudent()
        {
            string id = this.textBox1.Text.Trim();
            if (id.Length > 6)
            {
                this.BindIdCard(id);
            }
        }

        private void cbIdCard_TextChanged(object sender, EventArgs e)
        {
            if (this.cbIdCard.SelectedValue != null)
            {
                int i = this.cbIdCard.SelectedIndex;
                
                StudentInfo student=this.students[i] as StudentInfo;
                if (student != null)
                {
                    this.txtCoachName.Text = student.CoachName;
                    this.txtAllowExamDate.Text = student.ExamDate;
                    this.txtExamId.Text = student.ExamId;
                    this.txtName.Text = student.Name;
                    this.txtNewCarType.Text = student.NewCarType;
                    this.lbStudentId.Text = student.Id.ToString();
                    
                    //int count = FT.DAL.Orm.SimpleOrmOperator.QueryCounts(typeof(StudentExam), " where c_idcard='" + student.IdCard + "'");
                    if (student.State == "��ʼ����")
                    {
                    }
                    else if (student.State == "�ϸ��ҵ")
                    {
                        MessageBoxHelper.Show("��ѧ���Ѿ���ҵ����ѡ����ѧ����");
                        return;
                    }
                    else if (student.State == "��ѧ")
                    {
                        MessageBoxHelper.Show("��ѧ���Ѿ���ѧ����ѡ����ѧ����");
                        return;
                    }
                    else if(student.State.IndexOf("��Ŀ��")==-1)
                    {
                        int index = student.State.IndexOf("�ϸ�");
                        this.cbSubject.Text = student.State.Substring(0, index);
                        if (index != -1)
                        {
                            this.cbSubject.SelectedIndex += 1;
                        }
                        else//���ϸ��ʱ����������1
                        {
                        }
                    }
                    
                }
            }
        }

        private void txtScore_Validating(object sender, CancelEventArgs e)
        {
            this.ValidateNumber(sender, e, "���Գɼ����������֣�", false);
        }

        protected override void AfterSuccessCreate()
        {
            string date = this.dateExamDate.Value.ToString("yyyy-MM-dd");
            if (this.cbSubject.SelectedIndex != this.cbSubject.Items.Count - 1)
                {
                    FT.DAL.DataAccessFactory.GetDataAccess().ExecuteSql("update table_students set date_lastexam='"+
                        date+"', c_state='" + this.cbSubject.Text +
                        this.cbResult.Text + "' where id=" + this.lbStudentId.Text + " and " +
                        " c_state<>'��ѧ' and c_state<>'�ϸ��ҵ'"+"");
                }
                else
                {
                    FT.DAL.DataAccessFactory.GetDataAccess().ExecuteSql("update table_students set c_state='�ϸ��ҵ', date_lastexam='"+date+"' and date_graduation='" + date + "' where id=" + this.lbStudentId.Text + " and  c_state<>'��ҵ' and c_state<>'�ϸ��ҵ'");
                }
           
            //base.AfterSuccessCreate();
        }

        protected override bool CheckBeforeCreate()
        {
            bool result = true;
            int i = this.cbIdCard.SelectedIndex;
            if (this.students.Count == 0)
            {
                this.students = FT.DAL.Orm.SimpleOrmOperator.QueryConditionList<StudentInfo>(" where c_idcard = '" + this.cbIdCard.Text + "'");
            }
            if (i == -1)
            {
                i = 0;
            }
            StudentInfo student = this.students[i] as StudentInfo;
            if (student != null)
            {
                if (student.State == "�ϸ��ҵ")
                {
                    MessageBoxHelper.Show("��ѧ���Ѿ���ҵ����ѡ����ѧ����");
                    result = false;
                }
                else if (student.State == "��ѧ")
                {
                    MessageBoxHelper.Show("��ѧ���Ѿ���ѧ����ѡ����ѧ����");
                    result = false;
                }
               

            }
            return result;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SearchStudent();
            }
        }

        
    }
}
