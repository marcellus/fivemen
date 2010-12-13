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
using FT.Web;

public partial class SystemAdmin_top : AuthenticatedPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            this.Label2.Text = System.DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            this.Label1.Text = this.Operator.OperatorName;
        }

    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
       // Session.Clear();
        Page.RegisterStartupScript("", "<script>window.parent.location.href='../index.aspx'</script>");
    }
    protected void help_Click(object sender, EventArgs e)
    {
        if (Session["help"] != null)
        {
            Page.RegisterStartupScript("openhelp", "<script>window.open('../Help/" + Session["help"].ToString() + "');</script>");
        }
    }
}
