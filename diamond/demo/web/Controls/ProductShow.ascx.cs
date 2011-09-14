using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class Controls_ProductShow : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
       // this.txtBarCode.k
        //this.txtBarCode.Attributes["onkeydown"] = "javascript:ShowProductDetail(event);";
        this.txtBarCode.Attributes.Add("onkeydown", "if(event.which||event.keyCode){if ((event.which==13 ) || (event.keyCode==13)) { document.getElementById('" + this.btnSearch.UniqueID + "').click();return false;}}else{return true};");


    }

    public void Clear()
    {
        this.txtBarCode.Text = "";
        this.txtBz.Text = "";
        this.txtCplb.Text = "";
        this.txtCz.Text = "";
        this.txtFcz.Text = "";
        this.txtGchz.Text = "";
        this.txtGf.Text = "";
        this.txtJjz.Text = "";
        this.txtJs.Text = "";
        this.txtKh.Text = "";
        this.txtLsj.Text = "";
        this.txtPm.Text = "";
        this.txtSc.Text = "";
        this.txtSjgf.Text = "";
        this.txtYbh.Text = "";
        this.txtGhs.Text = "";
        this.lbProductId.Text = "";
        string file = Server.MapPath("~/FileServer");
        file = file + "/Pic/no_photo.jpg";
        this.imgPic.ImageUrl = file;
    }

    public void Focus()
    {
        this.txtBarCode.Focus();
    }

    public string BarCode
    {
        get{

            return this.txtBarCode.Text;
        }
    }

    public string ProductId
    {
        get
        {

            return this.lbProductId.Text;
        }
    }

    private string Trans(double str)
    {

        return str == null ? "0.00" : str.ToString();
    }

    private string Trans(string str)
    {

        return str == null ? string.Empty : str;
    }
    

    //当条码改变时触发事件
    public event ScanChangeHandler ScanChanged;//定义一个ColorChanged事件

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string barcode = this.BarCode;
        if (barcode.Length > 0)
        {
            ArrayList lists=FT.DAL.Orm.SimpleOrmOperator.QueryConditionList<ProductInfo>(" where Barcode='"+barcode+"'");
            if(lists!=null&&lists.Count==1)
            {
                ProductInfo info = lists[0] as ProductInfo;
                this.txtBz.Text = Trans(info.Bz).ToString();
                this.txtCplb.Text = Trans(info.Cplb).ToString();
                this.txtCz.Text = Trans(info.Cz).ToString();
                this.txtFcz.Text = Trans(info.Fcz).ToString();
                this.txtGchz.Text = Trans(info.Gchz).ToString();
                this.txtGf.Text = Trans(info.Gf).ToString();
                this.txtJjz.Text = Trans(info.Jjz).ToString();
                this.txtJs.Text = Trans(info.Js).ToString();
                this.txtKh.Text = Trans(info.Kh).ToString();
                this.txtLsj.Text = Trans(info.Lsj).ToString();
                this.txtPm.Text = Trans(info.Pm).ToString();
                this.txtSc.Text = Trans(info.Sc).ToString();
                this.txtSjgf.Text = Trans(info.Sjgf).ToString();
                this.txtYbh.Text = Trans(info.Ybh).ToString();
                this.txtGhs.Text = Trans(info.Ghs).ToString();
                this.lbProductId.Text = Trans(info.Product_Id).ToString();
                string file = Server.MapPath("~/FileServer");
                if (info.ImgPath!=null&&info.ImgPath.Length > 0)
                {
                    file = file + "/Pic/"+info.ImgPath;
                }
                else
                {
                    file = file + "/Pic/no_photo.jpg";
                }
                
                this.imgPic.ImageUrl = file;
            }
            else{

                this.txtBz.Text = "";
                this.txtCplb.Text = "";
                this.txtCz.Text = "";
                this.txtFcz.Text = "";
                this.txtGchz.Text = "";
                this.txtGf.Text = "";
                this.txtJjz.Text = "";
                this.txtJs.Text = "";
                this.txtKh.Text = "";
                this.txtLsj.Text = "";
                this.txtPm.Text = "";
                this.txtSc.Text = "";
                this.txtSjgf.Text = "";
                this.txtYbh.Text = "";
                this.txtGhs.Text = "";
                this.lbProductId.Text = "";
                string file = Server.MapPath("~/FileServer");
                file = file + "/Pic/no_photo.jpg";
                this.imgPic.ImageUrl = file;
            }
            if (ScanChanged != null)
            {//判断事件是否为空
                ScanChanged(this, e);//触发事件
            }
        }
       

    }
}

public delegate void ScanChangeHandler(object sender, EventArgs e);//事件所需的委托
