using System;
using System.Collections.Generic;
using System.Text;

namespace FT.DAL.Orm
{
    /// <summary>
    /// 用来指定数据库表名
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class SimpleTableAttribute:Attribute
    {
        private string table;

        /// <summary>
        /// 数据库对应的表名
        /// </summary>
        public string Table
        {
            get { return table; }
        }
        public SimpleTableAttribute(string table)
        {
            if (table == null || table.Length == 0)
            {
                throw new ArgumentException("表名不得为空！");
            }
            this.table = table;
        }
    }
}
