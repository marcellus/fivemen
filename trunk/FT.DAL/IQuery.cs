using System;
using System.Collections.Generic;
using System.Text;

namespace FT.DAL
{
    /// <summary>
    /// 查询条件接口,不同的helper都必须实现
    /// </summary>
    public interface IQuery
    {
        string Between();
    }
}
