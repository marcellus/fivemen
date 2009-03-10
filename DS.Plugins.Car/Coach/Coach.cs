using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Orm;
using FT.DAL.Entity;

namespace DS.Plugins.Car
{
    [SimpleTable("table_coach")]
    [Alias("教练信息表")]
    public class Coach : Person
    {
        [SimpleColumn(Column = "c_hmhp")]
        [Alias("号码号牌")]
        public string Hmhp;//号码好牌

        public string 号码号牌
        {
            get { return Hmhp; }
            set { Hmhp = value; }
        }

        [SimpleColumn(Column = "c_coachid")]
        [Alias("教练证号")]
        public string CoachId;//教练证号

        public string 教练证号
        {
            get { return CoachId; }
            set { CoachId = value; }
        }

        [SimpleColumn(Column = "c_driverid")]
        [Alias("驾驶证编号")]
        public string DriverId;//驾驶证编号

        public string 驾驶证编号
        {
            get { return DriverId; }
            set { DriverId = value; }
        }

        [SimpleColumn(Column = "c_cartype")]
        [Alias("准教车型")]
        public string CarType;//教练证号

        public string 准教车型
        {
            get { return CarType; }
            set { CarType = value; }
        }


    }
}
