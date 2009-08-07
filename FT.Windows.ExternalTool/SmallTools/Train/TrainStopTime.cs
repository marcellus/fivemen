using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Orm;

namespace FT.Windows.ExternalTool
{
    [SimpleTable("table_train_stoptime")]
    [Alias("火车停站信息")]
    public class TrainStopTime
    {
        [SimplePK]
        public int Id;

        public string 编号
        {
            get { return Id.ToString(); }
        }

        [SimpleColumn(Column = "station_no")]
        [Alias("序号")]
        public string StationNo;

        public string 序号
        {
            get { return StationNo; }
            set { StationNo = value; }
        }

        [SimpleColumn(Column = "station_name")]
        [Alias("站名")]
        public string StationName;

        public string 站名
        {
            get { return StationName; }
            set { StationName = value; }
        }

        [SimpleColumn(Column = "arrive_time")]
        [Alias("到时")]
        public string ArriveTime;

        public string 到时
        {
            get { return ArriveTime; }
            set { ArriveTime = value; }
        }

        [SimpleColumn(Column = "start_time")]
        [Alias("发时")]
        public string StartTime;

        public string 发时
        {
            get { return StartTime; }
            set { StartTime = value; }
        }

        [SimpleColumn(Column = "distance")]
        [Alias("里程")]
        public string Distance;

        public string 里程
        {
            get { return Distance; }
            set { Distance = value; }
        }

        [SimpleColumn(Column = "day_difference")]
        [Alias("天数")]
        public string Days;

        public string 天数
        {
            get { return Days; }
            set { Days = value; }
        }
    }
}
