using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

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
                else
                {
                    ctr.BackColor = SystemColors.Control;
                    ctr.ForeColor = Color.Black;
                }
            }
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
