using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace FT.Windows.Controls
{
    /// <summary>
    /// 皮肤默认方法
    /// </summary>
    public class SkinFactory
    {
        /// <summary>
        /// 默认的皮肤初始化方法
        /// </summary>
        /// <param name="ctr">控件</param>
        /// <param name="skin">皮肤类型</param>
        public static void DefaultDesignBySkin(Control ctr, SimpleSkinType skin)
        {
            ISkinControl tmp = ctr as ISkinControl;
            if (tmp != null)
            {
               // ctr.Paint += new PaintEventHandler(ctr_Paint);
                if (tmp.Skin == SimpleSkinType.Blue)
                {
                    //ctr.BackColor = Color.Blue;
                    ctr.BackColor = Color.FromArgb(113, 204, 255);
                    ctr.ForeColor = Color.Black;
                }
                else if (tmp.Skin == SimpleSkinType.Black)
                {
                    ctr.BackColor = Color.Black;
                    ctr.ForeColor = Color.White;
                }
                else if (tmp.Skin == SimpleSkinType.Red)
                {
                    ctr.BackColor = Color.Red;
                    ctr.ForeColor = Color.White;
                }
                else if(tmp.Skin==SimpleSkinType.Normal)
                {
                    ctr.BackColor = SystemColors.Control;
                    ctr.ForeColor = Color.Black;
                }
            }
        }

        static void ctr_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            
            //throw new NotImplementedException();
        }
        /// <summary>
        /// 为单个控件设置样式
        /// </summary>
        /// <param name="ctr">单个控件</param>
        /// <param name="skin">皮肤类别</param>
        private static void DesignBySkinOne(Control ctr, SimpleSkinType skin)
        {
            ISkinControl tmp = ctr as ISkinControl;
            if (tmp != null)
            {
                tmp.Skin = skin;
            }
        }
        /// <summary>
        /// 为所有实现ISkinControl设置样式
        /// </summary>
        /// <param name="ctr">控件，同样为控件的Control控件设置属性</param>
        /// <param name="skin">皮肤样式</param>
        public static void DesignBySkin(Control ctr,SimpleSkinType skin)
        {
            if (ctr.Controls.Count == 0)
            {
                DesignBySkinOne(ctr, skin);
            }
            foreach (Control tmpctr in ctr.Controls)
            {
                DesignBySkinOne(tmpctr, skin);
            }
        }
    }
}
