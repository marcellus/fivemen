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

public partial class DriverPerson_SystemCounter_YdSlSearch : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Server.ScriptTimeout = 420;
        if (!IsPostBack)
        {
            this.txtBeginDate.Value = this.txtEndDate.Value = System.DateTime.Now.ToShortDateString();
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string begin=this.txtBeginDate.Value;
        string end=this.txtEndDate.Value;
        if (begin.Length == 0||end.Length==0)
        {
            WebTools.Alert(this, "必须选择待统计的时间范围！");
            return;
        }
        this.BindData(begin,end);

    }

    private void BindData(string begin,string end)

    {

        string sql = "select  fzjg,count(*) num from "
 +" drv_admin.drivinglicense t where cclzrq between to_date('"+begin+" 00:00:00','yyyy-MM-dd') "
 +" and to_date('"+end+" 23:59:59', 'yyyy-MM-dd HH24:mi:ss') and t.ly in ('B') and "
 +"  zjcx like 'C%' and glbm like '"+WholeWebConfig.Glbm+"%' and fzjg='"+WholeWebConfig.Fzjg+"' group by fzjg order by fzjg";
        DataTable dt=WholeWebConfig.GetDrvIDataAccess().SelectDataTable(sql,"tmp");
        if (dt != null)
        {
            this.DataGrid1.DataSource = dt;
            this.DataGrid1.DataBind();
        }

    }
}
