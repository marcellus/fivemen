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
using FT.Web;
using FT.Web.Tools;
using FT.DAL.Orm;

public partial class DriverPreson_Preasign_PaibanCheck : FT.Web.AuthenticatedPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
          
            this.InitTableControls();
            if (Request.Params["id"] != null)
            {
                WeekRecord entity = WeekRecordOperator.Get(Convert.ToInt32(Request.Params["id"]));
                this.InitWeekRecord(entity);
            }
        }
    }

    private void InitWeekRecord(WeekRecord week)
    {
        string datestr ="";
        if (week.Id <= 0)
        {
            datestr=this.txtDate.Value;
           // return;
        }
        else{
        datestr= week.WeekRange.Substring(0, week.WeekRange.IndexOf('至'));
        }
        DateTime begin = DateTimeHelper.GetMonday(DateTime.Parse(datestr));
        this.txtDate.Value = datestr;
        for (int i = 0; i < 7; i++)
        {
            this.Table1.Rows[i + 2].Cells[0].Text = this.GetChineseXq(i + 1) + "(" + begin.AddDays(i).ToString("yyyy-MM-dd") + ")";
        }
        this.txtxq1km1zs.Text = week.Week1km1Num.ToString();
        this.Table1.Rows[2].Cells[2].Text = week.Week1km1fp == null ? "&nbsp;" : week.Week1km1fp.ToString();
        this.txtxq1km2zs.Text = week.Week1km2Num.ToString();
        this.Table1.Rows[2].Cells[4].Text = week.Week1km2fp == null ? "&nbsp;" : week.Week1km2fp.ToString();
        this.txtxq1km3zs.Text = week.Week1km3Num.ToString();
        this.Table1.Rows[2].Cells[6].Text = week.Week1km3fp == null ? "&nbsp;" : week.Week1km3fp.ToString();

        this.txtxq2km1zs.Text = week.Week2km1Num.ToString();
        this.Table1.Rows[3].Cells[2].Text = week.Week2km1fp == null ? "&nbsp;" : week.Week2km1fp.ToString();
        this.txtxq2km2zs.Text = week.Week2km2Num.ToString();
        this.Table1.Rows[3].Cells[4].Text = week.Week2km2fp == null ? "&nbsp;" : week.Week2km2fp.ToString();
        this.txtxq2km3zs.Text = week.Week2km3Num.ToString();
        this.Table1.Rows[3].Cells[6].Text = week.Week2km3fp == null ? "&nbsp;" : week.Week2km3fp.ToString();

        this.txtxq3km1zs.Text = week.Week3km1Num.ToString();
        this.Table1.Rows[4].Cells[2].Text = week.Week3km1fp == null ? "&nbsp;" : week.Week3km1fp.ToString();
        this.txtxq3km2zs.Text = week.Week3km2Num.ToString();
        this.Table1.Rows[4].Cells[4].Text = week.Week3km2fp == null ? "&nbsp;" : week.Week3km2fp.ToString();
        this.txtxq3km3zs.Text = week.Week3km3Num.ToString();
        this.Table1.Rows[4].Cells[6].Text = week.Week3km3fp == null ? "&nbsp;" : week.Week3km3fp.ToString();

        this.txtxq4km1zs.Text = week.Week4km1Num.ToString();
        this.Table1.Rows[5].Cells[2].Text = week.Week4km1fp == null ? "&nbsp;" : week.Week4km1fp.ToString();
        this.txtxq4km2zs.Text = week.Week4km2Num.ToString();
        this.Table1.Rows[5].Cells[4].Text = week.Week4km2fp == null ? "&nbsp;" : week.Week4km2fp.ToString();
        this.txtxq4km3zs.Text = week.Week4km3Num.ToString();
        this.Table1.Rows[5].Cells[6].Text = week.Week4km3fp == null ? "&nbsp;" : week.Week4km3fp.ToString();

        this.txtxq5km1zs.Text = week.Week5km1Num.ToString();
        this.Table1.Rows[6].Cells[2].Text = week.Week5km1fp == null ? "&nbsp;" : week.Week5km1fp.ToString();
        this.txtxq5km2zs.Text = week.Week5km2Num.ToString();
        this.Table1.Rows[6].Cells[4].Text = week.Week5km2fp == null ? "&nbsp;" : week.Week5km2fp.ToString();
        this.txtxq5km3zs.Text = week.Week5km3Num.ToString();
        this.Table1.Rows[6].Cells[6].Text = week.Week5km3fp == null ? "&nbsp;" : week.Week5km3fp.ToString();

        this.txtxq6km1zs.Text = week.Week6km1Num.ToString();
        this.Table1.Rows[7].Cells[2].Text = week.Week6km1fp == null ? "&nbsp;" : week.Week6km1fp.ToString();
        this.txtxq6km2zs.Text = week.Week6km2Num.ToString();
        this.Table1.Rows[7].Cells[4].Text = week.Week6km2fp == null ? "&nbsp;" : week.Week6km2fp.ToString();
        this.txtxq6km3zs.Text = week.Week6km3Num.ToString();
        this.Table1.Rows[7].Cells[6].Text = week.Week6km3fp == null ? "&nbsp;" : week.Week6km3fp.ToString();

        this.txtxq7km1zs.Text = week.Week7km1Num.ToString();
        this.Table1.Rows[8].Cells[2].Text = week.Week7km1fp == null ? "&nbsp;" : week.Week7km1fp.ToString();
        this.txtxq7km2zs.Text = week.Week7km2Num.ToString();
        this.Table1.Rows[8].Cells[4].Text = week.Week7km2fp == null ? "&nbsp;" : week.Week7km2fp.ToString();
        this.txtxq7km3zs.Text = week.Week7km3Num.ToString();
        this.Table1.Rows[8].Cells[6].Text = week.Week7km3fp == null ? "&nbsp;" : week.Week7km3fp.ToString();




    }


    private void InitTableControls()
    {

        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                this.Table1.Rows[i + 2].Cells[j + 1].ToolTip = j.ToString();
                this.Table1.Rows[i + 2].Cells[j + 1].CssClass = (i + 2).ToString();
            }
        }
        for (int i = 0; i < 7; i++)
        {
            //this.Table1.Rows[i + 2].Cells[1].Attributes.Add("onclick", "alert("+i+");");
            //this.Table1.
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string date = this.txtDate.Value.Trim();
        if (date.Length > 0)
        {
            DateTime begin = DateTimeHelper.GetMonday(DateTime.Parse(date));
            for (int i = 0; i < 7; i++)
            {
                this.Table1.Rows[i + 2].Cells[0].Text = this.GetChineseXq(i + 1) + "(" + begin.AddDays(i).ToString("yyyy-MM-dd") + ")";
            }

            this.InitWeekRecord(WeekRecordOperator.GetByWeekNum(DateTimeHelper.GetWeekOfYear(begin),begin.ToShortDateString()));

        }

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        DateTime date = Convert.ToDateTime(this.txtDate.Value);
        DateTime begin = DateTimeHelper.GetMonday(date);
        WeekRecord week = WeekRecordOperator.GetByWeekNum(DateTimeHelper.GetWeekOfYear(date), begin.ToShortDateString());
        if (week.Id <= 0)
        {
            WebTools.Alert("没有"+this.txtDate.Value+"本期的排班！");
            return;
        }
        if (week.Id>0&&week.Checked == 0)
        {
            week.Checked = 1;
            week.CheckOperator = this.Operator.OperatorName;
            SimpleOrmOperator.Update(week);
            //WeekRecordOperator.Update(week);
            WebTools.Alert("审核通过！");




        }
        
        else
        {
            WebTools.Alert("已审核的记录无法审核！");
        }
    }

    public string GetChineseXq(int i)
    {
        switch (i)
        {
            case 1:
                return "星期一";
            case 2:
                return "星期二";
            case 3:
                return "星期三";
            case 4:
                return "星期四";
            case 5:
                return "星期五";
            case 6:
                return "星期六";
            case 7:
                return "星期日";
            default:
                return "未知星期";
        }
    }
}
