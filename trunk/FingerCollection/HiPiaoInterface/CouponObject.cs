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
        /// 1指代兑换券，2指代抵换券
        /// </summary>
        public int Type
        {
            get { return type; }
            set { type = value; }
        }
    }
}
