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

        public string ���
        {
            get { return Id.ToString(); }
           //set { Id = value; }
        }

        [SimpleColumn(Column = "c_name")]
        [Alias("��������")]
        public String Name;

        public String ��������
        {
            get { return Name; }
            set { Name = value; }
        }

        [SimpleColumn(Column = "c_description")]
        [Alias("��������")]
        public String Description;

        public String ��������
        {
            get { return Description; }
            set { Description = value; }
        }
    }
}
