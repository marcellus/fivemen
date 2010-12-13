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

public partial class UserManage_RoleList : FT.Web.AuthenticatedPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.SimplePager1.Provider = new WebControls.PagerDataProvider(DgBind);
    }
    public DataTable DgBind()
    {
        DataTable table = null;
        string key = this.txtRoleName.Text;
        table = RoleOperator.Search(key);
        return table;
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        this.SimplePager1.Changed = true;
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
            RoleOperator.Delete(id);
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
        string url="RoleEdit.aspx";
        if(id>0)
        {
            url+="?id="+id;
        }
        WebTools.ShowModalWindows(this,url,  620,600);
    }
}
