using System;
using System.Collections.Generic;
using System.Text;

namespace DS.Plugins.Student
{
    /// <summary>
    /// 科目三考试成绩表的配置
    /// </summary>
    [Serializable]
    public class F6PrinterConfig:FT.Commons.PrinterEx.BatchPrintConfig
    {
        /// <summary>
        /// 准考证号前缀
        /// </summary>
        public string ExamIdPrefix=string.Empty;

        /// <summary>
        ///  考试地点需要打印的内容
        /// </summary>
        public string ExamAddress = string.Empty;

        /// <summary>
        /// 是否C1分类小轿车和货车
        /// </summary>
        public bool CheckC1 = false;

        /// <summary>
        /// 是否打印培训单位
        /// </summary>
        public bool PrintCompany = false;
    }
}
