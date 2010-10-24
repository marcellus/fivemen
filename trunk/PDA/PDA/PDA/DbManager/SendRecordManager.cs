using System;

using System.Collections.Generic;
using System.Text;
using System.Data;
using PDA.DataInit;
using System.Windows.Forms;

namespace PDA.DbManager
{
    public class SendRecordManager
    {
        /*
              create table sendrecord(id integer primary key autoincrement,
                * so varchar(20),otherso varchar(200),qufen varchar(20),
                * pnno varchar(20),cpqufen varchar(20),sl integer,
                * carno varchar(30),status integer,scaner varchar(30),
                * scantime datetime);
                             */
        public static void Save(SendRecord entity)
        {
            string sql = string.Empty;
            sql = "insert into sendrecord(so,otherso,qufen,pnno,cpqufen,carno,status,scaner,scantime) values('" +
                entity.So + "','" + entity.OtherSo + "','" +
                entity.QuFen + "','" + entity.PnNo + "','" +
                entity.CpQuFen + "','" + entity.CarNo + "',"+entity.Status+",'" + 
                entity.Scaner + "','" +
                System.DateTime.Now.ToString("s")
                + "')";
            //MessageBox.Show(sql);
            SqliteDbFactory.GetSqliteDbOperator().ExecuteNonQuery(sql);

        }

        public static bool CheckExists(SendRecord entity)
        {
            string sql = string.Empty;
            sql = "select * from sendrecord where so='" +
                entity.So + "' and otherso='" + entity.OtherSo + "' and qufen='" +
                entity.QuFen + "' and pnno='" +
                entity.PnNo + "' and cpqufen='" +
                entity.CpQuFen + "' and carno='" +
                entity.CarNo + "' and status="+entity.Status+""
                + " and scaner='" + entity.Scaner + "'";
            //MessageBox.Show(sql);
            DataTable dt = SqliteDbFactory.GetSqliteDbOperator().SelectFromSql(sql);

            return dt != null && dt.Rows.Count == 1;
        }


        public static void Delete(SendRecord entity)
        {
            string sql = string.Empty;
            sql = "delete from sendrecord where so='" +
                entity.So + "' and otherso='" + entity.OtherSo + "' and qufen='"+
                entity.QuFen+"' and pnno='"+
                entity.PnNo+"' and cpqufen='"+
                entity.CpQuFen+"' and carno='"+
                entity.CarNo+"' and status=''"
                +" and scaner='" + entity.Scaner + "'";
            SqliteDbFactory.GetSqliteDbOperator().ExecuteNonQuery(sql);

        }
        public static DataTable GetUserData(string uid)
        {
            string sql = "select so as 单号,pnno as 产品类别,carno as 车牌号"
                +" from sendrecord where scaner='" + uid + "'";
            return SqliteDbFactory.GetSqliteDbOperator().SelectFromSql(sql);
        }
    }
}
