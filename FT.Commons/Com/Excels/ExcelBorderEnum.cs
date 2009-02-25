/********************************************************************************
* File:ExcelBorderEnum.cs
* Author:austin chen
* Date:2008-4-21
* Copyright (c) fivemen company
*********************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;

namespace FT.Commons.Com.Excels
{
    /// <summary>
    /// Excel单元格范围内的边框及内部网格线
    /// </summary>
    public enum BordersEdge { xlLineStyleNone, xlLeft, xlRight, xlTop, xlBottom, xlDiagonalDown, xlDiagonalUp, xlInsideHorizontal, xlInsideVertical }

    /// <summary>
    /// Excel线样
    /// </summary>
    public enum BordersLineStyle { xlContinuous, xlDash, xlDashDot, xlDashDotDot, xlDot, xlDouble, xlLineStyleNone, xlSlantDashDot }

    /// <summary>
    /// Excel单元格范围内的边框及内部网格线粗细
    /// </summary>
    public enum BordersWeight { xlHairline, xlMedium, xlThick, xlThin }
}
