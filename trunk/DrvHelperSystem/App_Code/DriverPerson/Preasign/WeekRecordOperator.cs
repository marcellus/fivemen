using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using FT.DAL;
using FT.DAL.Orm;
using FT.Commons.Tools;
using System.Collections;

/// <summary>
///WeekRecordOperator 的摘要说明
/// </summary>
public class WeekRecordOperator
{
    public WeekRecordOperator()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    public static void Delete(int id)
    {
        SimpleOrmOperator.Delete<WeekRecord>(id);
       // DataAccessFactory.GetDataAccess().ExecuteSql("delete from table_yuyue_limit where i_week_num=" + week.WeekNum);
    }

    public static WeekRecord Get(int id)
    {
       return SimpleOrmOperator.Query<WeekRecord>(id);
       // SimpleOrmOperator.Delete<WeekRecord>(id);
    }
    public static WeekRecord GetByWeekNum(int num,string shortdate)
    {
        WeekRecord week = new WeekRecord();
        ArrayList lists = SimpleOrmOperator.QueryConditionList<WeekRecord>(" where i_week_num=" + num + " and c_week_range like '"+shortdate+"%'");
        if (lists.Count == 1)
        {
            week = lists[0] as WeekRecord;
        }
        return week;
        // SimpleOrmOperator.Delete<WeekRecord>(id);
    }

    public static void Update(WeekRecord week)
    {
        SimpleOrmOperator.Update(week);
        string datestr = week.WeekRange.Substring(0, week.WeekRange.IndexOf('至'));
        DateTime begin = DateTimeHelper.GetMonday(DateTime.Parse(datestr));
        DataAccessFactory.GetDataAccess().ExecuteSql("delete from table_yuyue_limit where i_week_num="+week.WeekNum+ " and date_ksrq like '"+begin.Year.ToString()+"%'");

       
        YuyueLimitOperator.Save(week, 1, 1, datestr, week.Week1km1fp);
        YuyueLimitOperator.Save(week, 1, 2, datestr, week.Week1km2fp);
        YuyueLimitOperator.Save(week, 1, 3, datestr, week.Week1km3fp);

        YuyueLimitOperator.Save(week, 2, 1, datestr, week.Week2km1fp);
        YuyueLimitOperator.Save(week, 2, 2, datestr, week.Week2km2fp);
        YuyueLimitOperator.Save(week, 2, 3, datestr, week.Week2km3fp);

        YuyueLimitOperator.Save(week, 3, 1, datestr, week.Week3km1fp);
        YuyueLimitOperator.Save(week, 3, 2, datestr, week.Week3km2fp);
        YuyueLimitOperator.Save(week, 3, 3, datestr, week.Week3km3fp);

        YuyueLimitOperator.Save(week, 4, 1, datestr, week.Week4km1fp);
        YuyueLimitOperator.Save(week, 4, 2, datestr, week.Week4km2fp);
        YuyueLimitOperator.Save(week, 4, 3, datestr, week.Week4km3fp);

        YuyueLimitOperator.Save(week, 5, 1, datestr, week.Week5km1fp);
        YuyueLimitOperator.Save(week, 5, 2, datestr, week.Week5km2fp);
        YuyueLimitOperator.Save(week, 5, 3, datestr, week.Week5km3fp);

        YuyueLimitOperator.Save(week, 6, 1, datestr, week.Week6km1fp);
        YuyueLimitOperator.Save(week, 6, 2, datestr, week.Week6km2fp);
        YuyueLimitOperator.Save(week, 6, 3, datestr, week.Week6km3fp);

        YuyueLimitOperator.Save(week, 7, 1, datestr, week.Week7km1fp);
        YuyueLimitOperator.Save(week, 7, 2, datestr, week.Week7km2fp);
        YuyueLimitOperator.Save(week, 7, 3, datestr, week.Week7km3fp);
    }

    public static void Update(WeekRecord week, ArrayList limits) {
        SimpleOrmOperator.Update(week);
        string datestr = week.WeekRange.Substring(0, week.WeekRange.IndexOf('至'));
        DateTime begin = DateTimeHelper.GetMonday(DateTime.Parse(datestr));
        string deleteSql = "delete from table_yuyue_limit where i_week_num=" + week.WeekNum + " and date_ksrq like '" + begin.Year.ToString() + "%'";
        DataAccessFactory.GetDataAccess().ExecuteSql(deleteSql);

        foreach (object obj in limits) {
            YuyueLimit limit = obj as YuyueLimit;
            YuyueLimitOperator.Save(week, limit, begin);
        }
    }

    public static void Create(WeekRecord week)
    {
        SimpleOrmOperator.Create(week);
        string datestr = week.WeekRange.Substring(0, week.WeekRange.IndexOf('至'));
        DateTime begin = DateTimeHelper.GetMonday(DateTime.Parse(datestr));
        YuyueLimitOperator.Save(week, 1, 1, datestr, week.Week1km1fp);
        YuyueLimitOperator.Save(week, 1, 2, datestr, week.Week1km2fp);
        YuyueLimitOperator.Save(week, 1, 3, datestr, week.Week1km3fp);

        YuyueLimitOperator.Save(week, 2, 1, datestr, week.Week2km1fp);
        YuyueLimitOperator.Save(week, 2, 2, datestr, week.Week2km2fp);
        YuyueLimitOperator.Save(week, 2, 3, datestr, week.Week2km3fp);

        YuyueLimitOperator.Save(week, 3, 1, datestr, week.Week3km1fp);
        YuyueLimitOperator.Save(week, 3, 2, datestr, week.Week3km2fp);
        YuyueLimitOperator.Save(week, 3, 3, datestr, week.Week3km3fp);

        YuyueLimitOperator.Save(week, 4, 1, datestr, week.Week4km1fp);
        YuyueLimitOperator.Save(week, 4, 2, datestr, week.Week4km2fp);
        YuyueLimitOperator.Save(week, 4, 3, datestr, week.Week4km3fp);

        YuyueLimitOperator.Save(week, 5, 1, datestr, week.Week5km1fp);
        YuyueLimitOperator.Save(week, 5, 2, datestr, week.Week5km2fp);
        YuyueLimitOperator.Save(week, 5, 3, datestr, week.Week5km3fp);

        YuyueLimitOperator.Save(week, 6, 1, datestr, week.Week6km1fp);
        YuyueLimitOperator.Save(week, 6, 2, datestr, week.Week6km2fp);
        YuyueLimitOperator.Save(week, 6, 3, datestr, week.Week6km3fp);

        YuyueLimitOperator.Save(week, 7, 1, datestr, week.Week7km1fp);
        YuyueLimitOperator.Save(week, 7, 2, datestr, week.Week7km2fp);
        YuyueLimitOperator.Save(week, 7, 3, datestr, week.Week7km3fp);
    }

    public static void Create(WeekRecord week, ArrayList limits) {
        SimpleOrmOperator.Create(week);
        string datestr = week.WeekRange.Substring(0, week.WeekRange.IndexOf('至'));
        DateTime begin = DateTimeHelper.GetMonday(DateTime.Parse(datestr));
        foreach (object obj in limits)
        {
            YuyueLimit limit = obj as YuyueLimit;
            YuyueLimitOperator.Save(week, limit, begin);
        }
    }


    public static DataTable Search()
    {
        return DataAccessFactory.GetDataAccess().SelectDataTable("select * from table_yuyue_day_limit", "tempdb");
    }
}
