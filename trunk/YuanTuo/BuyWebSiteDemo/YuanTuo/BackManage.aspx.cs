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
using System.Drawing;


public partial class YuanTuo_BackManage : FT.Web.AuthenticatedPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.lbUserName.Text = "["+this.Operator.OperatorName+"]";
            this.lbUserName.ForeColor = Color.DarkGreen;
        }
    }
}
