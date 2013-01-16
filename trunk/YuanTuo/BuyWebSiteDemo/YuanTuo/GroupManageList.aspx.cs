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

public partial class YuanTuo_GroupManageList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
   

    private void Pop(int id)
    {
        string url = "GroupEdit.aspx";
        if (id > 0)
        {
            url += "?id=" + id;
        }
        WebTools.ShowModalWindows(this, url, 550, 280);
    }
    protected void dgLists_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            int id = Convert.ToInt32(e.CommandArgument);
            FT.DAL.DataAccessFactory.GetDataAccess().ExecuteSql("delete from yuantuo_terminal_group where id=" + id);
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
        if (this.txtGroupName.Text.Length > 0)
            this.ProcedurePager1.RowFilter = " name like '%" + this.txtGroupName.Text.Trim() + "%'";
        else
            this.ProcedurePager1.RowFilter = "";
        this.ProcedurePager1.Changed = true;
    }
    protected void btnAdd_Click1(object sender, EventArgs e)
    {
        this.Pop(-1);
    }
}
