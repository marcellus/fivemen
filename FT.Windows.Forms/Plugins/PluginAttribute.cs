using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace FT.Windows.Forms.Plugins
{
    [AttributeUsage(AttributeTargets.Class)]
    public class PluginAttribute:AppUnitAttribute
    {
        private int relatationId;

        /// <summary>
        /// ������������Ϲ���id���Ա�������յ���������ʱ��λ
        /// </summary>
        public int RelatationId
        {
            get { return relatationId; }
            set { relatationId = value; }
        }

        private int categoryIndex;

        /// <summary>
        /// ����ķ�������
        /// </summary>
        public int CategoryIndex
        {
            get { return categoryIndex; }
            set { categoryIndex = value; }
        }

        private string text;

        /// <summary>
        /// ������ı�
        /// </summary>
        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        private string method = Default_Method;

        /// <summary>
        /// ������ִ�еķ���
        /// </summary>
        public string Method
        {
            get { return method; }
            set { method = value; }
        }

        /// <summary>
        /// Сͼ�꣬16*16��С
        /// </summary>
        private Image img;

        /// <summary>
        /// �����ͼ����ʾ
        /// </summary>
        public Image Img
        {
            get { return img; }
            set { img = value; }
        }
    }
}
