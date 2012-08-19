using System;
using System.Collections.Generic;
using System.Text;

namespace HiPiaoInterface
{
    [Serializable]
    public class RoomPlanObject
    {
        public string Color = "green";
        /// <summary>
        /// 最高价
        /// </summary>
        public double Price = 0.00d;
        /// <summary>
        /// 哈票价
        /// </summary>
        public double SPrice = 0.00d;
        public string PlanId;
        public string RoomId;
        public string RoomName;
        public string Playtime;

        

    }
}
