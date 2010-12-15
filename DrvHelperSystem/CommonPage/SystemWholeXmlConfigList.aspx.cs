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
using FT.Commons.Cache;

public partial class CommonPage_SystemWholeXmlConfigList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.BindDataGrid();
        }
    }

    private void BindDataGrid()
    {
        DataTable dt=new DataTable();
        dt.Columns.Add("id");
        dt.Columns.Add("key");
        dt.Columns.Add("value");
        dt.Columns.Add("description");
        dt.Columns.Add("valid");
        SystemWholeXmlConfigManager.EnsureLoaded();
        Hashtable cache=SystemWholeXmlConfigManager.Caches;
        SystemWholeXmlConfig config;
        System.Collections.IDictionaryEnumerator enumerator = cache.GetEnumerator();
        DataRow dr=null;
        while (enumerator.MoveNext())
        {
            config = enumerator.Value as SystemWholeXmlConfig;
            dr = dt.NewRow();
            dr["id"] = config.Id;
            dr["key"] = config.Key;
            dr["value"] = config.Value;
            dr["description"] = config.Description;
            dr["valid"] = config.Valid;
            dt.Rows.Add(dr);
        }
        this.DataGrid1.DataSource = dt;
        this.DataGrid1.DataBind();


    }

    private void Pop(string key)
    {
        string url = "SystemWholeXmlConfigEdit.aspx";
        if (key != null && key.Length > 0)
        {
            url += "?key=" + key;
        }
        else
        {
            url += "?key=";
        }
        WebTools.ShowModalWindows(this, url,800, 320);
    }
    protected void DataGrid1_ItemCommand1(object source, DataGridCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            SystemWholeXmlConfigManager.RemoveConfig(e.CommandArgument.ToString());
            WebTools.Alert(this, "删除成功！");
            this.BindDataGrid();
        }
        else if (e.CommandName == "Detail")
        {
            string key = e.CommandArgument.ToString();
            this.Pop(key);

        }
    }
    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        this.BindDataGrid();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        this.Pop(string.Empty);
    }
}
