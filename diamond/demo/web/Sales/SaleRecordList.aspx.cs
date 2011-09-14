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


public partial class Sales_SaleRecordList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            this.BindDdl();
        }
    }
    private void BindDdl()
    {

        DataTable dt = new DataTable();
        dt = FT.DAL.DataAccessFactory.GetDataAccess().SelectDataTable("select id,name from shop", "tmp");
        this.ddlShop.DataSource = dt;
        this.ddlShop.DataTextField = "name";
        this.ddlShop.DataValueField = "id";
        this.ddlShop.DataBind();
        this.ddlShop.Items.Insert(0, new ListItem("--请选择--", "-1"));
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string name = this.txtSaleName.Text.Trim();
        string sql = "SELECT     Sale_Product.State AS SaleState, SaleRecord.*, Product.*"
+" FROM         Sale_Product INNER JOIN "
                   +"  SaleRecord ON Sale_Product.SaleId = SaleRecord.Id INNER JOIN "
                   + "   Product ON Sale_Product.ProductId = Product.Product_ID where SaleRecord.Sales like '%" + name + "%'";

        if (this.ddlShop.SelectedIndex > 0)
        {
            // this.gridview.WhereClause += " &&ToShopId==" + this.ddlShop.SelectedValue.ToString() + "";
            sql += " and SaleRecord.ShopId=" + this.ddlShop.SelectedValue.ToString();
        }
        DataTable dt = FT.DAL.DataAccessFactory.GetDataAccess().SelectDataTable(sql, "tmp");
        this.gridview.DataSource = dt;
        this.gridview.DataBind();
        //;
        //Plan plan;
        // plan.ToShopId
        // this.gridview.BindGrid<Plan>();
    }
}
