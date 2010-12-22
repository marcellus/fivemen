using System;
using System.Collections.Generic;
using System.Text;

namespace FT.Commons.Tools
{
    /// <summary>
    /// ʱ���������
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
                    return "����һ";
                case 2:
                    return "���ڶ�";
                case 3:
                    return "������";
                case 4:
                    return "������";
                case 5:
                    return "������";
                case 6:
                    return "������";
                case 7:
                    return "������";
                default:
                    return "δ֪����";
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
        /// ��ȡĳ���ܵ�����һ
        /// </summary>
        /// <param name="now">��������</param>
        /// <returns>����һ</returns>
        public static DateTime GetMonday(DateTime now)
        {
            //���յ�����0-6
            Debug("��ʼ��ȡ"+now.ToShortDateString()+"������һ������");
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
            Debug("��ȡ��һ������Ϊ->"+result.ToShortDateString());
            return result;

        }

        public static DateTime GetSunday()
        {
            return GetSunday(System.DateTime.Now);
        }

        /// <summary>
        /// ��ȡĳ���ܵ�������
        /// </summary>
        /// <param name="now">��������</param>
        /// <returns>������</returns>
        public static DateTime GetSunday(DateTime now)
        {
            //���յ�����0-6
            Debug("��ʼ��ȡ" + now.ToShortDateString() + "�������յ�����");
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
            Debug("��ȡ���� ������Ϊ->" + result.ToShortDateString());
            return result;
        }


        /// <summary>
        /// ��ȡʱ��ľ��Ժ���ֵ
        /// </summary>
        /// <param name="pDt">����</param>
        /// <returns>������</returns>
        public static double fnGetTotalMillsecond(DateTime pDt)
        {

            DateTime d2 = new DateTime(1970, 1, 1);
            return pDt.Subtract(d2).TotalMilliseconds;

        }


        /// <summary>
        /// �ж��Ƿ��ʼ������
        /// </summary>
        /// <param name="pDt">����</param>
        /// <returns>�Ƿ�</returns>
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
