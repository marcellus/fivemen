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
using FT.Web.Tools;
using FT.DAL.Orm;
using FT.Web.Bll.YuanTuo;
using FT.Commons.Tools;

public partial class YuanTuo_TrafficExEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GobalTools.BindCity(this.cbCityCodeValue);
            if (Request.Params["id"] != null)
            {
                TrafficLimitExtendInfoEntity entity = SimpleOrmOperator.Query<TrafficLimitExtendInfoEntity>(Convert.ToInt32(Request.Params["id"]));
                WebFormHelper.SetDataToForm(this, entity);
                this.txtStartDateShow.Value = DateTimeHelper.DtToShortString(entity.StartDate);
                this.txtEndDateShow.Value = DateTimeHelper.DtToShortString(entity.EndDate);
            }
            else
            {
                this.txtStartDateShow.Value = DateTimeHelper.DtToShortString(System.DateTime.Now);
                this.txtEndDateShow.Value = DateTimeHelper.DtToShortString(System.DateTime.Now);
            }
        }
    }
    protected void btnSure_Click(object sender, EventArgs e)
    {
        if (this.cbCityCodeValue.SelectedIndex == 0)
        {
            return;
        }
        TrafficLimitExtendInfoEntity entity = new TrafficLimitExtendInfoEntity();

        WebFormHelper.GetDataFromForm(this, entity);
        // entity.MachineMac = FT.Commons.Web.Tools.WebToolsHelper.GetMac(entity.MachineIp);
        entity.StartDate = Convert.ToDateTime(this.txtStartDateShow.Value.ToString());
        entity.EndDate = Convert.ToDateTime(this.txtEndDateShow.Value.ToString());
        if (entity.Id < 0)
        {
            if (SimpleOrmOperator.Create(entity))
            {
                WebTools.Alert(this, "添加成功！");
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
                WebTools.Alert(this, "修改成功！");
            }
            else
            {
                WebTools.Alert("修改失败！");

            }

        }
    }
}
