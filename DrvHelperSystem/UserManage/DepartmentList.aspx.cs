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

public partial class UserManage_DepartmentList : FT.Web.AuthenticatedPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.SimplePager1.Provider = new WebControls.PagerDataProvider(DgBind);
        //this.SimplePager1.Changed = true;

    }
    protected void DataGrid1_ItemCommand1(object source, DataGridCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            int id = Convert.ToInt32(e.CommandArgument);
            DepartMentOperator.Delete(id);
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
        table = DepartMentOperator.Search(depName);
        return table;
    }

    private DataTable MockTable()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("id");
        dt.Columns.Add("depfullname");
        dt.Columns.Add("depnickname");
        dt.Columns.Add("depcode");
        dt.Columns.Add("parentcode");
        dt.Columns.Add("connector");
        dt.Columns.Add("mobile");
        dt.Columns.Add("phone");
        dt.Columns.Add("companycode");
        for (int i = 0; i < 45; i++)
        {
            dt.Rows.Add(new string[]{"id"+i,
            "depfullname"+i,"depnickname"+i,"depcode"+i,"parentcode"+i,
            "connector"+i,"mobile"+i,"phone"+i,"companycode"+i
            });
        }
        return dt;
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        this.SimplePager1.Changed = true;
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Pop(-1);
    }
    protected void btnAdd_Click1(object sender, EventArgs e)
    {
        Pop(-1);
    }

    private void Pop(int id)
    {
        string url="DepartmentEdit.aspx";
        if(id>0)
        {
            url+="?id="+id;
        }
        WebTools.ShowModalWindows(this,url,  870,400);
    }
}
