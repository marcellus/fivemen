using System;

using System.Collections.Generic;
using System.Text;
using System.Data;
using PDA.DbManager;
using PDA.DataInit;

namespace PDA.DbManager
{
    public class AnTuoYiKuManager
    {
        /*
    create table antuoyiku(id integer primary key autoincrement,
         * tph varchar(20),mdkw varchar(20),scaner varchar(30),
         * scantime datetime);
       */
        public static void Save(AnTuoYiKu entity)
        {
            string sql = string.Empty;
            sql = "insert into antuoyiku(tph,mdkw,scaner,scantime) values('" +
                entity.Tph + "','" + entity.Mdkw + "','" + entity.Scaner + "','" +
                System.DateTime.Now.ToString("s")
                + "')";
            SqliteDbFactory.GetSqliteDbOperator().ExecuteNonQuery(sql);

        }

        public static bool CheckExists(AnTuoYiKu entity)
        {
            string sql = string.Empty;
            sql = "select * from antuoyiku where tph='" +
                 entity.Tph + "'";
            DataTable dt = SqliteDbFactory.GetSqliteDbOperator().SelectFromSql(sql);

            return dt != null && dt.Rows.Count == 1;
        }

        public static void Delete(AnTuoYiKu entity)
        {
            string sql = string.Empty;
            sql = "delete from antuoyiku where tph='" + entity.Tph+ "'";
            SqliteDbFactory.GetSqliteDbOperator().ExecuteNonQuery(sql);

        }
        public static DataTable GetUserData(string uid)
        {
            string sql = "select tph as 托盘号,mdkw as 目的库位 from antuoyiku where scaner='" + uid + "'";
            return SqliteDbFactory.GetSqliteDbOperator().SelectFromSql(sql);
        }
    }
}
