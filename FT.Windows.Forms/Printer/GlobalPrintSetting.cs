using System;
using System.Collections.Generic;
using System.Text;

namespace FT.Windows.Forms
{
    /// <summary>
    /// 全局打印配置
    /// </summary>
    [Serializable]
    public class GlobalPrintSetting
    {

        public string Left="10";

        public string Right = "10";

        public string Top = "10";

        public string Bottom = "10";


        public string PageName = "A4";

        public string PrintModel = "打印预览";
    }
}
