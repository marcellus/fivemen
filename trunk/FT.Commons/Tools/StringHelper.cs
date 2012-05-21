using System;
using System.Collections.Generic;
using System.Text;

namespace FT.Commons.Tools
{
   public class StringHelper :BaseHelper
    {

        public static string fnFormatNullOrBlankString(String pStrCheck)
        {
           return  fnFormatNullOrBlankString(pStrCheck, "");
        }

        public static string fnFormatNullOrBlankString(string pStrCheck, string pStrDefault)
        {
            if (pStrCheck == null)
                return pStrDefault;
            else if (pStrCheck.Length <1)
                return pStrDefault;
            else
                return pStrCheck;
        }

        public static int fnFormatNullOrBlankInt(string pStrCheck)
        {
          return  fnFormatNullOrBlankInt(pStrCheck, 0);
        }

        public static int fnFormatNullOrBlankInt(string pStrCheck, int pIntDefault)
        {
            try
            {
                if (pStrCheck == null)
                    return pIntDefault;
                else if (pStrCheck.Length <1)
                    return pIntDefault;
                else
                    return int.Parse(pStrCheck);
            }
            catch (FormatException fe)
            {
                return pIntDefault;
            }
   
        }

        public static bool isNullOrBlank(object obj) {
            return obj == null || string.IsNullOrEmpty(obj.ToString());
        }
 

    }
}
