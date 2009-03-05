using System;
using System.Collections.Generic;
using System.Text;

namespace FT.DAL.Orm
{
    /// <summary>
    /// 简单的匿名属性,供查询使用
    /// 使用方法：
    /// Alias("")
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class AliasAttribute:Attribute
    {
         private string name;

        /// <summary>
        /// 数据库对应的表名
        /// </summary>
        public string Name
        {
            get { return name; }
        }
        public AliasAttribute(string name)
        {
            if (name == null || name.Length == 0)
            {
                throw new ArgumentException("别名不得为空！");
            }
            this.name = name;
        }
    }
}
