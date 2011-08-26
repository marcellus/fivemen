using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FT.Web.Tools;
using System.Data;
using FT.DAL;

public partial class FpSystem_FpHelper_FpSiteConfig : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) {
            return;
        }
        string sql = "select * from fp_site";
        DataTable dt = new DataTable();
        dt=DataAccessFactory.GetDataAccess().SelectDataTable(sql,"tmp");
        dgSites.DataSource = dt;
        dgSites.DataBind();
        //this.SimplePager1.Provider = new WebControls.PagerDataProvider(dt);
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {

    }
    protected void btnAdd_Click1(object sender, EventArgs e)
    {
        this.Pop(-1);
    }

    protected void dgSites_ItemCommand1(object source, DataGridCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            int id = Convert.ToInt32(e.CommandArgument);
            RoleOperator.Delete(id);
            WebTools.Alert(this, "删除成功！");
           // this.SimplePager1.Changed = true;
        }
        else if (e.CommandName == "Detail")
        {
            int id = Convert.ToInt32(e.CommandArgument);
            this.Pop(id);

        }
    }

    private void Pop(int id)
    {
        string url = "FpSiteEdit.aspx";
        if (id > 0)
        {
            url += "?id=" + id;
        }
        WebTools.ShowModalWindows(this, url, 620, 280);
    }
}
