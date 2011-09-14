using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.IO;
using System.Text;
using System;

public partial class Storage_SingleStorage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindStorage();
            //BindData();

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
    public string SelStorageNo
    {
        get
        {

            return this.ddl_StoNo.SelectedValue.ToString();
        }

    }

    #region 页面事件
    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        if (this.SelStorageNo == "-1")
        {
            Response.Write("<script>alert('请选择入库单号！');</script>");
            return;

        }

        string fileurl = MapPath(ConfigurationManager.AppSettings["FileServerPath"]);
        Product o = new Product();
       
     
        DateTime dt = System.DateTime.Now;
        decimal Factory_Weight = 0;
        decimal Gold_NetWeight = 0;
        decimal ShouCun = 0;
        decimal Price = 0;
       
       
        string picture = string.Empty;

        if (txt_FactoryWeight.Text != string.Empty)
        {
            Factory_Weight = Convert.ToDecimal(txt_FactoryWeight.Text);
        }
        if (txt_NetGoldWeight.Text != string.Empty)
        {
            Gold_NetWeight = Convert.ToDecimal(txt_NetGoldWeight.Text);
        }
        if (txt_Size.Text != string.Empty)
        {
            ShouCun = Convert.ToDecimal(txt_Size.Text);
        }
        if (txt_Price.Text != string.Empty)
        {
            Price = Convert.ToDecimal(txt_Price.Text);
        }

        string styleid = o.DatabaseAccess.ConvertToDBString(txt_StyleID.Text);
     
        string productname = o.DatabaseAccess.ConvertToDBString(txt_ProductName.Text);
        int maxid = o.getMaxID();
        string sql = string.Empty;

        string barcode = "360866" + (100000 + maxid + 1 ).ToString() + "1";
        string newFileName = string.Empty;
        if (UploadFile(barcode, ref newFileName))
        {
            picture = newFileName;

            sql = string.Format(@"insert into Product (Barcode,Product_Name,Factory_Weight,Gold_NetWeight,ShouCun,Style,Picture,
LeiBie,Cailiao,Factory_Name,Descriptions,Created_Date,StorageNo,ProductStatus,Price) values ('{0}','{1}',{2},{3},{4},'{5}','{6}','{7}','{8}','{9}','{10}',getdate(),'{11}','0',{12}) 
                                ; update Product set sort_value=@@IDENTITY, Barcode='360866'+cast(100000+@@IDENTITY as varchar(10))+
                                    right(cast(10-cast(right(cast((20+cast(substring(cast(100000+@@IDENTITY as varchar(10)),2,1) as int)+
                                    cast(substring(cast(100000+@@IDENTITY as varchar(10)),4,1) as int)+
                                    cast(substring(cast(100000+@@IDENTITY as varchar(10)),6,1) as int))*3+9+
                                    cast(substring(cast(100000+@@IDENTITY as varchar(10)),1,1) as int)+
                                    cast(substring(cast(100000+@@IDENTITY as varchar(10)),3,1) as int)+
                                    cast(substring(cast(100000+@@IDENTITY as varchar(10)),5,1) as int) as varchar(10)),1) as int) as varchar(10)),1)
                                    where Product_ID = @@IDENTITY
                                ; select top 1 barcode from product order by Product_ID desc"
                     , barcode, o.DatabaseAccess.ConvertToDBString(txt_ProductName.Text), Factory_Weight, Gold_NetWeight, ShouCun, txt_StyleID.Text,
                     picture,  this.ddl_LeiBie.SelectedValue, this.ddl_SmallType.SelectedValue, this.ddl_OrderName.SelectedValue,
                     o.DatabaseAccess.ConvertToDBString(txt_Description.Value),SelStorageNo,Price);

            string newbarcode = o.DatabaseAccess.ExecuteScalar(sql).ToString();
            Response.Write("<script>alert('产品入库成功！');</script>");

            ViewState["Barcode"] = newbarcode;

        }
        this.hiddenforupload.Value = newFileName;
    }

    private void ClearText()
    { 
    
    
    }

    protected bool UploadFile(string filename, ref string newFileName)
    {
      
        string fileSavePath = Server.MapPath("~/" + ConfigurationManager.AppSettings["FileServerPath"]);
        string fileExt = this.FileUpload1.FileName.Substring(FileUpload1.FileName.LastIndexOf(".") + 1);
        string filenamereal = this.FileUpload1.FileName.Substring(FileUpload1.FileName.LastIndexOf("\\") + 1);

        newFileName = filenamereal;
        if (File.Exists(fileSavePath + "\\" + newFileName))
        {
            File.Delete(fileSavePath + "\\" + newFileName);
        }
        FileStream fs = new FileStream(fileSavePath + "\\" + newFileName, FileMode.CreateNew);
        try
        {
            byte[] file = new byte[FileUpload1.FileContent.Length];
            FileUpload1.PostedFile.InputStream.Read(file, 0, FileUpload1.PostedFile.ContentLength);
            fs.Write(file, 0, FileUpload1.PostedFile.ContentLength);
            //Response.Write("<script>alert('Upload file succeed!')</script>");
            return true;
        }
        catch (Exception ee)
        {
            Response.Write("<script>alert('" + ee.Message + "')</script>");
            return false;
        }
        finally
        {
            fs.Close();
        }
    }

  
    #endregion

   
}
