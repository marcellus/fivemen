using System;
using System.Collections.Generic;
using System.Text;

namespace DS.Plugins.Student
{
    /// <summary>
    /// ��ʻԱ��ѵѧԱ�ǼǱ��ӡ����
    /// </summary>
    [Serializable]
    public class F4PrinterConfig : FT.Commons.PrinterEx.BatchPrintConfig
    {
        /// <summary>
        /// C1�Ƿ��ΪH��J
        /// </summary>
        public bool CheckC1=false;

        public bool PrintDate = false;
    }
}
