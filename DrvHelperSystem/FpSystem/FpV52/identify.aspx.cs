using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Identify : System.Web.UI.Page
{
    private wsFinger.wsFingerImplService wsFingerM = new wsFinger.wsFingerImplService();

    private wsUser.wsUserImplService wsUserM = new wsUser.wsUserImplService();
    protected void Page_Load(object sender, EventArgs e)
    {
        string strTmp = Request.QueryString["strTmp"];
        string result = wsFingerM.wsGetUserInResult(strTmp);
        Response.Write(result);

        
    }
}
