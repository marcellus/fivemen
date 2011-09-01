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


public partial class Show_view : System.Web.UI.Page
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
        sql.Append(@"select Barcode,Product_Name,Factory_Weight,Gold_NetWeight,ShouCun,Price,Style,SuJinFeiYong,GongFei,Factory_Name 
                    from Product where 1=1");
        if (this.ddl_Type1.SelectedValue != string.Empty && this.ddl_Type1.SelectedValue != "---")
        {
            sql.Append(string.Format(" and ShopName1='{0}' and ShopName2='{0}'", this.ddl_Type1.SelectedValue)); 
        }
        if (this.ddl_Type.SelectedValue != string.Empty && this.ddl_Type.SelectedValue != "---")
        {
            sql.Append(string.Format(" and Product.LeiBie='{0}'",this.ddl_Type.SelectedValue));
        }
        if (this.ddl_Type0.SelectedValue != string.Empty && this.ddl_Type0.SelectedValue != "---")
        {
            sql.Append(string.Format(" and Product.Cailiao='{0}'", this.ddl_Type0.SelectedValue));
        }
        sql.Append(" and Product.Delete_YN<>'Y' and Product.isSaled <> 'Y'");

        sql.Append(" order by Modify_Date desc");
        //ds = product.GetDateSet(sql.ToString());
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
        //if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        //{
        //    DataRowView rowView = (DataRowView)e.Item.DataItem;
        //    e.Item.Attributes.Add("onclick", "selectGridItem(this);");
        //    e.Item.Attributes.Add("ondblclick", string.Format("Product_OpenNormal('Product_Profile.aspx?PROID={0}&flag=Edit','Product');", rowView["Product_ID"].ToString().Trim()));
        //    e.Item.Attributes.Add("id", "TR" + rowView["Product_ID"].ToString().Trim());

        //    int head = e.Item.Cells[1].Text.Substring(0, e.Item.Cells[1].Text.Length - 1).LastIndexOf(">") + 1;
        //    int tail = e.Item.Cells[1].Text.Length;
        //    string str = e.Item.Cells[1].Text.Substring(head, tail - head);
        //}
    }
    protected void btn_Export_Click(object sender, EventArgs e)
    {
        DataSet ds = this.GetProductDataSource();
        if (ds.Tables.Count > 0)
        {
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                //dt.Columns.Remove("Picture");
                ExportExcel ex = new ExportExcel();
                string excelname = "Product";//this.ddl_Type1.SelectedValue;
                excelname += "_view";
                ex.ExportDataSource = dt;
                //excelname = MapPath("FileServer") + "\\" + excelname;//+ ".xls";
                ex.DownloadFileName = excelname;
                string filedownloadurl = MapPath(ConfigurationManager.AppSettings["FileDownloadPath"]) + "\\";
                ex.Download();
            }
            else
            {
                //Response.Write("<script language=javascript>alert('No record!')</script>");
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "a", "<script>alert('导出前请先查询数据！');</script>");
            }
        }
        else
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "a", "<script>alert('导出前请先查询数据！');</script>");
        }
    }
}
