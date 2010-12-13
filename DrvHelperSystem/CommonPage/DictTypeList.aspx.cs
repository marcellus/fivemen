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

public partial class CommonPage_DictTypeList : FT.Web.AuthenticatedPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

        this.SimplePager1.Provider = new WebControls.PagerDataProvider(DgBind); 
    }
    public DataTable DgBind()
    {
        DataTable table = null;
        string typeName = this.txtTypeName.Text;
        table = DictTypeOperator.Search(typeName);
        return table;
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        this.SimplePager1.Changed = true;
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        this.Pop(-1);
    }

    private void Pop(int id)
    {
        string url="DictTypeEdit.aspx";
        if(id>0)
        {
            url+="?id="+id;
        }
        WebTools.ShowModalWindows(this,url,450,200);
    }

    protected void DataGrid1_ItemCommand1(object source, DataGridCommandEventArgs e)
    {
       if (e.CommandName == "Delete")
        {
            int id = Convert.ToInt32(e.CommandArgument);
            DictTypeOperator.Delete(id);
            WebTools.Alert(this, "删除成功！");
            this.SimplePager1.Changed = true;
        }
        else if (e.CommandName == "Detail")
        {
            int id = Convert.ToInt32(e.CommandArgument);
            this.Pop(id);

        }
    }
}
