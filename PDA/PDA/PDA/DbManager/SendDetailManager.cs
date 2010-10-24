using System;

using System.Collections.Generic;
using System.Text;
using System.Data;
using PDA.DataInit;

namespace PDA.DbManager
{
   public class SendDetailManager
   { /*
       create table senddetail(pid integer,
         * sn varchar(20),fahuotype integer,
         * xxjh varchar(20),tph varchar(20),
         * scaner varchar(30),scantime datetime,status integer);
                      */
        public static void Save(SendDetail entity)
        {
            string sql = string.Empty;
            sql = "insert into senddetail(pid,sn,fahuotype,xxjh,tph,scaner,scantime) values(" +
                entity.Pid + ",'" + entity.Sn + "',"+
                entity.FahuoType+",'" +
                 
                entity.Xxjh + "','" +
                 entity.Tph + "','" +
                  entity.Scaner + "','" +
                System.DateTime.Now.ToString("s")
                + "')";
            SqliteDbFactory.GetSqliteDbOperator().ExecuteNonQuery(sql);

        }

        public static bool CheckExists(SendDetail entity)
        {
            string sql = string.Empty;
            sql = "select * from senddetail where sn='" +
               entity.Sn + "' and fahuotype='" + entity.FahuoType
              + "' and xxjh='" + entity.Xxjh
              + "' and tph='" + entity.Tph
               + "' and scaner='" + entity.Scaner + "'";
            DataTable dt = SqliteDbFactory.GetSqliteDbOperator().SelectFromSql(sql);

            return dt != null && dt.Rows.Count == 1;
        }


        public static void Delete(SendDetail entity)
        {
            string sql = string.Empty;
            sql = "delete from senddetail where sn='" +
                entity.Sn + "' and fahuotype='" + entity.FahuoType
               +"' and xxjh='" + entity.Xxjh
               + "' and tph='" + entity.Tph
                + "' and scaner='" + entity.Scaner + "'";
            SqliteDbFactory.GetSqliteDbOperator().ExecuteNonQuery(sql);

        }
        public static DataTable GetUserData(int pid,string uid)
        {
            string sql = "select sn as SN,xxjh as 下乡机号,tph as 托盘号 from senddetail where pid="+pid+" and scaner='" + uid + "'";
            return SqliteDbFactory.GetSqliteDbOperator().SelectFromSql(sql);
        }
    }
}
