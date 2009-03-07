using System;
using System.Collections.Generic;
using System.Text;

namespace DS.Plugins.Student
{
    /// <summary>
    /// 机动车驾驶培训记录
    /// </summary>
    [Serializable]
    public class F2PrinterConfig:FT.Commons.PrinterEx.BatchPrintConfig
    {
        public bool CheckC1=false;

        public bool PrintDate = false;
    }
}
