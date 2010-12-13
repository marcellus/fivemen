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
///YuyueDayLimitOperator 的摘要说明
/// </summary>
public class YuyueDayLimitOperator
{
    public YuyueDayLimitOperator()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    public static void Delete(int id)
    {
        SimpleOrmOperator.Delete<YuyueDayLimit>(id);
    }


    public static DataTable Search()
    {
        return DataAccessFactory.GetDataAccess().SelectDataTable("select * from table_yuyue_day_limit", "tempdb");
    }
}
