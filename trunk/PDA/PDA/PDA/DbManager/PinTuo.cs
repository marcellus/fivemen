using System;

using System.Collections.Generic;
using System.Text;

namespace PDA.DbManager
{
    public class PinTuo:BaseEntity
    {
        /*
        create table pintuo(id integer primary key autoincrement,
         * tph varchar(20),sn varchar(20),wz varchar(30),
         * xxjh varchar(20),scaner varchar(30),scantime datetime);
        */

        public string Tph;
        public string Sn;
        public string Wz;
        public string Xxjh;
    }
}
