using System;

using System.Collections.Generic;
using System.Text;

namespace PDA.DbManager
{
    public class SendRecord:BaseEntity
    {
        /*
       create table sendrecord(id integer primary key autoincrement,
         * so varchar(20),otherso varchar(200),qufen varchar(20),
         * pnno varchar(20),cpqufen varchar(20),sl integer,
         * carno varchar(30),status integer,scaner varchar(30),
         * scantime datetime);
                      */

        public string So;
        public string OtherSo;
        public string QuFen;
        public string PnNo;
        public string CpQuFen;
        public string CarNo;
        public int Status = 0;
    }
}
