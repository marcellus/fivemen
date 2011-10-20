using System;
using System.Collections.Generic;

using System.Text;
using DrvHelperSystemBLL.System.Commons.Model;
using FT.Web.Tools;

namespace DrvHelperSystemBLL.System.Commons.BLL
{
    /// <summary>
    /// 日志记录器
    /// </summary>
    public class LogInfoOperator
    {
        /// <summary>
        /// 记录车行日志
        /// </summary>
        /// <param name="carSalerId">车行编号</param>
        /// <param name="bustype">业务类型</param>
        /// <param name="content">日志内容</param>
        public static void LogCarSaler(int carSalerId,string bustype,string content)
        {
            LogDept(3, carSalerId, bustype, content);
        }
        /// <summary>
        /// 登记医院日志
        /// </summary>
        /// <param name="hospitalid">医院ID</param>
        /// <param name="bustype">业务类型</param>
        /// <param name="content">业务内容</param>
        public static void LogHospital(int hospitalid, string bustype, string content)
        {
            LogDept(2, hospitalid, bustype, content);
        }

        /// <summary>
        /// 记录驾校的日志内容
        /// </summary>
        /// <param name="schoolid">驾校ID</param>
        /// <param name="bustype">业务类型</param>
        /// <param name="content">日志内容</param>
        public static void LogSchool(int schoolid, string bustype, string content)
        {
            LogDept(1, schoolid, bustype, content);
        }
        /// <summary>
        /// 车管所日志内容查看，本部门只能查看本部门的日志内容
        /// </summary>
        /// <param name="deptid">部门ID</param>
        /// <param name="bustype">业务类型</param>
        /// <param name="content">日志内容</param>
        public static void LogCgs(int deptid, string bustype, string content)
        {
            LogDept(0, deptid, bustype, content);
        }
        /// <summary>
        /// 记录顶级的系统日志，无部门
        /// </summary>
        /// <param name="bustype">业务类型</param>
        /// <param name="content">日志内容</param>
        public static void LogSystem(string bustype, string content)
        {
            LogDept(-1, -1, bustype, content);
        }
        /// <summary>
        /// 记录日志详细情况
        /// </summary>
        /// <param name="deptype">部门类别</param>
        /// <param name="depid">部门ID</param>
        /// <param name="bustype">业务类型</param>
        /// <param name="content">日志内容</param>
        public static void LogDept(int deptype,int depid, string bustype, string content)
        {
            LogInfo log = new LogInfo();
            log.BusType = bustype;
            log.Content = content;
            log.DepId = depid;
            log.DepType = deptype;
            log.Des1 = WebTools.GetClientIPString();
            log.Operator = WebTools.GetLoginUser().OperatorName;
            Log(log);

        }

        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="logInfo">日志对象</param>
        public static void Log(LogInfo logInfo)
        {
            FT.DAL.Orm.SimpleOrmOperator.Create(logInfo);
        }
    }
}
