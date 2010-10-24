using System;

using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data;
using PDA.DbManager;
using PDA.DataInit;

namespace PDA.DbManager
{
    public class AnHuoYiKuManager
    {
        /*
       create table anhuoyiku(id integer primary key autoincrement,
         * ykw varchar(20),cp varchar(20),
         * sl integer,mdkw varchar(20),
         * scaner varchar(30),scantime datetime);
        */
        public static void Save(AnHuoYiKu entity)
        {
            string sql = string.Empty;
            sql = "insert into anhuoyiku(ykw,cp,mdkw,sl,scaner,scantime) values('" +
                entity.Ykw + "','" + entity.Cp + "','" +
                entity.MdKw + "',"+entity.Sl+",'" + entity.Scaner + "','" +
                System.DateTime.Now.ToString("s")
                + "')";
            SqliteDbFactory.GetSqliteDbOperator().ExecuteNonQuery(sql);

        }

        public static bool CheckExists(AnHuoYiKu entity)
        {
            string sql = string.Empty;
            sql = "select * from anhuoyiku where ykw='" +
                entity.Ykw + "' and cp='" + entity.Cp + "' and mdkw='" +
                entity.MdKw + "' and scaner='" + entity.Scaner + "'";
            DataTable dt = SqliteDbFactory.GetSqliteDbOperator().SelectFromSql(sql);

            return dt != null && dt.Rows.Count == 1;
        }

        public static void Delete(AnHuoYiKu entity)
        {
            string sql = string.Empty;
            sql = "delete from anhuoyiku where ykw='" +
                entity.Ykw + "' and cp='" + entity.Cp + "' and mdkw='" +
                entity.MdKw + "' and scaner='" + entity.Scaner + "'";
            SqliteDbFactory.GetSqliteDbOperator().ExecuteNonQuery(sql);

        }
        public static DataTable GetUserData(string uid)
        {
            string sql = "select ykw as 原库位,cp as 产品,sl as 数量,mdkw as 目的库位 from anhuoyiku where scaner='" + uid + "'";
            return SqliteDbFactory.GetSqliteDbOperator().SelectFromSql(sql);
        }
    }
}
