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

public partial class TerminalManager_TerminalList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string sql = "select id,name,ip,mac,'' as status from terminals";
            DataTable dt = GobalTools.Select(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string ip = dt.Rows[i]["ip"].ToString();
                    if (FT.Commons.Tools.WindowExHelper.CanConnectionTo(ip))
                    {
                        dt.Rows[i]["status"] = "在线";
                    }
                    else
                    {
                        dt.Rows[i]["status"] = "下线";
                    }
                }
                this.GridView1.DataSource = dt;
                this.GridView1.DataBind();

            }
        }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Refresh")
        {

        }
        else if (e.CommandName == "WakeUp")
        {

        }
        else if (e.CommandName == "Close")
        {

        }

        else if (e.CommandName == "Delete")
        {

        }
        else if (e.CommandName == "Edit")
        {

        }
    }
}
