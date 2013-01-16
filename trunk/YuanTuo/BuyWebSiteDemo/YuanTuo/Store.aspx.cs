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

public partial class YuanTuo_Store : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       // if (!IsPostBack)
       // {
            DataTable dt = Session["Store"] as DataTable;
            if (dt != null)
            {
                this.repeater1.Visible = true;
                this.repeater1.DataSource = dt;
                this.repeater1.DataBind();
            }
            else
            {
                this.repeater1.Visible = false;
            }
      //  }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        Session["Store"] = null;
        Session.Remove("Store");
        Session.Clear();
        Session.Abandon();
        this.repeater1.Visible = false;
        /*
        DataTable dt = Session["Store"] as DataTable;
        if (dt == null)
        {
            this.repeater1.DataSource = new DataTable();
            this.repeater1.DataBind();
        }
         * */
      //  Session.Abandon();//
    }
}
