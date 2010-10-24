using System;

using System.Collections.Generic;
using System.Text;

namespace PDA.DbManager
{
    public class AnHuoYiKu:BaseEntity
    {
        /*
       create table anhuoyiku(id integer primary key autoincrement,
         * ykw varchar(20),cp varchar(20),
         * sl integer,mdkw varchar(20),
         * scaner varchar(30),scantime datetime);
        */

        public string Ykw;
        public string Cp;
        public string Sl;
        public string MdKw;
    }
}
