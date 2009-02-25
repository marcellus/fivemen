using System;
using System.Collections.Generic;
using System.Text;

namespace FT.Commons.Tools
{
    public class DateTimeHelper : BaseHelper
    {
        /// <summary>
        /// 获取某个周的星期一
        /// </summary>
        /// <param name="now">周内日期</param>
        /// <returns>星期一</returns>
        public static DateTime GetMonday(DateTime now)
        {
            //周日到周六0-6
            Debug("开始获取"+now.ToShortDateString()+"所在周一的日期");
            int i = (int)now.DayOfWeek;
            DateTime result = now;
            if (i == 0)
            {
                result= now.AddDays(-6);
            }
            else if (i != 1)
            {
                result= now.AddDays(0 - i + 1);
            }
            else
            {
                result= now;
            }
            Debug("获取周一的日期为->"+result.ToShortDateString());
            return result;

        }

        /// <summary>
        /// 获取某个周的星期天
        /// </summary>
        /// <param name="now">周内日期</param>
        /// <returns>星期天</returns>
        public static DateTime GetSunday(DateTime now)
        {
            //周日到周六0-6
            Debug("开始获取" + now.ToShortDateString() + "所在周日的日期");
            int i = (int)now.DayOfWeek;
            DateTime result = now;
            if (i != 0)
            {
                result= now.AddDays(7 - i);
            }
            else
            {
                result= now;
            }
            Debug("获取周日 的日期为->" + result.ToShortDateString());
            return result;
        }
    }
}
