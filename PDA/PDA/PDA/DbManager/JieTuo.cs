using System;

using System.Collections.Generic;
using System.Text;

namespace PDA.DbManager
{
    public class JieTuo:BaseEntity
    {
        /*
                 create table jietuo(id integer primary key autoincrement,
         * tph varchar(20),sn varchar(20),iswhole integer,
         * scaner varchar(30),scantime datetime);
                      */

        public string Sn;
        public string Tph;
        public int IsWhole;
    }
}
