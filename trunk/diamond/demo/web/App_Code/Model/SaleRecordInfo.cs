using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using FT.DAL.Orm;

/// <summary>
///SaleRecordInfo 的摘要说明
/// </summary>
[SimpleTable("Shop")]
public class SaleRecordInfo
{
    public SaleRecordInfo()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
    [SimplePK]
    public int Id;

    [SimpleColumn(Column = "ProductId")]
    public int ProductId;

    [SimpleColumn(Column = "SalePrice")]
    public decimal SalePrice;

    [SimpleColumn(Column = "CouponsNo")]
       public string  CouponsNo;
    [SimpleColumn(Column = "CouponsPrice")]
        public decimal CouponsPrice;
    [SimpleColumn(Column = "Discount")]
       public decimal Discount;
    [SimpleColumn(Column = "SaleLsh")]
       public string  SaleLsh;
    [SimpleColumn(Column = "Sales")]
       public string  Sales;

    [SimpleColumn(Column = "InVoiceNo")]
      public string   InVoiceNo;
    [SimpleColumn(Column = "ShopId")]
      public int  ShopId;
    [SimpleColumn(Column = "CustomerName")]
      public string  CustomerName;
    [SimpleColumn(Column = "CustomerPhone")]
       public string CustomerPhone;
       //public string InVoiceNo;
      [SimpleColumn(Column = "VisaMoney")]
       public decimal VisaMoney;
       [SimpleColumn(Column = "UserCardMoney")]
        public decimal UserCardMoney;
       [SimpleColumn(Column = "CashMoney")]

        public decimal CashMoney;
       [SimpleColumn(Column = "TrueMoney")]
        public decimal  TrueMoney;
       [SimpleColumn(Column = "Bz")]
        public string Bz;

        //public string SaleLsh;


}
