using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.HPSF;
using NPOI.POIFS.FileSystem;
using NPOI.SS.UserModel;
using System.Data;
using System.Text;

public partial class report_StoreSalesReport : System.Web.UI.Page
{
    private HSSFWorkbook hssfworkbook;
    private Sheet sheet;
    private DataTable dtstorage;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindShop();
            BindData();

        }
    }


    public DateTime StartDate
    {
        get
        {

            return this.txt_startDate.CalendarDate == "" ? DateTime.MinValue : DateTime.Parse(this.txt_startDate.CalendarDate);
        }


    }

    public DateTime EndDate
    {
        get
        {

            return this.txt_endDate.CalendarDate == "" ? DateTime.MaxValue : DateTime.Parse(this.txt_endDate.CalendarDate);

        }


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
    public DataSet GetProductDataSource()
    {
        DataSet ds;
        //if (this.SelStorageNo == "-1")
        //{
        //    return null;

        //}
        Product product = new Product();
        System.Text.StringBuilder sql = new System.Text.StringBuilder();
        sql.Append(string.Format(@"select a.ProductId as Product_ID,b.Name as shopName, a.shopid,c.Product_Name,c.Barcode,SalePrice,CouponsNo,CouponsPrice,Discount,
                    SaleLsh ,Sales ,SaleTime,InVoiceNo,ShopId,CustomerName,CustomerPhone,a.Bz,VisaMoney,UserCardMoney,CashMoney,TrueMoney,b.name as shop
    from salerecord a , shop b,product c where  a.shopid=b.id and a.ProductId=c.Product_ID and convert(char(10),SaleTime,102)>= '{0}' and convert(char(10),SaleTime,102)<='{1}' ",
           this.StartDate.ToString("yyyy.MM.dd"), this.EndDate.ToString("yyyy.MM.dd") ));
        if (this.ddl_Shop.SelectedValue != "-1")
        {
            sql.Append("and a.shopid='"+this.ddl_Shop.SelectedValue+"' ");
        
        }
        sql.Append(" order by SaleLsh desc");
        ds = product.GetDateSet(sql.ToString());
        Session["Sale_Record"] = ds;
        return ds;
    }
    /// <summary>
    /// 绑定门店
    /// </summary>
    private void BindShop()
    {
        Product o = new Product();
        string sql = "select id,Name from Shop";
        this.ddl_Shop.DataSource = o.DatabaseAccess.ExecuteDataset(sql);
        this.ddl_Shop.DataBind();
        this.ddl_Shop.Items.Insert(0, new ListItem("----------", "-1"));




    }
    protected void ddl_Shop_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindData();
    }
    protected void ButtonEx1_Click(object sender, EventArgs e)
    {
        BindData();
    }
    protected void btn_Export_Click(object sender, EventArgs e)
    {
        ExportExcel();
    }
    protected void dgProduct_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            DataRowView rowView = (DataRowView)e.Item.DataItem;
            //e.Item.Attributes.Add("onclick", "selectGridItem(this);");
            //e.Item.Attributes.Add("ondblclick", string.Format("Product_OpenNormal('../Product_Profile.aspx?PROID={0}&flag=Edit','Product');", rowView["Product_ID"].ToString().Trim()));
            //e.Item.Attributes.Add("id", "TR" + rowView["Product_ID"].ToString().Trim());

            int head = e.Item.Cells[1].Text.Substring(0, e.Item.Cells[1].Text.Length - 1).LastIndexOf(">") + 1;
            int tail = e.Item.Cells[1].Text.Length;
            string str = e.Item.Cells[1].Text.Substring(head, tail - head);
        }
    }


    private void ExportExcel()
    {

        if (Session["Sale_Record"] == null)
        {

            Response.Write("<script>alert('请先进行查询！');</script>");
            return;
        
        }
        FileStream file = new FileStream( Server.MapPath ("../")+@"Template\SaleTemple.xls", FileMode.Open, FileAccess.Read);
        hssfworkbook = new HSSFWorkbook(file);

        string filename = DateTime.Now.ToString("yyyyMMddHHmmss")+ ".xls";
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", filename));
        Response.Clear();

       


       

        GenerateData();
        Response.BinaryWrite(WriteToStream().GetBuffer());
        Response.End();
    
    }
    MemoryStream WriteToStream()
    {
        //Write the stream data of workbook to the root directory
        MemoryStream file = new MemoryStream();
        hssfworkbook.Write(file);
        return file;
    }

    void GenerateData()
    {
        Sheet sheet1 = hssfworkbook.GetSheetAt(0);

        DataSet ds = Session["Sale_Record"] as DataSet;
        if (ds != null)
        {
            DataTable dt = ds.Tables[0];
            int iCount = dt.Rows.Count;
            Row newrow;
            for (int i = 0; i < iCount; i++)
            {
                newrow = sheet1.CreateRow(i + 1);
                newrow.CreateCell(0).SetCellValue(dt.Rows[i]["shopName"] == null ? "" : dt.Rows[i]["shopName"].ToString());
                newrow.CreateCell(1).SetCellValue(dt.Rows[i]["Product_Name"] == null ? "" : dt.Rows[i]["Product_Name"].ToString());
                newrow.CreateCell(2).SetCellValue(dt.Rows[i]["SalePrice"] == null ? "" : dt.Rows[i]["SalePrice"].ToString());
                newrow.CreateCell(3).SetCellValue(dt.Rows[i]["Barcode"] == null ? "" : dt.Rows[i]["Barcode"].ToString());
                newrow.CreateCell(4).SetCellValue(dt.Rows[i]["CouponsNo"] == null ? "" : dt.Rows[i]["CouponsNo"].ToString());
                newrow.CreateCell(5).SetCellValue(dt.Rows[i]["CouponsPrice"] == null ? "" : dt.Rows[i]["CouponsPrice"].ToString());
                newrow.CreateCell(6).SetCellValue(dt.Rows[i]["Discount"] == null ? "" : dt.Rows[i]["Discount"].ToString());
                newrow.CreateCell(7).SetCellValue(dt.Rows[i]["SaleLsh"] == null ? "" : dt.Rows[i]["SaleLsh"].ToString());
                newrow.CreateCell(8).SetCellValue(dt.Rows[i]["SaleTime"] == null ? "" : dt.Rows[i]["SaleTime"].ToString());
                newrow.CreateCell(9).SetCellValue(dt.Rows[i]["Sales"] == null ? "" : dt.Rows[i]["Sales"].ToString());
                newrow.CreateCell(10).SetCellValue(dt.Rows[i]["CustomerName"] == null ? "" : dt.Rows[i]["CustomerName"].ToString());
                newrow.CreateCell(11).SetCellValue(dt.Rows[i]["CustomerPhone"] == null ? "" : dt.Rows[i]["CustomerPhone"].ToString());
                newrow.CreateCell(12).SetCellValue(dt.Rows[i]["VisaMoney"] == null ? "" : dt.Rows[i]["VisaMoney"].ToString());
                newrow.CreateCell(13).SetCellValue(dt.Rows[i]["UserCardMoney"] == null ? "" : dt.Rows[i]["UserCardMoney"].ToString());
                newrow.CreateCell(14).SetCellValue(dt.Rows[i]["CashMoney"] == null ? "" : dt.Rows[i]["CashMoney"].ToString());
                newrow.CreateCell(15).SetCellValue(dt.Rows[i]["TrueMoney"] == null ? "" : dt.Rows[i]["TrueMoney"].ToString());
                newrow.CreateCell(16).SetCellValue(dt.Rows[i]["Bz"] == null ? "" : dt.Rows[i]["Bz"].ToString());

            }

        }
    }

    
}
