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
        public static void Save(ZuTuo zutuo)
        {
            string sql = string.Empty;
            sql = "insert into zutuo(tph,sn,xxjh,scaner,scantime) values('" +
                zutuo.Tph + "','" + zutuo.Sn + "','" +
                zutuo.Xxjh + "','" + Program.UserID + "','" +
                System.DateTime.Now.ToString("s")
                +"')";
            SqliteDbFactory.GetSqliteDbOperator().ExecuteNonQuery(sql);

        }
        public static DataTable GetUserData(string uid)
        {
            string sql = "select tph as 托盘号,sn as SN,xxjh as 下乡机号 from zutuo where scaner='"+uid+"'";
            return SqliteDbFactory.GetSqliteDbOperator().SelectFromSql(sql);
        }

    }
}
