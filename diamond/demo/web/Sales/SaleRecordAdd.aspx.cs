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
using System.IO;


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

        //FT.Commons.Tools.WebFormHelper.WriteScript(this, "<script language='javascript'>printSaleDetail();</script>");
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
    protected void btnExportPdf_Click(object sender, EventArgs e)
    {
        string file = Server.MapPath("~/FileServer");
        string filename=System.DateTime.Now.ToString("yyyyMMddHHmmss")+"-SaleRecord.pdf";
        file += "\\"+filename;
        FT.Commons.Com.Pdf.PdfHelper helper = new FT.Commons.Com.Pdf.PdfHelper(file);
        helper.Open();
        helper.AddTitle("                      金鑫珠宝销售明细单");
        helper.AddBody("                        ");
        helper.AddBody("销售单：OM41110908009  销售人员：贾名　打印时间："+System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        helper.AddBody("实收金额（元）：10000");
        helper.AddBody("银 行 卡：2000     现金： 4000     储值卡消费金额：4000");
        helper.AddBody("贵宾卡号：         储值卡余额：    顾客签名：_________   售后电话：0755-12345678");
        helper.AddBody("商品名称   条码号   数量(件)    金重(克)  当日金价(元)  金额(元)  工费(元)  折扣优惠(元)  实际收款(元)");
        helper.AddBody("黄金手环   001                                                      340         100           4000    ");
        helper.AddBody("翡翠手环   002                                                      800         700           6000    ");

        helper.Close();

        FileStream fs = File.Open(file, FileMode.Open);
        byte[] buffer = new byte[fs.Length];
        fs.Read(buffer, 0, buffer.Length);
        fs.Close();
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "filename=" + filename);
        Response.AddHeader("content-length", buffer.Length.ToString());
        Response.BinaryWrite(buffer);
        Response.Flush();
        Response.Close();
//*        */Response.End();
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
