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


public partial class Assignment_ProductAssignmentInShopScanner : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      
    }

    public static string Plan_Id = "Plan_Id";
    public static string Product_BarCode = "Product_BarCode";
    public static string Plan_Name = "Plan_Name";
    protected void scanChange_Click(object sender, EventArgs e)
    {
        Controls_ProductShow show = sender as Controls_ProductShow;
        string barcode = show.BarCode;
        int len = this.gridview.Rows.Count;
        Label lb;

        string productid = show.ProductId;
        for (int i = 0; i < len; i++)
        {
            lb = this.gridview.Rows[i].FindControl("lbBarCode") as Label;
            if (lb.Text.Trim() == barcode)
            {
                this.gridview.Rows[i].ForeColor = System.Drawing.Color.Red;
                string now = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string loginuser = "贾名";
                this.gridview.Rows[i].Cells[5].Text = now;
                this.gridview.Rows[i].Cells[6].Text = loginuser;
                string sql = "update Plan_Product set InShopTime=cast('" + now
                    + "',datetime),InShopScanner='"
                    + loginuser + "',state='进店扫描完成' where PlanId=" + ViewState[Plan_Id].ToString()
                    + " and ProductId=" + productid;
                FT.DAL.DataAccessFactory.GetDataAccess().ExecuteSql(sql);
            }
        }
        ViewState[Product_BarCode] = barcode;
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string planName = this.txtPlanName.Text.Trim();

        string sql = "SELECT AssignmentPlan.id,AssignmentPlan.Name, Product.Barcode, Product.Product_Name, "
            + "Plan_Product.InShopScanner, Plan_Product.InShopTime, Plan_Product.State,Plan_Product.OutStoreTime, Plan_Product.OutStoreScanner, Shop.Name AS ShopName "
            + "FROM AssignmentPlan INNER JOIN  Plan_Product ON AssignmentPlan.Id = Plan_Product.PlanId INNER JOIN"
            + "  Product ON Plan_Product.ProductId = Product.Product_ID INNER JOIN"
            + "   Shop ON AssignmentPlan.ToShopId = Shop.Id where AssignmentPlan.Name = '" + FT.DAL.DALSecurityTool.TransferInsertField(planName) + "'";
        DataTable dt = FT.DAL.DataAccessFactory.GetDataAccess().SelectDataTable(sql, "tmp");


        if (dt != null && dt.Rows.Count > 0)
        {
            ViewState[Plan_Name] = planName;
            this.gridview.DataSource = dt;
            this.gridview.DataBind();
            ViewState[Plan_Id] = dt.Rows[0][0].ToString();
        }
    }

    protected void btnFinish_Click(object sender, EventArgs e)
    {

        int len = this.gridview.Rows.Count;
        for (int i = 0; i < len; i++)
        {
            if (this.gridview.Rows[i].ForeColor != System.Drawing.Color.Red)
            {
                FT.Commons.Tools.WebFormHelper.Alert(this, "还有未扫描的产品！");
                return;
            }
        }
        string now = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        string loginuser = "贾名";

        string sql = "update AssignmentPlan set InShopTime=cast('" + now
                    + "',datetime),InShopScanner='"
                    + loginuser + "',state='进店扫描完成' where id=" + ViewState[Plan_Id].ToString();
        FT.DAL.DataAccessFactory.GetDataAccess().ExecuteSql(sql);
        //TODO.处理产品状态
        FT.Commons.Tools.WebFormHelper.Alert(this, "调拨单号" + ViewState[Plan_Name] + "的进店扫描完成！");
    }
}
