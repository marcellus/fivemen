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


public partial class Sales_SaleRecordAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
             ViewState[Sale_List]=new ArrayList();
             this.lbSaleTime.Text = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        SaleRecordInfo saleRecord = new SaleRecordInfo();
        saleRecord.SalePrice = TransMoney(this.txtSalePrice.Text);
        saleRecord.Discount = TransMoney(this.txtDiscount.Text);
        saleRecord.CouponsNo = this.txtCouponsNo.Text;
        saleRecord.CouponsPrice = TransMoney(this.txtCouponsMoney.Text);
        saleRecord.CashMoney = TransMoney(this.txtCashMoney.Text);
        saleRecord.VisaMoney = TransMoney(this.txtVisaCardMoney.Text);
        saleRecord.UserCardMoney = TransMoney(this.txtUserCardMoney.Text);
        saleRecord.TrueMoney = TransMoney(this.txtTrueMoney.Text);
        saleRecord.CustomerName = this.txtCustomerName.Text;
        saleRecord.CustomerPhone = this.txtCustomerPhone.Text;
        saleRecord.InVoiceNo = this.txtInvoiceNo.Text;
        saleRecord.Bz = this.txtBz.Text;
        saleRecord.SaleLsh = System.DateTime.Now.ToString("yyyyMMddHHmmss");
        string loginuser = "贾名";
        saleRecord.Sales = loginuser;
        saleRecord.ShopId = 2;
        FT.DAL.Orm.SimpleOrmOperator.Create(saleRecord);

        string sql = "";
        FT.DAL.IDataAccess access = FT.DAL.DataAccessFactory.GetDataAccess();

        object id = access.SelectScalar("select id from SaleRecord where SaleLsh='" + saleRecord.SaleLsh + "'");
        ArrayList lists = ViewState[Sale_List] as ArrayList;
        for (int i = 0; i < lists.Count; i++)
        {
            sql = "insert into Sale_Product(SaleId,ProductId,State) values(" + id.ToString() + "," + lists[i].ToString() + ",'"+ProductStateEnum.BeginSaleString+"')";
            access.ExecuteSql(sql);

            sql = "update Product set ProductStatus="+ProductStateEnum.BeginSaleInt+",State='"+ProductStateEnum.BeginSaleString+"' where Product_Id=" + lists[i].ToString();
            access.ExecuteSql(sql);
         }

        FT.Commons.Tools.WebFormHelper.WriteScript(this, "<script language='javascript'>printSaleDetail();</script>");
         // MagicAjax.AjaxCallHelper.WriteSetHtmlOfPageScript("<script language='javascript'>alert('请选择目标门店！');</script>");
       // ClientScript.RegisterStartupScript(this.GetType(), "tip", "<script>alert('请选择目标门店!');</script>");

    }


    private decimal TransMoney(string money)
    {
        if (money == null || money.Length == 0)
        {
            return 0;
        }
        else
            return decimal.Parse(money);
    }

    public static string Sale_List="product_lists";
     //ViewState[Plan_List]
    protected void ReBind()
    {
        ArrayList lists = ViewState[Sale_List] as ArrayList;
        
        // this.lbPlanNum.Text = lists.Count.ToString();
        string sql = "select * from Product";
        
        string condition=" where Product_Id in(-1 ";
        for (int i = 0; i < lists.Count;i++ )
        {
            condition += "," + lists[i].ToString() + "";
        }
        condition += ",-2)";
        DataTable dt = new DataTable();
        dt = FT.DAL.DataAccessFactory.GetDataAccess().SelectDataTable(sql+condition, "tmp");
        object obj = FT.DAL.DataAccessFactory.GetDataAccess().SelectScalar("select sum(Price) from Product "+condition);
        this.txtSalePrice.Text = obj.ToString();
        
        this.gridview.DataSource = dt;
        this.gridview.DataBind();
    }
    protected void scanChange_Click(object sender, EventArgs e)
    {
        
        Controls_ProductShow show = sender as Controls_ProductShow;
        //string barcode = show.BarCode;
        string productId=show.ProductId;
        ArrayList lists = ViewState[Sale_List] as ArrayList;
        if (lists.Contains(productId))
        {

            lists.Remove(productId);
        }
        else{
            lists.Add(productId);
        }
        //ViewState[Sale_List]=lists;
        this.ReBind();
        
       
        /*
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
                string sql = "update Plan_Product set OutStoreTime=cast('" + now
                    + "',datetime),OutStoreScanner='"
                    + loginuser + "',state='出库扫描完成' where PlanId=" + ViewState[Plan_Id].ToString()
                    + " and ProductId=" + productid;
                FT.DAL.DataAccessFactory.GetDataAccess().ExecuteSql(sql);
            }
        }
        ViewState[Product_BarCode] = barcode;
         * */
    }

    
}
