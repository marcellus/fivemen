using System;
using System.Collections.Generic;
using System.Text;

namespace FT.Windows.Forms.Plugins
{
    /// <summary>
    /// 插件文件配置，主要配置插件启动的顺序已经使用的插件文件
    /// </summary>
    [Serializable]
    public class PluginsFileConfig

       
    {
        /// <summary>
        /// 存放需要加载的插件配置文件,必须放置插件的全限定名
        /// </summary>
        public List<String> PluginTypes = new List<string>();
    }
}
