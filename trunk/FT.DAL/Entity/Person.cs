using System;
using System.Collections.Generic;
using System.Text;
using FT.Commons.PrinterEx;
using FT.DAL.Orm;

namespace FT.DAL.Entity
{
    /// <summary>
    /// 抽象人员表
    /// </summary>
    public abstract class Person
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

        [SimpleColumn(Column = "c_birthday")]
        [Alias("出生年月")]
        public String Birthday;

        public String 出生年月
        {
            get { return Birthday; }
            set { Birthday = value; }
        }

        [SimpleColumn(Column = "c_phone")]
        [Alias("固话")]
        public String Phone;

        public String 固话
        {
            get { return Phone; }
            set { Phone = value; }
        }

        [SimpleColumn(Column = "c_mobile")]
        [Alias("手机")]
        public String Mobile;

        public String 手机
        {
            get { return Mobile; }
            set { Mobile = value; }
        }

        [SimpleColumn(Column = "c_idcard")]
        [Alias("身份证明号码")]
        public String IdCard;

        public String 身份证明号码
        {
            get { return IdCard; }
            set { IdCard = value; }
        }

        [SimpleColumn(Column = "c_address")]
        [Alias("住址")]
        public String Address;

        public String 住址
        {
            get { return Address; }
            set { Address = value; }
        }

        [SimpleColumn(Column = "c_dept")]
        [Alias("所属部门")]
        public String Dept;

        public String 所属部门
        {
            get { return Dept; }
            set { Dept = value; }
        }

        [SimpleColumn(Column = "c_employdate")]
        [Alias("入职时间")]
        public String EmployDate;

        public String 入职时间
        {
            get { return EmployDate; }
            set { EmployDate = value; }
        }

        [SimpleColumn(Column = "c_state")]
        [Alias("状态")]
        public String State;

        public String 状态
        {
            get { return State; }
            set { State = value; }
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
