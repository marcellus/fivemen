using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Entity;
using FT.DAL.Orm;

namespace FT.Plugins.PersonCard
{
    [SimpleTable("table_cards")]
    public class Card
    {
        [SimplePK]
        public int Id;
        [SimpleColumn(Column = "c_name")]
        public String Name;

        [SimpleColumn(Column = "c_nickname")]
        public String NickName;

        [SimpleColumn(Column = "c_sex")]
        public String Sex;

        [SimpleColumn(Column = "c_birthday")]
        public String Birthday;

        [SimpleColumn(Column = "c_phone")]
        public String Phone;

        [SimpleColumn(Column = "c_mobile")]
        public String Mobile;

        [SimpleColumn(Column = "c_description")]
        public String Description;

        [SimpleColumn(Column = "c_interest")]
        public String Interest;

        [SimpleColumn(Column = "c_url")]
        public String Url;
        [SimpleColumn(Column = "c_email")]
        public String Email;
        [SimpleColumn(Column = "c_classical")]
        public String Classical;
    }
}
