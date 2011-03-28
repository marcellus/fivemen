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
using FT.Commons.Tools;

public partial class ShowImage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Params["idcard"] != null)
        {
            //string str=ImageHelper.ImageToBase64Str("c:\\123.jpg");
            string idcardtype = "A";
            if (Request.Params["idcardtype"] != null)
            {
                idcardtype = Request.Params["idcardtype"].ToString();
            }
            string str = FT.WebServiceInterface.WebService.DriverInterface.GetPersonPhoto(idcardtype,Request.Params["idcard"].ToString());
            if (str == null || str.Length == 0)
            {
                str = ImageHelper.ImageToBase64Str(Server.MapPath("~/images/no_photo.jpg"));
            }
            Bitmap image =ImageHelper.Base64StrToBmp(str);

            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            HttpContext.Current.Response.ClearContent();
           // HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.ContentType = "image/jpeg";
            HttpContext.Current.Response.BinaryWrite(ms.ToArray());
            image.Dispose();
        }

    }
}
