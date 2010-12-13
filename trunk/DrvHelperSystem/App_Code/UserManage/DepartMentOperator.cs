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
///DepartMentOperator 的摘要说明
/// </summary>
public class DepartMentOperator
{
    public DepartMentOperator()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    } 
    public static void Delete(int id)
    {
        SimpleOrmOperator.Delete<DepartMent>(id);
    }

    public static DepartMent Get(int id)
    {
        return SimpleOrmOperator.Query<DepartMent>(id);
    }

    public static DataTable Search(string depname)
    {
        return DataAccessFactory.GetDataAccess().SelectDataTable("select * from table_departments where c_depfullname like '%"+depname+"%'","tempdb");
    }

    public static void Bind(DropDownList ddl,string type)
    {
        DataTable dt = DataAccessFactory.GetDataAccess().SelectDataTable("select * from table_departments where c_deptype='"+type+"'", "tempdb");
        ddl.DataSource = dt;
        ddl.DataTextField = "c_depfullname";
        ddl.DataValueField = "c_depcode";
        ddl.DataBind();
    }

    public static void BindNick(DropDownList ddl, string type)
    {
        DataTable dt = DataAccessFactory.GetDataAccess().SelectDataTable("select * from table_departments where c_deptype='" + type + "'", "tempdb");
        ddl.DataSource = dt;
        ddl.DataTextField = "c_depnickname";
        ddl.DataValueField = "c_depcode";
        ddl.DataBind();
    }

    public static void Bind(DropDownList ddl)
    {
        DataTable dt = DataAccessFactory.GetDataAccess().SelectDataTable("select * from table_departments ", "tempdb");
        ddl.DataSource = dt;
        ddl.DataTextField = "c_depfullname";
        ddl.DataValueField = "id";
        ddl.DataBind();
    }
}
