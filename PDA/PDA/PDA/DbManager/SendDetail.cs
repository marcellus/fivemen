using System;

using System.Collections.Generic;
using System.Text;

namespace PDA.DbManager
{
    public class SendDetail:BaseEntity
    {
        /*
       create table senddetail(pid integer,
         * sn varchar(20),fahuotype integer,
         * xxjh varchar(20),tph varchar(20),
         * scaner varchar(30),scantime datetime,status integer);
                      */

        public int Pid;

        public string Sn;
        public int FahuoType;
        public string Xxjh;
        public string Tph;
    }
}
