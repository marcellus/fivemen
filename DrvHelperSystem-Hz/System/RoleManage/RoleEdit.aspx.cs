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
using FT.DAL;
using FT.DAL.Orm;
using FT.Commons.Tools;
using DrvHelperSystemBLL.System.Rbac.Model;
using DrvHelperSystemBLL.System;
using DrvHelperSystemBLL.System.Rbac.BLL;

public partial class System_RoleManage_RoleEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Constants.BindDepType(cbDepTypeValue);
            this.InitTree();
            if (Request.Params["id"] != null)
            {
                RoleInfo model = SimpleOrmOperator.Query<RoleInfo>(Convert.ToInt32(Request.Params["id"]));
                WebFormHelper.SetDataToForm(this, model);
               // this.ddlDepTypeValue.SelectedValue = model.DepType;
                this.InitCheckNode(model.MenuStr);
            }

        }
    }

    private void InitTree()
    {
        this.TreeView1.Nodes.Clear();
        string sql = "select c_text,id,c_url,c_img,i_is_parent,i_parent_id from table_menu_info";
        sql += " order by i_order_num asc";
        DataTable dt = FT.DAL.DataAccessFactory.GetDataAccess().SelectDataTable(sql, "tmpdb");
        if (dt != null && dt.Rows.Count > 0)
        {
            TreeNode parent = null;
            TreeNode node = null;
            foreach (DataRow row in dt.Rows)
            {

                node = new
                    TreeNode(row["c_text"].ToString(),
                    row["id"].ToString());
                node.ImageUrl = row["c_img"].ToString();
                // node.NavigateUrl = row["menuurl"].ToString();
                node.PopulateOnDemand = false;
                node.SelectAction = TreeNodeSelectAction.Expand;

                if (row["i_is_parent"].ToString() == "1")
                {
                    parent = node;
                    this.TreeView1.Nodes.Add(node);
                }
                else
                {
                    parent.ChildNodes.Add(node);
                }
            }
        }
    }
    private void InitCheckNode(string right)
    {
        foreach (TreeNode node in this.TreeView1.Nodes)
        {
            InitCheckNode(right, node);
        }
    }

    private void InitCheckNode(string right, TreeNode node)
    {
        if (right == null || right.Length == 0)
        {
            return;
        }
        string tmp = "";
        if (node.Depth >= 0)
        {

            tmp = ";" + node.Value + ";";
            if (right.IndexOf(tmp) != -1)
            {
                node.Checked = true;
            }
            if (node.ChildNodes.Count != 0)
            {
                foreach (TreeNode node1 in node.ChildNodes)
                {
                    InitCheckNode(right, node1);
                }
                //InitCheckNode(right, node);
            }
        }

    }

    private string GetMenuString()
    {
        //TreeNode[] nodes=;
        string right = ";";
        foreach (TreeNode node in this.TreeView1.CheckedNodes)
        {
            if (node.Depth >= 0)
            {
                right += node.Value + ";";
            }
        }
        return right;
    }

    protected void btnSure_Click(object sender, EventArgs e)
    {
        RoleInfo model = new RoleInfo();
        WebFormHelper.GetDataFromForm(this, model);
        model.MenuStr = this.GetMenuString();
        RoleInfoOperator.CreateOrUpdate(model);
        WebTools.CloseSelf(this);
    }
    protected void TreeView1_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {

    }
    protected void TreeView1_Load(object sender, EventArgs e)
    {

    }
}
