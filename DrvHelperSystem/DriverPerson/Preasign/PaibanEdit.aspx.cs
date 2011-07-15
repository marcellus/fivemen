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

public partial class DriverPreson_Preasign_PaibanEdit : AuthenticatedPage
{


    private static string VIEWSTATUE_LIMITS = "listLimits";
    private static string VIEWSTATUE_WEEKRECORD = "weekRecord";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           // ViewState
            DictOperator.BindDropDownList("考试地点", this.cbKsdd);
            DictOperator.BindDropDownList("考试场次", this.cbKscc);
            DepartMentOperator.BindNick(this.cbSchool, "驾校");
            this.InitTableControls();
            if (Request.Params["id"] != null)
            {
                WeekRecord entity = WeekRecordOperator.Get(Convert.ToInt32(Request.Params["id"]));
                //weekRocord = WeekRecordOperator.Get(Convert.ToInt32(Request.Params["id"]));
                this.InitWeekRecord(entity);
                string querySql = string.Format("where I_WEEK_NUM={0}", entity.WeekNum);
                ArrayList listLimits = SimpleOrmOperator.QueryConditionList<YuyueDayLimit>(querySql);
                ViewState[VIEWSTATUE_LIMITS] = listLimits;
                ViewState[VIEWSTATUE_WEEKRECORD] = entity;
            }
        }
    }




    private void InitWeekRecord(WeekRecord week)
    {
        string datestr = "";
        if (week.Id <= 0)
        {
            datestr = this.txtDate.Value;
            ViewState[VIEWSTATUE_LIMITS] = new ArrayList();
            ViewState[VIEWSTATUE_WEEKRECORD] = new WeekRecord();
           // return;
        }
        else
        {
            datestr = week.WeekRange.Substring(0, week.WeekRange.IndexOf('至'));
        }
        DateTime begin = DateTimeHelper.GetMonday(DateTime.Parse(datestr));
        this.txtDate.Value = datestr;
        for (int i = 0; i < 7; i++)
        {
            this.Table1.Rows[i + 2].Cells[0].Text = this.GetChineseXq(i + 1) + "(" + begin.AddDays(i).ToString("yyyy-MM-dd") + ")";
        }
        this.txtxq1km1zs.Text = week.Week1km1Num.ToString();
        this.Table1.Rows[2].Cells[2].Text=week.Week1km1fp == null ? "&nbsp;" : week.Week1km1fp.ToString();
        this.txtxq1km2zs.Text=week.Week1km2Num.ToString();
        this.Table1.Rows[2].Cells[4].Text = week.Week1km2fp == null ? "&nbsp;" : week.Week1km2fp.ToString();
        this.txtxq1km3zs.Text = week.Week1km3Num .ToString();
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
                this.Table1.Rows[i + 2].Cells[j+1].ToolTip = j.ToString();
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
            DateTime begin=DateTimeHelper.GetMonday(DateTime.Parse(date));
            for (int i = 0; i < 7; i++)
            {
                this.Table1.Rows[i + 2].Cells[0].Text = this.GetChineseXq(i+1)+"("+begin.AddDays(i).ToString("yyyy-MM-dd")+")";
            }
            this.InitWeekRecord(WeekRecordOperator.GetByWeekNum(DateTimeHelper.GetWeekOfYear(begin),begin.ToShortDateString()));
            
        }

    }

    public  string GetChineseXq(int i)
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


    protected void ImageButton_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btn=sender as ImageButton;
        TableRow row = btn.Parent.Parent as TableRow;
        TableCell cell = btn.Parent as TableCell;
        int i = int.Parse(cell.ToolTip);
        int rownum = int.Parse(cell.CssClass);
        if (btn.ToolTip == "重新分配")
        {
           // row.
            row.Cells[i + 2].Text="";
            ArrayList limits = ViewState[VIEWSTATUE_LIMITS] as ArrayList ;
            ArrayList removeLimits = new ArrayList();
            foreach (object obj in limits) {
                YuyueLimit limit = obj as YuyueLimit;
                int km = (i + 2) / 2;
                int datyOfWeek = rownum - 1;
                if (limit.DayOfWeek == datyOfWeek && limit.Km == km) {
                    removeLimits.Add(obj);
                }
            }
            foreach (object obj in removeLimits) {
                limits.Remove(obj);
            }
            ViewState[VIEWSTATUE_LIMITS] = limits;
            //row.Cells[i + 2].Controls.Clear();
            //string s = "";
        }
        if (btn.ToolTip == "添加分配")
        {
            //int count=row.Cells[i + 2].Controls.Count;
            if (this.hidRowOld.Value!="-1"&&this.hidColOld.Value != "-1")
            {
                int j = int.Parse(this.hidColOld.Value);
                int m = int.Parse(this.hidRowOld.Value);
                this.Table1.Rows[m].Cells[j + 2].BackColor = System.Drawing.Color.White;
            }
            this.hidColNew.Value = i.ToString();
            this.hidRowNew.Value = rownum.ToString();
            this.hidColOld.Value = i.ToString();
            this.hidRowOld.Value = rownum.ToString();
            if (this.hidColNew.Value != "-1")
            {
                int k= int.Parse(this.hidColNew.Value);
                row.Cells[k + 2].BackColor = System.Drawing.Color.Red;
            }
           
           
           
        }
    }
    protected void lbtn_Click(object sender, EventArgs e)
    {
        if (this.hidRowOld.Value != "-1" && this.hidColOld.Value != "-1")
        {
            int j = int.Parse(this.hidColOld.Value);
            int m = int.Parse(this.hidRowOld.Value);
            if (this.GetSl(this.txtNum) > 0)
            {
               // this.Table1.Rows[m].Cells[j + 2].Text += "<br/>" + this.cbKsdd.SelectedItem.Value + ":" +
               //        this.cbKsdd.SelectedItem.Text + ";" + this.cbKscc.SelectedItem.Value
               //        + ":" + this.cbKscc.SelectedItem.Text + ";"
               //        + this.cbSchool.SelectedItem.Value + ":" + this.cbSchool.SelectedItem.Text + ";" + this.txtNum.Text.Trim();
                string context = string.Format("<br/>{0}({1})",this.cbSchool.SelectedItem.Text,this.txtNum.Text.Trim());
                this.Table1.Rows[m].Cells[j + 2].Text += context;
                int km=(j+2)/2;
                int datyOfWeek=m-1;

                WeekRecord weekRecord=ViewState[VIEWSTATUE_WEEKRECORD] as WeekRecord;
                ArrayList limits = ViewState[VIEWSTATUE_LIMITS] as ArrayList;
                YuyueLimit tempLimit = new YuyueLimit();
                tempLimit.DayOfWeek = datyOfWeek;
                tempLimit.Km = km;
                tempLimit.WeekNum = weekRecord.WeekNum;
                tempLimit.Ksdd = this.cbKsdd.SelectedItem.Text;
                tempLimit.KsddCode =this.cbKsdd.SelectedItem.Value;
                tempLimit.Kscc = this.cbKscc.SelectedItem.Text;
                tempLimit.KsccCode = this.cbKscc.SelectedItem.Value;
                tempLimit.SchoolName = this.cbSchool.SelectedItem.Text;
                tempLimit.SchoolCode = this.cbSchool.SelectedItem.Value;
                tempLimit.Total = int.Parse(this.txtNum.Text.Trim());
                limits.Add(tempLimit);
                ViewState[VIEWSTATUE_LIMITS] = limits;
            }
            else
            {
                WebTools.Alert("分配的数量不得为0！");
            }
        }
    }

    public static int GetWeekOfYear(DateTime date)
    {
        DateTime curDay = Convert.ToDateTime(date);
        int firstdayofweek = Convert.ToInt32(Convert.ToDateTime(curDay.Year.ToString() + "- " + "1-1 ").DayOfWeek);
        int days = curDay.DayOfYear;
        int daysOutOneWeek = days - (7 - firstdayofweek);
        if (daysOutOneWeek <= 0)
        {
            return 1;
        }
        else
        {
            int weeks = daysOutOneWeek / 7;
            if (daysOutOneWeek % 7 != 0)
                weeks++;
            return weeks + 1;
        }

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        WeekRecord week = new WeekRecord();
        DateTime date = Convert.ToDateTime(this.txtDate.Value);
        ArrayList weeks = SimpleOrmOperator.QueryConditionList<WeekRecord>(" where i_week_num="+GetWeekOfYear(date));
        if (weeks.Count > 0)
        {
            week = weeks[0] as WeekRecord;
        }
        else
        {
            week.Checked = 0;
        }
        if (week.Checked == 0)
        {
            week.CheckOperator = this.Operator.OperatorName;

            week.WeekRange = DateTimeHelper.GetMonday(date).ToShortDateString() + "至" + DateTimeHelper.GetSunday(date).ToShortDateString();
            week.WeekNum = GetWeekOfYear(date);
            week.Week1km1Num = GetSl(this.txtxq1km1zs);
            week.Week1km1fp = this.Table1.Rows[2].Cells[2].Text;
            week.Week1km2Num = GetSl(this.txtxq1km2zs);
            week.Week1km2fp = this.Table1.Rows[2].Cells[4].Text;
            week.Week1km3Num = GetSl(this.txtxq1km3zs);
            week.Week1km3fp = this.Table1.Rows[2].Cells[6].Text;

            week.Week2km1Num = GetSl(this.txtxq2km1zs);
            week.Week2km1fp = this.Table1.Rows[3].Cells[2].Text;
            week.Week2km2Num = GetSl(this.txtxq2km2zs);
            week.Week2km2fp = this.Table1.Rows[3].Cells[4].Text;
            week.Week2km3Num = GetSl(this.txtxq2km3zs);
            week.Week2km3fp = this.Table1.Rows[3].Cells[6].Text;

            week.Week3km1Num = GetSl(this.txtxq3km1zs);
            week.Week3km1fp = this.Table1.Rows[4].Cells[2].Text;
            week.Week3km2Num = GetSl(this.txtxq3km2zs);
            week.Week3km2fp = this.Table1.Rows[4].Cells[4].Text;
            week.Week3km3Num = GetSl(this.txtxq3km3zs);
            week.Week3km3fp = this.Table1.Rows[4].Cells[6].Text;

            week.Week4km1Num = GetSl(this.txtxq4km1zs);
            week.Week4km1fp = this.Table1.Rows[5].Cells[2].Text;
            week.Week4km2Num = GetSl(this.txtxq4km2zs);
            week.Week4km2fp = this.Table1.Rows[5].Cells[4].Text;
            week.Week4km3Num = GetSl(this.txtxq4km3zs);
            week.Week4km3fp = this.Table1.Rows[5].Cells[6].Text;

            week.Week5km1Num = GetSl(this.txtxq5km1zs);
            week.Week5km1fp = this.Table1.Rows[6].Cells[2].Text;
            week.Week5km2Num = GetSl(this.txtxq5km2zs);
            week.Week5km2fp = this.Table1.Rows[6].Cells[4].Text;
            week.Week5km3Num = GetSl(this.txtxq5km3zs);
            week.Week5km3fp = this.Table1.Rows[6].Cells[6].Text;

            week.Week6km1Num = GetSl(this.txtxq6km1zs);
            week.Week6km1fp = this.Table1.Rows[7].Cells[2].Text;
            week.Week6km2Num = GetSl(this.txtxq6km2zs);
            week.Week6km2fp = this.Table1.Rows[7].Cells[4].Text;
            week.Week6km3Num = GetSl(this.txtxq6km3zs);
            week.Week6km3fp = this.Table1.Rows[7].Cells[6].Text;

            week.Week7km1Num = GetSl(this.txtxq7km1zs);
            week.Week7km1fp = this.Table1.Rows[8].Cells[2].Text;
            week.Week7km2Num = GetSl(this.txtxq7km2zs);
            week.Week7km2fp = this.Table1.Rows[8].Cells[4].Text;
            week.Week7km3Num = GetSl(this.txtxq7km3zs);
            week.Week7km3fp = this.Table1.Rows[8].Cells[6].Text;



          
        }
        ArrayList limits = ViewState[VIEWSTATUE_LIMITS] as ArrayList;
        if (week.Checked == 0 && week.Id > 0)
        {
            //WeekRecordOperator.Update(week);
            
            WeekRecordOperator.Update(week, limits);
            WebTools.Alert("保存成功！");
        }
        else if(week.Id<1)
        {
            WeekRecordOperator.Create(week,limits);
            WebTools.Alert("保存成功！");
        }

        if (week.Checked == 1 && week.Id > 0)
        {
           
            WebTools.Alert("已审核过的排班无法进行更改！");
        }
    }

    private int  GetSl(TextBox txt)
    {
        int result = 0;
        try
        {
            result = Convert.ToInt32(txt.Text.Trim());
        }
        catch(Exception ex)
        {
        }
        return result;
    }
}
