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

public partial class DriverPerson_SystemCounter_CoachCarSearch : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        this.BindData(this.txtIdCard.Text.Trim(), this.txtHmhp.Text.Trim());
    }

    private void BindData(string idCard, string hmhp)
    {

        string sql = "select distinct  c.hphm,c.clpp ,c.jxmc ,d.jlzh ,d.sj ,d.xm ,d.sfzmhm"
+" ,d.jlcxh,d.zjcx ,to_char(c.cjsj,'yyyy-MM-dd HH24:mi:ss') regdate"
+"   from (select a.cjsj,b.jxmc,b.xh,a.jlcxh,a.hphm,a.clpp from drv_admin.drv_learner_vehicle a"
+"    left join drv_admin.drv_schoolinfo b on  a.jxxh=b.xh where a.fzjg='"+WholeWebConfig.Fzjg+"'  ) c left join"
 +"    drv_admin.drv_instructor d on d.jxxh=c.xh and d.jlcxh=c.jlcxh  where d.sfzmhm like '%"+idCard+"%'"
 +"      or c.hphm like '%"+hmhp+"%'";
        DataTable dt = WholeWebConfig.GetDrvIDataAccess().SelectDataTable(sql, "tmp");
        if (dt != null)
        {
            this.DataGrid1.DataSource = dt;
            this.DataGrid1.DataBind();
        }

    }

  

}
