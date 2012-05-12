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

public partial class FpSystem_FpHelper_FpIdentityTrain : AuthenticatedPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //Session["site_id"] = Request.Params["site_id"];
            Session["bustype"] = "train";
            int site_id = StringHelper.fnFormatNullOrBlankInt(Request.Params["site_id"], -1);
            FpSite site = null;
            if (FPSystemBiz.DictFpSites.ContainsKey(site_id))
            {
                site = FPSystemBiz.DictFpSites[site_id];
            }
            else
            {
                 site = SimpleOrmOperator.Query<FpSite>(site_id);
                FPSystemBiz.DictFpSites.Add(site_id,site);
            }
            Session[typeof(FpSite).Name] = site;
            this.Title = site.NAME;
            Session["host"] = site.HOST;
        }
        catch (Exception ex) {
            this.RedirectNotRight();
        
        }
    }
}
