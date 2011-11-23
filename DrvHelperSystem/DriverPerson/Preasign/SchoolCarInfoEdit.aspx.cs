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
using FT.Web.Tools;
using FT.Web;
using FT.Commons.Tools;

public partial class DriverPerson_Preasign_SchoolCarInfoEdit : FT.Web.AuthenticatedPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DepartMentOperator.Bind(this.cbDepCodeValue, "驾校");
            if (Request.Params["id"] != null)
            {
                SchoolCarInfo entity = SimpleOrmOperator.Query<SchoolCarInfo>(Convert.ToInt32(Request.Params["id"]));
                WebFormHelper.SetDataToForm(this, entity);
            }

            if (!string.IsNullOrEmpty(Request.Params["depId"])) {
                int depId = this.Operator.DeptId;
                DepartMent dep = SimpleOrmOperator.Query<DepartMent>(depId);
                cbDepCodeValue.SelectedValue = dep.DepCode;
                cbDepCodeValue.Enabled = false;
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


    protected void btnSure_Click(object sender, EventArgs e)
    {
        SchoolCarInfo entity = new SchoolCarInfo();
        WebFormHelper.GetDataFromForm(this, entity);
        entity.DepName = this.cbDepCodeValue.SelectedItem.Text;
        if (entity.Id < 0)
        {
            if (SimpleOrmOperator.Create(entity))
            {
                WebTools.Alert("添加成功！");
            }
            else
            {
                WebTools.Alert("添加失败！");

            }
        }
        else
        {
            if (SimpleOrmOperator.Update(entity))
            {
                WebTools.Alert("修改成功！");
            }
            else
            {
                WebTools.Alert("修改失败！");

            }

        }
    }
}
