using System;
using System.Collections.Generic;
using System.Text;

namespace FT.Plugins.PersonCard
{
    [Serializable]
    public class CarStartSetting
    {
        //默认开启生日提醒
        public bool BirthDayHint = true;

        //默认生日提醒时间为7天
        public int Days = 7; 
    }
}
