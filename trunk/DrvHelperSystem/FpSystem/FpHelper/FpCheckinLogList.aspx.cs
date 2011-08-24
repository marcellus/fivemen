using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FT.DAL.Orm;
using FT.DAL;
using System.Data;
using FT.Commons.Tools;
using System.Collections;


public partial class FpSystem_FpHelper_FpCheckinLogList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ArrayList dllData = new ArrayList();
            FpSite newStie = new FpSite();
            newStie.ID = 0;
            newStie.NAME = "全部";
            dllData.Add(newStie);
            ArrayList listSite = SimpleOrmOperator.QueryConditionList<FpSite>("");
            dllData.AddRange(listSite);
            dllSite.DataSource = dllData;
            dllSite.DataTextField = "NAME";
            dllSite.DataValueField = "ID";
            dllSite.DataBind();
        }
    }
    protected void btnQuery_Click(object sender, EventArgs e)
    {
        string sql= "select m.*,s.name as site_name from FP_CHECKIN_LOG m left join FP_SITE s on s.id=m.site_id where 1=2 or (1=1  ";
        string qStrSiteId = StringHelper.fnFormatNullOrBlankString(dllSite.SelectedValue,"0");
        string qStrBustype = StringHelper.fnFormatNullOrBlankString(dllBustype.SelectedValue,"");
        string qStrDateStart = StringHelper.fnFormatNullOrBlankString(qDateStart.Value, "");
        string qStrDateEnd = StringHelper.fnFormatNullOrBlankString(qDateEnd.Value, "");
        if (qStrDateStart != "" && qStrDateEnd != "")
        {
            sql += string.Format(" and (m.checkin_date between to_date('{0}','YYYY-MM-DD') and to_date('{1}','YYYY-MM-DD') ) "
                      ,qStrDateStart
                      ,qStrDateEnd
            );
        }

        if (qStrSiteId != "0") {
            sql += string.Format(" and m.site_id={0} ",qStrSiteId);        
        }

        if (qStrBustype != "") {
            sql += string.Format(" and m.bustype='{0}' ",qStrBustype);
        }

        sql += ") ";

        DataTable dt = DataAccessFactory.GetDataAccess().SelectDataTable(sql, "tmp");
        dgLogs.DataSource = dt;
        dgLogs.DataBind();
    }
}
