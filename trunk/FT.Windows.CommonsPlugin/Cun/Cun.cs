using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Orm;
using FT.DAL.Entity;

namespace FT.Windows.CommonsPlugin
{
    [SimpleTable("table_cun")]
    [Alias("村居委信息表")]
    public class Cun
    {
        [SimplePK]
        public int Id;

        public string 编号
        {
            get { return Id.ToString(); }
        }

        [SimpleColumn(Column = "c_text")]
        [Alias("数据文本")]
        public string Text;

        public string 数据文本
        {
            get { return Text; }
            set { Text = value; }
        }

        [SimpleColumn(Column = "c_value")]
        [Alias("数据代码")]
        public string Value;

        public string 数据代码
        {
            get { return Value; }
            set { Value = value; }
        }

        [SimpleColumn(Column = "c_valid")]
        [Alias("是否有效")]
        public String Valid;

        public String 是否有效
        {
            get { return Valid; }
            set { Valid = value; }
        }

        [SimpleColumn(Column = "c_description")]
        [Alias("备注")]
        public String Description;

        public String 备注
        {
            get { return Description; }
            set { Description = value; }
        }

        [SimpleColumn(Column = "c_blongxiang")]
        [Alias("所属乡镇")]
        public string Xiang;

        public string 所属乡镇
        {
            get { return Xiang; }
            set { Xiang = value; }
        }

        [SimpleColumn(Column = "c_blongarea")]
        [Alias("所属辖区")]
        public string BlongArea;

        public string 所属辖区
        {
            get { return BlongArea; }
            set { BlongArea = value; }
        }
    }
}
