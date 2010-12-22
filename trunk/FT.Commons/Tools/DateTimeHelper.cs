using System;
using System.Collections.Generic;
using System.Text;

namespace FT.Commons.Tools
{
    /// <summary>
    /// 时间操作工具
    /// </summary>
    public class DateTimeHelper : BaseHelper
    {

        public static int MILLISECOND_ONE_MINUTE=6000;

        public static int GetWeekOfYear(DateTime date)
        {
            DateTime   curDay   =   Convert.ToDateTime(date); 
            int   firstdayofweek   =   Convert.ToInt32(Convert.ToDateTime(curDay.Year.ToString()   +   "- "   +   "1-1 ").DayOfWeek); 
            int   days   =   curDay.DayOfYear; 
            int   daysOutOneWeek   =   days   -   (7   -   firstdayofweek); 
            if   (daysOutOneWeek   <=   0) 
            { 
                return   1; 
            } 
            else 
            { 
                int   weeks   =   daysOutOneWeek   /   7; 
                if   (daysOutOneWeek   %   7   !=   0) 
                weeks   ++; 
                return   weeks   +   1; 
            } 

        }
        public static DateTime GetSeasonFirstDay()
        {
           
            return GetSeasonFirstDay(System.DateTime.Now);
        }

        public static DateTime GetSeasonFirstDay(DateTime now)
        {
            int month = now.Month;
            DateTime tmp = now;
            if (month <= 3)
            {
                tmp = new DateTime(now.Year, 1, 1);
            }
            else if (month >= 4 && month <= 6)
            {
                tmp = new DateTime(now.Year, 4, 1);
            }
            else if (month >= 7 && month <= 9)
            {
                tmp = new DateTime(now.Year, 7, 1);
            }
            else if (month >= 10 && month <= 12)
            {
                tmp = new DateTime(now.Year , 10, 1);
            }
            return tmp;
        }

        public static DateTime GetSeasonLastDay()
        {
            return GetSeasonLastDay(System.DateTime.Now);
        }

        public static DateTime GetSeasonLastDay(DateTime now)
        {
            int month=now.Month;
            DateTime tmp = now;
            if (month <= 3)
            {
                tmp = new DateTime(now.Year, 4, 1);
            }
            else if (month >= 4 && month <= 6)
            {
                tmp = new DateTime(now.Year, 7, 1);
            }
            else if (month >= 7 && month <= 9)
            {
                tmp = new DateTime(now.Year, 10, 1);
            }
            else if (month >= 10 && month <= 12)
            {
                tmp = new DateTime(now.Year+1, 1, 1);
            }
            return tmp.AddDays(-1);
        }

        public static DateTime GetMonthLastDay()
        {
            return GetMonthLastDay(System.DateTime.Now);
        }

        public static DateTime GetMonthLastDay(DateTime now)
        {
            DateTime tmp = new DateTime(now.Year, now.Month + 1, 1);
            return tmp.AddDays(-1);
        }


        public static DateTime GetMonthFirstDay()
        {
            return GetMonthFirstDay(System.DateTime.Now);
        }

        public static string GetChineseXq(int i)
        {
            switch (i)
            {
                case 1:
                    return "星期一";
                case 2:
                    return "星期二";
                case 3:
                    return "星期三";
                case 4:
                    return "星期四";
                case 5:
                    return "星期五";
                case 6:
                    return "星期六";
                case 7:
                    return "星期日";
                default:
                    return "未知星期";
            }
        }

        public static DateTime GetMonthFirstDay(DateTime now)
        {
            return new DateTime(now.Year, now.Month, 1);
        }

        public static DateTime GetMonday()
        {
            return GetMonday(System.DateTime.Now);
        }

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

        public static DateTime GetSunday()
        {
            return GetSunday(System.DateTime.Now);
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


        /// <summary>
        /// 获取时间的绝对毫秒值
        /// </summary>
        /// <param name="pDt">日期</param>
        /// <returns>毫秒数</returns>
        public static double fnGetTotalMillsecond(DateTime pDt)
        {

            DateTime d2 = new DateTime(1970, 1, 1);
            return pDt.Subtract(d2).TotalMilliseconds;

        }


        /// <summary>
        /// 判断是否初始化日期
        /// </summary>
        /// <param name="pDt">日期</param>
        /// <returns>是否</returns>
        public static Boolean fnIsNewDateTime(DateTime pDt)
        {
            if (pDt == null)
            {
                return false;
            }
            return fnGetTotalMillsecond(pDt) == fnGetTotalMillsecond(new DateTime());
        }



    }
}
