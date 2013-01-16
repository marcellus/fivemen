using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Layout_YuanTuoWebToCustomer : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.Url.AbsoluteUri.EndsWith("Index.aspx"))
            {
                Session["producttypeid"] = "-1";
            }
            object producttypeid=Session["producttypeid"];
            if (producttypeid != null)
            {
                string id = producttypeid.ToString();
                HtmlImage img=null;
                for (int i = 1; i <= 7; i++)
                {
                    img = this.FindControl("menu" + i.ToString()) as HtmlImage;
                    if (img != null)
                    {
                        if (id == i.ToString())
                        {
                            img.Attributes["src"] = img.Attributes["src"].Replace(".png", "-click.png");
                        }
                        else
                        {
                            img.Attributes["src"] = img.Attributes["src"].Replace("-click.png", ".png");
                        }
                    }
                }
                   
            }
        }
    }
}
