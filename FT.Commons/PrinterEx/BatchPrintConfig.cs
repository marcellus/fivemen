using System;
using System.Collections.Generic;
using System.Text;

namespace FT.Commons.PrinterEx
{
    /// <summary>
    /// �״��ӡ������,��λΪ����
    /// </summary>
    [Serializable]
    public class BatchPrintConfig
    {
        /// <summary>
        /// ���϶��ٺ���
        /// </summary>
        public int Up;

        /// <summary>
        /// ���¶��ٺ���
        /// </summary>
        public int Down;

        /// <summary>
        /// ������ٺ���
        /// </summary>
        public int Left;

        /// <summary>
        /// ���Ҷ��ٺ���
        /// </summary>
        public int Right;
    }
}
