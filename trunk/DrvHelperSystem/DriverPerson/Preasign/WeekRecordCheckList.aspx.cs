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
using FT.Web.Tools;

public partial class DriverPerson_Preasign_WeekRecordCheckList : FT.Web.AuthenticatedPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.ProcedurePager1.TableName = "TABLE_WEEK_RECORD";
            this.ProcedurePager1.FieldString = @"id ,
	i_week_num ,
	c_week_range ,
	c_check_operator,
    decode(i_checked,0,'未审核',1,'已审核',2,'审核不过') i_checked
	".Replace("\r\n", "").Replace("\t", "");
            this.ProcedurePager1.SortString = " order by id desc";
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (this.txtBeginDate.Value.Length > 0)
            this.ProcedurePager1.RowFilter = " i_week_num=" + GetWeekOfYear(Convert.ToDateTime(this.txtBeginDate.Value));
        else
            this.ProcedurePager1.RowFilter = "";
        this.ProcedurePager1.Changed = true;
    }
    protected void DataGrid1_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            int id = Convert.ToInt32(e.CommandArgument);
            WeekRecord record = WeekRecordOperator.Get(id);
            if (record != null && record.Checked == 1)
            {
                WebTools.Alert(this, "已审核过的数据无法删除！");
            }
            else
            {
                WeekRecordOperator.Delete(id);
                WebTools.Alert(this, "删除成功！");
                this.ProcedurePager1.Changed = true;
            }
        }
        else if (e.CommandName == "Detail")
        {
            int id = Convert.ToInt32(e.CommandArgument);
            this.Pop(id);

        }
    }

    private void Pop(int id)
    {
        string url = "PaibanCheck.aspx";
        if (id > 0)
        {
            url += "?id=" + id;
        }
        WebTools.ShowModalWindows(this, url, 1000, 750);
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
}
