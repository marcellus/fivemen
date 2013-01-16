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
using FT.Commons.Tools;


public partial class YuanTuo_ReportCounter : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GobalTools.BindTerminalGroup(this.ddlGroups);
            GobalTools.InitDDl(this.ddlTerminals);
            this.txtBeginDate.Value = DateTimeHelper.DtToLongString(System.DateTime.Now);
            this.txtEndDate.Value = DateTimeHelper.DtToLongString(System.DateTime.Now);

        }
    }
    protected void btnSearch_Click1(object sender, EventArgs e)
    {
        int count = this.SearchCount();
        if (count > 100)
        {
            this.lbMsg.Text = "由于报表数据超过100条，如要看全部数据请导出excel！";
        }
        else
        {
            this.lbMsg.Text = "";
        }
        DataTable dt = this.Search(100);
        if (dt != null)
        {
            this.dgLists.DataSource = dt;
            this.dgLists.DataBind();
        }
    }
    protected void btnAdd_Click1(object sender, EventArgs e)
    {

    }
    protected void dgLists_ItemCommand(object source, DataGridCommandEventArgs e)
    {

    }
    protected void dgLists_ItemDataBound(object sender, DataGridItemEventArgs e)
    {

    }
    protected void dgLists_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private int SearchCount()
    {
        string reportFormater = @" SELECT count(1)
 from yuantuo_terminal_orders a left join  yuantuo_product_info b on a.productid =b.id where 1=1 ";
        string begindate = this.txtBeginDate.Value.ToString();
        string enddate = this.txtEndDate.Value.ToString();
        if (begindate.Length > 0)
        {
            reportFormater += " and orderdate>'" + begindate + "'";
        }
        if (enddate.Length > 0)
        {
            reportFormater += " and orderdate<'" + enddate + "'";
        }
        if (this.ddlTerminals.SelectedIndex != 0)
        {
            reportFormater += " and terminalid=" + this.ddlTerminals.SelectedValue.ToString();
        }
        else if (this.ddlGroups.SelectedIndex != 0)
        {
            reportFormater += " and terminalid in (select distinct id from yuantuo_terminals where groupid=" + this.ddlGroups.SelectedValue.ToString() + ")";
        }
        reportFormater += " order by id desc";
        object obj=FT.DAL.DataAccessFactory.GetDataAccess().SelectScalar(reportFormater.Replace("\r\n", ""));
        if (obj != null)
        {
            return Convert.ToInt32(obj.ToString());

        }
        else
        {
            return 0;
        }
    }

    private DataTable Search(int num)
    {
        string reportFormater = @" SELECT top "+num.ToString()+@"convert(varchar, a.orderdate, 112) as 订购日期,
convert(varchar, a.orderdate, 108) as 订购时间
 ,a.orderid as 单据号
,(select storeno from yuantuo_terminals c where c.id=terminalid)as 网点编码
,(select storename from yuantuo_terminals c where c.id=terminalid) as 网点名称
,b.no as 商品编码
,b.name as 商品名称
,a.num as 配送数量
,a.mobile as 备注
 from yuantuo_terminal_orders a left join  yuantuo_product_info b on a.productid =b.id where 1=1 ";
        string begindate = this.txtBeginDate.Value.ToString();
        string enddate = this.txtEndDate.Value.ToString();
        if (begindate.Length > 0)
        {
            reportFormater += " and orderdate>'" + begindate + "'";
        }
        if (enddate.Length > 0)
        {
            reportFormater += " and orderdate<'" + enddate + "'";
        }
        if (this.ddlTerminals.SelectedIndex != 0)
        {
            reportFormater += " and terminalid=" + this.ddlTerminals.SelectedValue.ToString();
        }
        else if (this.ddlGroups.SelectedIndex != 0)
        {
            reportFormater += " and terminalid in (select distinct id from yuantuo_terminals where groupid=" + this.ddlGroups.SelectedValue.ToString() + ")";
        }
        reportFormater += " order by orderdate desc";
        return FT.DAL.DataAccessFactory.GetDataAccess().SelectDataTable(reportFormater.Replace("\r\n", ""), "tmp");
    }

    private DataTable Search()
    {
        string reportFormater = @" SELECT convert(varchar, a.orderdate, 112) as 订购日期,
convert(varchar, a.orderdate, 108) as 订购时间
 ,a.orderid as 单据号
,(select storeno from yuantuo_terminals c where c.id=terminalid)as 网点编码
,(select storename from yuantuo_terminals c where c.id=terminalid) as 网点名称
,b.no as 商品编码
,b.name as 商品名称
,a.num as 配送数量
,a.mobile as 备注
 from yuantuo_terminal_orders a left join  yuantuo_product_info b on a.productid =b.id where 1=1 ";
        string begindate=this.txtBeginDate.Value.ToString();
        string enddate=this.txtEndDate.Value.ToString();
        if (begindate.Length > 0)
        {
            reportFormater += " and orderdate>'"+begindate+"'";
        }
        if (enddate.Length > 0)
        {
            reportFormater += " and orderdate<'" + enddate + "'";
        }
        if (this.ddlTerminals.SelectedIndex != 0)
        {
            reportFormater += " and terminalid=" + this.ddlTerminals.SelectedValue.ToString();
        }
        else if(this.ddlGroups.SelectedIndex!=0)
        {
            reportFormater += " and terminalid in (select distinct id from yuantuo_terminals where groupid="+this.ddlGroups.SelectedValue.ToString()+")";
        }
        reportFormater += " order by orderdate desc";
        return FT.DAL.DataAccessFactory.GetDataAccess().SelectDataTable(reportFormater.Replace("\r\n", ""), "tmp");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        /*
         
        
         
         */

        string reportFormater = @" SELECT convert(varchar, a.orderdate, 112) as 订购日期,
convert(varchar, a.orderdate, 108) as 订购时间
 ,a.orderid as 单据号
,(select storeno from yuantuo_terminals c where c.id=terminalid)as 网点编码
,(select storename from yuantuo_terminals c where c.id=terminalid) as 网点名称
,b.no as 商品编码
,b.name as 商品名称
,a.num as 配送数量
,a.mobile as 备注
 from yuantuo_terminal_orders a left join  yuantuo_product_info b on a.productid =b.id";
        //20121019目录销售单据传递样表
        string title="20121019目录销售单据传递样表";
        string path = Server.MapPath("~/YuanTuo/ReportFiles/20121019目录销售单据传递样表.xls");
        DataTable dt=FT.DAL.DataAccessFactory.GetDataAccess().SelectDataTable(reportFormater.Replace("\r\n",""),"tmp");
        FT.Commons.Com.Excels.ListExcel excel = new FT.Commons.Com.Excels.ListExcel(path, dt);
        excel.Title = title;
        excel.HeaderWidth = new int[] { 10,10,20,10,30,10,40,10,10};
        excel.HasHeader = false;
        excel.HasFooter = false;
        //excel.GetExcelReport();
        FT.Web.Tools.WebTools.ExportExcelReport(title + ".xls", excel);
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string reportFormater = @" SELECT convert(varchar, a.orderdate, 112) as 订购日期,
convert(varchar, a.orderdate, 108) as 订购时间
 ,a.orderid as 单据号
,(select storeno from yuantuo_terminals c where c.id=terminalid)as 网点编码
,(select storename from yuantuo_terminals c where c.id=terminalid) as 网点名称
,b.no as 商品编码
,b.name as 商品名称
,a.num as 配送数量
,a.mobile as 备注
 from yuantuo_terminal_orders a left join  yuantuo_product_info b on a.productid =b.id";
        //20121019目录销售单据传递样表
        string title = "20121019目录销售单据传递样表";
        string path = Server.MapPath("~/YuanTuo/ReportFiles/20121019目录销售单据传递样表.xls");
        DataTable dt = FT.DAL.DataAccessFactory.GetDataAccess().SelectDataTable(reportFormater.Replace("\r\n", ""), "tmp");

        FT.Web.Tools.WebTools.ExportExcelReport(title + ".xls", dt);
    }
    protected void ddlGroups_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.ddlGroups.SelectedIndex != 0)
        {
            GobalTools.BindTerminalByGroup(this.ddlTerminals, this.ddlGroups.SelectedValue.ToString());
        }
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
       
        DataTable dt = this.Search();
        if (dt != null)
        {
            string title = "目录销售单据传递样表";
            string path = Server.MapPath("~/YuanTuo/ReportFiles/目录销售单据传递样表.xls");
            FT.Commons.Com.Excels.ListExcel excel = new FT.Commons.Com.Excels.ListExcel(path, dt);
            excel.IsReplaceReport = true;
            excel.Title = title;
            excel.HeaderWidth =new int[]{ 10,10,20,10,30,10,40,10,10};
            // excel.HasHeader = false;
            // excel.HasFooter = false;
            //excel.GetExcelReport();
            FT.Web.Tools.WebTools.ExportExcelReport(title + ".xls", excel);
        }
        else
        {
            WebTools.Alert("查询出错！");
        }
        
    }
}
