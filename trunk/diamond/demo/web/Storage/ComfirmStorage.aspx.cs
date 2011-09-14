using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Storage_ComfirmStorage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindStorage();
            BindData();
        }

    }
    private void BindStorage()
    {
        StorageList storage = new StorageList();
        string sql = "select StorageNo from StorageList";
        this.ddl_StoNo.DataSource = storage.DatabaseAccess.ExecuteDataset(sql);
        this.ddl_StoNo.DataBind();
        this.ddl_StoNo.Items.Insert(0, new ListItem("----------", "-1"));

    }
    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        if (this.BarCode != "")
        {
            ComfirmStorage(BarCode);
          
            //Response.Write("<script language=javascript>alert('确认成功!');</script>");
            BindData();
        
        }

    }
    /// <summary>
    /// 删除按钮
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btn_Delete_Click(object sender, EventArgs e)
    {
        Product o = new Product();
        string idlist = this.dgProduct.SelectedIDList;


        string picnamelist = o.GetPictureNameList(idlist);

        string sql = "delete from Product where Product_ID in ('" + idlist.Replace(",", "','") + "')";
        o.DatabaseAccess.ExecuteNonQuery(sql);
        Response.Write("<script language=javascript>alert('删除成功!')</script>");
        BindData();
    }
    /// <summary>
    /// 入库确认函数
    /// </summary>
    /// <param name="barCode"></param>
    private void ComfirmStorage(string barCode)
    {

        Product product = new Product();
        System.Text.StringBuilder sql = new System.Text.StringBuilder();
        sql.Append(@"update Product set ProductStatus='1' where Barcode='" + BarCode + "'");
        product.DatabaseAccess.ExecuteNonQuery(sql.ToString());
    }


    protected void BindData()
    {
        dgProduct.InvokeBuildDataSource();
        dgProduct.BuildData();
    }
    protected void dgProduct_BuildDataSource(object sender, EventArgs e)
    {
        dgProduct.DataSource = this.GetProductDataSource();
    }
    public string BarCode
    {
        get {

            return this.txt_BarCode.Text == null ? "" : this.txt_BarCode.Text.ToString();
        }
    
    }


    public DataSet GetProductDataSource()
    {
        
        Product product = new Product();
        System.Text.StringBuilder sql = new System.Text.StringBuilder();
        sql.Append(@"select Product_ID,Barcode,Product_Name,Factory_Weight,Gold_NetWeight,ShouCun,Style,Factory_Name,StorageNo,Descriptions,ProductStatus,ComfirmWeight
                    from Product where (ProductStatus='0' or ProductStatus='1')   ");
        if (this.ddl_StoNo.SelectedValue != "-1")
        {

            sql.Append("  and  StorageNo='" + this.ddl_StoNo.SelectedValue + "' ");
        
        }

        sql.Append(" and Product.Delete_YN<>'Y'");

        sql.Append(" order by ProductStatus, Modify_Date desc");

        return product.GetDateSet(sql.ToString());
    }


    protected void dgProduct_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            DataRowView rowView = (DataRowView)e.Item.DataItem;
            if (rowView["ProductStatus"].ToString().Trim() == "0")
            {
                e.Item.Style.Add(HtmlTextWriterStyle.Color, "Red");
            }
            else
            {

                e.Item.Style.Add(HtmlTextWriterStyle.Color, "Black");
                e.Item.Attributes.Add("ondblclick", string.Format("Product_OpenSmall('ComfirmWeightDetals.aspx?PROID={0}','Product');", rowView["Product_ID"].ToString().Trim()));
            }
            
          


          
        }
         
    }

    protected void ddl_StoNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindData();
    }
}
