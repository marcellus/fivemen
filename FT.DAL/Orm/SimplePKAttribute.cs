using System;
using System.Collections.Generic;
using System.Text;

namespace FT.DAL.Orm
{
    /// <summary>
    /// ����������ʱ��ʹ��
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class SimplePKAttribute:Attribute
    {
        public SimplePKAttribute()
        {
        }
    }
}
