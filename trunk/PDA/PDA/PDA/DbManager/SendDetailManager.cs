using System;

using System.Collections.Generic;
using System.Text;
using System.Data;
using PDA.DataInit;

namespace PDA.DbManager
{
   public class SendDetailManager
   { /*
       create table senddetail(so varchar(20),
         * sn varchar(20),fahuotype integer,
         * xxjh varchar(20),tph varchar(20),
         * scaner varchar(30),scantime datetime,status integer);
                      */
       /*
              create table sendrecord(id integer primary key autoincrement,
                * so varchar(20),otherso varchar(200),qufen varchar(20),
                * pnno varchar(20),cpqufen varchar(20),sl integer,
                * carno varchar(30),status integer,scaner varchar(30),
                * scantime datetime);
                             */
       public static void Save(SendDetail entity,SendRecord parent)
        {

            string pnno = string.Empty;
           if(entity.Sn!=null&&entity.Sn.Length>12)
               pnno = entity.Sn.Substring(2, 10);
            string sel = "select * from sendrecord where so='" + parent.So + "' and pnno='" + pnno + "'";
            DataTable dt = SqliteDbFactory.GetSqliteDbOperator().SelectFromSql(sel);
            string[] sql = new string[2];
            sql[1] = "insert into senddetail(so,sn,fahuotype,xxjh,tph,scaner,scantime) values('" +
              entity.So + "','" + entity.Sn + "'," +
              entity.FahuoType + ",'" +

              entity.Xxjh + "','" +
               entity.Tph + "','" +
                entity.Scaner + "','" +
              System.DateTime.Now.ToString("s")
              + "')";
           /*
            sql = "select * from sendrecord where so='" +
               entity.So + "' and otherso='" + entity.OtherSo + "' and qufen='" +
               entity.QuFen + "' and pnno='" +
               entity.PnNo + "' and cpqufen='" +
               entity.CpQuFen + "' and carno='" +
               entity.CarNo + "' and status=" + entity.Status + ""
               + " and scaner='" + entity.Scaner + "'";
            * */
            if (pnno.Length > 0)
            {
                if (dt == null || dt.Rows.Count == 0)
                {
                    SendRecord sendrecord = new SendRecord();
                    sendrecord.So = parent.So;
                    sendrecord.OtherSo = parent.OtherSo;
                    sendrecord.CarNo = parent.CarNo;
                    sendrecord.QuFen = parent.QuFen;
                    sendrecord.Status = 0;
                    sendrecord.CpQuFen = string.Empty;
                    sendrecord.PnNo = pnno;
                    sendrecord.Sl = 1;
                    sendrecord.Scaner = Program.UserID;
                    sendrecord.date = System.DateTime.Now;
                    sql[0] = "insert into sendrecord(sl,so,otherso,qufen,pnno,cpqufen,carno,status,scaner,scantime) values(1,'" +
                        sendrecord.So + "','" + sendrecord.OtherSo + "','" +
                        sendrecord.QuFen + "','" + sendrecord.PnNo + "','" +
                        sendrecord.CpQuFen + "','" + sendrecord.CarNo + "'," + sendrecord.Status + ",'" +
                        sendrecord.Scaner + "','" +
                        System.DateTime.Now.ToString("s")
                        + "')";
                    //SendRecordManager.Save(sendrecord);
                }
                else
                {

                    sql[0] = "update sendrecord set sl=sl+1 where so='" + parent.So + "' and pnno='" + pnno + "'";

                }
            }
            SqliteDbFactory.GetSqliteDbOperator().BatchExecute(sql);


           

        }

        public static bool CheckExists(SendDetail entity)
        {
            string sql = string.Empty;
            sql = "select * from senddetail where sn='" +
               entity.Sn + "'";
            DataTable dt = SqliteDbFactory.GetSqliteDbOperator().SelectFromSql(sql);

            return dt != null && dt.Rows.Count == 1;
        }

        public static bool CheckExistsTuopan(SendDetail entity)
        {
            string sql = string.Empty;
            sql = "select * from senddetail where tph='" +
               entity.Tph + "'";
            DataTable dt = SqliteDbFactory.GetSqliteDbOperator().SelectFromSql(sql);

            return dt != null && dt.Rows.Count == 1;
        }


        public static void Delete(SendDetail entity,SendRecord parent)
        {
            string[] sql = new string[2];
            sql[0] = "delete from senddetail where sn='" +
                entity.Sn + "'";
            if(entity.Sn!=null&&entity.Sn.Length>0)
                sql[1] = "update sendrecord set sl=sl-1 where so='" + parent.So + "' and pnno='" + entity.Sn.Substring(2,10) + "'";
            SqliteDbFactory.GetSqliteDbOperator().BatchExecute(sql);

        }

        public static void DeleteTuopan(SendDetail entity, SendRecord parent)
        {
            string[] sql = new string[1];
            sql[0] = "delete from senddetail where tph='" +
                entity.Tph + "'";
            SqliteDbFactory.GetSqliteDbOperator().BatchExecute(sql);

        }

        public static DataTable GetUserData(string so,string uid)
        {
            string sql = "select sn as SN,xxjh as 下乡机号,tph as 托盘号 from senddetail where so='"+so+"' and scaner='" + uid + "'";
            return SqliteDbFactory.GetSqliteDbOperator().SelectFromSql(sql);
        }
    }
}
