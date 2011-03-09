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
using FT.Web.Tools;

public partial class Admin_ProductList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.SimplePager1.Provider = new WebControls.PagerDataProvider(DgBind);
    }

    public DataTable DgBind()
    {
        DataTable table = null;
        table = DataAccessFactory.GetDataAccess().SelectDataTable(SimpleOrmCache.GetSelectSql(typeof(ProductObject)), "tmp");
        return table;
    }

    protected void btnAdd_Click1(object sender, EventArgs e)
    {
        this.Pop(-1);
    }
    protected void DataGrid1_ItemCommand1(object source, DataGridCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            int id = Convert.ToInt32(e.CommandArgument);
            SimpleOrmOperator.Delete<ProductObject>(id);
            WebTools.Alert(this, "删除成功！");
            this.SimplePager1.Changed = true;
        }
        else if (e.CommandName == "Detail")
        {
            int id = Convert.ToInt32(e.CommandArgument);
            this.Pop(id);

        }
    }
    private void Pop(int id)
    {
        string url = "ProductEdit.aspx";
        if (id > 0)
        {
            url += "?id=" + id;
        }
        WebTools.ShowModalWindows(this, url, 870, 350);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        this.SimplePager1.Changed = true;
    }
}
