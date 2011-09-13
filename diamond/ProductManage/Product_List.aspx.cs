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
using ACE.Common.Util;
using System.IO;

public partial class ProductList : Pagebase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //if (HttpContext.Current.Session["empRole"] == null)
            //{
            //    Response.Redirect("login.aspx");
            //}
            //else
            //{
            //    if (HttpContext.Current.Session["empRole"].ToString() != "Admin")
            //    {
            //        this.btn_Add.Visible = false;
            //        this.btn_Delete.Visible = false;
            //    }
            //}

            BindData();
        }

        //if (HttpContext.Current.Session["empRole"] == null && HttpContext.Current.Session["empRole"].ToString() != "Admin")
        //{
        //    this.btn_Add.Visible = false;
        //}
        
    }

    public DataSet GetProductDataSource()
    {
        Product product = new Product();
        System.Text.StringBuilder sql = new System.Text.StringBuilder();
        sql.Append(@"select Product_ID,Barcode,Product_Name,Factory_Weight,Gold_NetWeight,ShouCun,Price,Style,Old_NO,Real_Number,SuJinFeiYong,GongFei,Factory_Name 
                    from Product where 1=1");
        if (this.ddl_OrderName.SelectedValue != string.Empty && this.ddl_OrderName.SelectedValue != "---")
        {
            sql.Append(string.Format(" and Factory_Name='{0}'", this.ddl_OrderName.SelectedValue)); 
        }
        if (this.ddl_Type.SelectedValue != string.Empty && this.ddl_Type.SelectedValue != "---")
        {
            sql.Append(string.Format(" and Product.LeiBie='{0}'",this.ddl_Type.SelectedValue));
        }
        if (this.ddl_Type0.SelectedValue != string.Empty && this.ddl_Type0.SelectedValue != "---")
        {
            sql.Append(string.Format(" and Product.Cailiao='{0}'", this.ddl_Type0.SelectedValue));
        }
        if (this.txt_Barcode.Text != string.Empty)
        {
            sql.Append(string.Format(" and Barcode like '%{0}%'",product.DatabaseAccess.ConvertToDBString(this.txt_Barcode.Text)));
        }
        if (this.txt_ProductName.Text != string.Empty)
        {
            sql.Append(string.Format(" and Product_Name like '%{0}%'", product.DatabaseAccess.ConvertToDBString(this.txt_ProductName.Text)));
        }
        if (ddl_Type1.SelectedValue != string.Empty && ddl_Type1.SelectedValue != "---")
        {
            sql.Append(string.Format(" and (ShopName1='{0}' or ShopName2='{0}')", ddl_Type1.SelectedValue));
        }
        else
        {
            sql.Append(string.Format(" and ShopName1 is null and ShopName2 is null"));
        }
        if (this.chk_IsSaled.Checked)
        {
            sql.Append(string.Format(" and isSaled='Y'"));
        }
        sql.Append(" and Product.Delete_YN<>'Y'");

        sql.Append(" order by Modify_Date desc");
        return product.GetDateSet(sql.ToString());
    }
    protected void btn_Search_Click(object sender, EventArgs e)
    {
        BindData();
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
            e.Item.Attributes.Add("ondblclick", string.Format("Product_OpenNormal('Product_Profile.aspx?PROID={0}&flag=Edit','Product');", rowView["Product_ID"].ToString().Trim()));
            e.Item.Attributes.Add("id", "TR" + rowView["Product_ID"].ToString().Trim());

            int head = e.Item.Cells[1].Text.Substring(0, e.Item.Cells[1].Text.Length - 1).LastIndexOf(">") + 1;
            int tail = e.Item.Cells[1].Text.Length;
            string str = e.Item.Cells[1].Text.Substring(head, tail - head);
        }
    }
    protected void btn_Delete_Click(object sender, EventArgs e)
    {
        string fileSavePath = MapPath(ConfigurationManager.AppSettings["FileServerPath"]);
        Product o = new Product();        
        string idlist = this.dgProduct.SelectedIDList;


        string picnamelist = o.GetPictureNameList(idlist);
        if (picnamelist != string.Empty)
        {
            string[] picnames = picnamelist.Split(',');
            if (picnames.Length > 0)
            {
                foreach (string name in picnames)
                {
                    if (File.Exists(fileSavePath + "\\" + name))
                    {
                        if (!o.HaveProductExist(name))
                        {
                            File.Delete(fileSavePath + "\\" + name);
                        }
                    }
                }
            }
        }
        string sql = "delete from Product where Product_ID in ('" + idlist.Replace(",", "','") + "')";
        o.DatabaseAccess.ExecuteNonQuery(sql);
        Response.Write("<script language=javascript>alert('删除成功!')</script>");
        BindData();
    }
    protected void hiddenButton_Click(object sender, EventArgs e)
    {
        dgProduct.CurrentPageIndexEx = dgProduct.CurrentPageIndexEx;
        BindData();
    }
}