using System;
using System.Collections.Generic;
using System.Text;

namespace HiPiaoInterface
{
    /// <summary>
    /// 优惠券信息
    /// </summary>
    [Serializable]
    public  class CouponObject
    {

        private string name;

        /// <summary>
        /// 优惠券名称
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int type;

        /// <summary>
        /// 1.电影兑换券 2.小卖兑换券
        /// </summary>
        public int Type
        {
            get { return type; }
            set { type = value; }
        }

        private bool weekEnd;

        /// <summary>
        /// 周末节假日 1.可以使用 0.不可以使用
        /// </summary>
        public bool WeekEnd
        {
            get { return weekEnd; }
            set { weekEnd = value; }
        }

        private bool enable3D;

        /// <summary>
        /// 3D:3D影片 1.可购3D  0.不可购3D
        /// </summary>
        public bool Enable3D
        {
            get { return enable3D; }
            set { enable3D = value; }
        }


        private string cardId;

        /// <summary>
        /// 兑换券卡号
        /// </summary>
        public string CardId
        {
            get { return cardId; }
            set { cardId = value; }
        }

        private string useCinema;

        /// <summary>
        /// 可使用影院,多个影院用","分割
        /// </summary>
        public string UseCinema
        {
            get { return useCinema; }
            set { useCinema = value; }
        }

        private string everyDayTime;

        /// <summary>
        /// 每日有效时间
        /// </summary>
        public string EveryDayTime
        {
            get { return everyDayTime; }
            set { everyDayTime = value; }
        }

        

        private string period;

        /// <summary>
        /// 有效期
        /// </summary>
        public string Period
        {
            get { return period; }
            set { period = value; }
        }


        private string fileRule;

        /// <summary>
        /// 影片规则
        /// </summary>
        public string FileRule
        {
            get { return fileRule; }
            set { fileRule = value; }
        }

        private string useDate;

        /// <summary>
        /// 使用日期
        /// </summary>
        public string UseDate
        {
            get { return useDate; }
            set { useDate = value; }
        }


        private int status;

        /// <summary>
        /// '0创建1激活2已提取3已使用
        /// </summary>
        public int Status
        {
            get { return status; }
            set { status = value; }
        }
    }
}
