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
using DrvHelperSystemBLL.System.Rbac.BLL;
using WebControls;

public partial class System_DepartmentManage_DepartmentList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.SimplePager1.Provider = new WebControls.PagerDataProvider(DgBind);
    }


    protected void DataGrid1_ItemCommand1(object source, DataGridCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            int id = Convert.ToInt32(e.CommandArgument);
            DepartmentInfoOperator.Delete(id);
            WebTools.Alert(this, "删除成功！");
            this.SimplePager1.Changed = true;
        }
        else if (e.CommandName == "Detail")
        {
            int id = Convert.ToInt32(e.CommandArgument);
            this.Pop(id);

        }

    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    public DataTable DgBind()
    {
        DataTable table = null;
        string depName = this.txtDepName.Text;
        table = DepartmentInfoOperator.Search(depName);
        return table;
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        this.SimplePager1.Changed = true;
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Pop(-1);
    }
   

    private void Pop(int id)
    {
        string url = "DepartmentEdit.aspx";
        if (id > 0)
        {
            url += "?id=" + id;
        }
        //WebTools.Open(url, 870, 400);
        WebTools.ShowModalWindows(this, url, 820, 400);
    }
}
