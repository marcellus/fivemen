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

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

public partial class Services_ProductDetailShow : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ProductInfo product = new ProductInfo();
            product.Ghs = "金至尊";
            product.Pm = "品名1";
          /*
           product.Bz = "备注1";
            product.Cplb = "产品类别1";
            product.Cz = "材质1";
            product.Fcz = 50.0;
            product.Gchz = 55.00;
            product.Jjz = 51.01;
            product.ImgPath = "/web/images/logo.gif";
            product.Js = 1;
            product.Kh = "款号1";
            product.Lsj = 5999.98;
            product.Sc = "手寸123";
            product.Sjgf = 501.11;
            product.Ybh = "原编号";
            product.Gf = 101.12;
           * */
            product.State = "在库";
           // StringBuilder sb = new StringBuilder();
            string json = JsonConvert.SerializeObject(product, Formatting.Indented);
            
            Console.WriteLine("Json格式化列表：" + json);
            Response.Write(json);
            Response.End();
        }
    }

   
}
