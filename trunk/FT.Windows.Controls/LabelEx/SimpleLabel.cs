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
        #region ISkinControl 成员

        #region 每个控件必须拥有的字段
        private SimpleSkinType skin = SimpleSkinType.Custom;

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
