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
using FT.Web.Bll.Product;
using FT.Commons.Tools;
using FT.DAL.Orm;
using System.IO;

public partial class YuanTuo_BackProductEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.Label1.Text = string.Empty;
            this.Label2.Text = string.Empty;
            GobalTools.BindProductType(this.cbProductTypeIdValue);
            if (Request.Params["id"] != null)
            {
                ProductInfo entity = SimpleOrmOperator.Query<ProductInfo>(Convert.ToInt32(Request.Params["id"]));
                WebFormHelper.SetDataToForm(this, entity);
                this.CKEditorControl1.Text = System.Web.HttpUtility.HtmlDecode(entity.Production);
                ViewState["imgstr"] = entity.Imgs;
                ViewState["imgmain"] = entity.ImgMain;
                
            }
            else
            {
                ViewState["imgstr"] = ";";
                ViewState["imgmain"] = string.Empty;
            }
           
        }
        this.RefreshImgs();
    }

    private void RefreshImgs()
    {
        string file = ViewState["imgstr"].ToString();
        string[] imgs = file.Split(';');
        Image img = null;
        this.PlaceHolder1.Controls.Clear();
        for (int i = 0; i < imgs.Length; i++)
        {
            if (imgs[i].Length > 0)
            {
                img = new Image();
                img.ImageUrl = string.Format("~/YuanTuo/ProductPic/{0}", imgs[i]);
                img.Height = 60;
                img.Width = 60;
                this.PlaceHolder1.Controls.Add(img);
                Literal sep = new Literal();
                sep.Text = " ";
                this.PlaceHolder1.Controls.Add(sep);
            }
        }
        this.imgMainImgShow.ImageUrl = string.Format("~/YuanTuo/ProductPic/{0}", ViewState["imgmain"].ToString());
    }
    protected void btnSure_Click(object sender, EventArgs e)
    {
        ProductInfo entity = new ProductInfo();

        WebFormHelper.GetDataFromForm(this, entity);
        // entity.MachineMac = FT.Commons.Web.Tools.WebToolsHelper.GetMac(entity.MachineIp);
        //entity.StartDate = Convert.ToDateTime(this.txtBeginDate.Value.ToString());
        // entity.EndDate = Convert.ToDateTime(this.txtEndDate.Value.ToString());
         entity.Imgs=ViewState["imgstr"].ToString();
         entity.ImgMain = ViewState["imgmain"].ToString();
        entity.Production=System.Web.HttpUtility.HtmlEncode(this.CKEditorControl1.Text);

        //Server.HtmlEncode(this.i_content.Text); 
        if (entity.Id < 0)
        {
            if (SimpleOrmOperator.Create(entity))
            {
                WebTools.Alert(this, "添加成功！");
            }
            else
            {
                WebTools.Alert("添加失败！");

            }
        }
        else
        {
            if (SimpleOrmOperator.Update(entity))
            {
                WebTools.Alert(this, "修改成功！");
            }
            else
            {
                WebTools.Alert("修改失败！");

            }

        }
    }
    protected void CKEditorControl1_TextChanged(object sender, EventArgs e)
    {
        
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        if (this.FileUpload1.HasFile)
        {
            string fileContentType = FileUpload1.PostedFile.ContentType;
            if (fileContentType == "image/bmp" || fileContentType == "image/gif" || fileContentType == "image/pjpeg")
            {
                string name = FileUpload1.PostedFile.FileName;                  // 客户端文件路径
                string sub=name.Substring(name.IndexOf("."));
                FileInfo file = new FileInfo(name);
                string fileName = this.txtNo.Text.Trim()+"-" + System.DateTime.Now.ToString("yyyyMMddHHmmss")+sub;                                   // 文件名称
                string webFilePath = Server.MapPath("~/YuanTuo/ProductPic/" + fileName);        // 服务器端文件路径
               

                if (!File.Exists(webFilePath))
                {
                    try
                    {
                        FileUpload1.SaveAs(webFilePath);                                // 使用 SaveAs 方法保存文件
                       
                        this.Label1.Text = "提示：文件成功上传！";
                        ViewState["imgstr"] = ViewState["imgstr"].ToString() + ";" + fileName;
                        this.RefreshImgs();
                    }
                    catch (Exception ex)
                    {
                        Label1.Text = "提示：文件上传失败，失败原因：" + ex.Message;
                    }
                }
                else
                {
                    Label1.Text = "提示：文件已经存在，请重命名后上传";
                }
            }
            else
            {
                Label1.Text = "提示：文件类型不符";
            }
        }
    }
    protected void btnMainImgUpload_Click(object sender, EventArgs e)
    {
        if (this.FileUpload2.HasFile)
        {
            string fileContentType = FileUpload2.PostedFile.ContentType;
            if (fileContentType == "image/bmp" || fileContentType == "image/gif" || fileContentType == "image/pjpeg")
            {
                string name = FileUpload2.PostedFile.FileName;                  // 客户端文件路径
                string sub = name.Substring(name.IndexOf("."));
                FileInfo file = new FileInfo(name);
                string fileName = this.txtNo.Text.Trim() + "-main" + System.DateTime.Now.ToString("yyyyMMddHHmmss") + sub;                                   // 文件名称
                string webFilePath = Server.MapPath("~/YuanTuo/ProductPic/" + fileName);        // 服务器端文件路径


                if (!File.Exists(webFilePath))
                {
                    try
                    {
                        FileUpload2.SaveAs(webFilePath);                                // 使用 SaveAs 方法保存文件

                        this.Label2.Text = "提示：文件成功上传！";
                        ViewState["imgmain"] = fileName;
                        this.RefreshImgs();
                       
                    }
                    catch (Exception ex)
                    {
                        Label2.Text = "提示：文件上传失败，失败原因：" + ex.Message;
                    }
                }
                else
                {
                    Label2.Text = "提示：文件已经存在，请重命名后上传";
                }
            }
            else
            {
                Label2.Text = "提示：文件类型不符";
            }
        }
    }
    protected void btnCycleImgClear_Click(object sender, EventArgs e)
    {
        ViewState["imgstr"] = string.Empty;
        this.PlaceHolder1.Controls.Clear();
    }
}
