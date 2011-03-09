using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using FT.DAL;
using FT.DAL.Orm;
using FT.Commons.Tools;

public partial class Product : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.DbBind();
        }
    }
    private void DbBind()
    {
        string id = "1";
        if (Request.Params["id"] != null)
        {
            id = Request.Params["id"].ToString();
        }
        string sql= SimpleOrmCache.GetSelectSql(typeof(ProductObject));
        sql += " where typeid="+id;
        DataTable dt = DataAccessFactory.GetDataAccess().SelectDataTable(sql, "tmp");
        if (dt != null)
        {
            this.DataList1.DataSource = dt;
            this.DataList1.DataBind();
        }

    }
}
