using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class Sales_SaleProductConfirm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {

            ViewState[Product_Id] = "-1";
        }
    }

    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        if(this.txtCustomerName.Text.Length>0)
        {
            string sql = "update sale_product set state='" + ProductStateEnum.SaleString + "' where ProductId=" + ViewState[Product_Id].ToString();
            FT.DAL.DataAccessFactory.GetDataAccess().ExecuteSql(sql);
            sql = "update Product set State='" + ProductStateEnum.SaleString + "',ProductStatus="+ProductStateEnum.SaleInt+" where Product_Id=" + ViewState[Product_Id].ToString();
            FT.DAL.DataAccessFactory.GetDataAccess().ExecuteSql(sql);
            this.product1.Focus();
            this.product1.Clear();
            this.txtCustomerName.Text = "";
            FT.Commons.Tools.WebFormHelper.Alert(this,"确认完成！");
        }
    }

    public static string Product_Id = "Product_Id";

    protected void scanChange_Click(object sender, EventArgs e)
    {

        Controls_ProductShow show = sender as Controls_ProductShow;
        string productId = show.ProductId;
       // ViewState[Product_Id] = productId;
        string sql = "SELECT     SaleRecord.CustomerName "
+" FROM      Sale_Product INNER JOIN "
                   +  " SaleRecord ON Sale_Product.SaleId = SaleRecord.Id where Sale_Product.ProductId="+productId;
        object obj = FT.DAL.DataAccessFactory.GetDataAccess().SelectScalar(sql);
        if(obj!=null)
        {
            this.txtCustomerName.Text = obj.ToString();
            ViewState[Product_Id] = productId;
        }
    }
}
