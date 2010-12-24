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

        /// <summary>
        /// 获取几位的随机数
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public string GetRandomNumString(int length)
        {
            StringBuilder sbd = new StringBuilder();
            if (length <= 0)
            {
                throw new ArgumentException("个数必须大于0 ", "length ");
            }
            byte[] buffer = new byte[length * 4];
            System.Security.Cryptography.RandomNumberGenerator.Create().GetBytes(buffer);
            for (int i = 0; i < length; i++)
            {
                sbd.Append(Math.Abs(BitConverter.ToInt32(buffer, i * 4)) % 10);
            }
            return sbd.ToString();
        }
    }
}
