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
using System.Xml.Linq;

/// <summary>
///ProductStateEnum 的摘要说明
/// </summary>
public class ProductStateEnum
{
	public ProductStateEnum()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    //0：库存，1、已确认入库，2：出库扫描完成，3：进店扫描完成，4：已售出

    public static string InStoreString = "库存";
    public static int InStoreInt = 0;
    public static string InStoreCheckString = "已确认入库";
    public static int InStoreCheckInt = 1;
    public static string OutStoreScanString = "出库扫描完成";
    public static int OutStoreScanInt = 2;
    public static string InShopScanString = "进店扫描完成";
    public static int InShopScanInt = 3;
    public static string BeginSaleString = "销售开单";
    public static int BeginSaleInt = 4;
    public static string SaleString = "已售出";
    public static int SaleInt = 5;
}
