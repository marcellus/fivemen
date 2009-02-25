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
    /// Excel��Ԫ��Χ�ڵı߿��ڲ�������
    /// </summary>
    public enum BordersEdge { xlLineStyleNone, xlLeft, xlRight, xlTop, xlBottom, xlDiagonalDown, xlDiagonalUp, xlInsideHorizontal, xlInsideVertical }

    /// <summary>
    /// Excel����
    /// </summary>
    public enum BordersLineStyle { xlContinuous, xlDash, xlDashDot, xlDashDotDot, xlDot, xlDouble, xlLineStyleNone, xlSlantDashDot }

    /// <summary>
    /// Excel��Ԫ��Χ�ڵı߿��ڲ������ߴ�ϸ
    /// </summary>
    public enum BordersWeight { xlHairline, xlMedium, xlThick, xlThin }
}
