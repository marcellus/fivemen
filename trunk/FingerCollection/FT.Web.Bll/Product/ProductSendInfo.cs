using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Orm;

namespace FT.Web.Bll.Product
{
    [SimpleTable("yuantuo_product_send")]
    [Alias("产品赠送表")]
    [Serializable]
    public class ProductSendInfo
    {
        [SimplePK]
        public int Id;

        public int 编号
        {
            get { return Id; }
            set { Id = value; }
        }

        [SimpleColumn(Column = "productid")]
        [Alias("购买产品")]
        public int ProductId;

        public int 购买产品
        {
            get { return ProductId; }
            set { ProductId = value; }
        }


        [SimpleColumn(Column = "num")]
        [Alias("购买产品数量")]
        public int Num;

        public int 购买产品数量
        {
            get { return Num; }
            set { Num = value; }
        }



        [SimpleColumn(Column = "sendproductid")]
        [Alias("赠送产品")]
        public int SendProductId;

        public int 赠送产品
        {
            get { return SendProductId; }
            set { SendProductId = value; }
        }

        [SimpleColumn(Column = "startdate")]
        [Alias("优惠开始时间")]
        public DateTime StartDate;

        public DateTime 优惠开始时间
        {
            get { return StartDate; }
            set { StartDate = value; }
        }

        [SimpleColumn(Column = "enddate")]
        [Alias("优惠结束时间")]
        public DateTime EndDate;

        public DateTime 优惠结束时间
        {
            get { return EndDate; }
            set { EndDate = value; }
        }
    }
}
