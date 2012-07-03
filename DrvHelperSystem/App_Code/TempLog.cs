using System;
using System.Collections.Generic;
using System.Web;
using log4net;

/// <summary>
///TempLog 的摘要说明
/// </summary>

public class TempLog
{
    private TempLog()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    protected static ILog log = log4net.LogManager.GetLogger("TempLog");
    //protected static ILog log = log4net.LogManager.GetLogger("tools");

    /// <summary>
    /// 调试日志
    /// </summary>
    /// <param name="obj"></param>
    public static int Debug(object obj)
    {
      // if (log != null && log.IsDebugEnabled)
       // {
            log.Debug(obj);
       // }
            return DateTime.Now.Millisecond;
    }
    /// <summary>
    /// 错误日志
    /// </summary>
    /// <param name="obj"></param>
    public static int Info(object obj)
    {
       // if (log != null && log.IsInfoEnabled)
       // {
           // log.Info("客户机IP："+System.Web.HttpContext.Current.Request.UserHostAddress.ToString()+"，线程名->"+System.Threading.Thread.CurrentThread.Name+ obj);
       // }
            return DateTime.Now.Millisecond;
    }
}
