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
using FT.Web.Tools;

public partial class FpSystem_FpHelper_FPConfigEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            for (int hh = 0; hh < 24; hh++) {
               // ListItem li = new ListItem(hh.ToString(),hh.ToString());
                ddlTrain1EnterFromHH.Items.Add(new ListItem(hh.ToString(), hh.ToString()));
                ddlTrain1EnterToHH.Items.Add(new ListItem(hh.ToString(), hh.ToString()));
                ddlTrain2EnterFromHH.Items.Add(new ListItem(hh.ToString(), hh.ToString()));
                ddlTrain2EnterToHH.Items.Add(new ListItem(hh.ToString(), hh.ToString()));
                ddlTrain3EnterFromHH.Items.Add(new ListItem(hh.ToString(), hh.ToString()));
                ddlTrain3EnterToHH.Items.Add(new ListItem(hh.ToString(), hh.ToString()));

                ddlTrain1LeaveHH.Items.Add(new ListItem(hh.ToString(), hh.ToString()));
                ddlTrain2LeaveHH.Items.Add(new ListItem(hh.ToString(), hh.ToString()));
                ddlTrain3LeaveHH.Items.Add(new ListItem(hh.ToString(), hh.ToString()));

                ddlLessonEnter1HH.Items.Add(new ListItem(hh.ToString(), hh.ToString()));
                ddlLessonEnter2HH.Items.Add(new ListItem(hh.ToString(), hh.ToString()));
            }

            for (int mm = 0; mm < 60; mm++) {
                ddlTrain1EnterFromMM.Items.Add(new ListItem(mm.ToString(), mm.ToString()));
                ddlTrain1EnterToMM.Items.Add(new ListItem(mm.ToString(), mm.ToString()));
                ddlTrain2EnterFromMM.Items.Add(new ListItem(mm.ToString(), mm.ToString()));
                ddlTrain2EnterToMM.Items.Add(new ListItem(mm.ToString(), mm.ToString()));
                ddlTrain3EnterFromMM.Items.Add(new ListItem(mm.ToString(), mm.ToString()));
                ddlTrain3EnterToMM.Items.Add(new ListItem(mm.ToString(), mm.ToString()));

                ddlTrain1LeaveMM.Items.Add(new ListItem(mm.ToString(), mm.ToString()));
                ddlTrain2LeaveMM.Items.Add(new ListItem(mm.ToString(), mm.ToString()));
                ddlTrain3LeaveMM.Items.Add(new ListItem(mm.ToString(), mm.ToString()));
                ddlLessonEnter1MM.Items.Add(new ListItem(mm.ToString(), mm.ToString()));
                ddlLessonEnter2MM.Items.Add(new ListItem(mm.ToString(), mm.ToString()));
            }

            FPConfig config = FPConfig.GetCurrConfig();
            tbFp_lesson_interval.Text = config.FP_LESSON_INTERVAL.ToString();
            tbFp_train_interval.Text = config.FP_TRAIN_INTERVAL.ToString();

            ddlLessonEnter1HH.SelectedIndex = config.FP_LESSON_ENTER_1_HH;
            ddlLessonEnter1MM.SelectedIndex = config.FP_LESSON_ENTER_1_MM;
            ddlLessonEnter2HH.SelectedIndex = config.FP_LESSON_ENTER_2_HH;
            ddlLessonEnter2MM.SelectedIndex = config.FP_LESSON_ENTER_2_MM;



            ddlTrain1EnterFromHH.SelectedIndex = config.FP_TRAIN_1_ENTER_FROM_HH;
            ddlTrain1EnterFromMM.SelectedIndex = config.FP_TRAIN_1_ENTER_FROM_MM;
            ddlTrain1EnterToHH.SelectedIndex = config.FP_TRAIN_1_ENTER_TO_HH;
            ddlTrain1EnterToMM.SelectedIndex = config.FP_TRAIN_1_ENTER_TO_MM;


            ddlTrain2EnterFromHH.SelectedIndex = config.FP_TRAIN_2_ENTER_FROM_HH;
            ddlTrain2EnterFromMM.SelectedIndex = config.FP_TRAIN_2_ENTER_FROM_MM;
            ddlTrain2EnterToHH.SelectedIndex = config.FP_TRAIN_2_ENTER_TO_HH;
            ddlTrain2EnterToMM.SelectedIndex = config.FP_TRAIN_2_ENTER_TO_MM;


            ddlTrain3EnterFromHH.SelectedIndex = config.FP_TRAIN_3_ENTER_FROM_HH;
            ddlTrain3EnterFromMM.SelectedIndex = config.FP_TRAIN_3_ENTER_FROM_MM;
            ddlTrain3EnterToHH.SelectedIndex = config.FP_TRAIN_3_ENTER_TO_HH;
            ddlTrain3EnterToMM.SelectedIndex = config.FP_TRAIN_3_ENTER_TO_MM;

            ddlTrain1LeaveHH.SelectedIndex = config.FP_TRAIN_1_LEAVE_HH;
            ddlTrain1LeaveMM.SelectedIndex = config.FP_TRAIN_1_LEAVE_MM;
            ddlTrain2LeaveHH.SelectedIndex = config.FP_TRAIN_2_LEAVE_HH;
            ddlTrain2LeaveMM.SelectedIndex = config.FP_TRAIN_2_LEAVE_MM;
            ddlTrain3LeaveHH.SelectedIndex = config.FP_TRAIN_3_LEAVE_HH;
            ddlTrain3LeaveMM.SelectedIndex = config.FP_TRAIN_3_LEAVE_MM;
        }

    }


    protected void btnEdit_Click(object sender, EventArgs e)
    {
        FPConfig config = FPConfig.GetCurrConfig();
        config.FP_LESSON_INTERVAL = StringHelper.fnFormatNullOrBlankInt(tbFp_lesson_interval.Text, 1);
        config.FP_TRAIN_INTERVAL = StringHelper.fnFormatNullOrBlankInt(tbFp_train_interval.Text, 1);
        config.FP_LESSON_ENTER_1_HH = ddlLessonEnter1HH.SelectedIndex;
        config.FP_LESSON_ENTER_1_MM = ddlLessonEnter1MM.SelectedIndex;
        config.FP_LESSON_ENTER_2_HH = ddlLessonEnter2HH.SelectedIndex;
        config.FP_LESSON_ENTER_2_MM = ddlLessonEnter2MM.SelectedIndex;
        config.FP_TRAIN_1_ENTER_FROM_HH = ddlTrain1EnterFromHH.SelectedIndex;
        config.FP_TRAIN_1_ENTER_FROM_MM = ddlTrain1EnterFromMM.SelectedIndex;
        config.FP_TRAIN_1_ENTER_TO_HH = ddlTrain1EnterToHH.SelectedIndex;
        config.FP_TRAIN_1_ENTER_TO_MM = ddlTrain1EnterToMM.SelectedIndex;

        config.FP_TRAIN_2_ENTER_FROM_HH = ddlTrain2EnterFromHH.SelectedIndex;
        config.FP_TRAIN_2_ENTER_FROM_MM = ddlTrain2EnterFromMM.SelectedIndex;
        config.FP_TRAIN_2_ENTER_TO_HH = ddlTrain2EnterToHH.SelectedIndex;
        config.FP_TRAIN_2_ENTER_TO_MM = ddlTrain2EnterToMM.SelectedIndex;

        config.FP_TRAIN_3_ENTER_FROM_HH = ddlTrain3EnterFromHH.SelectedIndex;
        config.FP_TRAIN_3_ENTER_FROM_MM = ddlTrain3EnterFromMM.SelectedIndex;
        config.FP_TRAIN_3_ENTER_TO_HH = ddlTrain3EnterToHH.SelectedIndex;
        config.FP_TRAIN_3_ENTER_TO_MM = ddlTrain3EnterToMM.SelectedIndex;

        config.FP_TRAIN_1_LEAVE_HH = ddlTrain1LeaveHH.SelectedIndex;
        config.FP_TRAIN_1_LEAVE_MM = ddlTrain1LeaveMM.SelectedIndex;
        config.FP_TRAIN_2_LEAVE_HH = ddlTrain2LeaveHH.SelectedIndex;
        config.FP_TRAIN_2_LEAVE_MM = ddlTrain2LeaveMM.SelectedIndex;
        config.FP_TRAIN_3_LEAVE_HH = ddlTrain3LeaveHH.SelectedIndex;
        config.FP_TRAIN_3_LEAVE_MM = ddlTrain3LeaveMM.SelectedIndex;


        if (SimpleOrmOperator.Update(config))
        {
            WebTools.Alert("配置修改成功");
        }
        else {
            WebTools.Alert("配置修改失败");
        }
        
    }
}
