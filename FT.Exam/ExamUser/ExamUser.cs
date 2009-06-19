using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Orm;

namespace FT.Exam
{
    [SimpleTable("table_exam_user")]
    [Alias("考生信息")]
    public class ExamUser
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
        /// 考试总次数
        /// </summary>
        [SimpleColumn(Column = "i_all_count")]
        [Alias("考试总次数")]
        public int AllCount;

        public int 考试总次数
        {
            get { return AllCount; }
            set { AllCount = value; }
        }


        /// <summary>
        /// 合格次数
        /// </summary>
        [SimpleColumn(Column = "i_pass_count")]
        [Alias("合格次数")]
        public int PassCount;

        public int 合格次数
        {
            get { return PassCount; }
            set { PassCount = value; }
        }

        /// <summary>
        /// 不合格次数
        /// </summary>
        [SimpleColumn(Column = "i_not_pass_count")]
        [Alias("不合格次数")]
        public int NotPassCount;

        public int 不合格次数
        {
            get { return NotPassCount; }
            set { NotPassCount = value; }
        }



    }
}
