using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FT.Commons.Tools;
using FT.DAL.Orm;

public partial class FpSystem_UserControler_viewSiteInfo : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int site_id = StringHelper.fnFormatNullOrBlankInt(Request.Params["site_id"], -1);
        if (site_id == -1)
        {
            return;
        }
        FpSite site = SimpleOrmOperator.Query<FpSite>(site_id);
        if (site == null)
        {
            return;
        }

        string lStrLimit = "无限制";
        if (site.LIMIT != null &&site.LIMIT>0) {
            lStrLimit = site.LIMIT.ToString();
        }

        lbSiteName.Text = site.NAME;
        lbSiteLimit.Text = lStrLimit;
        lbToday.Text = DateTime.Now.ToString("yyyy-MM-dd");
    }
}
