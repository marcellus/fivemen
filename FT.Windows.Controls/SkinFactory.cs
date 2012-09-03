using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace FT.Windows.Controls
{
    /// <summary>
    /// Ƥ��Ĭ�Ϸ���
    /// </summary>
    public class SkinFactory
    {
        /// <summary>
        /// Ĭ�ϵ�Ƥ����ʼ������
        /// </summary>
        /// <param name="ctr">�ؼ�</param>
        /// <param name="skin">Ƥ������</param>
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
        /// Ϊ�����ؼ�������ʽ
        /// </summary>
        /// <param name="ctr">�����ؼ�</param>
        /// <param name="skin">Ƥ�����</param>
        private static void DesignBySkinOne(Control ctr, SimpleSkinType skin)
        {
            ISkinControl tmp = ctr as ISkinControl;
            if (tmp != null)
            {
                tmp.Skin = skin;
            }
        }
        /// <summary>
        /// Ϊ����ʵ��ISkinControl������ʽ
        /// </summary>
        /// <param name="ctr">�ؼ���ͬ��Ϊ�ؼ���Control�ؼ���������</param>
        /// <param name="skin">Ƥ����ʽ</param>
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
