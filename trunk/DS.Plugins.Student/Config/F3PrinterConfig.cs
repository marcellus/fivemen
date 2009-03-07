using System;
using System.Collections.Generic;
using System.Text;

namespace DS.Plugins.Student
{
    /// <summary>
    /// 身体条件证明
    /// </summary>
    [Serializable]
    public class F3PrinterConfig:FT.Commons.PrinterEx.BatchPrintConfig
    {
        public bool PrintProfile;
    }
}
