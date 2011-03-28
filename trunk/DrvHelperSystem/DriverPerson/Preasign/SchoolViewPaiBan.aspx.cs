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
using FT.Web;
using FT.Web.Tools;
using FT.DAL;
using System.Text;
using FT.Commons.Tools;

public partial class DriverPerson_Preasign_SchoolViewPaiBan : AuthenticatedPage
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

    private string ComputeLink(WeekRecord week, int dayofweek, int km)
    {
        if (week.Id <= 0)
        {
            return string.Empty;
        }
        string sql = "select id,i_total,i_used_num,i_checked_num,c_kscc,c_kscc_code,c_ksdd,c_ksdd_code,c_school_name,c_school_code,date_ksrq from table_yuyue_limit "
            +" where i_week_num="+week.WeekNum+" and i_dayofweek="+dayofweek+" and i_km="+km;
        DataTable dt = DataAccessFactory.GetDataAccess().SelectDataTable(sql,"tmp");
        string depcode=this.Operator.Desp3;
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            sb.Append(dt.Rows[i][6].ToString() + ";" + dt.Rows[i][4].ToString());

            if (dt.Rows[i][9].ToString() == depcode)
            {
                sb.Append(";" + "<a href='SchoolCommitUser.aspx?id="+dt.Rows[i][0].ToString()+"' target='_blank'>" + dt.Rows[i][8].ToString() + "</a>");
            }
            else
            {
                sb.Append(";" + dt.Rows[i][8].ToString());
            }
            sb.Append("(" + dt.Rows[i][2].ToString() + "/" + dt.Rows[i][3].ToString() + ")");
            sb.Append("/" + dt.Rows[i][1].ToString());
            sb.Append("<br/>");
            
        }
        return sb.ToString();
    }

    private void InitWeekRecord(WeekRecord week)
    {
        string datestr = "";
        if (week.Id <= 0)
        {
            datestr = this.txtDate.Value;
           // return;
        }
        else
        {
            datestr = week.WeekRange.Substring(0, week.WeekRange.IndexOf('至'));
        }
        if (week.Checked != 1)
        {
            return;
        }
        DateTime begin = DateTimeHelper.GetMonday(DateTime.Parse(datestr));
        this.txtDate.Value = datestr;
        for (int i = 0; i < 7; i++)
        {
            this.Table1.Rows[i + 2].Cells[0].Text = this.GetChineseXq(i + 1) + "(" + begin.AddDays(i).ToString("yyyy-MM-dd") + ")";
        }
        this.txtxq1km1zs.Text = week.Week1km1Num.ToString();
        this.Table1.Rows[2].Cells[2].Text = this.ComputeLink(week, 1, 1);
        this.txtxq1km2zs.Text = week.Week1km2Num.ToString();
        this.Table1.Rows[2].Cells[4].Text = this.ComputeLink(week, 1, 2);
        this.txtxq1km3zs.Text = week.Week1km3Num.ToString();
        this.Table1.Rows[2].Cells[6].Text = this.ComputeLink(week, 1, 3);

        this.txtxq2km1zs.Text = week.Week2km1Num.ToString();
        this.Table1.Rows[3].Cells[2].Text = this.ComputeLink(week, 2, 1);
        this.txtxq2km2zs.Text = week.Week2km2Num.ToString();
        this.Table1.Rows[3].Cells[4].Text = this.ComputeLink(week, 2, 2);
        this.txtxq2km3zs.Text = week.Week2km3Num.ToString();
        this.Table1.Rows[3].Cells[6].Text = this.ComputeLink(week, 2, 3);

        this.txtxq3km1zs.Text = week.Week3km1Num.ToString();
        this.Table1.Rows[4].Cells[2].Text = this.ComputeLink(week, 3, 1);
        this.txtxq3km2zs.Text = week.Week3km2Num.ToString();
        this.Table1.Rows[4].Cells[4].Text = this.ComputeLink(week, 3, 2);
        this.txtxq3km3zs.Text = week.Week3km3Num.ToString();
        this.Table1.Rows[4].Cells[6].Text = this.ComputeLink(week, 3, 3);

        this.txtxq4km1zs.Text = week.Week4km1Num.ToString();
        this.Table1.Rows[5].Cells[2].Text = this.ComputeLink(week, 4, 1);
        this.txtxq4km2zs.Text = week.Week4km2Num.ToString();
        this.Table1.Rows[5].Cells[4].Text = this.ComputeLink(week, 4, 2);
        this.txtxq4km3zs.Text = week.Week4km3Num.ToString();
        this.Table1.Rows[5].Cells[6].Text = this.ComputeLink(week, 4, 3);

        this.txtxq5km1zs.Text = week.Week5km1Num.ToString();
        this.Table1.Rows[6].Cells[2].Text = this.ComputeLink(week, 5, 1);
        this.txtxq5km2zs.Text = week.Week5km2Num.ToString();
        this.Table1.Rows[6].Cells[4].Text = this.ComputeLink(week, 5, 2);
        this.txtxq5km3zs.Text = week.Week5km3Num.ToString();
        this.Table1.Rows[6].Cells[6].Text = this.ComputeLink(week,5, 3);

        this.txtxq6km1zs.Text = week.Week6km1Num.ToString();
        this.Table1.Rows[7].Cells[2].Text = this.ComputeLink(week, 6, 1);
        this.txtxq6km2zs.Text = week.Week6km2Num.ToString();
        this.Table1.Rows[7].Cells[4].Text = this.ComputeLink(week, 6, 2);
        this.txtxq6km3zs.Text = week.Week6km3Num.ToString();
        this.Table1.Rows[7].Cells[6].Text = this.ComputeLink(week, 6, 3);

        this.txtxq7km1zs.Text = week.Week7km1Num.ToString();
        this.Table1.Rows[8].Cells[2].Text = this.ComputeLink(week, 7, 1);
        this.txtxq7km2zs.Text = week.Week7km2Num.ToString();
        this.Table1.Rows[8].Cells[4].Text = this.ComputeLink(week, 7, 2);
        this.txtxq7km3zs.Text = week.Week7km3Num.ToString();
        this.Table1.Rows[8].Cells[6].Text = this.ComputeLink(week, 7, 3);




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
            WeekRecord week = WeekRecordOperator.GetByWeekNum(DateTimeHelper.GetWeekOfYear(begin),begin.ToShortDateString());
            if (week.Id <= 0||week.Checked!=1)
            {
                WebTools.Alert("找不到"+date+"的周排班表！");
                return;
            }
            this.InitWeekRecord(week);

        }
    }
}
