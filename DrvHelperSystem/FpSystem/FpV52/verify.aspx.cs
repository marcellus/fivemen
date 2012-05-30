using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using FT.Web.Tools;

public partial class Verify : System.Web.UI.Page
{

    private wsFinger.wsFingerImplService wsFingerM = new wsFinger.wsFingerImplService();

    private wsUser.wsUserImplService wsUserM = new wsUser.wsUserImplService();
    protected void Page_Load(object sender, EventArgs e)
    {
        string strTmp = Request.QueryString["strTmp"];
        int result = wsFingerM.wsFPCompare(strTmp);
        
        // Session[FPSystemBiz.PARAM_RESULT] = idcard;

        string gStrTargetFrame = Session["targetFrame"] as string;

        string gStrCheckinLogFrame = Session["checkinLogFrame"] as string;
        string idcard = Session["userId"].ToString();
        string lStrSearch = "", SCP_ALERT = "";
        SCP_ALERT += string.Format("window.parent.document.frames('{0}').location.search='{1}';", gStrTargetFrame, lStrSearch);
        if (result == 0)
        {
          //  Response.Write("指纹比对成功！");
             lStrSearch = string.Format("?{0}={1}", FPSystemBiz.PARAM_RESULT, idcard);
             SCP_ALERT += string.Format("window.parent.document.frames('{0}').location.reload();", gStrCheckinLogFrame);
        }
        else
        {
           // Response.Write("指纹比对失败！错误代码为：" + result);
             lStrSearch = string.Format("?{0}={1}", FPSystemBiz.PARAM_RESULT, "");
        }
        
       
        SCP_ALERT += string.Format("window.location.href='../FpHelper/FpVerify52_Idcard.aspx';", gStrCheckinLogFrame);
        WebTools.WriteScript(SCP_ALERT);
    }
}
