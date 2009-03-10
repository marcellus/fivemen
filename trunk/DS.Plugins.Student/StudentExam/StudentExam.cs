using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Orm;
using FT.DAL.Entity;

namespace DS.Plugins.Student
{
    [SimpleTable("table_student_exam")]
    [Alias("学员考试记录表")]
    public class StudentExam
    {
        [SimplePK]
        public int Id;

        public string 编号
        {
            get { return Id.ToString(); }
        }
        [SimpleColumn(Column = "c_name")]
        [Alias("姓名")]
        public String Name;

        /// <summary>
        /// 供datagridview显示使用
        /// </summary>
        public String 姓名
        {
            get { return Name; }
            set { Name = value; }
        }

        [SimpleColumn(Column = "c_idcard")]
        [Alias("身份证明号码")]
        public String IdCard;

        public String 身份证明号码
        {
            get { return IdCard; }
            set { IdCard = value; }
        }

        [SimpleColumn(Column = "c_new_cartype")]
        [Alias("学习车型")]
        public String NewCarType;

        public String 学习车型
        {
            get { return NewCarType; }
            set { NewCarType = value; }
        }

        [SimpleColumn(Column = "c_examid")]
        [Alias("准考证号")]
        public String ExamId;

        public String 准考证号
        {
            get { return ExamId; }
            set { ExamId = value; }
        }

        [SimpleColumn(Column = "c_allowexamdate")]
        [Alias("准考日期")]
        public String AllowExamDate;

        public String 准考日期
        {
            get { return AllowExamDate; }
            set { AllowExamDate = value; }
        }

        [SimpleColumn(Column = "c_coach")]
        [Alias("教练")]
        public string CoachName;

        public string 教练
        {
            get { return CoachName; }
            set { CoachName = value; }
        }
        [SimpleColumn(Column = "c_examdate")]
        [Alias("考试日期")]
        public string ExamDate;

        public string 考试日期
        {
            get { return ExamDate; }
            set { ExamDate = value; }
        }
        [SimpleColumn(Column = "c_subject")]
        [Alias("考试科目")]
        public string Subject;

        public string 考试科目
        {
            get { return Subject; }
            set { Subject = value; }
        }

        [SimpleColumn(Column = "c_examperson")]
        [Alias("考试员")]
        public string ExamPerson;

        public string 考试员
        {
            get { return ExamPerson; }
            set { ExamPerson = value; }
        }

        [SimpleColumn(Column = "c_score")]
        [Alias("考试成绩")]
        public string Score;

        public string 考试成绩
        {
            get { return Score; }
            set { Score = value; }
        }

        [SimpleColumn(Column = "c_result")]
        [Alias("考试结果")]
        public string Result;

        public string 考试结果
        {
            get { return Result; }
            set { Result = value; }
        }
    }
}
