using System;
using System.Collections.Generic;
using System.Text;

namespace FT.Commons.Cache
{
    /// <summary>
    /// 可自动更新的Cache，主要放一些表数据
    /// </summary>
    public interface IRefreshCache
    {
        /// <summary>
        /// 获取Cache数据
        /// </summary>
        void Load();
    }
}
