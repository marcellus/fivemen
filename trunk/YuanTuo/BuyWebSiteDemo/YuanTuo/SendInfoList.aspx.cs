using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using FT.Web.Tools;

public partial class YuanTuo_SendInfoList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GobalTools.BindProduct(this.ddlProducts);
        }
    }
    private void Pop(int id)
    {
        string url = "SendInfoEdit.aspx";
        if (id > 0)
        {
            url += "?id=" + id;
        }
        WebTools.ShowModalWindows(this, url, 820, 350);
    }
    protected void dgLists_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            int id = Convert.ToInt32(e.CommandArgument);
            FT.DAL.DataAccessFactory.GetDataAccess().ExecuteSql("delete from yuantuo_product_send where id=" + id);
            WebTools.Alert(this, "删除成功！");
            this.ProcedurePager1.Changed = true;
        }
        else if (e.CommandName == "Detail")
        {
            int id = Convert.ToInt32(e.CommandArgument);
            this.Pop(id);

        }
    }
    protected void btnSearch_Click1(object sender, EventArgs e)
    {
        if (this.ddlProducts.SelectedIndex > 0)
            this.ProcedurePager1.RowFilter = " productid like '%" + this.ddlProducts.SelectedValue.Trim() + "%'";
        else
            this.ProcedurePager1.RowFilter = "";
        this.ProcedurePager1.Changed = true;
    }
    protected void btnAdd_Click1(object sender, EventArgs e)
    {
        this.Pop(-1);
    }
    protected void dgLists_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
