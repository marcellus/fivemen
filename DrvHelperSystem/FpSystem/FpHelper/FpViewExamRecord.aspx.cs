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
        string lStrIDCard = Request.Params[FPSystemBiz.PARAM_RESULT].ToString();
        if (lStrIDCard.Length < 1)
        {
            return;
        }
        //int lIntResultCode = FPSystemBiz.fnIdendityStudentTrain(lStrIDCard);
        FpStudentObject fso = SimpleOrmOperator.Query<FpStudentObject>("'" + lStrIDCard + "'");
        bool isCheckin = false;
        bool isUpdateSuc = false;
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
            isCheckin = fso.checkin(bustype, lDtToday);
        }

        fso.IDCARD = "'" + fso.IDCARD + "'";
        isUpdateSuc = SimpleOrmOperator.Update(fso);
        if (isCheckin && isUpdateSuc)
        {
            int site_id = StringHelper.fnFormatNullOrBlankInt(Session["site_id"].ToString());
            FpCheckinLog log = new FpCheckinLog();
            log.BUSTYPE = bustype;
            log.SITE_ID = site_id;
            log.CHECKIN_NAME = fso.NAME;
            log.CHECKIN_IDCARD = fso.IDCARD.Trim('\'');
            log.CHECKIN_DATE = lDtToday;
            log.REMARK = fso.REMARK;
            SimpleOrmOperator.Create(log);
        }

        this.fnUILoadStudentRecord(fso, 0);
    }



    private void fnUILoadStudentRecord(FpStudentObject pFso, int pResultCode)
    {

        lbStudentAlertMsg.Text = pFso.REMARK;
    }

}
