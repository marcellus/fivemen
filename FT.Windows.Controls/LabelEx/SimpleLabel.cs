using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Drawing2D;
using FT.Commons.Tools;

namespace FT.Windows.Controls.LabelEx
{
    public class SimpleLabel:System.Windows.Forms.Label,ISkinControl
    {
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {

            ImageHelper.SetSmoothFont(e.Graphics);
            
            base.OnPaint(e);
        }
        #region ISkinControl ��Ա

        #region ÿ���ؼ�����ӵ�е��ֶ�
        private SimpleSkinType skin = SimpleSkinType.Custom;

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
