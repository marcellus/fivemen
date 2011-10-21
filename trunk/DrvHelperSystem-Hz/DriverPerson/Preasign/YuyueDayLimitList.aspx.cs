using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DrvHelperSystemBLL.DriverPerson.BLL;
using FT.Web.Tools;

public partial class DriverPerson_Preasign_YuyueDayLimit :FT.Web.AuthenticatedPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.SimplePager1.Provider = new WebControls.PagerDataProvider(DgBind);
    }
    protected void DataGrid1_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            int id = Convert.ToInt32(e.CommandArgument);
            YuyueDayLimitOperator.Delete(id);
            WebTools.Alert(this, "删除成功！");
            this.SimplePager1.Changed = true;
        }
        else if (e.CommandName == "Detail")
        {
            int id = Convert.ToInt32(e.CommandArgument);
            this.Pop(id);
        }
    }

    public DataTable DgBind()
    {
        DataTable table = null;
        table = YuyueDayLimitOperator.Search();
        return table;
    }
    private void Pop(int id)
    {
        string url = "YuyueDayLimitEdit.aspx";
        if (id > 0)
        {
            url += "?id=" + id;
        }
        WebTools.ShowModalWindows(this, url, 500, 280);
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        this.Pop(-1);
    }
}
