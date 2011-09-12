using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Storage_StorageListMange : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    #region 私有函数

    public DataSet GetStorageListDataSource()
    {
      
        StorageList storage = new StorageList();
        System.Text.StringBuilder sql = new System.Text.StringBuilder();
        sql.Append(@"SELECT StorageNo,StorageDescription,GenerationTime FROM StorageList where 1=1 ");

        if (this.txt_StoNo.Text != string.Empty)
        {
            sql.Append(string.Format(" and StorageNo='{0}'", storage.DatabaseAccess.ConvertToDBString(this.txt_StoNo.Text)));
        }
        sql.Append(string.Format(" and convert(char(10),GenerationTime,102)>= '{0}' and convert(char(10),GenerationTime,102)<='{1}' ", this.StartDate.ToString("yyyy.MM.dd"), this.EndDate.ToString("yyyy.MM.dd")));
        sql.Append(" order by GenerationTime desc");
        return storage.GetDateSet(sql.ToString());
    }
    protected void dgProduct_SortCommand(object source, DataGridSortCommandEventArgs e)
    {
        //ViewState["OrderFloor"] = null;
        // ViewState["flag"] = null;
        // Response.Write(e.SortExpression);
    }
    protected void dgProduct_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            DataRowView rowView = (DataRowView)e.Item.DataItem;
            e.Item.Attributes.Add("onclick", "selectGridItem(this);");
            e.Item.Attributes.Add("ondblclick", string.Format("Product_OpenNormal(StorageDetails.aspx?type=edit&sid={0}','入库单');", rowView["StorageNo"].ToString().Trim()));
            e.Item.Attributes.Add("id", "TR" + rowView["StorageNo"].ToString().Trim());

            int head = e.Item.Cells[1].Text.Substring(0, e.Item.Cells[1].Text.Length - 1).LastIndexOf(">") + 1;
            int tail = e.Item.Cells[1].Text.Length;
            string str = e.Item.Cells[1].Text.Substring(head, tail - head);
        }
    }
    #endregion

    protected void BindData()
    {
        dgProduct.InvokeBuildDataSource();
        dgProduct.BuildData();
    }

    protected void dgProduct_BuildDataSource(object sender, EventArgs e)
    {
        dgProduct.DataSource = this.GetStorageListDataSource();
    }


    public DateTime StartDate
    {
        get
        {

            return this.txt_startDate.CalendarDate==""?DateTime .MinValue: DateTime.Parse(this.txt_startDate.CalendarDate);
        }
    
    
    }

    public DateTime EndDate
    {
        get {

            return this.txt_endDate.CalendarDate == "" ? DateTime.MaxValue: DateTime.Parse(this.txt_endDate.CalendarDate);
        
        }
    
    
    }


    #region 页面事件
    /// <summary>
    /// 删除按钮
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btn_Delete_Click(object sender, EventArgs e)
    {
        StorageList storage = new StorageList();
        string idlist = this.dgProduct.SelectedIDList;
        string sql = "delete from StorageList where StorageNo in ('" + idlist.Replace(",", "','") + "')";
        storage.DatabaseAccess.ExecuteNonQuery(sql);
        Response.Write("<script language=javascript>alert('删除成功!')</script>");
        BindData();
    }
    /// <summary>
    /// 查询按钮
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btn_Search_Click(object sender, EventArgs e)
    {
        BindData();
    } 
    #endregion
}
