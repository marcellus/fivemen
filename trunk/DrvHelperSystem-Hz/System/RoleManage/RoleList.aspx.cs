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
using DrvHelperSystemBLL.System;
using DrvHelperSystemBLL.System.Rbac.BLL;

public partial class System_RoleManage_RoleList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.ProcedurePager1.TableName = "TABLE_ROLE_INFO";
            this.ProcedurePager1.FieldString = @"id ,
	c_role_name ,
    " + Constants.DecodeDepType + @",
	c_des1 ,
    c_des2 ,
    c_des3 
	".Replace("\r\n", "").Replace("\t", "");
            this.ProcedurePager1.SortString = " order by id asc";
        }
        //
    }

   
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        
        this.ProcedurePager1.RowFilter = "c_role_name like '%"+this.txtName.Text.Trim()+"%'";
        this.ProcedurePager1.Changed = true;
    }

    protected void DataGrid1_ItemCommand1(object source, DataGridCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            int id = Convert.ToInt32(e.CommandArgument);
            RoleInfoOperator.Delete(id);
            WebTools.Alert(this, "删除成功！");
            this.ProcedurePager1.Changed = true;
        }
        else if (e.CommandName == "Detail")
        {
            int id = Convert.ToInt32(e.CommandArgument);
            this.Pop(id);

        }

    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Pop(-1);
    }


    private void Pop(int id)
    {
        string url = "RoleEdit.aspx";
        if (id > 0)
        {
            url += "?id=" + id;
        }
        //WebTools.Open(url, 870, 400);
        WebTools.ShowModalWindows(this, url, 820, 400);
    }
}
