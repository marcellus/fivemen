using System;
using System.Collections.Generic;
using System.Text;

namespace DS.Plugins.Student
{
    /// <summary>
    /// 驾驶员培训学员登记表打印配置
    /// </summary>
    [Serializable]
    public class F4PrinterConfig : FT.Commons.PrinterEx.BatchPrintConfig
    {
        /// <summary>
        /// C1是否分为H和J
        /// </summary>
        public bool CheckC1=false;

        public bool PrintDate = false;
    }
}
