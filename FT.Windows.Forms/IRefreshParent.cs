using System;
using System.Collections.Generic;
using System.Text;

namespace FT.Windows.Forms
{
    /// <summary>
    /// 刷新父类的接口，主要是修改和添加的时候刷新父类窗口或者面板
    /// 也供查询时候设置查询条件用
    /// </summary>
    public interface IRefreshParent
    {
        /// <summary>
        /// 更新一个实体到父类窗口
        /// </summary>
        /// <param name="entity"></param>
        void Update(object entity);
        /// <summary>
        /// 添加一个实体到父类窗口
        /// </summary>
        /// <param name="entity"></param>
        void Add(object entity);
        /// <summary>
        /// 设置查询条件语句
        /// </summary>
        /// <param name="conditions"></param>
        void SetConditions(string conditions);
    }
}
