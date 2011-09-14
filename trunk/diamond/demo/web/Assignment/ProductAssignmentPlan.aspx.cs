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



public partial class Assignment_ProductAssignmentPlan : System.Web.UI.Page
{
    public static string Plan_List = "plan_list";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.BindDdl();
            this.lbCreateTime.Text = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            this.txtPlanName.Attributes["onkeyup"] = "changePlanName();";
            ViewState[Plan_List] =new ArrayList();
            this.RebindPlanList();
        }
    }
    private void BindDdl()
    {

        //ShopInfo shop = new ShopInfo();
        //shop.Id = -1;
        //shop.Name = "--请选择--";
        DataTable dt = new DataTable();
        dt = FT.DAL.DataAccessFactory.GetDataAccess().SelectDataTable("select id,name from shop", "tmp");
        this.ddlShop.DataSource =dt;
        this.ddlShop.DataTextField = "name";
        this.ddlShop.DataValueField = "id";
        this.ddlShop.DataBind();
        this.ddlShop.Items.Insert(0, new ListItem("--请选择--", "-1"));
        this.ddlShop.Attributes["onchange"] = "changeShop();";
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt = FT.DAL.DataAccessFactory.GetDataAccess().SelectDataTable("select * from Product where Product_Name like '%"+this.txtSearchName.Text.Trim()+"%'", "tmp");
        this.gridviewselector.DataSource = dt;
        this.gridviewselector.DataBind();
        this.lbPlanName1.Text = this.lbPlanName2.Text = this.txtPlanName.Text;
        this.lbDestName.Text = this.ddlShop.SelectedItem.Text;
        //cbProductPlanSelector
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        string sql="";
        FT.DAL.IDataAccess access= FT.DAL.DataAccessFactory.GetDataAccess();
        if(this.ddlShop.SelectedIndex!=0)
        {
            sql = "insert into AssignmentPlan(Name,Creator,CreateTime,State,ToShopId) values('" + this.txtPlanName.Text.Trim() + "','" + this.lbCreator.Text.Trim() + "',CAST('"+System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+ "' AS datetime),'新增',"+this.ddlShop.SelectedValue.ToString()+")";
            access.ExecuteSql(sql);
            object id=access.SelectScalar("select id from AssignmentPlan where Name='"+this.txtPlanName.Text.Trim()+"'");
            ArrayList lists = ViewState[Plan_List] as ArrayList;
            for(int i=0;i<lists.Count;i++)
            {
                sql = "insert into Plan_Product(PlanId,ProductId,State) values("+id.ToString()+","+lists[i].ToString()+",'新增')";
                access.ExecuteSql(sql);
            }

        }
        else{

           // MagicAjax.AjaxCallHelper.WriteSetHtmlOfPageScript("<script language='javascript'>alert('请选择目标门店！');</script>");
            ClientScript.RegisterStartupScript(this.GetType(), "tip", "<script>alert('请选择目标门店!');</script>"); 
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        int len=this.gridviewselector.Rows.Count;
        CheckBox cb;
        string id=string.Empty;
        ArrayList lists = ViewState[Plan_List] as ArrayList;
        for(int i=0;i<len;i++)
        {
            cb=this.gridviewselector.Rows[i].FindControl("cbProductSelector") as CheckBox;
            if(cb.Checked)
            {

                
                id=cb.ToolTip.ToString();
                if(!lists.Contains(id))
                {
                    lists.Add(id);
                }
            }
        }
        ViewState[Plan_List] = lists;
        this.RebindPlanList();
    }


    protected void btnClear_Click(object sender, EventArgs e)
    {
        
        ViewState[Plan_List] = new ArrayList();
        this.RebindPlanList();
    }

    private void RebindPlanList()
    {
        ArrayList lists = ViewState[Plan_List] as ArrayList;
        this.lbPlanNum.Text = lists.Count.ToString();
        string sql = "select * from Product where Product_Id in(-1 ";
        for (int i = 0; i < lists.Count;i++ )
        {
            sql += "," + lists[i].ToString();
        }
        sql += ",-2)";
        DataTable dt = new DataTable();
        dt = FT.DAL.DataAccessFactory.GetDataAccess().SelectDataTable(sql, "tmp");
        
        this.gridviewplan.DataSource = dt;
        this.gridviewplan.DataBind();

    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        CheckBox cb;
        string id = string.Empty;
        ArrayList lists = ViewState[Plan_List] as ArrayList;
        int len = this.gridviewplan.Rows.Count;
        for (int i = 0; i < len; i++)
        {
            cb = this.gridviewplan.Rows[i].FindControl("cbProductPlanSelector") as CheckBox;
            if (cb.Checked)
            {


                id = cb.ToolTip.ToString();
                if (lists.Contains(id))
                {
                    lists.Remove(id);
                }
            }
        }
        ViewState[Plan_List] = lists;
        this.RebindPlanList();
    }
}
