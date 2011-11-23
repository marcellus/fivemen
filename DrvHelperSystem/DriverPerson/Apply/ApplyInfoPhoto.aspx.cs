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

public partial class DriverPerson_Apply_ApplyInfoPhoto : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Params["idcard"] != null)
        {
            //string str=ImageHelper.ImageToBase64Str("c:\\123.jpg");
            string idcard = Request.Params["idcard"].ToString();
            byte[] img = StudentApplyInfoOperator.GetPhoto(idcard);
            
            //HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.ContentType = "image/jpeg";
            if (img != null && img.Length > 0)
            {
                HttpContext.Current.Response.BinaryWrite(img);
            }
            else
            {
                HttpContext.Current.Response.WriteFile(Server.MapPath("~/images/no_photo.jpg"));
            }
            
            //image.Dispose();
        }
    }
}
