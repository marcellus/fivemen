using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using FT.DAL.Orm;
using FT.DAL;

/// <summary>
///ZwTpOperator 的摘要说明
/// </summary>
public class ZwTpOperator
{
    public ZwTpOperator()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    public static void Delete(int id)
    {
        SimpleOrmOperator.Delete<ZwTpObject>(id);
        // DataAccessFactory.GetDataAccess().ExecuteSql("delete from table_yuyue_limit where i_week_num=" + week.WeekNum);
    }

    public static void Create(ZwTpObject tp)
    {
        SimpleOrmOperator.Create(tp);
        // DataAccessFactory.GetDataAccess().ExecuteSql("delete from table_yuyue_limit where i_week_num=" + week.WeekNum);
    }

}
