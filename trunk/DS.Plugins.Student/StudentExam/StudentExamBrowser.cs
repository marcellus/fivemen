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
            this.InitComBox();
           
        }
        public StudentExamBrowser(object entity, IRefreshParent refresher)
            : base(entity, refresher)
        {
            InitializeComponent();
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
                FT.Windows.CommonsPlugin.DictManager.BindSubject(this.cbSubject);
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
                }
            }
        }

        private void txtScore_Validating(object sender, CancelEventArgs e)
        {
            this.ValidateNumber(sender, e, "考试成绩必须是数字！", false);
        }
    }
}

