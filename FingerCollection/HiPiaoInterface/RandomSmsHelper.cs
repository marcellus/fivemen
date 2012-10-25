using System;
using System.Collections.Generic;
using System.Text;

namespace HiPiaoInterface
{
    /// <summary>
    /// 随机短信验证
    /// </summary>
    public class RandomSmsHelper
    {
        private static string oldCode = string.Empty;
        public static bool IsRight(string code)
        {
            return code.Equals(oldCode);
        }

        public static string GenerateNumberCode(int len)
        {
            Random r = new Random();
           // long tick = DateTime.Now.Ticks;
          //  Random r = new Random((int)(tick & 0xffffffffL) | (int)(tick >> 32));

            string str=string.Empty;
            for (int i = 0; i < len; i++)
            {
                
                str += r.Next(10).ToString();
            }
            oldCode=str;
            return str;
        }
    }
}
