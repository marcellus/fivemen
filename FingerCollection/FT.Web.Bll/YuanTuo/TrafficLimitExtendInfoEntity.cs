using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Orm;

namespace FT.Web.Bll.YuanTuo
{
    [SimpleTable("common_traffic_limitinfo_extend")]
    [Alias("交通限行扩展信息")]
    [Serializable]
    public class TrafficLimitExtendInfoEntity
    {

        [SimplePK]
        public int Id;

        [SimpleColumn(Column = "startdate")]
        [Alias("限行开始时间")]
        public DateTime StartDate;

        [SimpleColumn(Column = "enddate")]
        [Alias("限行结束时间")]
        public DateTime EndDate;


        [SimpleColumn(Column = "citycode")]
        [Alias("城市")]
        public string CityCode;

        [SimpleColumn(Column = "limitcontent")]
        [Alias("限行内容")]
        public string LimitContent;
    }
}
