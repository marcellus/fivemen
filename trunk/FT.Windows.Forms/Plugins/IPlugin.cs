using System;
using System.Collections.Generic;
using System.Text;
using FT.Windows.Forms;

namespace FT.Windows.Forms.Plugins
{
    /// <summary>
    /// 插件接口
    /// </summary>
    public interface IPlugin:IAppUnit
    {
        /// <summary>
        /// 注入到主窗体中
        /// </summary>
        /// <param name="form">主窗体，带有toolstrip，menustrip，statusstrip和basetabcontrol</param>
        void Emmit(BaseMainForm form);

        /// <summary>
        /// 插件初始化，主要是检测是否存在数据库表，如果没有就执行创建
        /// </summary>
        void Init();
    }
}
