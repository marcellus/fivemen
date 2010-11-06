using System;

using System.Collections.Generic;
using System.Text;
using PDA.DataInit;
using System.Data;

namespace PDA
{
    class ASNMain
    {
        #region 私有属性
        private string receiveno;
        private string factory;
        private string factoryid;
        private string storage;
        private string storageid;
        private string carno;
        private string receivetype;
        private string qufen;
        private string pnno;
        private string tno;
        private string hold;
        private int sl;
        private string scanner;
        private DateTime scantime;
        private int status;
        #endregion

        #region 公共属性
        public string Receiveno
        {
            get
            {
                return receiveno;
            }
            set
            {
                receiveno = value;
            }
        }

        public string Factory
        {
            get
            {
                return factory;
            }
            set
            {
                factory = value;
            }
        }

        public string Factoryid
        {
            get
            {
                return factoryid;
            }
            set
            {
                factoryid = value;
            }
        }

        public string Storage
        {
            get
            {
                return storage;
            }
            set
            {
                storage = value;
            }
        }

        public string Storageid
        {
            get
            {
                return storageid;
            }
            set
            {
                storageid = value;
            }
        }

        public string Carno
        {
            get
            {
                return carno;
            }
            set
            {
                carno = value;
            }
        }

        public string Receivetype
        {
            get
            {
                return receivetype;
            }
            set
            {
                receivetype = value;
            }
        }

        public string Qufen
        {
            get
            {
                return qufen;
            }
            set
            {
                qufen = value;
            }
        }

        public string Pnno
        {
            get
            {
                return pnno;
            }
            set
            {
                pnno = value;
            }
        }

        public string Tno
        {
            get
            {
                return tno;
            }
            set
            {
                tno = value;
            }
        }

        public string Hold
        {
            get
            {
                return hold;
            }
            set
            {
                hold = value;
            }
        }

        public int Sl
        {
            get
            {
                return sl;
            }
            set
            {
                sl = value;
            }
        }

        public string Scanner
        {
            get
            {
                return scanner;
            }
            set
            {
                scanner = value;
            }
        }

        public DateTime Scantime
        {
            get
            {
                return scantime;
            }
            set
            {
                scantime = value;
            }
        }

        public int Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
            }
        }
        #endregion

        public void SaveAsnMain(string RollBack)
        {
            if (RollBack == string.Empty)
            {
                string sqlForSelect = string.Format(@"select * from receiverecord where pnno='{0}'", this.pnno);
                DataTable dt = SqliteDbFactory.GetSqliteDbOperator().SelectFromSql(sqlForSelect);
                if (dt.Rows.Count == 0)
                {
                    string sqlInsert = string.Format(@"insert into receiverecord (receiveno,factory,factoryid,storage,storageid,carno,receivetype,qufen,pnno,
tno,hold,sl,scaner,scantime,status) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}',{11},'{12}','{13}',{14})",
        this.receiveno, this.factory, this.factoryid, this.storage, this.storageid, this.carno, this.receivetype, this.qufen, this.pnno, this.tno, this.hold,
        this.sl, this.scanner, this.scantime, this.status);
                    SqliteDbFactory.GetSqliteDbOperator().ExecuteNonQuery(sqlInsert);
                }
                else
                {
                    string sqlUpdate = string.Format(@"update receiverecord set sl=sl+" + this.sl + " where pnno='{0}'", this.pnno);
                    SqliteDbFactory.GetSqliteDbOperator().ExecuteNonQuery(sqlUpdate);
                }
            }
            else
            {
                string sqlRollBack = string.Format(@"update receiverecord set sl+sl-" + this.sl + " where pnno='{0}'", this.pnno);
                SqliteDbFactory.GetSqliteDbOperator().ExecuteNonQuery(sqlRollBack);
            }
        }

    }
}
