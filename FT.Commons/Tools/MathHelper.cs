using System;
using System.Collections.Generic;
using System.Text;

namespace FT.Commons.Tools
{
    /// <summary>
    /// 数字操作类
    /// </summary>
    public class MathHelper : BaseHelper
    {
        private MathHelper()
        {
        }

        public static string Percent(double a,double b)
        {
            if (b == 0.0d)
            {
                return "0.00%";
            }
            double percent = Math.Round(a / b , 4);
            return percent.ToString("p");

        }
    }
}
