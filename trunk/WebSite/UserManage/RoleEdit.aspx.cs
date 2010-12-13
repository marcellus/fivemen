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
using BLL;
using System.Data.SqlClient;

public partial class UserManage_RoleEdit :CqGuoTong.AuthenticatedPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            MyDataBind();
            Session["help"] = "RoleManageHelp.html";
        }

        this.SimplePager1.Provider = new WebControls.PagerDataProvider(MyDataBind);
    }

    private DataTable MyDataBind()
    {
        string roleName = this.tbRoleName.Text;
        DataTable table = UserManage.RoleQuery(roleName);
        this.dgRole.DataSource = table;
        this.dgRole.DataBind();
        return table;
    }

    //protected void dgRole_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    //{
    //    this.dgRole.CurrentPageIndex = e.NewPageIndex;
    //    MyDataBind();
    //}

    protected void dgRole_DeleteCommand(object source, DataGridCommandEventArgs e)
    {
        if (UserManage.DelRole(this.Operator.OperatorID, Convert.ToInt32(e.Item.Cells[0].Text)))
        {
            Common.WebTools.Alert(this, "删除成功！");
            MyDataBind();
        }
        else
        {
            Common.WebTools.Alert(this, "删除失败！");
            return;
        }
    }
    protected void dgRole_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.EditItem || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            LinkButton lkBtn = (LinkButton)e.Item.Cells[5].Controls[0];
            lkBtn.Attributes.Add("onclick", "javascript:return confirm('确定要删除 " + e.Item.Cells[1].Text + " 吗？')");
        }
    }
    protected void dgRole_EditCommand(object source, DataGridCommandEventArgs e)
    {
        Response.Redirect("RoleAlter.aspx?roleid=" + e.Item.Cells[0].Text);
    }
}
