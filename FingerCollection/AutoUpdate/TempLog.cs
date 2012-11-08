using System;
using System.Collections.Generic;

using System.Text;
//using log4net;

namespace AutoUpdate
{
    public class TempLog
    {
        private TempLog()
        {
        }
       // protected static ILog log = log4net.LogManager.GetLogger("FT.Commons.Tools");

        public static void Debug(object obj)
        {
            /*
            if (log.IsDebugEnabled)
            {
                log.Debug(obj);
            }
             * */
        }

        public static void Info(object obj)
        {
            /*
            if (log.IsInfoEnabled)
            {
                log.Info(obj);
            }
             * */
        }
    }
}
