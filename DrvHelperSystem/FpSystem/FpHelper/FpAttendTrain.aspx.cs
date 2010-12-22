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
using FT.Commons.Tools;
using FT.DAL.Orm;

public partial class FpSystem_FpHelper_FpAttendTrain : System.Web.UI.Page
{
    private FpBase _FP;

    protected void Page_Load(object sender, EventArgs e)
    {
        _FP = new FpBase(this,new EventHandler(FpVerifyHandler));
    }

    private void FpVerifyHandler(object o, EventArgs e)
    {
        ResultCodeArgs re = (ResultCodeArgs)e;
        string[] lStrUserIds = FpBase.getUserIds(re);

        string idcard = lStrUserIds.Length > 0 ? lStrUserIds[0].ToString() : "";

        int rcode = FPSystemBiz.fnIdendityStudentTrain(idcard);

        if (rcode == FPSystemBiz.CHECHIN_NO_RECARD)
        {
            this.lbStudentAlertMsg.Text = "没有该学员的指纹信息";
            return;
        }
        FpStudentObject fso = SimpleOrmOperator.Query<FpStudentObject>(idcard);
        if (fso == null)
        {
            this.lbStudentAlertMsg.Text = "没有该学员的个人信息";
            return;
        }
        this.fnUILoadStudentRecord(fso, rcode);
        this.lbStudentAlertMsg.Text = "指纹确认成功";
    }



    protected void btnIdentity_Click(object sender, EventArgs e)
    {
        _FP.FpIdentityUser();
    }


    private void fnUILoadStudentRecord(FpStudentObject pFso, int pResultCode)
    {
        this.lbStrName.Text = pFso.NAME;
        this.lbStuIdCard.Text = pFso.IDCARD;
        this.lbStuTrainEnter1.Text = DateTimeHelper.fnIsNewDateTime(pFso.TRAIN_ENTER_1) ? "" : pFso.TRAIN_ENTER_1.ToString();
        this.lbStuTrainLeave1.Text = DateTimeHelper.fnIsNewDateTime(pFso.TRAIN_LEAVE_1) ? "" : pFso.TRAIN_LEAVE_1.ToString();

        this.lbStuTrainEnter2.Text = DateTimeHelper.fnIsNewDateTime(pFso.TRAIN_ENTER_2) ? "" : pFso.TRAIN_ENTER_2.ToString();
        this.lbStuTrainLeave2.Text = DateTimeHelper.fnIsNewDateTime(pFso.TRAIN_LEAVE_2) ? "" : pFso.TRAIN_LEAVE_2.ToString();

        this.lbStuTrainEnter3.Text = DateTimeHelper.fnIsNewDateTime(pFso.TRAIN_ENTER_3) ? "" : pFso.TRAIN_ENTER_3.ToString();
        this.lbStuTrainLeave3.Text = DateTimeHelper.fnIsNewDateTime(pFso.TRAIN_LEAVE_3) ? "" : pFso.TRAIN_LEAVE_3.ToString();

        this.lbStuTrainEnter4.Text = DateTimeHelper.fnIsNewDateTime(pFso.TRAIN_ENTER_4) ? "" : pFso.TRAIN_ENTER_4.ToString();
        this.lbStuTrainLeave4.Text = DateTimeHelper.fnIsNewDateTime(pFso.TRAIN_LEAVE_4) ? "" : pFso.TRAIN_LEAVE_4.ToString();

        this.lbStuTrainEnter5.Text = DateTimeHelper.fnIsNewDateTime(pFso.TRAIN_ENTER_5) ? "" : pFso.TRAIN_ENTER_5.ToString();
        this.lbStuTrainLeave5.Text = DateTimeHelper.fnIsNewDateTime(pFso.TRAIN_LEAVE_5) ? "" : pFso.TRAIN_LEAVE_5.ToString();

        this.lbStuTrainEnter6.Text = DateTimeHelper.fnIsNewDateTime(pFso.TRAIN_ENTER_6) ? "" : pFso.TRAIN_ENTER_6.ToString();
        this.lbStuTrainLeave6.Text = DateTimeHelper.fnIsNewDateTime(pFso.TRAIN_LEAVE_6) ? "" : pFso.TRAIN_LEAVE_6.ToString();

        this.lbStuTrainEnter7.Text = DateTimeHelper.fnIsNewDateTime(pFso.TRAIN_ENTER_7) ? "" : pFso.TRAIN_ENTER_7.ToString();
        this.lbStuTrainLeave7.Text = DateTimeHelper.fnIsNewDateTime(pFso.TRAIN_LEAVE_7) ? "" : pFso.TRAIN_LEAVE_7.ToString();

        this.lbStuTrainEnter8.Text = DateTimeHelper.fnIsNewDateTime(pFso.TRAIN_ENTER_8) ? "" : pFso.TRAIN_ENTER_8.ToString();
        this.lbStuTrainLeave8.Text = DateTimeHelper.fnIsNewDateTime(pFso.TRAIN_LEAVE_8) ? "" : pFso.TRAIN_LEAVE_8.ToString();

       
 //       if (pResultCode == FPSystemBiz.LESSON_ENTER_1_FAILE)
 //       {
  //          this.lbStudentAlertMsg.Text = "本次上课与上次不在同一天进行，旧上课记录已被清空，请再次确认上课";
 //       }
   //     else if (pResultCode == FPSystemBiz.LESSON_ENTER_2_FAILE)
  //      {
 //           this.lbStudentAlertMsg.Text = "下午上课确认失败";
 //       }
  //      else if (pResultCode == FPSystemBiz.LESSON_LEAVE_2_FAILE)
  //      {
  //          this.lbStudentAlertMsg.Text = "下午离场确认失败";
  //      }

    }
}
