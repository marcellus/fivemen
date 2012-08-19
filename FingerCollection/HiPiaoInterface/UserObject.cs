using System;
using System.Collections.Generic;
using System.Text;

namespace HiPiaoInterface
{
    [Serializable]
    public class UserObject
    {
        private string name;

        /// <summary>
        /// 用户名称
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string pwd;

        /// <summary>
        /// 用户密码
        /// </summary>
        public string Pwd
        {
            get { return pwd; }
            set { pwd = value; }
        }

        private string mobile;

        /// <summary>
        /// 用户手机号码
        /// </summary>
        public string Mobile
        {
            get { return mobile; }
            set { mobile = value; }
        }

        private int balance;

        /// <summary>
        /// 账户余额
        /// </summary>
        public int Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        private int rewardPoints;

        /// <summary>
        /// 账户积分
        /// </summary>
        public int RewardPoints
        {
            get { return rewardPoints; }
            set { rewardPoints = value; }
        }

        private string email;

        /// <summary>
        /// 邮箱地址
        /// </summary>
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private List<CouponObject> coupons=new List<CouponObject>();

        public int OneTypeCouponNum
        {
            get
            {
                int result = 0;
                for (int i = 0; i < coupons.Count; i++)
                {
                    if (coupons[i].Type == 1)
                    {
                        result++;
                    }
                }
                return result;
            }
        }

        public int TwoTypeCouponNum
        {
            get
            {
                int result = 0;
                for (int i = 0; i < coupons.Count; i++)
                {
                    if (coupons[i].Type == 2)
                    {
                        result++;
                    }
                }
                return result;
            }
        }

        /// <summary>
        /// 优惠券数量
        /// </summary>
        public List<CouponObject> Coupons
        {
            get { return coupons; }
            set { coupons = value; }
        }

        private List<BuyRecordObject> buyRecords=new List<BuyRecordObject>();

        /// <summary>
        /// 购买记录数
        /// </summary>
        public List<BuyRecordObject> BuyRecords
        {
            get { return buyRecords; }
            set { buyRecords = value; }
        }
        
    }
}
