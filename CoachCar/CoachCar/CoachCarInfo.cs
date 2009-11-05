using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Entity;
using FT.DAL.Orm;

namespace CoachCar
{
    [SimpleTable("table_coach_cars")]
    [Alias("珠海市各培训单位教练车/员入场登记表")]
    public class CoachCarInfo
    {
        [SimplePK]
        public int Id;

        public int 编号
        {
            get { return Id; }
            set { Id = value; }
        }


        [SimpleColumn(Column = "c_company")]
        [Alias("单位")]
        public string Company;

        public string 单位
        {
            get { return Company; }
            set { Company = value; }
        }
        [SimpleColumn(Column = "c_cjh")]
        [Alias("车架号")]
        public string Cjh;

        public string 车架号
        {
            get { return Cjh; }
            set { Cjh = value; }
        }

        [SimpleColumn(Column = "date_reg")]
        [Alias("入场日期")]
        public String RegDate;

        public String 入场日期
        {
            get { return RegDate; }
            set { RegDate = value; }
        }

        [SimpleColumn(Column = "c_idcard")]
        [Alias("身份证号")]
        public string IdCard;

        public string 身份证号
        {
            get { return IdCard; }
            set { IdCard = value; }
        }

        [SimpleColumn(Column = "c_coach_id")]
        [Alias("教练证号")]
        public string CoachId;

        public string 教练证号
        {
            get { return CoachId; }
            set { CoachId = value; }
        }

        [SimpleColumn(Column = "c_coach_name")]
        [Alias("姓名")]
        public string CoachName;

        public string 姓名
        {
            get { return CoachName; }
            set { CoachName = value; }
        }

        [SimpleColumn(Column = "c_car_no")]
        [Alias("教练车号")]
        public string CarNo;

        public string 教练车号
        {
            get { return CarNo; }
            set { CarNo = value; }
        }

        [SimpleColumn(Column = "c_description")]
        [Alias("备注")]
        public string Description;

        public string 备注
        {
            get { return Description; }
            set { Description = value; }
        }

        [SimpleColumn(Column = "c_keyWords")]
        [Alias("关键字")]
        public string KeyWords;

        public string 关键字
        {
            get { return KeyWords; }
            set { KeyWords = value; }
        }
    }
}
