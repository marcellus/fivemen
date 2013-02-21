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
using FT.Web.Bll.Terminal;
using FT.Commons.Tools;
using System.Drawing;
using FT.DAL.Orm;
using FT.Web.Tools;

public partial class YuanTuo_TerminalEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GobalTools.BindCity(this.cbCityCodeValue);
            GobalTools.BindTerminalGroup(this.cbMachineGroupIdValue);
            if (Request.Params["id"] != null)
            {
                TerminalEntity entity = SimpleOrmOperator.Query<TerminalEntity>(Convert.ToInt32(Request.Params["id"]));
                WebFormHelper.SetDataToForm(this, entity);
                this.lbLastOnlineTime.Text = DateTimeHelper.DtToLongString(entity.LastOnlineTime);
                this.lbLastOutlineTime.Text = DateTimeHelper.DtToLongString(entity.LastOutlineTime);
                this.lbCurrentStatus.ForeColor = Color.Red;
                this.lbCurrentStatus.Text = string.Format("({0})",FT.Commons.Tools.WindowExHelper.CanConnectionTo(entity.MachineIp)?"在线":"不在线");
            }
            else
            {
            }
        }
    }
    protected void btnSure_Click(object sender, EventArgs e)
    {
        TerminalEntity entity = new TerminalEntity();
        
        WebFormHelper.GetDataFromForm(this, entity);
       // entity.MachineMac = FT.Commons.Web.Tools.WebToolsHelper.GetMac(entity.MachineIp);
        //entity.StartDate = Convert.ToDateTime(this.txtBeginDate.Value.ToString());
       // entity.EndDate = Convert.ToDateTime(this.txtEndDate.Value.ToString());
        if (entity.Id < 0)
        {
            if (SimpleOrmOperator.Create(entity))
            {
                TerminalOnlineMonitorThread.InitTerminalList();
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
                TerminalOnlineMonitorThread.InitTerminalList();
                WebTools.Alert(this, "修改成功！");

            }
            else
            {
                WebTools.Alert("修改失败！");

            }

        }
    }
}
