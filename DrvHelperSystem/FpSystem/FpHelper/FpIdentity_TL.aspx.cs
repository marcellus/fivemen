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
using FT.Web.Tools;
using FT.Commons.Tools;

public partial class FpSystem_FpHelper_FpIndentityLesson_TL : System.Web.UI.Page
{

    

    private FpBase _FP;
    private static Boolean gBlIdentityStrat;
    private string gStrTargetFrame="";
    private string gStrCheckinLogFrame = "";
   

    protected void Page_Load(object sender, EventArgs e)
    {
        
            _FP = new FpBase(this, new EventHandler(FpVerifyHandler), true);
            gStrTargetFrame = StringHelper.fnFormatNullOrBlankString( Request.Params["targetFrame"],"");
            gStrCheckinLogFrame = StringHelper.fnFormatNullOrBlankString(Request.Params["checkinLogFrame"],"");
        
      
    }

    protected void btnIdentity_Click(object sender, EventArgs e)
    {

        _FP.FpIdentityUser();
    }

    private void FpVerifyHandler(object sender, EventArgs e)
    {
        //string SCP_SCRIPT_START = "\n<script language=\"javascript\">\n";
        string SCP_ALERT = "";
        //string SCP_SCRIPT_END = "</script>\n";

        ResultCodeArgs re = (ResultCodeArgs)e;
        if (re.ResultCode == 215)
            return;
        string[] lArrIdCards = FpBase.getUserIds(re);
        string idcard = lArrIdCards.Length > 0 ? lArrIdCards[0].ToString().Split('_')[0] : "";
       // idcard = Server.UrlEncode(idcard);
        string lStrSearch = string.Format("?{0}={1}",FPSystemBiz.PARAM_RESULT, idcard);
       // Session[FPSystemBiz.PARAM_RESULT] = idcard;
         SCP_ALERT += string.Format("window.parent.document.frames('{0}').location.search='{1}';", gStrTargetFrame, lStrSearch);
         SCP_ALERT += string.Format("window.parent.document.frames('{0}').location.reload();",gStrCheckinLogFrame);
        ClientScriptManager newCSM = Page.ClientScript;
        //newCSM.RegisterStartupScript(this.GetType(), this.GetHashCode().ToString(), SCP_SCRIPT_START + SCP_ALERT + SCP_SCRIPT_END);
        WebTools.WriteScript(SCP_ALERT); 

        if (cboAuto.Checked)
            _FP.FpIdentityUser();
    }
}
