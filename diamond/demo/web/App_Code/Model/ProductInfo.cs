using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using FT.DAL.Orm;
/// <summary>
///ProductInfo 的摘要说明
/// </summary>
[SimpleTable("Product")]
public class ProductInfo
{
	public ProductInfo()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    [SimplePK]
    [SimpleColumn(Column = "Product_Id")]
    public int Product_Id;


    
    [SimpleColumn(Column = "Product_Name")]
    public string Pm;

    [SimpleColumn(Column = "Factory_Name")]
    public string Ghs;

    [SimpleColumn(Column = "Barcode")]
    public string BarCode;

    [SimpleColumn(Column = "Style")]
    public string Kh;
    [SimpleColumn(Column = "LeiBie")]
    public string Cplb;
    [SimpleColumn(Column = "Factory_Weight")]
    public double Gchz;
    [SimpleColumn(Column = "Cailiao")]
    public string Cz;
    [SimpleColumn(Column = "Gold_NetWeight")]
    public double Jjz;
    [SimpleColumn(Column = "ComfirmWeight")]
    public double Fcz;
    [SimpleColumn(Column = "Old_NO")]
    public string Ybh;
    [SimpleColumn(Column = "ShouCun")]
    public string Sc;
    [SimpleColumn(Column = "Price")]
    public double Lsj;
    [SimpleColumn(Column = "SuJinFeiYong")]
    public double Sjgf;
    [SimpleColumn(Column = "Real_Number")]
    public int Js;
    [SimpleColumn(Column = "GongFei")]
    public double Gf;
    [SimpleColumn(Column = "Descriptions")]
    public string Bz;
    /* */
    [SimpleColumn(Column = "Picture")]
    public string ImgPath;
    [SimpleColumn(Column = "ProductStatus")]
    public string State;
}
