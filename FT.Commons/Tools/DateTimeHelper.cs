using System;
using System.Collections.Generic;
using System.Text;

namespace FT.Commons.Tools
{
    public class DateTimeHelper : BaseHelper
    {
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
    }
}
