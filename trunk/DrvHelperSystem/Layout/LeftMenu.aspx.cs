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
using FT.Web;

public partial class Layout_LeftMenu : AuthenticatedPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.InitTree();
        }
    }

    private void InitTree()
    {
        this.TreeView1.Nodes.Clear();
        string[] ids = this.Operator.Right.Split(';');
        string condition=" where menuid in(";
        for (int i = 0; i < ids.Length - 1;i++ )
        {
            if(ids[i].Length>0)
                condition += ids[i] + ",";
        }
        condition += "-1)";
        string sql = "select menutext,menuid,menuurl,menuimg,isparent,parentid from table_menus";
        sql += condition;
        sql += " order by ordernum asc";
        DataTable dt = FT.DAL.DataAccessFactory.GetDataAccess().SelectDataTable(sql, "tmpdb");
        if (dt != null && dt.Rows.Count > 0)
        {
            TreeNode parent = null;
            TreeNode node = null;
            foreach (DataRow row in dt.Rows)
            {

                node = new
                    TreeNode(row["menutext"].ToString(),
                    row["menuid"].ToString());
                node.ImageUrl = row["menuimg"].ToString();
                node.NavigateUrl = row["menuurl"].ToString();
                node.PopulateOnDemand = false;
                node.SelectAction = TreeNodeSelectAction.Expand;

                if (row["isparent"].ToString() == "1")
                {
                    parent = node;
                    this.TreeView1.Nodes.Add(node);
                }
                else if(parent!=null)
                {
                    parent.ChildNodes.Add(node);
                }
            }
        }
    }

    private void InitTreeViewByMock()
    {

        DataTable dt = new DataTable();
        dt.Columns.Add("menuid");
        dt.Columns.Add("menutext");
        dt.Columns.Add("menuurl");
    }
    /*
    protected void TreeView1_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {
        if (e.Node.ChildNodes.Count == 0)
        {
            switch (e.Node.Depth)
            {
                case 0:
                    PopulateMenu(e.Node);
                    break;
                case 1:
                    PopulateMenu(e.Node);
                    break;
            }
        }

    }

    void PopulateMenu(TreeNode node)
    {
        string sql = "select menutext,menuid,menuurl,menuimg from table_menus";
        if (node.Depth == 0)
            sql += " where isparent=1";
        else
        {
            sql += " where isparent=0 and parentid="+node.Value;
        }
        sql += " order by ordernum asc";
        DataTable dt = FT.DAL.DataAccessFactory.GetDataAccess().SelectDataTable(sql,"tmpdb");
        if (dt!=null&&dt.Rows.Count > 0)
        {
            foreach (DataRow row in dt.Rows)
            {
                TreeNode NewNode = new
                    TreeNode(row["menutext"].ToString(),
                    row["menuid"].ToString());
                NewNode.ImageUrl = row["menuimg"].ToString();
                NewNode.NavigateUrl = row["menuurl"].ToString();
                NewNode.PopulateOnDemand = true;
                NewNode.SelectAction = TreeNodeSelectAction.Expand;
                node.ChildNodes.Add(NewNode);
            }
        }
    }
     * */

    
}
