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
        /// 数据库编号
        /// </summary>
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        private string cn_Classical;
        /// <summary>
        /// 中文型号
        /// </summary>
        public string Cn_Classical
        {
            get { return cn_Classical; }
            set { cn_Classical = value; }
        }

        private string cn_Type;

        /// <summary>
        /// 中文类型
        /// </summary>
        public string Cn_Type
        {
            get { return cn_Type; }
            set { cn_Type = value; }
        }

        private Image picture;

        /// <summary>
        /// 车辆照片
        /// </summary>
        public Image Picture
        {
            get { return picture; }
            set { picture = value; }
        }

        private string suffix;

        /// <summary>
        /// 图片类型后缀
        /// </summary>
        public string Suffix
        {
            get { return suffix; }
            set { suffix = value; }
        }

        private string xuHao;

        /// <summary>
        /// 照片序号
        /// </summary>
        public string XuHao
        {
            get { return xuHao; }
            set { xuHao = value; }
        }
    }
}
