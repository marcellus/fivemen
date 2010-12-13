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

/// <summary>
///DictTypeOperator 的摘要说明
/// </summary>
public class DictTypeOperator
{
    public DictTypeOperator()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    public static void Delete(int id)
    {
        SimpleOrmOperator.Delete<DictType>(id);
    }


    public static DataTable Search(string typename)
    {
        return DataAccessFactory.GetDataAccess().SelectDataTable("select * from table_dicttype where c_typename like '%" + typename + "%'", "tempdb");
    }

    public static void Bind(DropDownList ddl)
    {
        DataTable dt=DataAccessFactory.GetDataAccess().SelectDataTable("select * from table_dicttype ", "tempdb");
        ddl.DataSource = dt;
        ddl.DataTextField = "c_typename";
        ddl.DataValueField = "c_typename";
        ddl.DataBind();
    }
}
