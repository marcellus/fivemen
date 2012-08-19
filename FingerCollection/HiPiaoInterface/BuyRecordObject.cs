using System;
using System.Collections.Generic;
using System.Text;

namespace HiPiaoInterface
{
    [Serializable]
    public class BuyRecordObject
    {
        private UserObject user;

        /// <summary>
        /// 关联用户对象
        /// </summary>
        public UserObject User
        {
            get { return user; }
            set { user = value; }
        }

        public int TotalPrice
        {
            get
            {
                int result=0;
                for (int i = 0; i < tickets.Count; i++)
                {
                    result+=tickets[i].Price;
                }
                return result;
            }
        }

        private string connectMobile;


        /// <summary>
        /// 取票联系电话
        /// </summary>
        public string ConnectMobile
        {
            get { return connectMobile; }
            set { connectMobile = value; }
        }
        private string validCode;

        /// <summary>
        /// 取票验证码
        /// </summary>
        public string ValidCode
        {
            get { return validCode; }
            set { validCode = value; }
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



        private List<TicketObject> tickets = new List<TicketObject>();

        /// <summary>
        /// 购买的票
        /// </summary>
        public List<TicketObject> Tickets
        {
            get { return tickets; }
            set { tickets = value; }
        }
    }
}
