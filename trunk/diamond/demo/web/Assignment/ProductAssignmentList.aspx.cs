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


public partial class Assignment_ProductAssignmentList : System.Web.UI.Page
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
        string name = this.txtPlanName.Text.Trim();
        string sql = "SELECT AssignmentPlan.Name, AssignmentPlan.Id, AssignmentPlan.Creator, AssignmentPlan.CreateTime, AssignmentPlan.OutStoreTime, "
      + " AssignmentPlan.OutStoreScanner, AssignmentPlan.ToShopId, AssignmentPlan.InShopTime, AssignmentPlan.InShopScanner, "
      + "  AssignmentPlan.State, AssignmentPlan.Bz, Shop.Name AS ShopName"
 + " FROM AssignmentPlan INNER JOIN"
      + "  Shop ON AssignmentPlan.ToShopId = Shop.Id where AssignmentPlan.Name like '%" + name + "%'";
       
        if(this.ddlShop.SelectedIndex>0)
        {
           // this.gridview.WhereClause += " &&ToShopId==" + this.ddlShop.SelectedValue.ToString() + "";
            sql += " and AssignmentPlan.ToShopId="+this.ddlShop.SelectedValue.ToString();
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
