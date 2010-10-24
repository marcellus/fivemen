using System;

using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data;
using PDA.DbManager;
using PDA.DataInit;

namespace PDA.DbManager
{
    public class PinTuoManager
    {
        /*
        create table pintuo(id integer primary key autoincrement,
         * tph varchar(20),sn varchar(20),wz varchar(30),
         * xxjh varchar(20),scaner varchar(30),scantime datetime);
        */
        public static void Save(PinTuo entity)
        {
            string sql = string.Empty;
            sql = "insert into pintuo(tph,sn,xxjh,wz,scaner,scantime) values('" +
                entity.Tph + "','" + entity.Sn + "','" +entity.Xxjh+"','"+
                entity.Wz + "','" + entity.Scaner + "','" +
                System.DateTime.Now.ToString("s")
                + "')";
            SqliteDbFactory.GetSqliteDbOperator().ExecuteNonQuery(sql);

        }

        public static bool CheckExists(PinTuo entity)
        {
            string sql = string.Empty;
            sql = "select * from pintuo where tph='" +
                entity.Tph + "' and sn='" + entity.Sn + "' and xxjh='" +
                entity.Xxjh + "' and wz='" + entity.Wz + "' and scaner='" + entity.Scaner + "'";
            DataTable dt = SqliteDbFactory.GetSqliteDbOperator().SelectFromSql(sql);

            return dt != null && dt.Rows.Count == 1;
        }


        public static void Delete(PinTuo entity)
        {
            string sql = string.Empty;
            sql = "delete from pintuo where tph='" +
                entity.Tph + "' and sn='" + entity.Sn + "' and xxjh='" +
                entity.Xxjh + "' and wz='"+entity.Wz+"' and scaner='" + entity.Scaner + "'";
            SqliteDbFactory.GetSqliteDbOperator().ExecuteNonQuery(sql);

        }
        public static DataTable GetUserData(string uid)
        {
            string sql = "select tph as 托盘号,sn as SN,xxjh as 下乡机号,wz as 位置 from pintuo where scaner='" + uid + "'";
            return SqliteDbFactory.GetSqliteDbOperator().SelectFromSql(sql);
        }
    }
}
