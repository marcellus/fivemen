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
        #region 子类必须实现的
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
                //    this.cbHmhp.DisplayMember = "号码号牌";
                //    this.cbHmhp.ValueMember = "号码号牌";
                //    this.cbHmhp.SelectedIndex = 0;
                //}
                //FT.Windows.CommonsPlugin.DictManager.BindSubject(this.cbSubject);
                SubjectHelper.BindSubject(this.cbSubject);
                
            }
            //this.cbSex.SelectedIndex = 0;
        }

        /// <summary>
        /// 关联实体的类别,该实体必须有一个Id的属性
        /// </summary>
        /// <returns>实体类别</returns>
        protected override object GetEntity()
        {
            return new StudentExam();
            //   return null;
        }
        #endregion

        private ArrayList students = new ArrayList();

        private void BindIdCard(string id)
        {
            this.students = FT.DAL.Orm.SimpleOrmOperator.QueryConditionList<StudentInfo>(" where c_idcard like '%"+id+"%'");

            this.cbIdCard.ValueMember = "身份证明号码";
            this.cbIdCard.DisplayMember = "身份证明号码";
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
                    
                    //int count = FT.DAL.Orm.SimpleOrmOperator.QueryCounts(typeof(StudentExam), " where c_idcard='" + student.IdCard + "'");
                    if (student.State == "初始报名")
                    {
                    }
                    else if (student.State == "合格结业")
                    {
                        MessageBoxHelper.Show("该学生已经毕业，请选择别的学生！");
                        return;
                    }
                    else if (student.State == "退学")
                    {
                        MessageBoxHelper.Show("该学生已经退学，请选择别的学生！");
                        return;
                    }
                    else if(student.State.IndexOf("科目三")==-1)
                    {
                        int index = student.State.IndexOf("合格");
                        if (index != -1)
                        {
                            this.cbSubject.Text = student.State.Substring(0, index);
                            this.cbSubject.SelectedIndex += 1;
                        }
                    }
                    
                }
            }
        }

        private void txtScore_Validating(object sender, CancelEventArgs e)
        {
            this.ValidateNumber(sender, e, "考试成绩必须是数字！", false);
        }

        protected override void AfterSuccessCreate()
        {
            if (this.cbResult.Text == "合格")
            {
                if (this.cbSubject.SelectedIndex != this.cbSubject.Items.Count - 1)
                {
                    FT.DAL.DataAccessFactory.GetDataAccess().ExecuteSql("update table_students set c_state='" + this.cbSubject.Text + "合格' where c_idcard='"+this.cbIdCard.Text+"'");
                }
                else
                {
                    FT.DAL.DataAccessFactory.GetDataAccess().ExecuteSql("update table_students set c_state='合格结业' and date_graduation='"+System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+"' where c_idcard='" + this.cbIdCard.Text + "'");
                }
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
                if (student.State == "合格结业")
                {
                    MessageBoxHelper.Show("该学生已经毕业，请选择别的学生！");
                    result = false;
                }
                else if (student.State == "退学")
                {
                    MessageBoxHelper.Show("该学生已经退学，请选择别的学生！");
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

