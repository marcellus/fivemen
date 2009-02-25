using System;
using System.Collections.Generic;
using System.Text;

namespace FT.Windows.Controls
{
    public  interface ISkinControl
    {
        /// <summary>
        /// 皮肤样子
        /// </summary>
        SimpleSkinType Skin
        {
            get;
            set;
        }
        /// <summary>
        /// 根据皮肤进行Paint
        /// </summary>
        void DesignBySkin(SimpleSkinType skin);
    }
}
