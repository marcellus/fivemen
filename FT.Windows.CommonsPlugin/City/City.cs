using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Orm;

namespace FT.Windows.CommonsPlugin
{
    [SimpleTable("table_city")]
    [Alias("市区信息表")]
    public class City
    {
        [SimplePK]
        public int Id;

        public string 编号
        {
            get { return Id.ToString(); }
        }

        [SimpleColumn(Column = "c_code")]
        [Alias("市代码")]
        public string Code;

        public string 市代码
        {
            get { return Code; }
            set { Code = value; }
        }

        [SimpleColumn(Column = "c_text")]
        [Alias("市名称")]
        public string Text;

        public string 市名称
        {
            get { return Text; }
            set { Text = value; }
        }
        [SimpleColumn(Column = "c_father_code")]
        [Alias("所属省份")]
        public string FatherCode;

        public string 所属省份
        {
            get { return FatherCode; }
            set { FatherCode = value; }
        }

    }
}
