using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FT.Commons.Tools;
using FT.Web.Tools;
using FT.DAL.Orm;
using System.Threading;

public partial class FpSystem_FpHelper_FpVerify_Idcard : System.Web.UI.Page
{

    private FpBase _FP;
    private static Boolean gBlIdentityStrat;

    private static string KEY_TRAGET_FRAME = "targetFrame", KEY_CHECKINLOG_FRAME = "checkinLogFrame";

    protected void Page_Load(object sender, EventArgs e)
    {

        _FP = new FpBase(this, new EventHandler(FpVerifyHandler), true );
        txtIdcard.Focus();

       // btnVerify.Enabled = true;


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
               // _FP.FpVerifyUser(idcard);
                this.doVerify(idcard);
            }
            
        }else{
            string FunName = Request.Form["FunName"];
            if ( FunName == "doVerify")
            {
                this.doVerify(this.txtIdcard.Value.Trim());
            
            }
           
        }



    }



    private void FpVerifyHandler(object sender, EventArgs e)
    {



        ResultCodeArgs re = (ResultCodeArgs)e;
        if (re.ResultCode == 215)
            return;
        //string[] lArrIdCards = FpBase.getUserIds(re);
        //string idcard = Request.Params["idcard"];
        string idcard = txtIdcard.Value.Trim();
        
        // idcard = Server.UrlEncode(idcard);
        string SCP_ALERT="", lStrSearch = "";
        // Session[FPSystemBiz.PARAM_RESULT] = idcard;

        string gStrTargetFrame = Session[KEY_TRAGET_FRAME] as string;

        string gStrCheckinLogFrame = Session[KEY_CHECKINLOG_FRAME] as string;
        
        if (re.ResultCode == FpBase.SUCCESSED)
        {
            //WebTools.Alert("身份识别成功:" + idcard);
            lStrSearch = string.Format("?{0}={1}", FPSystemBiz.PARAM_RESULT, idcard);
            SCP_ALERT += string.Format("window.parent.document.frames('{0}').location.search='{1}';", gStrTargetFrame, lStrSearch);
            SCP_ALERT += string.Format("window.parent.document.frames('{0}').location.reload();", gStrCheckinLogFrame);
            ViewState["verifyFail"] = null;
            txtIdcard.Value = string.Empty;
        }
        else {
            //WebTools.Alert("身份识别失败:" + idcard);
            lStrSearch = string.Format("?{0}={1}", FPSystemBiz.PARAM_RESULT, "");
            SCP_ALERT += string.Format("window.parent.document.frames('{0}').location.search='{1}';", gStrTargetFrame, lStrSearch);
           
            if (ViewState["verifyFail"] == null)
            {
                Thread.Sleep(500);
                doVerify(idcard);
                ViewState["verifyFail"] = true;
            }
            else {
                ViewState["verifyFail"] = null;
                txtIdcard.Value = string.Empty;
            }
            
        }

        
       // WebTools.Alert(SCP_ALERT);
       // ClientScriptManager newCSM = Page.ClientScript;
        //newCSM.RegisterStartupScript(this.GetType(), this.GetHashCode().ToString(), SCP_SCRIPT_START + SCP_ALERT + SCP_SCRIPT_END);
        WebTools.WriteScript(SCP_ALERT);

        //if (cboAuto.Checked)
        //    _FP.FpIdentityUser();
    }

    private void doVerify(string idcard) {

        DateTime begin = DateTime.Now;
        if (string.IsNullOrEmpty(idcard)) return;
        FpStudentObject student = SimpleOrmOperator.Query<FpStudentObject>(idcard);

        string gStrTargetFrame = Session[KEY_TRAGET_FRAME] as string;
        string SCP_ALERT = "", lStrSearch = "";
        string gStrCheckinLogFrame = Session[KEY_CHECKINLOG_FRAME] as string;
        if (student == null)
        {

            lStrSearch = string.Format("?{0}={1}", FPSystemBiz.PARAM_RESULT, idcard);
            SCP_ALERT += string.Format("window.parent.document.frames('{0}').location.search='{1}';", gStrTargetFrame, lStrSearch);
            WebTools.WriteScript(SCP_ALERT);
            btnVerify.Enabled = true;
            txtIdcard.Value = string.Empty;
            return;
        }
        //WebTools.Alert(string.Format("当前用户:{0}", _FP.getCurrAuthenID()));
        DateTime end = DateTime.Now;
        // TempLog.Info(string.Format("SimpleOrmOperator.Query<FpStudentObject>({0}) : {1}",idcard,end.Subtract(begin).TotalMilliseconds.ToString()));
        int re = _FP.FpVerifyUser(idcard);

        btnVerify.Enabled = true;
        if (re == 215)
        {
        }
        else if (re != FpBase.SUCCESSED)
        {
            //WebTools.Alert(string.Format("学员 {0} 指纹数据不存在 ",idcard));
            lStrSearch = string.Format("?{0}={1}", FPSystemBiz.PARAM_RESULT, "");
            SCP_ALERT += string.Format("window.parent.document.frames('{0}').location.search='{1}';", gStrTargetFrame, lStrSearch);
            WebTools.WriteScript(SCP_ALERT);
        }
    }

    protected void btnVerify_Click(object sender, EventArgs e)
    {
       // btnVerify.Enabled = false;

        string idcard = txtIdcard.Value.Trim();
        this.doVerify(idcard);
        
    }

}
