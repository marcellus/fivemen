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

    public int ProductId;

    public decimal SalePrice;

       public string  CouponsNo;
        public decimal CouponsPrice;
       public decimal Discount;
       public string  SaleLsh;
       public string  Sales;
      public DateTime  SaleTime;
      public string   InVoiceNo;
      public int  ShopId;
      public string  CustomerName;
       public string CustomerPhone;
       //public string InVoiceNo;
       public decimal VisaMoney;
        public decimal UserCardMoney;
        public decimal CashMoney;
        public decimal  TrueMoney;
        public string Bz;

        //public string SaleLsh;


}
