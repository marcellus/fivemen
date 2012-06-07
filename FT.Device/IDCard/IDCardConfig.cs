using System;
using System.Collections.Generic;
using System.Text;

namespace FT.Device.IDCard
{
    [Serializable]
    public class IDCardConfig
    {
        public bool UseIDCard = true;

        public int MiniSecond = 500;

        public bool AddReturn = false;
    }
}
