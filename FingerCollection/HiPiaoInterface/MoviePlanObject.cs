using System;
using System.Collections.Generic;
using System.Text;

namespace HiPiaoInterface
{
    [Serializable]
    public class MoviePlanObject
    {
        public string Language;
        public string Type;
        public List<RoomPlanObject> RoomPlans = new List<RoomPlanObject>();
    }
}
