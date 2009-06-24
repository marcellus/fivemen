using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Orm;


namespace Jxc.Plugin
{
    [SimpleTable("table_jxc_basedata")]
    [Alias("产品种类配置")]
    public class BaseData
    {
        [SimplePK]
        [Alias("编号")]
        public int Id;

        public string 编号
        {
            get { return Id.ToString(); }

        }

        /// <summary>
        /// 种类名称
        /// </summary>
        [SimpleColumn(Column = "c_name")]
        [Alias("种类名称")]
        public string TypeName;

        public string 种类名称
        {
            get { return TypeName; }
            set { TypeName = value; }
        }

        /// <summary>
        /// 每支重量
        /// </summary>
        [SimpleColumn(Column = "i_weight")]
        [Alias("每支重量")]
        public decimal Weight;

        public decimal 每支重量
        {
            get { return Weight; }
            set { Weight = value; }
        }

        /// <summary>
        /// 每吨单价
        /// </summary>
        [SimpleColumn(Column = "i_price")]
        [Alias("每吨单价")]
        public decimal Price;

        public decimal 每吨单价
        {
            get { return Price; }
            set { Price = value; }
        }

        /// <summary>
        /// 库存数量
        /// </summary>
        [SimpleColumn(Column = "i_store_num")]
        [Alias("库存数量")]
        public decimal StoreNum;

        public decimal 库存数量
        {
            get { return StoreNum; }
            set { StoreNum = value; }
        }
    }
}
