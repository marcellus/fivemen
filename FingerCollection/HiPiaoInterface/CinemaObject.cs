using System;
using System.Collections.Generic;
using System.Text;

namespace HiPiaoInterface
{
    /// <summary>
    /// 影院对象
    /// </summary>
    [Serializable]
    public class CinemaObject
    {

        private string address;

        /// <summary>
        /// 影院地址
        /// </summary>
        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        private string cinemanumber;

        /// <summary>
        /// 影院编码
        /// </summary>
        public string Cinemanumber
        {
            get { return cinemanumber; }
            set { cinemanumber = value; }
        }

        private string tel;

        /// <summary>
        /// 影院联系电话
        /// </summary>
        public string Tel
        {
            get { return tel; }
            set { tel = value; }
        }

        private string name;

        /// <summary>
        /// 院线名称
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string ip;

        /// <summary>
        /// 机器IP地址
        /// </summary>
        public string Ip
        {
            get { return ip; }
            set { ip = value; }
        }
        private string className;

        /// <summary>
        /// 接口实现类名称
        /// </summary>
        public string ClassName
        {
            get { return className; }
            set { className = value; }
        }

        private string department;

        /// <summary>
        /// 分店名称
        /// </summary>
        public string Department
        {
            get { return department; }
            set { department = value; }
        }

        private List<RoomObject> rooms = new List<RoomObject>();


        /// <summary>
        /// 拥有的影厅信息
        /// </summary>
        public List<RoomObject> Rooms
        {
            get { return rooms; }
            set { rooms = value; }
        }
    }
}
