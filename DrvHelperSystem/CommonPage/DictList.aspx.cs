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
using FT.DAL.Orm;
using FT.Commons.Tools;
using FT.Web.Tools;

public partial class CommonPage_DictList : FT.Web.AuthenticatedPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.SimplePager1.Provider = new WebControls.PagerDataProvider(DgBind);
        if (!IsPostBack)
        {
            DictTypeOperator.Bind(this.DropDownList1);
        }
    } 
    public DataTable DgBind()
    {
        DataTable table = null;
        string typename = this.DropDownList1.Text;
        string dicttext = this.txtDictText.Text.Trim();
        table = DictOperator.Search(typename,dicttext);
        return table;
    }


    protected void btnSearch_Click(object sender, EventArgs e)
    {
        this.SimplePager1.Changed = true; 
    }
    protected void btnAdd_Click1(object sender, EventArgs e)
    {
        Pop(-1);
    }
    protected void DataGrid1_ItemCommand1(object source, DataGridCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            int id = Convert.ToInt32(e.CommandArgument);
            DictOperator.Delete(id);
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
        string url="DictEdit.aspx";
        if(id>0)
        {
            url+="?id="+id;
        }
        WebTools.ShowModalWindows(this,url,  870,350);
    }

}
