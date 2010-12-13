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
using FT.DAL;
using FT.DAL.Orm;
using FT.Web.Tools;
using FT.Web;

public partial class UserManage_UserList : FT.Web.AuthenticatedPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.SimplePager1.Provider = new WebControls.PagerDataProvider(DgBind);
    }

    public DataTable DgBind()
    {
        DataTable table = null;
        string name = this.txtUserName.Text;
        table = UserOperator.Search(name);
        return table;
    }
    
    protected void btnAdd_Click1(object sender, EventArgs e)
    {
        Pop(-1);
    }
    private void Pop(int id)
    {
        string url="UserEdit.aspx";
        if(id>0)
        {
            url+="?id="+id;
        }
        WebTools.ShowModalWindows(this,url,  900,450);
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
            this.SimplePager1.Changed = true;
    }
    protected void DataGrid1_ItemCommand1(object source, DataGridCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            int id = Convert.ToInt32(e.CommandArgument);
            UserOperator.Delete(id);
            WebTools.Alert(this, "删除成功！");
            this.SimplePager1.Changed = true;
        }
        else if (e.CommandName == "Detail")
        {
            int id = Convert.ToInt32(e.CommandArgument);
            this.Pop(id);

        }
        else if (e.CommandName == "ResetPwd")
        {
            int id = Convert.ToInt32(e.CommandArgument);
            bool result=UserOperator.ResetPwd(id, ConfigurationManager.AppSettings["DefaultPassword"].ToString());
            if(result)
                WebTools.Alert(this, "密码重置成功！");
            else
                WebTools.Alert(this, "密码重置失败！");

        }
    }
}
