using System;
using System.Collections.Generic;
using System.Text;

namespace FT.Windows.Controls
{
    public  interface ISkinControl
    {
        /// <summary>
        /// Ƥ������
        /// </summary>
        SimpleSkinType Skin
        {
            get;
            set;
        }
        /// <summary>
        /// ����Ƥ������Paint
        /// </summary>
        void DesignBySkin(SimpleSkinType skin);
    }
}
