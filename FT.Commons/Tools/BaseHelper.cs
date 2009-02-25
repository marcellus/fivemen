using System;
using System.Collections.Generic;
using System.Text;
using log4net;

namespace FT.Commons.Tools
{
    public abstract class BaseHelper
    {
        protected static ILog log = log4net.LogManager.GetLogger("FT.Commons.Tools");

        /// <summary>
        /// 调试日志
        /// </summary>
        /// <param name="obj"></param>
        protected static void Debug(object obj)
        {
            if (log.IsDebugEnabled)
            {
                log.Debug(obj);
            }
        }
        /// <summary>
        /// 错误日志
        /// </summary>
        /// <param name="obj"></param>
        protected static void Info(object obj)
        {
            if (log.IsInfoEnabled)
            {
                log.Info(obj);
            }
        }
    }
}
