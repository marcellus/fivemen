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
using FT.DAL.Orm;
using FT.Commons.Tools;
using FT.Web.Tools;

public partial class UserManage_RoleManage : FT.Web.AuthenticatedPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if(!IsPostBack)
        {
            this.InitTree();
             if (Request.Params["id"] != null)
            {
                RoleObject dep = SimpleOrmOperator.Query<RoleObject>(Convert.ToInt32(Request.Params["id"]));
                WebFormHelper.SetDataToForm(this, dep);
                 this.InitCheckNode(dep.RoleString);
            }
            
        }
    }

    private void InitTree()
    {
        this.TreeView1.Nodes.Clear();
        string sql = "select menutext,menuid,menuurl,menuimg,isparent,parentid from table_menus";
        sql += " order by ordernum asc";
        DataTable dt = FT.DAL.DataAccessFactory.GetDataAccess().SelectDataTable(sql, "tmpdb");
        if (dt != null && dt.Rows.Count > 0)
        {
            TreeNode parent = null;
            TreeNode node=null;
            foreach (DataRow row in dt.Rows)
            {
                
                node = new
                    TreeNode(row["menutext"].ToString(),
                    row["menuid"].ToString());
                node.ImageUrl = row["menuimg"].ToString();
               // node.NavigateUrl = row["menuurl"].ToString();
                node.PopulateOnDemand = false;
                node.SelectAction = TreeNodeSelectAction.Expand;

                if (row["isparent"].ToString() == "1")
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

    private void InitCheckNode(string right,TreeNode node)
    {
        if (right == null || right.Length == 0)
        {
            return;
        }
        string tmp="";
        if (node.Depth >= 0)
        {

            tmp = ";"+node.Value + ";";
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
    private string GetRightString()
    {
        //TreeNode[] nodes=;
        string right=";";
        foreach(TreeNode node in this.TreeView1.CheckedNodes)
        {
            if(node.Depth>=0)
            {
                right+=node.Value+";";
            }
        }
        return right;
    }
    protected void btnSure_Click(object sender, EventArgs e)
    {
        RoleObject dep = new RoleObject();
        WebFormHelper.GetDataFromForm(this, dep);
        dep.RoleString=this.GetRightString();
        if(dep.Id<0)
        {
            if (SimpleOrmOperator.Create(dep))
            {
                WebTools.Alert("添加成功！");
            }
            else
            {
                WebTools.Alert("添加失败！");

            }
        }
        else
        {
            if (SimpleOrmOperator.Update(dep))
            {
                WebTools.Alert("修改成功！");
            }
            else
            {
                WebTools.Alert("修改失败！");

            }

        }
        WebTools.CloseSelf(this);
    }
    protected void TreeView1_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {
        
    }
    protected void TreeView1_Load(object sender, EventArgs e)
    {
        
    }
}
