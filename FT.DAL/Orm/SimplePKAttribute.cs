using System;
using System.Collections.Generic;
using System.Text;

namespace FT.DAL.Orm
{
    /// <summary>
    /// 主键，更新时候使用
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class SimplePKAttribute:Attribute
    {
        public SimplePKAttribute()
        {
        }
    }
}
