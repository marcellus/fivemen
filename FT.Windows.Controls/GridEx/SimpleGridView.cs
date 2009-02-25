using System;
using System.Collections.Generic;
using System.Text;

namespace FT.Windows.Controls.GridEx
{
    public class SimpleGridView:System.Windows.Forms.DataGridView,ISkinControl
    {
        #region ISkinControl 成员

        #region 每个控件必须拥有的字段
        private SimpleSkinType skin = SimpleSkinType.Normal;

        /// <summary>
        /// 皮肤样子
        /// </summary>
        public SimpleSkinType Skin
        {
            get { return skin; }
            set
            {
                if (this.skin == value)
                {

                }
                else
                {
                    skin = value;
                    this.DesignBySkin(value);

                }
            }
        }

        #endregion

        public void DesignBySkin(SimpleSkinType skin)
        {

            SkinFactory.DefaultDesignBySkin(this, skin);
        }

        #endregion
    }
}
