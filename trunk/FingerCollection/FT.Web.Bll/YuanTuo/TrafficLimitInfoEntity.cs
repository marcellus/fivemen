using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Orm;

namespace FT.Web.Bll.YuanTuo
{
    [SimpleTable("common_traffic_limitinfo")]
    [Alias("交通限行信息")]
    [Serializable]
    public class TrafficLimitInfoEntity
    {

        [SimplePK]
        public int Id;

        public int 编号
        {
            get { return Id; }
            set { Id = value; }
        }

        [SimpleColumn(Column = "citycode")]
        [Alias("城市")]
        public string CityCode;


        [SimpleColumn(Column = "weekday")]
        [Alias("星期几")]
        public int Weekday;


        [SimpleColumn(Column = "limitcontent")]
        [Alias("限行内容")]
        public string LimitContent;


    }
}
