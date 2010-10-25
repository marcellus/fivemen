using System;

using System.Collections.Generic;
using System.Text;
using System.Data;
using PDA.DbManager;
using PDA.DataInit;


namespace PDA.DbManager
{
    public class KuWeiManager
    {

        public static bool IsExists(string kuweicode)
        {
            string sql = "select * from kuweiinfo where kuweicode='" + kuweicode + "'";
            DataTable dt = SqliteDbFactory.GetSqliteDbOperator().SelectFromSql(sql);
            return dt!=null&&dt.Rows.Count==1;
        }
    }
}
