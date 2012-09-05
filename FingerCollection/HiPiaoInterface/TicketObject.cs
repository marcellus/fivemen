using System;
using System.Collections.Generic;
using System.Text;

namespace HiPiaoInterface
{
    [Serializable]
    public class TicketObject
    {
        private string ticketId;

        /// <summary>
        /// 票ID
        /// </summary>
        public string TicketId
        {
            get { return ticketId; }
            set { ticketId = value; }
        }
        private MovieObject movie;

        /// <summary>
        /// 关联电影对象
        /// </summary>
        public MovieObject Movie
        {
            get { return movie; }
            set { movie = value; }
        }
        private string connectMobile;


        private DateTime playTime;

        /// <summary>
        /// 播放时间
        /// </summary>
        public DateTime PlayTime
        {
            get { return playTime; }
            set { playTime = value; }
        }


        private DateTime buyTime;

        /// <summary>
        /// 购买时间
        /// </summary>
        public DateTime BuyTime
        {
            get { return buyTime; }
            set { buyTime = value; }
        }


        private SeatObject seat;
        /// <summary>
        /// 座位
        /// </summary>
        public SeatObject Seat
        {
            get { return seat; }
            set { seat= value; }
        }

        private int price;

        /// <summary>
        /// 票价
        /// </summary>
        public int Price
        {
            get { return price; }
            set { price = value; }
        }

        private bool isPrinted;

        /// <summary>
        /// 是否打印过
        /// </summary>
        public bool IsPrinted
        {
            get { return isPrinted; }
            set { isPrinted = value; }
        }
        
    }
}
