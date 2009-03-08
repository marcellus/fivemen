using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Orm;

namespace FT.Windows.CommonsPlugin
{
    [SimpleTable("table_province")]
    [Alias("省份信息表")]
    public class Province
    {
        [SimplePK]
        public int Id;

        public string 编号
        {
            get { return Id.ToString(); }
        }

        [SimpleColumn(Column = "c_code")]
        [Alias("省份代码")]
        public string Code;

        public string 省份代码
        {
            get { return Code; }
            set { Code = value; }
        }

        [SimpleColumn(Column = "c_text")]
        [Alias("省份名称")]
        public string Text;

        public string 省份名称
        {
            get { return Text; }
            set { Text = value; }
        }
    }
}
