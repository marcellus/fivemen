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
public partial class Storage_BulkStorage : System.Web.UI.Page
{
    private HSSFWorkbook hssfworkbook;
    private Sheet sheet;
    private DataTable dtstorage;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindStorage();
            //BindData();

        }
    }
    #region 页面事件
    /// <summary>
    /// 导入
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btn_Import_Click(object sender, EventArgs e)
    {
        string path = Server.MapPath("~/TempFiles/" + DateTime.Now.ToString("yyyymmddhhmmss") + ".xls");
        if (this.FileUpload1.HasFile)
        {
            try
            {
                if (this.SelStorageNo == "-1")
                {
                    Response.Write("<script>alert('请选择入库单号！');</script>");
                    return;

                }
                if (!FileUpload1.FileName.EndsWith("xls"))
                {
                    Response.Write("<script>alert('请选择正确的Excel文件！');</script>");
                    return;

                }


                FileUpload1.SaveAs(path);
                FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read);
                hssfworkbook = new HSSFWorkbook(file);
                sheet = hssfworkbook.GetSheetAt(0);
                dtstorage = GetDataTable();//读取Excel值到datatable中
                ImportToDataBase();//导入数据库
            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('" + ex.ToString() + "');</script>");

            }

        }
    }
    protected void ddl_StoNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindData();

    }
    public string SelStorageNo
    {
        get
        {

            return this.ddl_StoNo.SelectedValue.ToString();
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


    #endregion
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
        //if (this.SelStorageNo == "-1")
        //{
        //    return null;

        //}
        Product product = new Product();
        System.Text.StringBuilder sql = new System.Text.StringBuilder();
        sql.Append(@"select Product_ID,Barcode,Product_Name,Factory_Weight,Gold_NetWeight,ShouCun,Style,Factory_Name,Descriptions 
                    from Product where StorageNo='" + this.SelStorageNo + "' and ProductStatus='0'");
        sql.Append(" and Product.Delete_YN<>'Y'");

        sql.Append(" order by Modify_Date desc");

        return product.GetDateSet(sql.ToString());
    }
    private void BindStorage()
    {
        StorageList storage = new StorageList();
        string sql = "select StorageNo from StorageList";
        this.ddl_StoNo.DataSource = storage.DatabaseAccess.ExecuteDataset(sql);
        this.ddl_StoNo.DataBind();
      this.ddl_StoNo.Items.Insert(0, new ListItem("----------", "-1"));




    }


    /// <summary>
    /// 将数据插入数据库
    /// </summary>
    private void ImportToDataBase()
    {
        if (dtstorage != null && dtstorage.Rows.Count > 0)
        {
            Product product = new Product();
            StringBuilder strsql = new StringBuilder();
            string stNo = this.SelStorageNo;
            int iCount = dtstorage.Rows.Count;
            //int maxid = product.getMaxID();
            //string barCode;
            for (int i = 0; i < iCount; i++)
            {
                //barCode = "360866" + (100000 + maxid + 1 + i).ToString() + "1";
                strsql.Append(string.Format(@"INSERT INTO Product(Product_Name,Factory_Weight,Gold_NetWeight,ShouCun,Style,LeiBie,Cailiao,Factory_Name,Descriptions,Created_Date,Barcode,StorageNo,ProductStatus,Price)
     VALUES('{0}',{1},{2},{3},'{4}','{5}','{6}','{7}','{8}',getdate(),{9},'{10}','{11}',{12});",
         dtstorage.Rows[i]["Product_Name"].ToString(),
         dtstorage.Rows[i]["Factory_Weight"].ToString(),
         dtstorage.Rows[i]["Gold_NetWeight"].ToString(),
         dtstorage.Rows[i]["ShouCun"].ToString(),
         dtstorage.Rows[i]["Style"].ToString(),
         dtstorage.Rows[i]["LeiBie"].ToString(),
         dtstorage.Rows[i]["Cailiao"].ToString(),
         dtstorage.Rows[i]["Factory_Name"].ToString(),
         dtstorage.Rows[i]["Descriptions"].ToString(), dtstorage.Rows[i]["Bar_Code"].ToString(), stNo, '0',
         dtstorage.Rows[i]["SalePrice"].ToString() ));
            }


            product.DatabaseAccess.ExecuteNonQuery(strsql.ToString());
            
            Response.Write("<script>alert('入库单导入成功！');</script>");
            BindData();
        }






    }

    private DataTable GetDataTable()
    {
        DataTable dt = new DataTable();
        if (sheet != null)
        {
            dt.Columns.Add("Bar_Code", Type.GetType("System.String"));//条码
            dt.Columns.Add("Product_Name", Type.GetType("System.String"));//产品名称
            dt.Columns.Add("Factory_Weight", Type.GetType("System.Double"));//工厂重量
            dt.Columns.Add("Gold_NetWeight", Type.GetType("System.Double"));//净金重量
            dt.Columns.Add("ShouCun", Type.GetType("System.Double"));//手寸
            dt.Columns.Add("Style", Type.GetType("System.String"));//款号
            dt.Columns.Add("LeiBie", Type.GetType("System.String"));//类别
            dt.Columns.Add("Cailiao", Type.GetType("System.String"));//材料
            dt.Columns.Add("Factory_Name", Type.GetType("System.String"));//供应商
            dt.Columns.Add("SalePrice", Type.GetType("System.Double"));//零售价
            dt.Columns.Add("Descriptions", Type.GetType("System.String"));//描述

            int rowcount = sheet.PhysicalNumberOfRows;
            Row temprow;
            DataRow newRow;//声明一个新行
            ///遍历所有行
            for (int i = 1; i < rowcount; i++)
            {
                temprow = sheet.GetRow(i);

                if (temprow == null || temprow.GetCell(0) == null || string.IsNullOrEmpty(temprow.GetCell(0).StringCellValue))
                {
                    continue;
                }
                newRow = dt.NewRow();
                newRow["Bar_Code"] = temprow.GetCell(0) == null ? "" : temprow.GetCell(0).ToString();
                newRow["Factory_Name"] = temprow.GetCell(1) == null ? "" : temprow.GetCell(1).ToString();
                newRow["Product_Name"] = temprow.GetCell(2) == null ? "" : temprow.GetCell(2).ToString();
                newRow["Style"] = temprow.GetCell(3) == null ? "" : temprow.GetCell(3).ToString();
                newRow["LeiBie"] = temprow.GetCell(4) == null ? "" : temprow.GetCell(4).ToString();
                newRow["Cailiao"] = temprow.GetCell(5) == null ? "" : temprow.GetCell(5).ToString();
                newRow["Factory_Weight"] = temprow.GetCell(6) == null ? 0 : temprow.GetCell(6).NumericCellValue;
                newRow["Gold_NetWeight"] = temprow.GetCell(7) == null ? 0 : temprow.GetCell(7).NumericCellValue;

                newRow["ShouCun"] = temprow.GetCell(8) == null ? 0 : temprow.GetCell(8).NumericCellValue;
                newRow["SalePrice"] = temprow.GetCell(9) == null ? 0 : temprow.GetCell(9).NumericCellValue;
                newRow["Descriptions"] = temprow.GetCell(10) == null ? "" : temprow.GetCell(10).ToString();


                dt.Rows.Add(newRow);

            }
        }

        return dt;



    }


}
