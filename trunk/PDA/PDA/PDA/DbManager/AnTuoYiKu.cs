using System;

using System.Collections.Generic;
using System.Text;

namespace PDA.DbManager
{
    public class AnTuoYiKu:BaseEntity
    {
        /*
       create table antuoyiku(id integer primary key autoincrement,
         tph varchar(20),mdkw varchar(20),scaner varchar(30),scantime datetime);
        */

        public string Tph;
        public string Mdkw;
       
    }
}
