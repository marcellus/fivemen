using System;
using System.Collections.Generic;
using System.Text;

namespace DS.Plugins.Student
{
    /// <summary>
    /// ��Ŀ�����Գɼ��������
    /// </summary>
    [Serializable]
    public class F6PrinterConfig:FT.Commons.PrinterEx.BatchPrintConfig
    {
        /// <summary>
        /// ׼��֤��ǰ׺
        /// </summary>
        public string ExamIdPrefix=string.Empty;

        /// <summary>
        ///  ���Եص���Ҫ��ӡ������
        /// </summary>
        public string ExamAddress = string.Empty;

        /// <summary>
        /// �Ƿ�C1����С�γ��ͻ���
        /// </summary>
        public bool CheckC1 = false;

        /// <summary>
        /// �Ƿ��ӡ��ѵ��λ
        /// </summary>
        public bool PrintCompany = false;
    }
}
