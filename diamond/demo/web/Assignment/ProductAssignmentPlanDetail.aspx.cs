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


public partial class Assignment_ProductAssignmentPlanDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {

            string id = Request.Params["id"].ToString();
            if(id!=null&&id.Length>0)
            {
                string sql = "SELECT AssignmentPlan.Name, AssignmentPlan.Id, Plan_Product.OutStoreTime, Plan_Product.OutStoreScanner,"
                    +"Plan_Product.InShopTime, Plan_Product.InShopScanner, Plan_Product.State, "
                    + " Product.Barcode, Product.Price,Product.Product_ID,Product.Gold_NetWeight,Product.Factory_Weight,Product.Factory_Name,Product.Cailiao,Product.Style, Product.Product_Name,   Shop.Name AS ShopName"
                    +" FROM AssignmentPlan INNER JOIN   Plan_Product ON AssignmentPlan.Id = Plan_Product.PlanId INNER JOIN  Product"
                    +" ON Plan_Product.ProductId = Product.Product_ID INNER JOIN  Shop ON AssignmentPlan.ToShopId = Shop.Id"
                    +" where AssignmentPlan.Id="+id.ToString();
                DataTable dt = FT.DAL.DataAccessFactory.GetDataAccess().SelectDataTable(sql,"tmp");
                this.gridview.DataSource = dt;
                this.gridview.DataBind();
                string sql2 = "SELECT AssignmentPlan.Name, AssignmentPlan.Creator, AssignmentPlan.CreateTime, AssignmentPlan.State, "
                + "Shop.Name AS ShopName FROM AssignmentPlan INNER JOIN  Shop ON AssignmentPlan.ToShopId = Shop.Id where AssignmentPlan.Id=" + id.ToString();
                DataTable dt2 = FT.DAL.DataAccessFactory.GetDataAccess().SelectDataTable(sql2, "tmp");
                if(dt2.Rows.Count==1)
                {
                    DataRow dr=dt2.Rows[0];
                    this.lbPlanName1.Text=this.lbPlanName.Text = Trans(dr,"Name");
                    this.lbPlanShopName.Text = Trans(dr, "ShopName");
                    this.lbProductCount.Text = dt.Rows.Count.ToString();
                    this.lbCreator.Text = Trans(dr, "Creator");
                    string date=Trans(dr, "CreateTime");
                    if(date.Length>0)
                    {
                        DateTime time=DateTime.Parse(date);
                        date = time.ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    else
                    {

                        date = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    this.lbCreateTime.Text = date;
                   
                }
            }
        }
    }

    private string Trans(DataRow dr,string col)
    {

        return dr[col]==null?string.Empty:dr[col].ToString();
    }
}
