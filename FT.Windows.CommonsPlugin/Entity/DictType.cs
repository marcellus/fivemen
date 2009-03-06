using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Orm;

namespace FT.Windows.CommonsPlugin.Entity
{
    [SimpleTable("table_dicttype")]
    public class DictType
    {
        [SimplePK]
        public int Id;

        public string 编号
        {
            get { return Id.ToString(); }
        }

        [SimpleColumn(Column = "c_name")]
        [Alias("类型名称")]
        public string Name;

        public string 类型名称
        {
            get { return Name; }
            set { Name = value; }
        }
    }
}
