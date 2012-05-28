using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FT.Commons.Tools;
using FT.DAL.Orm;
using FT.Web.Tools;
using FT.WebServiceInterface.DrvQuery;
using System.Collections;


public partial class FpSystem_FpHelper_FpStudentRecordEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {

            foreach (int key in FpStudentObject.GetDictStatue().Keys) {

                string text = FpStudentObject.GetDictStatue()[key];
                ddlStatue.Items.Add(new ListItem(text,key.ToString()));
            
            }
        
        }

    }

    protected void btnQuery_Click(object sender, EventArgs e)
    {
       // string idcard = StringHelper.fnFormatNullOrBlankString(txtIDCard.Text, "");
       // if (idcard == "")
       // {
       //     WebTools.Alert("请输入要查询的身份证号码");
       //      return;
       //   }
       //  FpStudentObject fso = SimpleOrmOperator.Query<FpStudentObject>(idcard);
       //   if (fso ==null) {
       //       WebTools.Alert("查询的身份证号码不存在");
       //   }
       //   if (fso != null)
       //    {
       //        ViewState[typeof(FpStudentObject).Name] = fso;
       //        fnUILoadStudentRecord(fso, 0);
       //        ucStudentInfo.fnUILoadStudentRecord(fso);
       //     }
        string queryText = ddlQueryType.SelectedItem.Text;
        string queryType = ddlQueryType.SelectedValue;
        string quserValue = txtIDCard.Text;
        string condition = string.Format("where {0} like '%{1}'", queryType, quserValue);

        if (string.IsNullOrEmpty(quserValue))
        {
            WebTools.Alert("查询条件不能为空");
            return;
        }

        ArrayList fsos = SimpleOrmOperator.QueryConditionList<FpStudentObject>(condition);
        if (fsos.Count == 1)
        {
            ViewState[typeof(FpStudentObject).Name] = fsos[0];
            FpStudentObject fso = fsos[0] as FpStudentObject;
            fnUILoadStudentRecord(fso, 0);
            ucStudentInfo.fnUILoadStudentRecord(fso);
            txtIDCard.Text = string.Empty;
        }
        else if (fsos.Count == 0)
        {
            WebTools.Alert(string.Format("{0}为\"{1}\" 的学员不存在", queryText, quserValue));
        }
        else if (fsos.Count > 1)
        {
            WebTools.Alert(string.Format("{0}为\"{1}\" 的学员存在多个，请使用证件号码查询", queryText, quserValue));
        }
        

    }

    private void fnUILoadStudentRecord(FpStudentObject pFso, int pResultCode)
    {
        string datePattern = "yyyy-MM-dd HH:mm:ss";
      
        this.lbStuLessonEnter1.Value = DateTimeHelper.fnIsNewDateTime(pFso.LESSON_ENTER_1) ? "" : pFso.LESSON_ENTER_1.ToString(datePattern);
        this.lbStuLessonLeave1.Value = DateTimeHelper.fnIsNewDateTime(pFso.LESSON_LEAVE_1) ? "" :pFso.LESSON_LEAVE_1.ToString(datePattern);
        this.lbStuLessonEnter2.Value = DateTimeHelper.fnIsNewDateTime(pFso.LESSON_ENTER_2) ? "" :pFso.LESSON_ENTER_2.ToString(datePattern);
        this.lbStuLessonLeave2.Value = DateTimeHelper.fnIsNewDateTime(pFso.LESSON_LEAVE_2) ? "" :pFso.LESSON_LEAVE_2.ToString(datePattern);
        this.lbStuTrainEnter1.Value = DateTimeHelper.fnIsNewDateTime(pFso.TRAIN_ENTER_1) ? "" : pFso.TRAIN_ENTER_1.ToString(datePattern);
        this.lbStuTrainLeave1.Value = DateTimeHelper.fnIsNewDateTime(pFso.TRAIN_LEAVE_1) ? "" : pFso.TRAIN_LEAVE_1.ToString(datePattern);
        this.lbStuTrainEnter2.Value = DateTimeHelper.fnIsNewDateTime(pFso.TRAIN_ENTER_2) ? "" : pFso.TRAIN_ENTER_2.ToString(datePattern);
        this.lbStuTrainLeave2.Value = DateTimeHelper.fnIsNewDateTime(pFso.TRAIN_LEAVE_2) ? "" : pFso.TRAIN_LEAVE_2.ToString(datePattern);
        this.lbStuTrainEnter3.Value = DateTimeHelper.fnIsNewDateTime(pFso.TRAIN_ENTER_3) ? "" : pFso.TRAIN_ENTER_3.ToString(datePattern);
        this.lbStuTrainLeave3.Value = DateTimeHelper.fnIsNewDateTime(pFso.TRAIN_LEAVE_3) ? "" : pFso.TRAIN_LEAVE_3.ToString(datePattern);
        this.lbStuTrainEnter4.Value = DateTimeHelper.fnIsNewDateTime(pFso.TRAIN_ENTER_4) ? "" : pFso.TRAIN_ENTER_4.ToString(datePattern);
        this.lbStuTrainLeave4.Value = DateTimeHelper.fnIsNewDateTime(pFso.TRAIN_LEAVE_4) ? "" : pFso.TRAIN_LEAVE_4.ToString(datePattern);
        this.lbStuTrainEnter5.Value = DateTimeHelper.fnIsNewDateTime(pFso.TRAIN_ENTER_5) ? "" : pFso.TRAIN_ENTER_5.ToString(datePattern);
        this.lbStuTrainLeave5.Value = DateTimeHelper.fnIsNewDateTime(pFso.TRAIN_LEAVE_5) ? "" : pFso.TRAIN_LEAVE_5.ToString(datePattern);
        this.lbStuTrainEnter6.Value = DateTimeHelper.fnIsNewDateTime(pFso.TRAIN_ENTER_6) ? "" : pFso.TRAIN_ENTER_6.ToString(datePattern);
        this.lbStuTrainLeave6.Value = DateTimeHelper.fnIsNewDateTime(pFso.TRAIN_LEAVE_6) ? "" : pFso.TRAIN_LEAVE_6.ToString(datePattern);
        this.lbStuTrainEnter7.Value = DateTimeHelper.fnIsNewDateTime(pFso.TRAIN_ENTER_7) ? "" : pFso.TRAIN_ENTER_7.ToString(datePattern);
        this.lbStuTrainLeave7.Value = DateTimeHelper.fnIsNewDateTime(pFso.TRAIN_LEAVE_7) ? "" : pFso.TRAIN_LEAVE_7.ToString(datePattern);
        this.lbStuTrainEnter8.Value = DateTimeHelper.fnIsNewDateTime(pFso.TRAIN_ENTER_8) ? "" : pFso.TRAIN_ENTER_8.ToString(datePattern);
        this.lbStuTrainLeave8.Value = DateTimeHelper.fnIsNewDateTime(pFso.TRAIN_LEAVE_8) ? "" : pFso.TRAIN_LEAVE_8.ToString(datePattern);
        this.lbStuKm1Enter.Value = DateTimeHelper.fnIsNewDateTime(pFso.KM1_ENTER) ? "" : pFso.KM1_ENTER.ToString(datePattern);
        this.lbStuKm2Enter.Value = DateTimeHelper.fnIsNewDateTime(pFso.KM2_ENTER) ? "" : pFso.KM2_ENTER.ToString(datePattern);
        this.lbStuKm3Enter.Value = DateTimeHelper.fnIsNewDateTime(pFso.KM3_ENTER) ? "" : pFso.KM3_ENTER.ToString(datePattern);
        this.lbKM23IN9ENTER.Value = DateTimeHelper.fnIsNewDateTime(pFso.KM2_3IN9_ENTER) ? "" : pFso.KM2_3IN9_ENTER.ToString(datePattern);
        this.lbStuTrainEndDate.Value = DateTimeHelper.fnIsNewDateTime(pFso.TRAIN_END_DATE) ? "" : pFso.TRAIN_END_DATE.ToString(datePattern);
        

        this.ddlStatue.SelectedValue = pFso.STATUE.ToString();

        this.btnSave.Enabled = true;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        FpStudentObject pFso = ViewState[typeof(FpStudentObject).Name] as FpStudentObject;

        Random random = new Random();
            pFso.LESSON_ENTER_1 = DateTimeHelper.fnParseDateTime(this.lbStuLessonEnter1.Value, default(DateTime));
            pFso.LESSON_LEAVE_1 = DateTimeHelper.fnParseDateTime(this.lbStuLessonLeave1.Value, default(DateTime));


            pFso.LESSON_ENTER_2 = DateTimeHelper.fnParseDateTime(this.lbStuLessonEnter2.Value, default(DateTime));
            pFso.LESSON_LEAVE_2 = DateTimeHelper.fnParseDateTime(this.lbStuLessonLeave2.Value, default(DateTime));

            pFso.TRAIN_ENTER_1 = DateTimeHelper.fnParseDateTime(this.lbStuTrainEnter1.Value, default(DateTime));
            pFso.TRAIN_LEAVE_1 = DateTimeHelper.fnParseDateTime(this.lbStuTrainLeave1.Value, default(DateTime));

            pFso.TRAIN_ENTER_2 = DateTimeHelper.fnParseDateTime(this.lbStuTrainEnter2.Value, default(DateTime));
            pFso.TRAIN_LEAVE_2 = DateTimeHelper.fnParseDateTime(this.lbStuTrainLeave2.Value, default(DateTime));

            pFso.TRAIN_ENTER_3 = DateTimeHelper.fnParseDateTime(this.lbStuTrainEnter3.Value, default(DateTime));
            pFso.TRAIN_LEAVE_3 = DateTimeHelper.fnParseDateTime(this.lbStuTrainLeave3.Value, default(DateTime));

            pFso.TRAIN_ENTER_4 = DateTimeHelper.fnParseDateTime(this.lbStuTrainEnter4.Value, default(DateTime));
            pFso.TRAIN_LEAVE_4 = DateTimeHelper.fnParseDateTime(this.lbStuTrainLeave4.Value, default(DateTime));

            pFso.TRAIN_ENTER_5 = DateTimeHelper.fnParseDateTime(this.lbStuTrainEnter5.Value, default(DateTime));
            pFso.TRAIN_LEAVE_5 = DateTimeHelper.fnParseDateTime(this.lbStuTrainLeave5.Value, default(DateTime));

            pFso.TRAIN_ENTER_6 = DateTimeHelper.fnParseDateTime(this.lbStuTrainEnter6.Value, default(DateTime));
            pFso.TRAIN_LEAVE_6 = DateTimeHelper.fnParseDateTime(this.lbStuTrainLeave6.Value, default(DateTime));

            pFso.TRAIN_ENTER_7 = DateTimeHelper.fnParseDateTime(this.lbStuTrainEnter7.Value, default(DateTime));
            pFso.TRAIN_LEAVE_7 = DateTimeHelper.fnParseDateTime(this.lbStuTrainLeave7.Value, default(DateTime));

            pFso.TRAIN_ENTER_8 = DateTimeHelper.fnParseDateTime(this.lbStuTrainEnter8.Value, default(DateTime));
            pFso.TRAIN_LEAVE_8 = DateTimeHelper.fnParseDateTime(this.lbStuTrainLeave8.Value, default(DateTime));


            pFso.KM1_ENTER = DateTimeHelper.fnParseDateTime(this.lbStuKm1Enter.Value, default(DateTime));

            pFso.KM2_ENTER = DateTimeHelper.fnParseDateTime(this.lbStuKm2Enter.Value, default(DateTime));

            pFso.KM3_ENTER = DateTimeHelper.fnParseDateTime(this.lbStuKm3Enter.Value, default(DateTime));

            pFso.KM2_3IN9_ENTER = DateTimeHelper.fnParseDateTime(this.lbKM23IN9ENTER.Value, default(DateTime));


            pFso.TRAIN_END_DATE = DateTimeHelper.fnParseDateTime(this.lbStuTrainEndDate.Value, default(DateTime));

            pFso.STATUE = Convert.ToInt32(ddlStatue.SelectedValue);
       
        if (SimpleOrmOperator.Update(pFso))
        {
            WebTools.Alert("学员信息保存成功");
        }
        else {
            return;
        }

    }
}
