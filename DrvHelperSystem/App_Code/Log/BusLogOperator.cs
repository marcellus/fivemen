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

/// <summary>
///BusLogOperator 的摘要说明
/// </summary>
public class BusLogOperator
{
    public BusLogOperator()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
    public static void InitByLoginUser(BusLog log)
    {
        log.DepId = "-1";
        log.Operator = "admin";
    }

    

    public static DataTable Search(string name)
    {
        return DataAccessFactory.GetDataAccess().SelectDataTable("select * from table_departments where c_depfullname like '%" + name + "%'", "tempdb");
    }

    public static DataTable Count(string name)
    {
        return DataAccessFactory.GetDataAccess().SelectDataTable("select * from table_departments where c_depfullname like '%" + name + "%'", "tempdb");
    }
}
