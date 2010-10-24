using System;

using System.Collections.Generic;
using System.Text;

namespace PDA.DbManager
{
    public class ZtPinTuo:BaseEntity
    {
        /*
           create table ztpintuo(id integer primary key autoincrement,
         * tph varchar(20),ytph varchar(20),scaner varchar(30),
         * scantime datetime);
               */

        public string Tph;
        public string Ytph;
    }
}
