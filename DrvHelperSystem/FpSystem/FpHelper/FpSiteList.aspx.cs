using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FT.Commons.Tools;
using FT.DAL.Orm;
using System.Collections;

public partial class FpSystem_FpHelper_FpSiteList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string bustype = StringHelper.fnFormatNullOrBlankString(Request.Params["bustype"],"");
        if (bustype == null) {
            return;
        }
        string condition=string.Format("where bustype='{0}'",bustype);
        ArrayList listSite= SimpleOrmOperator.QueryConditionList<FpSite>(condition);
        rpSite.DataSource = listSite;
        rpSite.DataBind();
    }
}
