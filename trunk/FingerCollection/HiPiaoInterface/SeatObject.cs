using System;
using System.Collections.Generic;
using System.Text;

namespace HiPiaoInterface
{
    [Serializable]
    public class SeatObject
    {
        private string lockState;

        public string LockState
        {
            get { return lockState; }
            set { lockState = value; }
        }
        private string seatId;

        public string SeatId
        {
            get { return seatId; }
            set { seatId = value; }
        }
        private int xPoint;

        public int XPoint
        {
            get { return xPoint; }
            set { xPoint = value; }
        }

        private int yPoint;

        public int YPoint
        {
            get { return yPoint; }
            set { yPoint = value; }
        }

        private RoomObject room;

        /// <summary>
        /// 第几号厅
        /// </summary>
        public RoomObject Room
        {
            get { return room; }
            set { room= value; }
        }

        private int rowNum;

        /// <summary>
        /// 第几排
        /// </summary>
        public int RowNum
        {
            get { return rowNum; }
            set { rowNum = value; }
        }
        private int seatNo;

        /// <summary>
        /// 座位号
        /// </summary>
        public int SeatNo
        {
            get { return seatNo; }
            set { seatNo = value; }
        }
    }
}
