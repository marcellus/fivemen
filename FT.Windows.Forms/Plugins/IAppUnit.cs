using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace FT.Windows.Forms.Plugins
{
    /// <summary>
    /// 软件单元的接口
    /// </summary>
    public interface IAppUnit
    {
        /// <summary>
        /// 软件单元根据文化进行国际化
        /// </summary>
        /// <param name="cultureInfo">文化</param>
        void BeginGlobalization(CultureInfo cultureInfo);

        /// <summary>
        /// 软件单元开始执行的方法入口
        /// </summary>
        void BeginCall();
    }
}
