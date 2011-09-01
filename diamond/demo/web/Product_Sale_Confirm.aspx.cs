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
using System.Text;

public partial class Product_Sale_Confirm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btn_OK_Click(object sender, EventArgs e)
    {
        string filedownloadurl = ConfigurationManager.AppSettings["FileDownloadPath"];

        Small_Type st = new Small_Type();
        Product o = new Product();
        string sql = string.Empty;
        sql = string.Format(@"select Product.*,Shop_Sale.Customer from Shop_Sale left join  Product on Shop_Sale.Barcode=Product.Barcode where Shop_Sale.Barcode='{0}'", this.TextBoxEx1.Text.Trim());
        DataSet ds = o.GetDateSet(sql);
        DataTable dt = ds.Tables[0];
        if (dt.Rows.Count > 0)
        {
            DataRow dr = dt.Rows[0];
            if (dr["LeiBie"] != DBNull.Value)
            {
                if (ddl_LeiBie.Items.FindByValue(dr["LeiBie"].ToString()) != null)
                {
                    ddl_LeiBie.SelectedValue = dr["LeiBie"].ToString();
                }
            }
            if (dr["Factory_Weight"] != DBNull.Value)
            {
                txt_FactoryWeight.Text = Convert.ToDecimal(dr["Factory_Weight"].ToString()).ToString("N2");
            }
            if (dr["Factory_Name"] != DBNull.Value)
            {
                if (ddl_OrderName.Items.FindByValue(dr["Factory_Name"].ToString()) != null)
                {
                    ddl_OrderName.SelectedValue = dr["Factory_Name"].ToString();
                }
            }
            if (dr["Style"] != DBNull.Value)
            {
                txt_StyleID.Text = dr["Style"].ToString();
            }
            if (dr["Cailiao"] != DBNull.Value)
            {
                if (ddl_SmallType.Items.FindByValue(dr["Cailiao"].ToString()) != null)
                {
                    ddl_SmallType.SelectedValue = dr["Cailiao"].ToString();
                }
            }
            if (dr["Factory_Weight"] != DBNull.Value)
            {
                txt_FactoryWeight.Text = Convert.ToDecimal(dr["Factory_Weight"].ToString()).ToString("N2");
            }

            if (dr["Gold_NetWeight"] != DBNull.Value)
            {
                txt_NetGoldWeight.Text = Convert.ToDecimal(dr["Gold_NetWeight"].ToString()).ToString("N2");

            }
            if (dr["Barcode"] != DBNull.Value)
            {
                TextBoxEx1.Text = dr["Barcode"].ToString();
            }
            if (dr["Product_Name"] != DBNull.Value)
            {
                txt_ProductName.Text = dr["Product_Name"].ToString();
            }
            if (dr["Style"] != DBNull.Value)
            {
                txt_StyleID.Text = dr["Style"].ToString();
            }
            if (dr["Price"] != DBNull.Value)
            {
                txt_Price.Text = dr["Price"].ToString();
            }
            if (dr["Old_NO"] != DBNull.Value)
            {
                txt_OldNO.Text = dr["Old_NO"].ToString();
            }
            if (dr["ShouCun"] != DBNull.Value)
            {
                txt_Size.Text = dr["ShouCun"].ToString();
            }

            if (dr["SuJinFeiYong"] != DBNull.Value)
            {
                txt_SuJinGongFei.Text = Convert.ToDecimal(dr["SuJinFeiYong"].ToString()).ToString("N2");
            }
            if (dr["GongFei"] != DBNull.Value)
            {
                txt_GongFei.Text = Convert.ToDecimal(dr["GongFei"].ToString()).ToString("N2");
            }
            if (dr["Real_Number"] != DBNull.Value)
            {
                txt_Count.Text = dr["Real_Number"].ToString();
            }

            if (dr["Descriptions"] != DBNull.Value)
            {
                txt_Description.Value = dr["Descriptions"].ToString();
            }
            if (dr["Picture"] != DBNull.Value && dr["Picture"].ToString() != string.Empty)
            {
                this.hiddenforimage.Value = filedownloadurl + "/" + dr["Picture"].ToString();
            }
            else
            {
                this.hiddenforimage.Value = string.Empty;
            }
            this.txt_StyleID0.Text = dr["Customer"].ToString(); 
        }
        else
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "a", "<script>alert('此商品尚未销售，不能进行销售确认！');</script>");
            //Response.Write("<script>alert('此商品尚未销售，不能进行销售确认！');</script>");
        }
    }
    protected void btn_Submit0_Click(object sender, EventArgs e)
    {
        Product o = new Product();
        string sql = "update Shop_Sale set isOK='Y' where Barcode='" + this.TextBoxEx1.Text + "' update Product set isSaled='Y'  where Barcode='" + this.TextBoxEx1.Text + "'";
        o.DatabaseAccess.ExecuteNonQuery(sql);
        //Response.Write("<script>alert('销售确认成功');</script>");
        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "a", "<script>alert('销售确认成功！');</script>");
    }
}
