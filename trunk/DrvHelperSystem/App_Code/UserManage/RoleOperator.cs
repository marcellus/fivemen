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
///RoleOperator 的摘要说明
/// </summary>
public class RoleOperator
{
    public RoleOperator()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    public static void Delete(int id)
    {
        SimpleOrmOperator.Delete<RoleObject>(id);
    }

    public static RoleObject Get(int id)
    {
        return SimpleOrmOperator.Query<RoleObject>(id);
    }

    public static DataTable Search(string name)
    {
        return DataAccessFactory.GetDataAccess().SelectDataTable("select * from table_roles where c_name like '%" + name + "%'", "tempdb");
    }
    public static void Bind(DropDownList ddl)
    {
        DataTable dt = DataAccessFactory.GetDataAccess().SelectDataTable("select * from table_roles ", "tempdb");
        ddl.DataSource = dt;
        ddl.DataTextField = "c_name";
        ddl.DataValueField = "id";
        ddl.DataBind();
    }
}
