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

public partial class FpSystem_FpHelper_FpViewStudentRecord : System.Web.UI.Page
{
    private FpStudentObject gObjStu;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.Params[FPSystemBiz.PARAM_RESULT] == null||IsPostBack) 
            return;
        string lStrIDCard = Request.Params[FPSystemBiz.PARAM_RESULT].ToString();
        if (lStrIDCard.Length < 1)
        {
            return;
        }
        int lIntResultCode= FPSystemBiz.fnIdendityStudentLesson(lStrIDCard);
        FpStudentObject fso = SimpleOrmOperator.Query<FpStudentObject>("'" + lStrIDCard + "'");
        if (fso == null)
        {
            this.lbStudentAlertMsg.Text = "没有该学员的个人信息";
            return;
        }
        else {
            fso.checkin("lesson");
        }
        this.fnUILoadStudentRecord(fso, lIntResultCode);
    }

    private void fnUILoadStudentRecord(FpStudentObject pFso, int pResultCode)
    {
        //this.lbStrName.Text = pFso.NAME;
        //this.lbStuIdCard.Text = pFso.IDCARD;
        this.lbStuLessonEnter1.Text = DateTimeHelper.fnIsNewDateTime(pFso.LESSON_ENTER_1) ? "" : pFso.LESSON_ENTER_1.ToString();
        this.lbStuLessonLeave1.Text = "";
        this.lbStuLessonEnter2.Text = DateTimeHelper.fnIsNewDateTime(pFso.LESSON_ENTER_2) ? "" : pFso.LESSON_ENTER_2.ToString();
        this.lbStuLessonLeave2.Text = DateTimeHelper.fnIsNewDateTime(pFso.LESSON_LEAVE_2) ? "" : pFso.LESSON_LEAVE_2.ToString();

        if (pResultCode == FPSystemBiz.LESSON_ENTER_1_FAILE)
        {
            this.lbStudentAlertMsg.Text = "本次上课与上次不在同一天进行，旧上课记录已被清空，请再次确认上课";
        }
        else if (pResultCode == FPSystemBiz.LESSON_ENTER_2_FAILE)
        {
            this.lbStudentAlertMsg.Text = "下午上课确认失败";
        }
        else if (pResultCode == FPSystemBiz.LESSON_LEAVE_2_FAILE)
        {
            this.lbStudentAlertMsg.Text = "下午离场确认失败";
        }
        else if (pResultCode == FPSystemBiz.LESSON_FINISH)
        {
            this.lbStudentAlertMsg.Text = "学员已完成上课考勤";
        }

        this.lbStudentAlertMsg.Text = pFso.REMARK;

    }
}
