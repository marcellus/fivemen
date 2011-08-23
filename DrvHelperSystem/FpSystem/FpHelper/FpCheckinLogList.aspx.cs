using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FT.DAL.Orm;
using FT.DAL;
using System.Data;
using FT.Commons.Tools;


public partial class FpSystem_FpHelper_FpCheckinLogList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnQuery_Click(object sender, EventArgs e)
    {
        string sql= "select m.* from FP_CHECKIN_LOG m where 1=2 or (";
        string qStrSiteId = StringHelper.fnFormatNullOrBlankString(dllSite.SelectedValue,"");
        string qStrBustype = StringHelper.fnFormatNullOrBlankString(dllBustype.SelectedValue,"");
        string qStrDateStart = StringHelper.fnFormatNullOrBlankString(qDateStart.Value, "");
        string qStrDateEnd = StringHelper.fnFormatNullOrBlankString(qDateEnd.Value, "");
        if (qStrDateStart != "" || qStrDateEnd != "")
        {
            return;
        }

        DataTable dt = DataAccessFactory.GetDataAccess().SelectDataTable(sql, "tmp");
        dgLogs.DataSource = dt;
        dgLogs.DataBind();
    }
}
