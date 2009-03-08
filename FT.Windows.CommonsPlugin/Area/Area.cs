using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Orm;

namespace FT.Windows.CommonsPlugin
{
    [SimpleTable("table_area")]
    [Alias("县区信息表")]
    public class Area
    {
        [SimplePK]
        public int Id;

        public string 编号
        {
            get { return Id.ToString(); }
        }

        [SimpleColumn(Column = "c_code")]
        [Alias("县区代码")]
        public string Code;

        public string 县区代码
        {
            get { return Code; }
            set { Code = value; }
        }

        [SimpleColumn(Column = "c_text")]
        [Alias("县区名称")]
        public string Text;

        public string 县区名称
        {
            get { return Text; }
            set { Text = value; }
        }

        [SimpleColumn(Column = "c_province_code")]
        [Alias("所属省份")]
        public string ProvinceCode;

        public string 所属省份
        {
            get { return ProvinceCode; }
            set { ProvinceCode = value; }
        }

        [SimpleColumn(Column = "c_father_code")]
        [Alias("所属市")]
        public string FatherCode;

        public string 所属市
        {
            get { return FatherCode; }
            set { FatherCode = value; }
        }

    }
}
