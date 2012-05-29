using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FT.Commons.Tools;
using FT.Web.Tools;

public partial class FpSystem_FpHelper_FpVerify_Idcard : System.Web.UI.Page
{

    private FpBase _FP;
    private static Boolean gBlIdentityStrat;

    private static string KEY_TRAGET_FRAME = "targetFrame", KEY_CHECKINLOG_FRAME = "checkinLogFrame";

    protected void Page_Load(object sender, EventArgs e)
    {
        _FP = new FpBase(this, new EventHandler(FpVerifyHandler), false);

        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.Params[KEY_TRAGET_FRAME]))
            {
                Session[KEY_TRAGET_FRAME] = Request.Params[KEY_TRAGET_FRAME];
            }
            if (!string.IsNullOrEmpty(Request.Params[KEY_CHECKINLOG_FRAME]))
            {
                Session[KEY_CHECKINLOG_FRAME] =Request.Params[KEY_CHECKINLOG_FRAME];
            }
            string idcard = Request.Params["idcard"];
            if (!string.IsNullOrEmpty(idcard))
            {
                _FP.FpVerifyUser(idcard);
            }
        }
    }



    private void FpVerifyHandler(object sender, EventArgs e)
    {
        //string SCP_SCRIPT_START = "\n<script language=\"javascript\">\n";
        string SCP_ALERT = "";
        //string SCP_SCRIPT_END = "</script>\n";

        ResultCodeArgs re = (ResultCodeArgs)e;
        if (re.ResultCode == 215)
            return;
        //string[] lArrIdCards = FpBase.getUserIds(re);
        //string idcard = Request.Params["idcard"];
        string idcard = txtIdcard.Text.Trim();
        if (re.ResultCode == FpBase.SUCCESSED)
        {
            //WebTools.Alert("身份识别成功:" + idcard);
        }
        else {
            WebTools.Alert("身份识别失败:" + idcard);
            return;
        }
        // idcard = Server.UrlEncode(idcard);
        string lStrSearch = string.Format("?{0}={1}", FPSystemBiz.PARAM_RESULT, idcard);
        // Session[FPSystemBiz.PARAM_RESULT] = idcard;
        
        string gStrTargetFrame = Session[KEY_TRAGET_FRAME] as string;
    
        string gStrCheckinLogFrame = Session[KEY_CHECKINLOG_FRAME] as string;
        SCP_ALERT += string.Format("window.parent.document.frames('{0}').location.search='{1}';", gStrTargetFrame, lStrSearch);
        SCP_ALERT += string.Format("window.parent.document.frames('{0}').location.reload();", gStrCheckinLogFrame);
        WebTools.Alert(SCP_ALERT);
        ClientScriptManager newCSM = Page.ClientScript;
        //newCSM.RegisterStartupScript(this.GetType(), this.GetHashCode().ToString(), SCP_SCRIPT_START + SCP_ALERT + SCP_SCRIPT_END);
        WebTools.WriteScript(SCP_ALERT);

        //if (cboAuto.Checked)
        //    _FP.FpIdentityUser();
    }

    protected void btnVerify_Click(object sender, EventArgs e)
    {
        string idcard = txtIdcard.Text.Trim();
      
        int re= _FP.FpVerifyUser(idcard);
        if (re == 215) {
        }
        else if (re != FpBase.SUCCESSED) {
            WebTools.Alert(string.Format("学员 {0} 指纹数据不存在 ",idcard));
        }
    }
}
