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
///SchoolCarInfoOperator 的摘要说明
/// </summary>
public class SchoolCarInfoOperator
{
    public SchoolCarInfoOperator()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    public static void Delete(int id)
    {
        SimpleOrmOperator.Delete<SchoolCarInfo>(id);
    }


    public static DataTable Search(string hmhp)
    {
        return DataAccessFactory.GetDataAccess().SelectDataTable("select * from table_school_car_info where hmhp like '%"+hmhp+"%'", "tempdb");
    }

    public static void Bind(DropDownList ddl,string depcode)
    {
        DataTable dt = DataAccessFactory.GetDataAccess().SelectDataTable("select * from table_school_car_info where depcode='"+depcode+"'", "tempdb");
        ddl.DataSource = dt;
        ddl.DataTextField = "hmhp";
        ddl.DataValueField = "idcard";
        ddl.DataBind();
    }
}
