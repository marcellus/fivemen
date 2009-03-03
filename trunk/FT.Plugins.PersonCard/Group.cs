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

        [SimpleColumn(Column = "c_name")]
        public String Name;

        [SimpleColumn(Column = "c_description")]
        public String Description;
    }
}
