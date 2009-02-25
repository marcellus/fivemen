using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace FT.Windows.Forms.Plugins
{
    [AttributeUsage(AttributeTargets.Class)]
    public class PluginAttribute:AppUnitAttribute
    {
        private int relatationId;

        /// <summary>
        /// 插件跟服务器上关联id，以便服务器收到插件错误的时候定位
        /// </summary>
        public int RelatationId
        {
            get { return relatationId; }
            set { relatationId = value; }
        }

        private int categoryIndex;

        /// <summary>
        /// 插件的分类索引
        /// </summary>
        public int CategoryIndex
        {
            get { return categoryIndex; }
            set { categoryIndex = value; }
        }

        private string text;

        /// <summary>
        /// 插件的文本
        /// </summary>
        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        private string method = Default_Method;

        /// <summary>
        /// 点击插件执行的方法
        /// </summary>
        public string Method
        {
            get { return method; }
            set { method = value; }
        }

        /// <summary>
        /// 小图标，16*16大小
        /// </summary>
        private Image img;

        /// <summary>
        /// 插件的图标显示
        /// </summary>
        public Image Img
        {
            get { return img; }
            set { img = value; }
        }
    }
}
