using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Orm;

namespace FT.Windows.CommonsPlugin.Entity
{
    [SimpleTable("table_users")]
    public class User
    {
        [SimplePK]
        public int Id;

        public int 编号
        {
            get { return Id; }
            set { Id = value; }
        }
        [SimpleColumn(Column = "c_name")]
        [Alias("登录名")]
        public String Name;

        /// <summary>
        /// 供datagridview显示使用
        /// </summary>
        public String 登录名
        {
            get { return Name; }
            set { Name = value; }
        }

        [SimpleColumn(Column = "c_password")]
        public String Password;

        [SimpleColumn(Column = "c_valid")]
        [Alias("是否有效")]
        public String Valid;

        public String 是否有效
        {
            get { return Valid; }
            set { Valid = value; }
        }

        [SimpleColumn(Column = "c_description")]
        [Alias("备注")]
        public String Description;

        public String 备注
        {
            get { return Description; }
            set { Description = value; }
        }
    }
}
