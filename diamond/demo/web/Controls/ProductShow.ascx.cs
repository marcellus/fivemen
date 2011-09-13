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
                this.txtBz.Text = info.Bz.ToString();
                this.txtCplb.Text = info.Cplb.ToString();
                this.txtCz.Text = info.Cz.ToString();
                this.txtFcz.Text = info.Fcz.ToString();
                this.txtGchz.Text = info.Gchz.ToString();
                this.txtGf.Text = info.Gf.ToString();
                this.txtJjz.Text = info.Jjz.ToString();
                this.txtJs.Text = info.Js.ToString();
                this.txtKh.Text = info.Kh.ToString();
                this.txtLsj.Text = info.Lsj.ToString();
                this.txtPm.Text = info.Pm.ToString();
                this.txtSc.Text = info.Sc.ToString();
                this.txtSjgf.Text = info.Sjgf.ToString();
                this.txtYbh.Text = info.Ybh.ToString();
                this.txtGhs.Text = info.Ghs.ToString();
                this.lbProductId.Text = info.Product_Id.ToString();
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
            }
            if (ScanChanged != null)
            {//判断事件是否为空
                ScanChanged(this, e);//触发事件
            }
        }
       

    }
}

public delegate void ScanChangeHandler(object sender, EventArgs e);//事件所需的委托
