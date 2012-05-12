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
using FT.DAL.Orm;
using FT.Commons.Tools;
using FT.Web.Tools;

public partial class FpSystem_FpHelper_FpViewExamRecord : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Params[FPSystemBiz.PARAM_RESULT] == null)
            return;
        string lStrIDCard = StringHelper.fnFormatNullOrBlankString(Request.Params[FPSystemBiz.PARAM_RESULT],"");
        if (lStrIDCard=="")
        {
            return;
        }
        //int lIntResultCode = FPSystemBiz.fnIdendityStudentTrain(lStrIDCard);
       
        FpStudentObject fso = SimpleOrmOperator.Query<FpStudentObject>(lStrIDCard);
        bool isCheckin = false;

        DateTime lDtToday = DateTime.Now;
        string bustype = "km";
        if (Session["bustype"] != null) {
            bustype = Session["bustype"].ToString();
        }
        if (fso == null)
        {
            this.lbStudentAlertMsg.Text = "学员个人信息不存在";
            WebTools.PlaySound("../../sound/学员个人信息不存在.wav");
            return;
        }
        else
        {
            ucStudentInfo.fnUILoadStudentRecord(fso);
            try
            {
                //int site_id = StringHelper.fnFormatNullOrBlankInt(Session["site_id"].ToString());
                FpSite fpSite = Session[typeof(FpSite).Name] as FpSite;
                isCheckin = FPSystemBiz.fnStudentCheckIn(ref fso, fpSite, lDtToday);
                if (isCheckin)
                {
                    WebTools.PlaySound("../../sound/考试入场考勤有效.wav");
                }
                else
                {
                    WebTools.PlaySound("../../sound/考试入场考勤无效.wav");
                }
                this.fnUILoadStudentRecord(fso, 0);
            }
            catch (Exception ex) {
                lbStudentAlertMsg.Text = ex.Message;
            }
        }

        
    }



    private void fnUILoadStudentRecord(FpStudentObject pFso, int pResultCode)
    {

        lbStudentAlertMsg.Text = pFso.REMARK;
    }

}
