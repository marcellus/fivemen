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
using System.IO;
using System.Text;

public partial class Product_Profile : Pagebase
{
    public int ProductID
    {
        get
        {
            return ACE.Common.Util.ACEUtil.GetIntQueryString("PROID");
        }
    }

    public string Flag
    {
        get
        {
            return ACE.Common.Util.ACEUtil.GetStringQueryString("flag");
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadData();
        }
    }



    public void LoadData()
    {
        
        string filedownloadurl = ConfigurationManager.AppSettings["FileDownloadPath"];
        
        Small_Type st=new Small_Type();
        Product o = new Product();
        string sql = string.Empty;
        if (ViewState["Barcode"] != null && ViewState["Barcode"].ToString() != string.Empty)
        {
            sql = string.Format(@"select Product.* from Product where Barcode={0}", ViewState["Barcode"].ToString());
        }
        else
        {
            sql = string.Format(@"select Product.* from Product where Product_ID={0}", ProductID);
        }
        DataSet ds = o.GetDateSet(sql);
        DataTable dt = ds.Tables[0];
        if (dt.Rows.Count > 0)
        {
            DataRow dr = dt.Rows[0];
            if (dr["LeiBie"] != DBNull.Value)
            {
                if (ddl_LeiBie.Items.FindByValue(dr["LeiBie"].ToString()) != null)
                {
                    ddl_LeiBie.SelectedValue = dr["LeiBie"].ToString();
                }
            }
            if (dr["Factory_Weight"] != DBNull.Value)
            {
                txt_FactoryWeight.Text = Convert.ToDecimal(dr["Factory_Weight"].ToString()).ToString("N2");
            }
            if (dr["Factory_Name"] != DBNull.Value)
            {
                if (ddl_OrderName.Items.FindByValue(dr["Factory_Name"].ToString()) != null)
                {
                    ddl_OrderName.SelectedValue = dr["Factory_Name"].ToString();
                }
            }
            if (dr["Style"] != DBNull.Value)
            {
                txt_StyleID.Text = dr["Style"].ToString();
            }
            if (dr["Cailiao"] != DBNull.Value)
            {
                if (ddl_SmallType.Items.FindByValue(dr["Cailiao"].ToString()) != null)
                {
                    ddl_SmallType.SelectedValue = dr["Cailiao"].ToString();
                }                
            }
            if (dr["Factory_Weight"] != DBNull.Value)
            {
                txt_FactoryWeight.Text = Convert.ToDecimal(dr["Factory_Weight"].ToString()).ToString("N2");
            }

            if (dr["Gold_NetWeight"] != DBNull.Value)
            {
                txt_NetGoldWeight.Text = Convert.ToDecimal(dr["Gold_NetWeight"].ToString()).ToString("N2");
                
            }
            if (dr["Barcode"] != DBNull.Value)
            {
                txt_Barcode.Text = dr["Barcode"].ToString();
                ViewState["Barcode"] = dr["Barcode"].ToString();
            }
            if (dr["Product_Name"] != DBNull.Value)
            {
                txt_ProductName.Text = dr["Product_Name"].ToString();
            }
            if (dr["Style"] != DBNull.Value)
            {
                txt_StyleID.Text = dr["Style"].ToString();
            }
            if (dr["Price"] != DBNull.Value)
            {
                txt_Price.Text = dr["Price"].ToString();
            }
            if (dr["Old_NO"] != DBNull.Value)
            {
                txt_OldNO.Text = dr["Old_NO"].ToString();
            }
            if (dr["ShouCun"] != DBNull.Value)
            {
                txt_Size.Text = dr["ShouCun"].ToString();
            }

            if (dr["SuJinFeiYong"] != DBNull.Value)
            {
                txt_SuJinGongFei.Text = Convert.ToDecimal(dr["SuJinFeiYong"].ToString()).ToString("N2");
            }
            if (dr["GongFei"] != DBNull.Value)
            {
                txt_GongFei.Text = Convert.ToDecimal(dr["GongFei"].ToString()).ToString("N2");
            }
            if (dr["Real_Number"] != DBNull.Value)
            {
                txt_Count.Text = dr["Real_Number"].ToString();
            }

            if (dr["Descriptions"] != DBNull.Value)
            {
                txt_Description.Value = dr["Descriptions"].ToString();
            }
            if (dr["Picture"] != DBNull.Value && dr["Picture"].ToString() != string.Empty)
            {
                //this.ImageEx1.ImageUrl = filedownloadurl + "/" + dr["Picture"].ToString();
                this.hiddenforimage.Value = filedownloadurl + "/" + dr["Picture"].ToString();
                //if (HttpContext.Current.Session["empRole"].ToString() == "Admin")
                //{
                //    this.btn_DeletePicture.Visible = true;
                //}
            }
            else
            {
                this.hiddenforimage.Value = string.Empty;
                this.btn_DeletePicture.Visible = false;
            }
        }
    }
    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        string fileurl = MapPath(ConfigurationManager.AppSettings["FileServerPath"]);
        Product o = new Product();
        int userid = 0;
        int maxid = 0;
        DateTime dt = System.DateTime.Now;
        decimal Factory_Weight = 0;
        decimal Gold_NetWeight = 0;
        decimal ShouCun = 0;
        decimal Price = 0;
        decimal SuJinFeiYong = 0;
        decimal GongFei = 0;
        decimal Real_Number = 1;
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
        if (txt_SuJinGongFei.Text != string.Empty)
        {
            SuJinFeiYong = Convert.ToDecimal(txt_SuJinGongFei.Text);
        }
        if (txt_GongFei.Text != string.Empty)
        {
            GongFei = Convert.ToDecimal(txt_GongFei.Text);
        }
        if (txt_Count.Text != string.Empty)
        {
            Real_Number = Convert.ToInt32(txt_Count.Text);
        }
        string styleid = o.DatabaseAccess.ConvertToDBString(txt_StyleID.Text);
        string size = o.DatabaseAccess.ConvertToDBString(txt_Price.Text);
        string productname = o.DatabaseAccess.ConvertToDBString(txt_ProductName.Text);

        string sql = string.Empty;

        string barcode = "360866" + (100000 + maxid + 1).ToString() + "1";
        string newFileName = string.Empty;
        if (UploadFile(barcode, ref newFileName))
        {
            picture = newFileName;

            sql = string.Format(@"insert into Product (Barcode,Product_Name,Factory_Weight,Gold_NetWeight,ShouCun,Price,Style,Picture,Old_NO,Real_Number,SuJinFeiYong,GongFei,
LeiBie,Cailiao,Factory_Name,Descriptions,Created_Date,Created_By,Modify_Date,Modify_By) values ('{0}','{1}',{2},{3},{4},{5},'{6}','{7}','{8}',{9},{10},{11},'{12}','{13}','{14}','{15}',
getdate(),0,getdate(),0) 
                                ; update Product set sort_value=@@IDENTITY, Barcode='360866'+cast(100000+@@IDENTITY as varchar(10))+
                                    right(cast(10-cast(right(cast((20+cast(substring(cast(100000+@@IDENTITY as varchar(10)),2,1) as int)+
                                    cast(substring(cast(100000+@@IDENTITY as varchar(10)),4,1) as int)+
                                    cast(substring(cast(100000+@@IDENTITY as varchar(10)),6,1) as int))*3+9+
                                    cast(substring(cast(100000+@@IDENTITY as varchar(10)),1,1) as int)+
                                    cast(substring(cast(100000+@@IDENTITY as varchar(10)),3,1) as int)+
                                    cast(substring(cast(100000+@@IDENTITY as varchar(10)),5,1) as int) as varchar(10)),1) as int) as varchar(10)),1)
                                    where Product_ID = @@IDENTITY
                                ; select top 1 barcode from product order by Product_ID desc"
                     , barcode, o.DatabaseAccess.ConvertToDBString(txt_ProductName.Text), Factory_Weight, Gold_NetWeight, ShouCun, Price, txt_StyleID.Text,
                     picture, txt_OldNO.Text, Real_Number, SuJinFeiYong, GongFei, this.ddl_LeiBie.SelectedValue, this.ddl_SmallType.SelectedValue, this.ddl_OrderName.SelectedValue,
                     o.DatabaseAccess.ConvertToDBString(txt_Description.Value));

            string newbarcode = o.DatabaseAccess.ExecuteScalar(sql).ToString();
            Response.Write("<script>alert('产品入库成功！');opener.location = opener.location;</script>");

            ViewState["Barcode"] = newbarcode;
            LoadData();
        }
        this.hiddenforupload.Value = newFileName;
    }

    protected bool UploadFile(string filename, ref string newFileName)
    {
        string fileSavePath =  MapPath(ConfigurationManager.AppSettings["FileServerPath"]);
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
    
    protected void btn_DeletePicture_Click(object sender, EventArgs e)
    {
        string fileSavePath = MapPath(ConfigurationManager.AppSettings["FileServerPath"]);
        Product o = new Product();
        string sql = string.Empty;
        if (ViewState["Barcode"] != null && ViewState["Barcode"].ToString() != string.Empty)
        {
            sql = string.Format(@"select Picture from Product where Barcode={0}", ViewState["Barcode"].ToString());
        }
        else
        {
            sql = string.Format(@"select Picture from Product where Product_ID={0}", ProductID);
        }
        DataSet ds = o.GetDateSet(sql);
        DataTable dt = ds.Tables[0];
        if (dt.Rows.Count > 0 && dt.Rows[0][0] != null && dt.Rows[0][0].ToString() != string.Empty)
        {
            string picurl = fileSavePath + "\\" + dt.Rows[0][0].ToString();
            if (File.Exists(picurl))
            {
                if (!o.HaveProductExist(dt.Rows[0][0].ToString()))
                {
                    File.Delete(picurl);
                }
            }
        }
        string sqlupdate = string.Empty;
        if (ViewState["Barcode"] != null && ViewState["Barcode"].ToString() != string.Empty)
        {
            sqlupdate = string.Format(@"update Product set Picture='' where Barcode={0}", ViewState["Barcode"].ToString());
        }
        else
        {
            sqlupdate = string.Format(@"update Product set Picture='' where Product_ID={0}", ProductID);
        }
        o.DatabaseAccess.ExecuteNonQuery(sqlupdate);
        Response.Write("<script>alert('Delete picture succeed!');</script>");
        LoadData();
    }
}
