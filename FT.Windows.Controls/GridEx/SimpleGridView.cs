using System;
using System.Collections.Generic;
using System.Text;

namespace FT.Windows.Controls.GridEx
{
    public class SimpleGridView:System.Windows.Forms.DataGridView,ISkinControl
    {
        #region ISkinControl ��Ա

        #region ÿ���ؼ�����ӵ�е��ֶ�
        private SimpleSkinType skin = SimpleSkinType.Normal;

        /// <summary>
        /// Ƥ������
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
