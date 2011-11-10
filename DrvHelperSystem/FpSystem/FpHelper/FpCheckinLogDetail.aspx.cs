using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FT.Commons.Tools;
using FT.DAL.Orm;
using System.Collections;
using FT.Web.Tools;

public partial class FpSystem_FpHelper_FpCheckinLogDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnQuery_Click(object sender, EventArgs e)
    {

        string queryText = ddlQueryType.SelectedItem.Text;
        string queryType = ddlQueryType.SelectedValue;
        string quserValue=txtQueryValue.Text;
        string condition=string.Format("where {0}='{1}'",queryType,quserValue);

        if (string.IsNullOrEmpty(quserValue))
        {
            WebTools.Alert("查询条件不能为空");
            return;
        }

        ArrayList fsos = SimpleOrmOperator.QueryConditionList<FpStudentObject>(condition);
        if (fsos.Count ==1) {
            FpStudentObject fso = fsos[0] as FpStudentObject;
            fnUILoadStudentRecord(fso, 0);
            ucStudentInfo.fnUILoadStudentRecord(fso);
        }
        else if (fsos.Count == 0) {
            WebTools.Alert(string .Format("{0}为\"{1}\" 的学员不存在",queryText,quserValue));
        }
        else if (fsos.Count > 1)
        {
            WebTools.Alert(string.Format("{0}为\"{1}\" 的学员存在多个，请使用证件号码查询", queryText, quserValue));
        }
    }

    private void fnUILoadStudentRecord(FpStudentObject pFso, int pResultCode)
    {

        this.lbStuLessonEnter1.Text = DateTimeHelper.fnIsNewDateTime(pFso.LESSON_ENTER_1) ? "" : pFso.LESSON_ENTER_1.ToString();
        this.lbStuLessonLeave1.Text = DateTimeHelper.fnIsNewDateTime(pFso.LESSON_ENTER_1) ? "" : pFso.LESSON_LEAVE_1.ToString();
        this.lbStuLessonEnter2.Text = DateTimeHelper.fnIsNewDateTime(pFso.LESSON_ENTER_2) ? "" : pFso.LESSON_ENTER_2.ToString();
        this.lbStuLessonLeave2.Text = DateTimeHelper.fnIsNewDateTime(pFso.LESSON_LEAVE_2) ? "" : pFso.LESSON_LEAVE_2.ToString();


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


        this.lbStuKm1Enter.Text = DateTimeHelper.fnIsNewDateTime(pFso.KM1_ENTER) ? "" : pFso.KM1_ENTER.ToString();
        this.lbStuKm2Enter.Text = DateTimeHelper.fnIsNewDateTime(pFso.KM2_ENTER) ? "" : pFso.KM2_ENTER.ToString();
        this.lbStuKm3Enter.Text = DateTimeHelper.fnIsNewDateTime(pFso.KM3_ENTER) ? "" : pFso.KM3_ENTER.ToString();
        this.lbStr3in9Enter.Text = DateTimeHelper.fnIsNewDateTime(pFso.KM2_3IN9_ENTER) ? "" : pFso.KM2_3IN9_ENTER.ToString();

        this.lbStudentAlertMsg.Text = pFso.REMARK;
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
