using System;

using System.Collections.Generic;
using System.Text;

namespace PDA.DataInit
{
    public class SqliteDbFactory
    {
        private static  SqliteDbOperator dbOperator;

        private SqliteDbFactory()
        {


        }
        
        public static  SqliteDbOperator GetSqliteDbOperator()
        {
            if(dbOperator==null)
            {
                dbOperator = new SqliteDbOperator("db.db3");
            }
            return dbOperator;
        }
    }
}
