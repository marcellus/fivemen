using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Orm;

namespace FT.Windows.ExternalTool
{
    [SimpleTable("table_train_stoptime")]
    [Alias("��ͣվ��Ϣ")]
    public class TrainStopTime
    {
        [SimplePK]
        public int Id;

        public string ���
        {
            get { return Id.ToString(); }
        }

        [SimpleColumn(Column = "station_no")]
        [Alias("���")]
        public string StationNo;

        public string ���
        {
            get { return StationNo; }
            set { StationNo = value; }
        }

        [SimpleColumn(Column = "station_name")]
        [Alias("վ��")]
        public string StationName;

        public string վ��
        {
            get { return StationName; }
            set { StationName = value; }
        }

        [SimpleColumn(Column = "arrive_time")]
        [Alias("��ʱ")]
        public string ArriveTime;

        public string ��ʱ
        {
            get { return ArriveTime; }
            set { ArriveTime = value; }
        }

        [SimpleColumn(Column = "start_time")]
        [Alias("��ʱ")]
        public string StartTime;

        public string ��ʱ
        {
            get { return StartTime; }
            set { StartTime = value; }
        }

        [SimpleColumn(Column = "distance")]
        [Alias("���")]
        public string Distance;

        public string ���
        {
            get { return Distance; }
            set { Distance = value; }
        }

        [SimpleColumn(Column = "day_difference")]
        [Alias("����")]
        public string Days;

        public string ����
        {
            get { return Days; }
            set { Days = value; }
        }
    }
}
