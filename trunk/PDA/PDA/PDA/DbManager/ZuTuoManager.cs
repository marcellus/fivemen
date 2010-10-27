using System;

using System.Collections.Generic;
using System.Text;
using PDA.DataInit;
using System.Data;

namespace PDA.DbManager
{
    public class ZuTuoManager
    {
        /*
         create table zutuo(id integer primary key autoincrement
        ,tph varchar(20),sn varchar(20),xxjh varchar(20),
         scaner varchar(30),scantime datetime);
         */
        public static void Save(ZuTuo entity)
        {
            string sql = string.Empty;
            sql = "insert into zutuo(tph,sn,xxjh,scaner,scantime) values('" +
                entity.Tph + "','" + entity.Sn + "','" +
                entity.Xxjh + "','" + entity.Scaner + "','" +
                entity.date.ToString("s")
                +"')";
            SqliteDbFactory.GetSqliteDbOperator().ExecuteNonQuery(sql);

        }

        public static bool CheckExists(ZuTuo entity)
        {
            string sql = string.Empty;
            sql = "select * from zutuo where sn='" + entity.Sn + "'";
            DataTable dt = SqliteDbFactory.GetSqliteDbOperator().SelectFromSql(sql);

            return dt != null && dt.Rows.Count == 1;
        }

        public static void Delete(ZuTuo entity)
        {
            string sql = string.Empty;
            sql = "delete from zutuo where sn='" + entity.Sn + "'";
            SqliteDbFactory.GetSqliteDbOperator().ExecuteNonQuery(sql);

        }



        public static DataTable GetUserData(string uid)
        {
            string sql = "select tph as 托盘号,sn as SN,xxjh as 下乡机号 from zutuo where scaner='"+uid+"'";
            return SqliteDbFactory.GetSqliteDbOperator().SelectFromSql(sql);
        }

      

    }
}
