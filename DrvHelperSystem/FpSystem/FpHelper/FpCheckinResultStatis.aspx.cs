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

public partial class FpSystem_FpHelper_FpCheckinResultStatis : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            qDateStart.Value = DateTime.Now.ToString("yyyy-MM-dd");
            qDateEnd.Value = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");


            DepartMentOperator.Bind2(ddlSchoolCode);
            ddlSchoolCode.Items.Insert(0, new ListItem("全部", "all"));

            DictOperator.BindDropDownList("车辆类型", ddlCarType);
            ddlCarType.Items.Insert(0, new ListItem("全部", "all"));
        }
    }



    private void QueryStudent(string startDate, string endDate)
    {
        string schoolId = ddlSchoolCode.SelectedValue;
        string carType = ddlCarType.SelectedValue;
        

           string sqlConditionFinishLesson = "where LESSON_LEAVE_2 between to_date('{0}','YYYY-MM-DD') and to_date('{1}','YYYY-MM-DD')";
            //fileName = string.Format(fileNamePattern, startDate, endDate, "已完成上课");

          string sqlConditionFinishTrain = "where TRAIN_END_DATE between to_date('{0}','YYYY-MM-DD') and to_date('{1}','YYYY-MM-DD')";
            //fileName = string.Format(fileNamePattern, startDate, endDate, "已完成入场训练");

          if (schoolId != "all")
          {
              //DepartMent depart = SimpleOrmOperator.Query<DepartMent>(schoolId);
              //string schoolCode = depart.DepCode;
              sqlConditionFinishLesson += string.Format(" and school_code='{0}' ", schoolId);
              sqlConditionFinishTrain += string.Format(" and school_code='{0}' ", schoolId);
          }

          if (carType != "all")
          {
              sqlConditionFinishLesson += string.Format(" and car_type='{0}' ", carType);
              sqlConditionFinishTrain += string.Format(" and car_type='{0}' ", carType);
          }

          int countFinishLesson = SimpleOrmOperator.QueryConditionList<FpStudentObject>(string.Format(sqlConditionFinishLesson, startDate, endDate)).Count;
          int countFinishTrain = SimpleOrmOperator.QueryConditionList<FpStudentObject>(string.Format(sqlConditionFinishTrain, startDate, endDate)).Count;


        lbCountFinishLesson.Text = countFinishLesson.ToString();
        lbCountFinishTrain.Text = countFinishTrain.ToString();

        lbStartDate.Text = startDate;
        lbEndDate.Text = endDate;

       

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string qStrDateStart = StringHelper.fnFormatNullOrBlankString(qDateStart.Value, "");
        string qStrDateEnd = StringHelper.fnFormatNullOrBlankString(qDateEnd.Value, "");
        QueryStudent(qStrDateStart,qStrDateEnd);
    }
}
