using System;
using System.Collections.Generic;
using System.Text;

namespace FT.Commons.PrinterEx
{
    /// <summary>
    /// 套打打印的配置,单位为毫米
    /// </summary>
    [Serializable]
    public class BatchPrintConfig
    {
        /// <summary>
        /// 向上多少毫米
        /// </summary>
        public int Up;

        /// <summary>
        /// 向下多少毫米
        /// </summary>
        public int Down;

        /// <summary>
        /// 向左多少毫米
        /// </summary>
        public int Left;

        /// <summary>
        /// 向右多少毫米
        /// </summary>
        public int Right;
    }
}
