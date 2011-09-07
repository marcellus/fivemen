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
        ucStudentInfo.fnUILoadStudentRecord(lStrIDCard);
        FpStudentObject fso = SimpleOrmOperator.Query<FpStudentObject>(lStrIDCard);
        bool isCheckin = false;

        DateTime lDtToday = DateTime.Now;
        string bustype = "km";
        if (Session["bustype"] != null) {
            bustype = Session["bustype"].ToString();
        }
        if (fso == null)
        {
            this.lbStudentAlertMsg.Text = "没有该学员的个人信息";
            return;
        }
        else
        {
            try
            {
                int site_id = StringHelper.fnFormatNullOrBlankInt(Session["site_id"].ToString());
                isCheckin = FPSystemBiz.fnStudentCheckIn(ref fso, site_id, lDtToday);
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
