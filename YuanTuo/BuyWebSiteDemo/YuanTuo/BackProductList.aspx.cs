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
using FT.Web.Bll.Product;
using FT.DAL.Orm;
using System.Drawing;

public partial class YuanTuo_BackProductList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GobalTools.BindProductType(this.ddlProductType);
        }
    }
    private void Pop(int id)
    {
        string url = "BackProductEdit.aspx";
        if (id > 0)
        {
            url += "?id=" + id;
        }
        WebTools.ShowModalWindows(this, url, 1000, 800);
    }
    protected void dgLists_ItemCommand(object source, DataGridCommandEventArgs e)
    {

        if (e.CommandName == "Delete")
        {
           // Response.Write(e.CommandArgument);
            int id = Convert.ToInt32(e.CommandArgument);
            FT.DAL.DataAccessFactory.GetDataAccess().ExecuteSql("delete from yuantuo_product_info where id=" + id);
            WebTools.Alert(this, "删除成功！");
            this.ProcedurePager1.Changed = true;
        }
        else if (e.CommandName == "Detail")
        {
           // Response.Write(e.CommandArgument);
            int id = Convert.ToInt32(e.CommandArgument);
            this.Pop(id);

        }
        else if (e.CommandName == "Up")
        {
            int id = Convert.ToInt32(e.CommandArgument);
            ProductInfo entity = SimpleOrmOperator.Query<ProductInfo>(id);
            if (entity.Status == 0)
            {
                entity.Status = 1;
                SimpleOrmOperator.Update(entity);
                e.Item.Cells[8].Text = "上架中";
                e.Item.Cells[8].ForeColor = Color.Black;
                WebTools.Alert(this, "已将产品" + entity.Name + "上架！！！");
            }
            else
            {
                WebTools.Alert(this, "产品" + entity.Name + "正处于上架中！！！");
            }

        }
        else if (e.CommandName == "Down")
        {
            int id = Convert.ToInt32(e.CommandArgument);
            ProductInfo entity = SimpleOrmOperator.Query<ProductInfo>(id);
            if (entity.Status == 1)
            {
                entity.Status = 0;
                SimpleOrmOperator.Update(entity);
                e.Item.Cells[8].Text = "已下架";
                e.Item.Cells[8].ForeColor = Color.Red;
                WebTools.Alert(this, "已将产品" + entity.Name + "下架！！！");
            }
            else
            {
                WebTools.Alert(this, "产品" + entity.Name + "正处于下架状态！！！");
            }

            // FT.Commons.Tools.WindowExHelper.WakeUp(entity.MachineMac);

        }
    }
    protected void btnSearch_Click1(object sender, EventArgs e)
    {
        if (this.ddlProductType.SelectedIndex > 0)
            this.ProcedurePager1.RowFilter = " producttypeid = " + this.ddlProductType.SelectedValue.Trim();
        else
            this.ProcedurePager1.RowFilter = "";
       
        if (this.txtProductName.Text.Length > 0)
        {
            if (this.ProcedurePager1.RowFilter.Length > 0)
            {
                this.ProcedurePager1.RowFilter += "  and ";
            }
            this.ProcedurePager1.RowFilter += " name like '%" + this.txtProductName.Text.Trim() + "%'";
        }
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

            string status = e.Item.Cells[8].Text;
            if (status == "1")
            {
                e.Item.Cells[8].Text = "上架中";
                e.Item.Cells[8].ForeColor = Color.Black;
            }
            else
            {
                e.Item.Cells[8].Text = "已下架";
                e.Item.Cells[8].ForeColor = Color.Red;
            }
           
        }
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        string reportFormater = @"SELECT [no] as 产品编号
      ,[name] as 产品名称
      ,[price] as 产品价格
      ,case [status] when 1 then '上架中' else '已下架' end as 产品状态
      ,[pinpai] as 品牌
      ,[guige] as 规格
      ,[chandi] as 场地
      ,[getproductdays] as 取货天数
      ,[seetimes] as 浏览次数
  FROM [yuantuo_product_info]";
        if (this.ddlProductType.SelectedIndex > 0)
            reportFormater += " where producttypeid = " + this.ddlProductType.SelectedValue.Trim();
       
        //20121019目录销售单据传递样表
        string title = "产品列表";
        string path = Server.MapPath("~/YuanTuo/ReportFiles/产品列表.xls");
        DataTable dt = FT.DAL.DataAccessFactory.GetDataAccess().SelectDataTable(reportFormater.Replace("\r\n", ""), "tmp");
        FT.Commons.Com.Excels.ListExcel excel = new FT.Commons.Com.Excels.ListExcel(path, dt);
        excel.IsReplaceReport = true;
        excel.Title = title;
        excel.HeaderWidth = new int[] { 10, 40, 10, 10, 20, 20, 20, 10, 10 };
       // excel.HasHeader = false;
       // excel.HasFooter = false;
        //excel.GetExcelReport();
        FT.Web.Tools.WebTools.ExportExcelReport(title + ".xls", excel);
    }
}
