using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using wsFinger;
using wsUser;
using FT.Web.Tools;

    
public partial class FpSystem_FpHelper_FpVerify52_Idcard : System.Web.UI.Page
{

    public static string KEY_TRAGET_FRAME = "targetFrame", KEY_CHECKINLOG_FRAME = "checkinLogFrame";

   // private wsFingerImplService wsFingerM = new wsFingerImplService();

   // private wsUserImplService wsUserM = new wsUserImplService();


    protected void Page_Load(object sender, EventArgs e)
    {
        txtIdcard.Focus();
        if (!IsPostBack) {
            if (!string.IsNullOrEmpty(Request.Params[KEY_TRAGET_FRAME]))
            {
                Session[KEY_TRAGET_FRAME] = Request.Params[KEY_TRAGET_FRAME];
            }
            if (!string.IsNullOrEmpty(Request.Params[KEY_CHECKINLOG_FRAME]))
            {
                Session[KEY_CHECKINLOG_FRAME] = Request.Params[KEY_CHECKINLOG_FRAME];
            }
        }
    }
    protected void btnVerify_Click(object sender, EventArgs e)
    {
        string idcard = txtIdcard.Text.Trim();
        if (!string.IsNullOrEmpty(idcard))
        {
            Response.Redirect("~/FpSystem/FpV52/finger_as_pwd.aspx?strfp=" + idcard);
        }
    }
}
