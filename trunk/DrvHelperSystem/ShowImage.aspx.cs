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
            string str=ImageHelper.ImageToBase64Str("c:\\123.jpg");
            Bitmap image =ImageHelper.Base64StrToBmp(str);
            image.Save(this.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
        }

    }
}
