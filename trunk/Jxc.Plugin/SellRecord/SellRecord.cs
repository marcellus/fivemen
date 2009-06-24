using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Orm;


namespace Jxc.Plugin
{
    [SimpleTable("table_jxc_sell_record")]
    [Alias("销售记录")]
    public class SellRecord
    {
        [SimplePK]
        [Alias("编号")]
        public int Id;

        public string 编号
        {
            get { return Id.ToString(); }

        }

        [SimpleColumn(Column = "date_sell")]
        [Alias("销售日期")]
        public string SellDate;

        public string 销售日期
        {
            get { return SellDate; }
            set { SellDate = value; }
        }

        /// <summary>
        /// 货品名称
        /// </summary>
        [SimpleColumn(Column = "c_name")]
        [Alias("货品名称")]
        public string TypeName;

        public string 货品名称
        {
            get { return TypeName; }
            set { TypeName = value; }
        }

        /// <summary>
        /// 支数
        /// </summary>
        [SimpleColumn(Column = "i_zhi_shu")]
        [Alias("支数")]
        public int ZhiShu;

        public int 支数
        {
            get { return ZhiShu; }
            set { ZhiShu = value; }
        }

        /// <summary>
        /// 吨数
        /// </summary>
        [SimpleColumn(Column = "m_dun_shu")]
        [Alias("吨数")]
        public decimal DunShu;

        public decimal 吨数
        {
            get { return DunShu; }
            set { DunShu = value; }
        }

        

        /// <summary>
        /// 总价
        /// </summary>
        [SimpleColumn(Column = "m_price")]
        [Alias("总价")]
        public decimal Price;

        public decimal 总价
        {
            get { return Price; }
            set { Price = value; }
        }


    }
}
