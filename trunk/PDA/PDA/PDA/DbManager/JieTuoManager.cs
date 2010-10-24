using System;

using System.Collections.Generic;
using System.Text;
using System.Data;
using PDA.DataInit;
using System.Windows.Forms;

namespace PDA.DbManager
{
    public class JieTuoManager
    {
      /*
                 create table jietuo(id integer primary key autoincrement,
         * tph varchar(20),sn varchar(20),iswhole integer,
         * scaner varchar(30),scantime datetime);
                      */
       
        public static void Save(JieTuo entity)
        {
            string sql = string.Empty;
            sql = "insert into jietuo(tph,sn,iswhole,scaner,scantime) values('" +
                entity.Tph + "','" + entity.Sn + "',"+entity.IsWhole+",'" + 
                entity.Scaner + "','" +
                System.DateTime.Now.ToString("s")
                + "')";
            //MessageBox.Show(sql);
            SqliteDbFactory.GetSqliteDbOperator().ExecuteNonQuery(sql);

        }
        public static bool CheckExists(JieTuo entity)
        {
            string sql = string.Empty;
            sql = "select * from jietuo where tph='" +
                entity.Tph + "' and sn='" + entity.Sn + "' and iswhole=" +
                entity.IsWhole + " and scaner='" + entity.Scaner + "'";
            DataTable dt = SqliteDbFactory.GetSqliteDbOperator().SelectFromSql(sql);

            return dt != null && dt.Rows.Count == 1;
        }



        public static void Delete(JieTuo entity)
        {
            string sql = string.Empty;
            sql = "delete from jietuo where tph='" +
                entity.Tph + "' and sn='" + entity.Sn + "' and iswhole="+
                entity.IsWhole+" and scaner='" + entity.Scaner + "'";
            SqliteDbFactory.GetSqliteDbOperator().ExecuteNonQuery(sql);

        }
        public static DataTable GetUserData(string uid)
        {
            string sql = "select tph as 托盘号,sn as SN from jietuo where scaner='" + uid + "'";
            return SqliteDbFactory.GetSqliteDbOperator().SelectFromSql(sql);
        }
    }
}
