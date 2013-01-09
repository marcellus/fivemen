using System;
using System.Collections.Generic;
using System.Text;

namespace FT.Commons.ExtendServices.Weather
{
    /// <summary>
    /// 天气对象
    /// </summary>
    [Serializable]
    public class WeatherObject
    {
        public WeatherInfo weatherinfo;

    }

    [Serializable]
    public class WeatherInfo
    {
        public string city;
        public string cityid;
        public string week;
        public string temp1;
        public string weather1;
        public string img1;
        public string wind1;
        public string fl1;
    }
}
