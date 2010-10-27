using System;

using System.Collections.Generic;
using System.Text;
using System.Data;
using PDA.DbManager;
using PDA.DataInit;

namespace PDA.DbManager
{
    public class ZtPinTuoManager
    {
        /*
       create table ztpintuo(id integer primary key autoincrement,
         * tph varchar(20),ytph varchar(20),scaner varchar(30),
         * scantime datetime);
        */
        public static void Save(ZtPinTuo entity)
        {
            string sql = string.Empty;
            sql = "insert into ztpintuo(tph,ytph,scaner,scantime) values('" +
                entity.Tph + "','" + entity.Ytph + "','" + 
                entity.Scaner + "','" +
                System.DateTime.Now.ToString("s")
                + "')";
            SqliteDbFactory.GetSqliteDbOperator().ExecuteNonQuery(sql);

        }

        public static bool CheckExists(ZtPinTuo entity)
        {
            string sql = string.Empty;
            sql = "select * from ztpintuo where tph='" +
                entity.Tph + "'";
            DataTable dt = SqliteDbFactory.GetSqliteDbOperator().SelectFromSql(sql);

            return dt != null && dt.Rows.Count == 1;
        }


        public static void Delete(ZtPinTuo entity)
        {
            string sql = string.Empty;
            sql = "delete from ztpintuo where tph='" +
                entity.Tph + "'";
            SqliteDbFactory.GetSqliteDbOperator().ExecuteNonQuery(sql);

        }
        public static DataTable GetUserData(string uid)
        {
            string sql = "select tph as 托盘号,ytph as 原托盘号 from ztpintuo where scaner='" + uid + "'";
            return SqliteDbFactory.GetSqliteDbOperator().SelectFromSql(sql);
        }
    }
}
