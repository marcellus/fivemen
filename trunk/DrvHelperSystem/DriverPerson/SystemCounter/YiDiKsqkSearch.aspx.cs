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

public partial class DriverPerson_SystemCounter_YiDiKsqkSearch : System.Web.UI.Page
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
        string begin = this.txtBeginDate.Value;
        string end = this.txtEndDate.Value;
        if (begin.Length == 0 || end.Length == 0)
        {
            WebTools.Alert(this, "必须选择待统计的时间范围！");
            return;
        }
        this.BindData(begin, end);

    }

    private void BindData(string begin, string end)
    {

        string sql = "select m.* from ( select to_char(km3ksrq,'yyyy-MM-dd')"
+ " km3ksrq,to_char(km3ksrq,'DY') wk,count(*) num from  drv_admin.drv_grade t,drv_admin.person p,"
+"  drv_admin.drivinglicense d  where p.sfzmhm=t.sfzmhm and p.sfzmhm=d.sfzmhm  and d.cclzrq"
+"    between to_date('"+begin+"','yyyy-MM-dd') and to_date('"+end+" 23:59:59', 'yyyy-MM-dd HH24:mi:ss')"
+"     and kscx like 'C%' and d.ly='B' and d.fzjg='"+WholeWebConfig.Fzjg+"'  group by d.fzjg, km3ksrq,to_char(km3ksrq,'DY') "
+"      having count(*)>100 Order By num Desc ) m order by num desc";
        DataTable dt = WholeWebConfig.GetDrvIDataAccess().SelectDataTable(sql, "tmp");
        if (dt != null)
        {
            this.DataGrid1.DataSource = dt;
            this.DataGrid1.DataBind();
        }

    }
}
