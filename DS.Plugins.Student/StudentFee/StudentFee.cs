using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Orm;
using FT.DAL.Entity;

namespace DS.Plugins.Student
{
    /// <summary>
    /// 学员缴费信息
    /// </summary>
    [SimpleTable("table_student_fee")] 
    [Alias("学员缴费信息表")]
    public class StudentFee
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

        [SimpleColumn(Column = "date_fee")]
        [Alias("费用时间")]
        public string FeeDate;

        public string 费用时间
        {
            get { return FeeDate; }
            set { FeeDate = value; }
        }

        [SimpleColumn(Column = "i_fee")]
        [Alias("费用金额")]
        public string Fee;

        public string 费用金额
        {
            get { return Fee; }
            set { Fee = value; }
        }

        [SimpleColumn(Column = "c_feetype")]
        [Alias("费用类别")]
        public string FeeType;

        public string 费用类别
        {
            get { return FeeType; }
            set { FeeType = value; }
        }

        [SimpleColumn(Column = "c_description")]
        [Alias("备注")]
        public String Description;

        public String 备注
        {
            get { return Description; }
            set { Description = value; }
        }
    }
}
