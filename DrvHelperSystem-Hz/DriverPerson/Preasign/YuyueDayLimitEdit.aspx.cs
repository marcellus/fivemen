using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DrvHelperSystemBLL.DriverPerson.Model;
using FT.DAL.Orm;
using FT.Commons.Tools;
using FT.Web.Tools;

public partial class DriverPerson_Preasign_YuyueDayLimitEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.Params["id"] != null)
            {
                YuyueDayLimit entity = SimpleOrmOperator.Query<YuyueDayLimit>(Convert.ToInt32(Request.Params["id"]));
                WebFormHelper.SetDataToForm(this, entity);
            }
        }
    }
    protected void btnSure_Click(object sender, EventArgs e)
    {
        YuyueDayLimit entity = new YuyueDayLimit();
        WebFormHelper.GetDataFromForm(this, entity);
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
        else {
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
