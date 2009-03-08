using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Orm;
using FT.DAL.Entity;

namespace DS.Plugins.Student
{
    [SimpleTable("table_student_exam")]
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

        [SimpleColumn(Column = "c_sex")]
        [Alias("性别")]
        public String Sex;

        public String 性别
        {
            get { return Sex; }
            set { Sex = value; }
        }

        [SimpleColumn(Column = "c_idcard")]
        [Alias("身份证号")]
        public String IdCard;

        public String 身份证号
        {
            get { return IdCard; }
            set { IdCard = value; }
        }
    }
}
