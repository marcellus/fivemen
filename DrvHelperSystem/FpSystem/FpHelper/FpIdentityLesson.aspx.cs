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
using FT.Commons.Tools;
using FT.DAL.Orm;
using FT.Web;

public partial class FpSystem_FpHelper_FpIdentityLesson : AuthenticatedPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Session["site_id"] = Request.Params["site_id"];
            Session["bustype"] = "lesson";
            int site_id = StringHelper.fnFormatNullOrBlankInt(Session["site_Id"].ToString(), -1);
            FpSite site = SimpleOrmOperator.Query<FpSite>(site_id);
            this.Title = site.NAME;
            Session["host"] = site.HOST;
        }
        catch (Exception ex) {
            this.RedirectNotRight();
        
        }
    }
}
