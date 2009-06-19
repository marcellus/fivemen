using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Orm;

namespace FT.Exam
{
    [SimpleTable("table_exam_log")]
    [Alias("模拟考试记录")]
    public class ExamLog
    {
        [SimplePK]
        [Alias("编号")]
        public int Id;

        public string 编号
        {
            get { return Id.ToString(); }

        }

        /// <summary>
        /// 身份证明号码
        /// </summary>
        [SimpleColumn(Column = "c_idcard")]
        [Alias("身份证明号码")]
        public string IdCard;

        public string 身份证明号码
        {
            get { return IdCard; }
            set { IdCard = value; }
        }

        /// <summary>
        /// 姓名
        /// </summary>
        [SimpleColumn(Column = "c_name")]
        [Alias("姓名")]
        public string Name;

        public string 姓名
        {
            get { return Name; }
            set { Name = value; }
        }

        /// <summary>
        /// 考试时间
        /// </summary>
        [SimpleColumn(Column = "c_exam_date")]
        [Alias("考试时间")]
        public string ExamDate;

        public string 考试时间
        {
            get { return ExamDate; }
            set { ExamDate = value; }
        }


        /// <summary>
        /// 考试成绩
        /// </summary>
        [SimpleColumn(Column = "i_score")]
        [Alias("考试成绩")]
        public int Score;

        public int 考试成绩
        {
            get { return Score; }
            set { Score = value; }
        }

        



    }
}
