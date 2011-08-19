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

public partial class FpSystem_FpHelper_FpIdentityExam : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["site_id"] = Request.Params["site_id"];
        Session["bustype"] = Request.Params["bustype"];
    }


}
