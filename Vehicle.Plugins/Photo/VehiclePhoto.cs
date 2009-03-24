using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Vehicle.Plugins
{
    public class VehiclePhoto
    {
        private string id;

        /// <summary>
        /// ���ݿ���
        /// </summary>
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        private string cn_Classical;
        /// <summary>
        /// �����ͺ�
        /// </summary>
        public string Cn_Classical
        {
            get { return cn_Classical; }
            set { cn_Classical = value; }
        }

        private string cn_Type;

        /// <summary>
        /// ��������
        /// </summary>
        public string Cn_Type
        {
            get { return cn_Type; }
            set { cn_Type = value; }
        }

        private Image picture;

        /// <summary>
        /// ������Ƭ
        /// </summary>
        public Image Picture
        {
            get { return picture; }
            set { picture = value; }
        }

        private string suffix;

        /// <summary>
        /// ͼƬ���ͺ�׺
        /// </summary>
        public string Suffix
        {
            get { return suffix; }
            set { suffix = value; }
        }

        private string xuHao;

        /// <summary>
        /// ��Ƭ���
        /// </summary>
        public string XuHao
        {
            get { return xuHao; }
            set { xuHao = value; }
        }
    }
}
