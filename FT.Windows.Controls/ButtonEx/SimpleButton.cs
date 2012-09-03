using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using FT.Commons.Tools;

namespace FT.Windows.Controls.ButtonEx
{
    public class SimpleButton : System.Windows.Forms.Button, ISkinControl
    {


        protected override void OnPaint(System.Windows.Forms.PaintEventArgs pevent)
        {
            //this.DesignBySkin();
            ImageHelper.SetSmoothFont(pevent.Graphics);
            base.OnPaint(pevent);
        }

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
