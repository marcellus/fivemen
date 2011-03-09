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
using FT.DAL.Orm;



public partial class Hr : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.BindData();
        }
    }

    private void BindData()
    {
        string sql = SimpleOrmCache.GetSelectSql(typeof(HrObject));
        
        DataTable dt=FT.DAL.DataAccessFactory.GetDataAccess().SelectDataTable(sql, "tmp");
        if (dt != null && dt.Rows.Count >= 0)
        {
            this.GridView1.DataSource = dt;
            this.GridView1.DataBind();
        }

    }
}
