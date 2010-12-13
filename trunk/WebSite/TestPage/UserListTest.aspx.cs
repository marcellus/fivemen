using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using FT.DAL;
using FT.Web.Tools;

public partial class TestPage_UserListTest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.SimplePager1.Provider = new WebControls.PagerDataProvider(this.GetDataTable);
    }

    private DataTable GetDataTable()
    {
        DataTable dt;
        //dt = FT.DAL.Orm.SimpleOrmOperator.QueryConditionList(typeof(TestUser), " where c_name like '%" + this.tbUserName .Text+ "%'");
        dt = FT.DAL.DataAccessFactory.GetDataAccess().SelectDataTable("select * from table_users","temp");
        return dt;
    }
    protected void dg_EditCommand(object source, DataGridCommandEventArgs e)
    {

    }
    protected void dg_DeleteCommand(object source, DataGridCommandEventArgs e)
    {

    }
    protected void dg_ItemDataBound(object sender, DataGridItemEventArgs e)
    {

    }
    protected void dg_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        this.SimplePager1.CurrentPageIndex = 1;
        this.SimplePager1.Changed = true;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        WebTools.ShowModalWindows("UserEdit.aspx",500,500);
    }
}
