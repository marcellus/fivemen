using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Orm;

namespace FT.Web.Bll.Product
{


    [SimpleTable("yuantuo_product_discount")]
    [Alias("产品折扣表")]
    [Serializable]
    public class ProductDiscountInfo
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


        [SimpleColumn(Column = "discount")]
        [Alias("折扣")]
        public double Discount;

        public double 折扣
        {
            get { return Discount; }
            set { Discount = value; }
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
