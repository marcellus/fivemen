using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FT.Commons.Tools;
using FT.DAL.Orm;
using FT.DAL;
using System.Data;

public partial class FpSystem_FpHelper_FpCheckinLogStatis : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnQuery_Click(object sender, EventArgs e)
    {
        string patternQuery = "select m.NAME as name,m.BUSTYPE as bustype,"
        + " (SELECT count(s.ID) from Fp_Checkin_Log s where s.site_id=m.id and (s.checkin_date between to_date('{0}','YYYY-MM-DD') and to_date('{1}','YYYY-MM-DD') )  ) as tnum"
        + " from FP_SITE m"
        ;
        string qStrDateStart = StringHelper.fnFormatNullOrBlankString(qDateStart.Value,"");
        string qStrDateEnd = StringHelper.fnFormatNullOrBlankString(qDateEnd.Value, "");
        if (qStrDateStart == "" || qStrDateEnd == "") {
            return;
        }

        string sql = string.Format(patternQuery, qStrDateStart, qStrDateEnd);
        DataTable dt= DataAccessFactory.GetDataAccess().SelectDataTable(sql,"tmp");
        dgLogs.DataSource = dt;
        dgLogs.DataBind();
    }

}
