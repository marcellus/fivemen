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
using FT.Web.Bll.Terminal;
using FT.DAL.Orm;
using FT.Web.Bll;
using System.Drawing;

public partial class YuanTuo_TerminalList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GobalTools.BindTerminalGroup(this.ddlGroups);
        }
    }
    private void Pop(int id)
    {
        string url = "TerminalEdit.aspx";
        if (id > 0)
        {
            url += "?id=" + id;
        }
        WebTools.ShowModalWindows(this, url, 820, 360);
    }
    protected void dgLists_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        
        if (e.CommandName == "Delete")
        {
            int id = Convert.ToInt32(e.CommandArgument);
            FT.DAL.DataAccessFactory.GetDataAccess().ExecuteSql("delete from yuantuo_terminals where id=" + id);
            WebTools.Alert(this, "删除成功！");
            this.ProcedurePager1.Changed = true;
        }
        else if (e.CommandName == "Detail")
        {
            int id = Convert.ToInt32(e.CommandArgument);
            this.Pop(id);

        }
        else if (e.CommandName == "Open")
        {
            int id = Convert.ToInt32(e.CommandArgument);
            TerminalEntity entity = SimpleOrmOperator.Query<TerminalEntity>(id);
            FT.Commons.Tools.WindowExHelper.WakeUp(entity.MachineMac);
            WebTools.Alert(this,"已给终端"+entity.MachineName+"发送开机命令，请稍等片刻！！！");

        }
        else if (e.CommandName == "Close")
        {
            int id = Convert.ToInt32(e.CommandArgument);
            TerminalEntity entity = SimpleOrmOperator.Query<TerminalEntity>(id);
            WholeBllTools.CloseComputer(entity.MachineIp);
            WebTools.Alert(this, "已给终端" + entity.MachineName + "发送关机命令，请稍等片刻！！！");

           // FT.Commons.Tools.WindowExHelper.WakeUp(entity.MachineMac);

        }
    }
    protected void btnSearch_Click1(object sender, EventArgs e)
    {
        if (this.ddlGroups.SelectedIndex > 0)
            this.ProcedurePager1.RowFilter = " groupid = " + this.ddlGroups.SelectedValue.Trim() ;
        else
            this.ProcedurePager1.RowFilter = "";
        this.ProcedurePager1.Changed = true;
    }
    protected void btnAdd_Click1(object sender, EventArgs e)
    {
        this.Pop(-1);
    }
    protected void dgLists_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void dgLists_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {

            string ip=e.Item.Cells[1].Text;
            TerminalStatus terminal=TerminalOnlineMonitorThread.GetTerminal(ip);
            if(terminal!=null)
            {
                e.Item.Cells[5].Text = terminal.OnlineSeconds.ToString();
                e.Item.Cells[6].Text = terminal.OnlineStatus;
                if (terminal.OnlineStatus == "不在线")
                {
                    e.Item.Cells[6].ForeColor = Color.Red;

                }
                else
                {
                    e.Item.Cells[6].ForeColor = Color.Black;
                }
            }
        }
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        string reportFormater = @"SELECT [ip] as 终端IP
      ,[mac] as 终端MAC
      ,[address] as 终端地址
      ,[onlineseconds] as 在线时长
      ,[name] as 终端名称
      ,(select name from common_weather_city where code=[citycode]) as 所在城市
      ,[storeno] as 门店编号
      ,[storename] as 门店名称
      ,[storephone] as 门店电话
      ,[storeprefix] as 门店前缀
  FROM [yuantuo_terminals]";
        if (this.ddlGroups.SelectedIndex > 0)
            reportFormater += " where groupid = " + this.ddlGroups.SelectedValue.Trim();
        reportFormater += " order by citycode,id";
        //20121019目录销售单据传递样表
        string title = "终端列表";
        string path = Server.MapPath("~/YuanTuo/ReportFiles/终端列表.xls");
        DataTable dt = FT.DAL.DataAccessFactory.GetDataAccess().SelectDataTable(reportFormater.Replace("\r\n", ""), "tmp");
        FT.Commons.Com.Excels.ListExcel excel = new FT.Commons.Com.Excels.ListExcel(path, dt);
        excel.IsReplaceReport = true;
        excel.Title = title;
        excel.HeaderWidth = new int[] { 20, 20, 30, 10, 20, 20, 10, 10, 10,10 };
        // excel.HasHeader = false;
        // excel.HasFooter = false;
        //excel.GetExcelReport();
        FT.Web.Tools.WebTools.ExportExcelReport(title + ".xls", excel);
    }
}
