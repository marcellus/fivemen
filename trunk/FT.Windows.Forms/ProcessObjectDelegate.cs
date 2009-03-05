using System;
using System.Collections.Generic;
using System.Text;

namespace FT.Windows.Forms
{
    /// <summary>
    /// 处理数据的委托
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public delegate void ProcessObjectDelegate(ref object entity);
}
