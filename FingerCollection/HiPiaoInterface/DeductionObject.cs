using System;
using System.Collections.Generic;
using System.Text;

namespace HiPiaoInterface
{
    /// <summary>
    /// 抵扣券信息
    /// </summary>
    [Serializable]
    public class DeductionObject
    {
        private string cardId;

        /// <summary>
        /// 抵扣券卡号
        /// </summary>
        public string CardId
        {
            get { return cardId; }
            set { cardId = value; }
        }

        private double amount;

        /// <summary>
        /// 金额
        /// </summary>
        public double Amount
        {
            get { return amount; }
            set { amount = value; }
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


        private string useRule;

        /// <summary>
        /// 使用规则
        /// </summary>
        public string UseRule
        {
            get { return useRule; }
            set { useRule = value; }
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
        /// 1未提取2已提取未使用3已使用4已作废5单张激活
        /// </summary>
        public int Status
        {
            get { return status; }
            set { status = value; }
        }

        
    }
}
