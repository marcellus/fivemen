using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Entity;
using FT.DAL.Orm;

namespace DS.Plugins.Car
{
    [SimpleTable("table_car_out")]
    [Alias("车辆出车记录表")]
    public class CarOut
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

        [SimpleColumn(Column = "date_out")]
        [Alias("出车时间")]
        public string OutDate;

        public string 出车时间
        {
            get { return OutDate; }
            set { OutDate = value; }
        }

        [SimpleColumn(Column = "c_reason")]
        [Alias("出车原因")]
        public string Reason;

        public string 出车原因
        {
            get { return Reason; }
            set { Reason = value; }
        }
    
    }
}
