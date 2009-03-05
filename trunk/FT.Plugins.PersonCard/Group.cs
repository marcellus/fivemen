using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Entity;
using FT.DAL.Orm;

namespace FT.Plugins.PersonCard
{
    [SimpleTable("table_cards_group")]
    public class Group
    {
        [SimplePK]
        public int Id;

        public string 编号
        {
            get { return Id.ToString(); }
           //set { Id = value; }
        }

        [SimpleColumn(Column = "c_name")]
        [Alias("分组名称")]
        public String Name;

        public String 分组名称
        {
            get { return Name; }
            set { Name = value; }
        }

        [SimpleColumn(Column = "c_description")]
        [Alias("分组描述")]
        public String Description;

        public String 分组描述
        {
            get { return Description; }
            set { Description = value; }
        }
    }
}
