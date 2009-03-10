using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Orm;
using FT.DAL.Entity;

namespace DS.Plugins.Student
{
    [SimpleTable("table_student_exam")]
    [Alias("ѧԱ���Լ�¼��")]
    public class StudentExam
    {
        [SimplePK]
        public int Id;

        public string ���
        {
            get { return Id.ToString(); }
        }
        [SimpleColumn(Column = "c_name")]
        [Alias("����")]
        public String Name;

        /// <summary>
        /// ��datagridview��ʾʹ��
        /// </summary>
        public String ����
        {
            get { return Name; }
            set { Name = value; }
        }

        [SimpleColumn(Column = "c_idcard")]
        [Alias("���֤������")]
        public String IdCard;

        public String ���֤������
        {
            get { return IdCard; }
            set { IdCard = value; }
        }

        [SimpleColumn(Column = "c_new_cartype")]
        [Alias("ѧϰ����")]
        public String NewCarType;

        public String ѧϰ����
        {
            get { return NewCarType; }
            set { NewCarType = value; }
        }

        [SimpleColumn(Column = "c_examid")]
        [Alias("׼��֤��")]
        public String ExamId;

        public String ׼��֤��
        {
            get { return ExamId; }
            set { ExamId = value; }
        }

        [SimpleColumn(Column = "c_allowexamdate")]
        [Alias("׼������")]
        public String AllowExamDate;

        public String ׼������
        {
            get { return AllowExamDate; }
            set { AllowExamDate = value; }
        }

        [SimpleColumn(Column = "c_coach")]
        [Alias("����")]
        public string CoachName;

        public string ����
        {
            get { return CoachName; }
            set { CoachName = value; }
        }
        [SimpleColumn(Column = "c_examdate")]
        [Alias("��������")]
        public string ExamDate;

        public string ��������
        {
            get { return ExamDate; }
            set { ExamDate = value; }
        }
        [SimpleColumn(Column = "c_subject")]
        [Alias("���Կ�Ŀ")]
        public string Subject;

        public string ���Կ�Ŀ
        {
            get { return Subject; }
            set { Subject = value; }
        }

        [SimpleColumn(Column = "c_examperson")]
        [Alias("����Ա")]
        public string ExamPerson;

        public string ����Ա
        {
            get { return ExamPerson; }
            set { ExamPerson = value; }
        }

        [SimpleColumn(Column = "c_score")]
        [Alias("���Գɼ�")]
        public string Score;

        public string ���Գɼ�
        {
            get { return Score; }
            set { Score = value; }
        }

        [SimpleColumn(Column = "c_result")]
        [Alias("���Խ��")]
        public string Result;

        public string ���Խ��
        {
            get { return Result; }
            set { Result = value; }
        }
    }
}
