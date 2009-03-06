using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Entity;
using FT.DAL.Orm;


namespace DS.Plugins.Car
{
    [SimpleTable("table_car_fee")]
    public class CarFee
    {
        [SimplePK]
        public int Id;

        public int 编号
        {
            get { return Id; }
            set { Id = value; }
        }

        [SimpleColumn(Column = "c_hmhp")]
        [Alias("号码号牌")]
        public string Hmhp;//号码好牌

        public string 号码号牌
        {
            get { return Hmhp; }
            set { Hmhp = value; }
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
