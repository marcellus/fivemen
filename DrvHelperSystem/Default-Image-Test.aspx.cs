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

public partial class Default_Image_Test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Image1.ImageUrl = "ShowImage.aspx?idcardtype=A&idcard=440201";
      
    }
}
