using System;
using System.Collections.Generic;
using System.Text;

namespace FT.Commons.Cache
{
    /// <summary>
    /// ���Զ����µ�Cache����Ҫ��һЩ������
    /// </summary>
    public interface IRefreshCache
    {
        /// <summary>
        /// ��ȡCache����
        /// </summary>
        void Load();
    }
}
