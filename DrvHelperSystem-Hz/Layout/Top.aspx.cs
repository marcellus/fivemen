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
using FT.Web;
using FT.Web.Tools;

public partial class Layout_Top : AuthenticatedPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        }
    }
    protected void lbtnCancel_Click(object sender, EventArgs e)
    {
        this.ClearOperatorInfo();
        WebTools.WriteScript("parent.location='" + this.ResolveUrl("~/System/UserManage/Login.aspx") + "';parent.reload();");
       
    }
}
