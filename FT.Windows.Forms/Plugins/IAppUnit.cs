using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace FT.Windows.Forms.Plugins
{
    /// <summary>
    /// �����Ԫ�Ľӿ�
    /// </summary>
    public interface IAppUnit
    {
        /// <summary>
        /// �����Ԫ�����Ļ����й��ʻ�
        /// </summary>
        /// <param name="cultureInfo">�Ļ�</param>
        void BeginGlobalization(CultureInfo cultureInfo);

        /// <summary>
        /// �����Ԫ��ʼִ�еķ������
        /// </summary>
        void BeginCall();
    }
}
