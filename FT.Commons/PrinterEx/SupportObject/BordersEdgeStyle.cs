using System;
using System.Collections.Generic;
using System.Text;

namespace FT.Commons.PrinterEx.SupportObject
{
    /// <summary>
    /// 设置打印对象的边框
    /// </summary>
    public enum BordersEdgeStyle
    {
        Left=1,
        Right=2,
        Top=4,
        Bottom=8,
        DiagonalDown=16, 
        DiagonalUp=32,
        All=64,
        None=128
    }
}
