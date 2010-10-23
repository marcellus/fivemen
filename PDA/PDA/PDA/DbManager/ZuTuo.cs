using System;

using System.Collections.Generic;
using System.Text;

namespace PDA.DbManager
{
    public class ZuTuo : BaseEntity  
    {
        /*
         create table zutuo(id integer primary key autoincrement
        ,tph varchar(20),sn varchar(20),xxjh varchar(20),
         scaner varchar(30),scantime datetime);
         */

        public string Tph;
        public string Sn;
        public string Xxjh;
    }
}
