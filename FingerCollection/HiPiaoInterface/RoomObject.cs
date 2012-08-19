using System;
using System.Collections.Generic;
using System.Text;

namespace HiPiaoInterface
{
    /// <summary>
    ///   影厅信息
    /// </summary>
    [Serializable]
    public class RoomObject
    {
        private CinemaObject cinema;

        /// <summary>
        /// 房间名
        /// </summary>
        public CinemaObject Cinema
        {
            get { return cinema; }
            set { cinema = value; }
        }

        private string name;
        /// <summary>
        /// 影厅名称
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private List<SeatObject> seats = new List<SeatObject>();

        /// <summary>
        /// 影厅的座位数
        /// </summary>
        public List<SeatObject> Seats
        {
            get { return seats; }
            set { seats = value; }
        }
    }
}
